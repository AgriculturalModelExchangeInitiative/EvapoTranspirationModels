#include "soilmoisture.h"

#include <algorithm> //for min, max
#include <iostream>
#define _USE_MATH_DEFINES
#include <cmath>
#include "snow-component.h"
#include "soilcolumn.h"
#include "crop-module.h"
#include "monica-model.h"
#include "tools/algorithms.h"
#include "soil/conversion.h"

using namespace std;
using namespace monica;
using namespace Tools;

SoilMoisture::SoilMoisture(MonicaModel &mm, const SoilMoistureModuleParameters &smPs)
    : soilColumn(mm.soilColumnNC())
    , siteParameters(mm.siteParameters())
    , monica(mm)
    , _params(smPs)
    , cropPs(mm.cropParameters())
    , numberOfMoistureLayers(soilColumn.numberOfLayers() + 1)
    , numberOfSoilLayers(soilColumn.numberOfLayers()) //extern
    , vm_Evaporation(numberOfMoistureLayers, 0.0) //intern
    , vm_Evapotranspiration(numberOfMoistureLayers, 0.0) //intern
    , vm_FieldCapacity(numberOfMoistureLayers, 0.0)
    , vs_Latitude(siteParameters.vs_Latitude)
    , vm_LayerThickness(numberOfMoistureLayers, 0.01)
    , vm_PermanentWiltingPoint(numberOfMoistureLayers, 0.0)
    , vm_SoilMoisture(numberOfMoistureLayers, 0.20) //result
    , vm_Transpiration(numberOfMoistureLayers, 0.0) //intern
    , snowComponent(kj::heap<SnowComponent>(soilColumn, smPs)) {
}

void SoilMoisture::step(double vs_GroundwaterDepth,
                        double vw_Precipitation,
                        double vw_MaxAirTemperature,
                        double vw_MinAirTemperature,
                        double vw_RelativeHumidity,
                        double vw_MeanAirTemperature,
                        double vw_WindSpeed,
                        double vw_WindSpeedHeight,
                        double vw_GlobalRadiation,
                        int vs_JulianDay,
                        double vw_ReferenceEvapotranspiration,
                        double vaporPressure) {
  _vaporPressure = vaporPressure;

  for (int i = 0; i < numberOfSoilLayers; i++) {
    // initialization with moisture values stored in the layer
    vm_SoilMoisture[i] = soilColumn[i].get_Vs_SoilMoisture_m3();
    vm_FieldCapacity[i] = soilColumn[i].vs_FieldCapacity();
    vm_PermanentWiltingPoint[i] = soilColumn[i].vs_PermanentWiltingPoint();
    vm_LayerThickness[i] = soilColumn[i].vs_LayerThickness;
  }

  vm_SoilMoisture[numberOfMoistureLayers - 1] = soilColumn[numberOfMoistureLayers - 2].get_Vs_SoilMoisture_m3();
  vm_FieldCapacity[numberOfMoistureLayers - 1] = soilColumn[numberOfMoistureLayers - 2].vs_FieldCapacity();
  vm_LayerThickness[numberOfMoistureLayers - 1] = soilColumn[numberOfMoistureLayers - 2].vs_LayerThickness;
  vm_SurfaceWaterStorage = soilColumn.vs_SurfaceWaterStorage;

  int vc_DevelopmentalStage = 0;
  if (monica.cropGrowth()) {
    vc_PercentageSoilCoverage = monica.cropGrowth()->get_SoilCoverage();
    vc_KcFactor = monica.cropGrowth()->get_KcFactor();
    vc_DevelopmentalStage = static_cast<int>(monica.cropGrowth()->get_DevelopmentalStage());
  } else {
    vc_KcFactor = _params.pm_KcFactor;
    vc_PercentageSoilCoverage = 0.0;
  }

  // calculates snow layer water storage and release
  snowComponent->calcSnowLayer(vw_MeanAirTemperature, vc_NetPrecipitation);

  fm_Evapotranspiration(siteParameters.vs_HeightNN, vw_MaxAirTemperature,
                        vw_MinAirTemperature, vw_RelativeHumidity, vw_MeanAirTemperature, vw_WindSpeed,
                        vw_WindSpeedHeight,
                        vw_GlobalRadiation, vc_DevelopmentalStage, vs_JulianDay, vs_Latitude,
                        vw_ReferenceEvapotranspiration);

  for (int i_Layer = 0; i_Layer < numberOfSoilLayers; i_Layer++) {
    soilColumn[i_Layer].set_Vs_SoilMoisture_m3(vm_SoilMoisture[i_Layer]);
  }
  soilColumn.vs_SurfaceWaterStorage = vm_SurfaceWaterStorage;
}

/*!
/**
 * @brief Calculation of Evapotranspiration
 * Calculation of transpiration and evaporation.
 *
 * @param vc_PercentageSoilCoverage
 * @param vc_KcFactor Needed for calculation of the Evapo-transpiration
 * @param vs_HeightNN
 * @param vw_MaxAirTemperature Maximal air temperature
 * @param vw_MinAirTemperature Minimal air temperature
 * @param vw_RelativeHumidity Relative Humidity
 * @param vw_MeanAirTemperature Mean air temperature
 * @param vw_WindSpeed Speed of wind
 * @param vw_WindSpeedHeight Height for the measurement of the wind speed
 * @param vw_GlobalRadiation Global radiaton
 * @param vc_DevelopmentalStage
 */
void SoilMoisture::fm_Evapotranspiration(double vs_HeightNN,
                                         double vw_MaxAirTemperature, double vw_MinAirTemperature,
                                         double vw_RelativeHumidity, double vw_MeanAirTemperature,
                                         double vw_WindSpeed, double vw_WindSpeedHeight, double vw_GlobalRadiation,
                                         int vc_DevelopmentalStage, int vs_JulianDay,
                                         double vs_Latitude, double externalReferenceEvapotranspiration) {
  double potentialEvapotranspiration = 0.0;
  double evaporatedFromIntercept = 0.0;
  vm_EvaporatedFromSurface = 0.0;
  const double snowDepth = snowComponent->getSnowDepth();

  // calculate soil evaporation until max 0.4m depth
  const double evaporationZeta = _params.pm_EvaporationZeta;

  // parameter for the slope of the deprivation function
  vm_XSACriticalSoilMoisture = _params.pm_XSACriticalSoilMoisture;

  // @todo <b>Claas:</b> pm_MaximumEvaporationImpactDepth is dependent on soil type
  // something has to be done there
  // this is the depth until which the evaporation can penetrate maximally
  const double maximumEvaporationImpactDepth = _params.pm_MaximumEvaporationImpactDepth;

  // If a crop grows, ETp is taken from crop module
  if (vc_DevelopmentalStage > 0) {
    // Reference evapotranspiration is only grabbed here for consistent
    // output in monica.cpp
    if (externalReferenceEvapotranspiration < 0.0) {
      vm_ReferenceEvapotranspiration = monica.cropGrowth()->get_ReferenceEvapotranspiration();
    } else {
      vm_ReferenceEvapotranspiration = externalReferenceEvapotranspiration;
    }

    // Remaining ET from crop module already includes Kc factor and evaporation
    // from interception storage
    potentialEvapotranspiration = monica.cropGrowth()->get_RemainingEvapotranspiration();
    evaporatedFromIntercept = monica.cropGrowth()->get_EvaporatedFromIntercept();
  } else { // if no crop grows ETp is calculated from ET0 * kc
    if (externalReferenceEvapotranspiration < 0.0) {
      vm_ReferenceEvapotranspiration = referenceEvapotranspiration(vs_HeightNN, vw_MaxAirTemperature,
                                                                   vw_MinAirTemperature, vw_RelativeHumidity,
                                                                   vw_MeanAirTemperature, vw_WindSpeed,
                                                                   vw_WindSpeedHeight,
                                                                   vw_GlobalRadiation, vs_JulianDay, vs_Latitude);
    } else {
      vm_ReferenceEvapotranspiration = externalReferenceEvapotranspiration;
    }

    potentialEvapotranspiration = vm_ReferenceEvapotranspiration * vc_KcFactor; // - vm_InterceptionReference;
  }

  vm_ActualEvaporation = 0.0;
  vm_ActualTranspiration = 0.0;

  // from HERMES:
  if (potentialEvapotranspiration > 6.5) potentialEvapotranspiration = 6.5;

  if (potentialEvapotranspiration > 0.0) {
    bool evaporationFromSurface = false;
    // If surface is water-logged, subsequent evaporation from surface water sources
    if (vm_SurfaceWaterStorage > 0.0) {
      evaporationFromSurface = true;
      // Water surface evaporates with Kc = 1.1.
      potentialEvapotranspiration = potentialEvapotranspiration * (1.1 / vc_KcFactor);

      // If a snow layer is present no water evaporates from surface water sources
      if (snowDepth > 0.0) {
        vm_EvaporatedFromSurface = 0.0;
      } else {
        if (vm_SurfaceWaterStorage < potentialEvapotranspiration) {
          potentialEvapotranspiration -= vm_SurfaceWaterStorage;
          vm_EvaporatedFromSurface = vm_SurfaceWaterStorage;
          vm_SurfaceWaterStorage = 0.0;
        } else {
          vm_SurfaceWaterStorage -= potentialEvapotranspiration;
          vm_EvaporatedFromSurface = potentialEvapotranspiration;
          potentialEvapotranspiration = 0.0;
        }
      }
      potentialEvapotranspiration = potentialEvapotranspiration * (vc_KcFactor / 1.1);
    }

    if (potentialEvapotranspiration > 0) { // Evaporation from soil
      for (auto i = 0; i < numberOfSoilLayers; i++) {
        const auto eRed1 = eReducer1(i, vc_PercentageSoilCoverage, potentialEvapotranspiration);
        auto eRed2 = 0.0;
        if (i >= maximumEvaporationImpactDepth) {
          // layer is too deep for evaporation
          eRed2 = 0.0;
        } else {
          // 2nd factor to reduce actual evapotranspiration by
          // MaximumEvaporationImpactDepth and EvaporationZeta
          eRed2 = get_DeprivationFactor(i + 1, maximumEvaporationImpactDepth,
                                        evaporationZeta, vm_LayerThickness[i]);
        }

        auto eRed3 = 0.0;
        if (i > 0) {
          if (vm_SoilMoisture[i] < vm_SoilMoisture[i - 1]) {
            // 3rd factor to consider if above layer contains more water than
            // the adjacent layer below, evaporation will be significantly reduced
            eRed3 = 0.1;
          } else {
            eRed3 = 1.0;
          }
        } else {
          eRed3 = 1.0;
        }
        // EReducer-> factor to reduce evaporation
        const double eReducer = eRed1 * eRed2 * eRed3;

        if (vc_DevelopmentalStage > 0) {
          // vegetation is present

          //Interpolation between [0,1]
          if (vc_PercentageSoilCoverage >= 0.0 && vc_PercentageSoilCoverage < 1.0) {
            vm_Evaporation[i] = (1.0 - vc_PercentageSoilCoverage) * eReducer * potentialEvapotranspiration;
          } else if (vc_PercentageSoilCoverage >= 1.0) {
             vm_Evaporation[i] = 0.0;
          }

          if (snowDepth > 0.0) vm_Evaporation[i] = 0.0;

          // Transpiration is derived from ET0; Soil coverage and Kc factors
          // already considered in crop part!
          vm_Transpiration[i] = monica.cropGrowth()->get_Transpiration(i);

          // Transpiration is capped in case potential ET after surface
          // and interception evaporation has occurred on same day
          if (evaporationFromSurface) {
            vm_Transpiration[i] = vc_PercentageSoilCoverage * eReducer * potentialEvapotranspiration;
          }
        } else {
          // no vegetation present
          if (snowDepth > 0.0) vm_Evaporation[i] = 0.0;
          else vm_Evaporation[i] = potentialEvapotranspiration * eReducer;
          vm_Transpiration[i] = 0.0;

        } // if(vc_DevelopmentalStage > 0)

        vm_Evapotranspiration[i] = vm_Evaporation[i] + vm_Transpiration[i];
        vm_SoilMoisture[i] -= vm_Evapotranspiration[i] / 1000.0 / vm_LayerThickness[i];

        //  Generelle Begrenzung des Evaporationsentzuges
        if (vm_SoilMoisture[i] < 0.01) vm_SoilMoisture[i] = 0.01;

        vm_ActualTranspiration += vm_Transpiration[i];
        vm_ActualEvaporation += vm_Evaporation[i];
      } // for
    } // vm_PotentialEvapotranspiration > 0
  } // vm_PotentialEvapotranspiration > 0.0
  vm_ActualEvapotranspiration = vm_ActualTranspiration + vm_ActualEvaporation
      + evaporatedFromIntercept + vm_EvaporatedFromSurface;
}

/**
 * @brief Reference evapotranspiration
 *
 * A method following Penman-Monteith as described by the FAO in Allen
 * RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.
 * Guidelines for computing crop water requirements. FAO Irrigation and
 * Drainage Paper 56, FAO, Roma
 *
 * @param vs_HeightNN
 * @param vw_MaxAirTemperature
 * @param vw_MinAirTemperature
 * @param vw_RelativeHumidity
 * @param vw_MeanAirTemperature
 * @param vw_WindSpeed
 * @param vw_WindSpeedHeight
 * @param vw_GlobalRadiation
 * @return
 */
double SoilMoisture::referenceEvapotranspiration(double vs_HeightNN, double vw_MaxAirTemperature,
                                                 double vw_MinAirTemperature, double vw_RelativeHumidity,
                                                 double vw_MeanAirTemperature, double vw_WindSpeed,
                                                 double vw_WindSpeedHeight, double vw_GlobalRadiation, int vs_JulianDay,
                                                 double vs_Latitude) {
  double vc_Declination = -23.4 * cos(2.0 * M_PI * ((vs_JulianDay + 10.0) / 365.0));
  // old SINLD
  double vc_DeclinationSinus = sin(vc_Declination * M_PI / 180.0) * sin(vs_Latitude * M_PI / 180.0);
  // old COSLD
  double vc_DeclinationCosinus = cos(vc_Declination * M_PI / 180.0) * cos(vs_Latitude * M_PI / 180.0);

  double arg_AstroDayLength = vc_DeclinationSinus / vc_DeclinationCosinus;
  arg_AstroDayLength = bound(-1.0, arg_AstroDayLength, 1.0); //The argument of asin must be in the range of -1 to 1  
  double vc_AstronomicDayLenght = 12.0 * (M_PI + 2.0 * asin(arg_AstroDayLength)) / M_PI;

  double arg_EffectiveDayLength = (-sin(8.0 * M_PI / 180.0) + vc_DeclinationSinus) / vc_DeclinationCosinus;
  arg_EffectiveDayLength = bound(-1.0, arg_EffectiveDayLength,
                                 1.0); //The argument of asin must be in the range of -1 to 1
  //double vc_EffectiveDayLenght = 12.0 * (M_PI + 2.0 * asin(arg_EffectiveDayLength)) / M_PI;

  double arg_PhotoDayLength = (-sin(-6.0 * M_PI / 180.0) + vc_DeclinationSinus) / vc_DeclinationCosinus;
  arg_PhotoDayLength = bound(-1.0, arg_PhotoDayLength, 1.0); //The argument of asin must be in the range of -1 to 1
  //double vc_PhotoperiodicDaylength = 12.0 * (M_PI + 2.0 * asin(arg_PhotoDayLength)) / M_PI;

  double arg_PhotAct = min(1.0, ((vc_DeclinationSinus / vc_DeclinationCosinus) *
                                 (vc_DeclinationSinus / vc_DeclinationCosinus))); //The argument of sqrt must be >= 0
  double vc_PhotActRadiationMean = 3600.0 * (vc_DeclinationSinus * vc_AstronomicDayLenght + 24.0 / M_PI *
    vc_DeclinationCosinus
    * sqrt(1.0 - arg_PhotAct));


  double vc_ClearDayRadiation = 0;
  if (vc_PhotActRadiationMean > 0 && vc_AstronomicDayLenght > 0) {
    vc_ClearDayRadiation = 0.5 * 1300.0 * vc_PhotActRadiationMean * exp(-0.14 / (vc_PhotActRadiationMean
                                                                                 / (vc_AstronomicDayLenght * 3600.0)));
  }

  //double vc_OvercastDayRadiation = 0.2 * vc_ClearDayRadiation;
  double SC = 24.0 * 60.0 / M_PI * 8.20 * (1.0 + 0.033 * cos(2.0 * M_PI * vs_JulianDay / 365.0));
  double arg_SHA = bound(-1.0, -tan(vs_Latitude * M_PI / 180.0) * tan(vc_Declination * M_PI / 180.0),
                         1.0); //The argument of acos must be in the range of -1 to 1
  double SHA = acos(arg_SHA);

  double vc_ExtraterrestrialRadiation = SC * (SHA * vc_DeclinationSinus + vc_DeclinationCosinus * sin(SHA)) / 100.0; // [J cm-2] --> [MJ m-2]

  // Calculation of atmospheric pressure //[kPA]
  double vm_AtmosphericPressure = 101.3 * pow(((293.0 - (0.0065 * vs_HeightNN)) / 293.0), 5.26);

  // Calculation of psychrometer constant //[kPA °C-1] - Luchtfeuchtigkeit
  double vm_PsycrometerConstant = 0.000665 * vm_AtmosphericPressure;

  // Calc. of saturated water vapour pressure at daily max temperature
  //[kPA]
  double vm_SaturatedVapourPressureMax = 0.6108 *
    exp((17.27 * vw_MaxAirTemperature) / (237.3 + vw_MaxAirTemperature));

  // Calc. of saturated water vapour pressure at daily min temperature
  //[kPA]
  double vm_SaturatedVapourPressureMin = 0.6108 *
    exp((17.27 * vw_MinAirTemperature) / (237.3 + vw_MinAirTemperature));

  // Calculation of the saturated water vapour pressure //[kPA]
  double vm_SaturatedVapourPressure = (vm_SaturatedVapourPressureMax + vm_SaturatedVapourPressureMin) / 2.0;

  if (_vaporPressure < 0)
  {
    // Calculation of the water vapour pressure
    if (vw_RelativeHumidity <= 0.0) {
      // Assuming Tdew = Tmin as suggested in FAO56 Allen et al. 1998
      _vaporPressure = vm_SaturatedVapourPressureMin;
    } else {
      _vaporPressure = vw_RelativeHumidity * vm_SaturatedVapourPressure;
    }
  }

  // Calculation of the air saturation deficit //[kPA]
  double vm_SaturationDeficit = vm_SaturatedVapourPressure - _vaporPressure;

  // Slope of saturation water vapour pressure-to-temperature relation
  //[kPA °C-1]
  double vm_SaturatedVapourPressureSlope = (4098.0 * (0.6108 * exp(
      (17.27 * vw_MeanAirTemperature) / (vw_MeanAirTemperature
        + 237.3)))) /
    ((vw_MeanAirTemperature + 237.3) * (vw_MeanAirTemperature + 237.3));

  // Calculation of wind speed in 2m height //[m s-1]
  double vm_WindSpeed_2m = max(0.5, vw_WindSpeed * (4.87 / (log(67.8 * vw_WindSpeedHeight - 5.42))));
  // 0.5 minimum allowed windspeed for Penman-Monteith-Method FAO

  // Calculation of the aerodynamic resistance [s m-1]
  double vm_AerodynamicResistance = 208.0 / vm_WindSpeed_2m;

  vc_StomataResistance = 100; // FAO default value [s m-1]

  double vm_SurfaceResistance = vc_StomataResistance / 1.44; //[s m-1]

  double vc_ClearSkySolarRadiation = (0.75 + 0.00002 * vs_HeightNN) * vc_ExtraterrestrialRadiation;
  double vc_RelativeShortwaveRadiation =
      vc_ClearSkySolarRadiation > 0 ? min(vw_GlobalRadiation / vc_ClearSkySolarRadiation, 1.0) : 1.0;

  double pc_BolzmannConstant = 0.0000000049;
  // FAO Green gras reference albedo from Allen et al. (1998)
  double vc_ShortwaveRadiation = (1.0 - cropPs.pc_ReferenceAlbedo) * vw_GlobalRadiation;
  double vc_LongwaveRadiation = pc_BolzmannConstant
                                * ((pow((vw_MinAirTemperature + 273.16), 4.0)
                                    + pow((vw_MaxAirTemperature + 273.16), 4.0)) / 2.0)
                                * (1.35 * vc_RelativeShortwaveRadiation - 0.35)
                                * (0.34 - 0.14 * sqrt(_vaporPressure));
  vw_NetRadiation = vc_ShortwaveRadiation - vc_LongwaveRadiation;

  // Calculation of the reference evapotranspiration
  // Penman-Monteith-Methode FAO
  //[mm]
  double vm_ReferenceEvapotranspiration = ((0.408 * vm_SaturatedVapourPressureSlope * vw_NetRadiation)
      + (vm_PsycrometerConstant * (900.0 / (vw_MeanAirTemperature + 273.0))
        * vm_WindSpeed_2m * vm_SaturationDeficit))
    / (vm_SaturatedVapourPressureSlope + vm_PsycrometerConstant
      * (1.0 + (vm_SurfaceResistance / 208.0) *
        vm_WindSpeed_2m));

  if (vm_ReferenceEvapotranspiration < 0.0) {
    vm_ReferenceEvapotranspiration = 0.0;
  }

  return vm_ReferenceEvapotranspiration;
}

/*!
 * Calculation of evaporation reduction by soil moisture content
 *
 * @param layerIndex
 * @param percentageSoilCoverage
 * @param referenceEvapotranspiration
 *
 * @return Value for evaporation reduction by soil moisture content
 */
double SoilMoisture::eReducer1(int layerIndex,
                               double percentageSoilCoverage,
                               double referenceEvapotranspiration,
                               int evaporationReductionMethod) {
  double eReductionFactor = 0;
  double pwp = soilColumn[layerIndex].vs_PermanentWiltingPoint();
  double fc = soilColumn[layerIndex].vs_FieldCapacity();
  double sm = max(0.33*pwp, soilColumn[layerIndex].get_Vs_SoilMoisture_m3());
  double relativeEvaporableWater = min(1.0, (sm - 0.33*pwp) / (fc - 0.33*pwp));

  switch (evaporationReductionMethod) {
  case 0: // THESEUS
  {
    double criticalSoilMoisture = 0.65 * fc;
    if (percentageSoilCoverage > 0) {
      double reducer = 1;
      if (referenceEvapotranspiration > 2.5) {
        double xsa = (0.65 * fc - pwp) * (fc - pwp);
        reducer = xsa + (((1 - xsa) / 17.5) * (referenceEvapotranspiration - 2.5));
      } else {
        reducer = vm_XSACriticalSoilMoisture / 2.5 * referenceEvapotranspiration;
      }
      criticalSoilMoisture = fc * reducer;
    }

    // Calculation of an evaporation-reducing factor in relation to soil water content
    if (sm > criticalSoilMoisture) {
      // Moisture is higher than critical value so there is a
      // normal evaporation and nothing must be reduced
      eReductionFactor = 1.0;
    } else {
      // critical value is reached, actual evaporation is below potential
      if (sm > 0.33 * pwp) {
        // moisture is higher than 30% of permanent wilting point
        eReductionFactor = relativeEvaporableWater;
      } else {
        // if moisture is below 30% of wilting point nothing can be evaporated
        eReductionFactor = 0.0;
      }
    }
  }
  break;
  case 1: // HERMES
  default:
    if (relativeEvaporableWater > 0.33) {
      eReductionFactor = 1.0 - (0.1 * (1.0 - relativeEvaporableWater) / (1.0 - 0.33));
    } else if (relativeEvaporableWater > 0.22) {
      eReductionFactor = 0.9 - (0.625 * (0.33 - relativeEvaporableWater) / (0.33 - 0.22));
    } else if (relativeEvaporableWater > 0.2) {
      eReductionFactor = 0.275 - (0.225 * (0.22 - relativeEvaporableWater) / (0.22 - 0.2));
    } else {
      eReductionFactor = 0.05 - (0.05 * (0.2 - relativeEvaporableWater) / 0.2);
    } // end if
    break;
  }
  return eReductionFactor;
}

/*!
 * @brief Calculation of deprivation factor
 * @return deprivationFactor
 *
 * PET deprivation distribution (factor as function of depth).
 * The PET is spread over the deprivation depth. This function computes
 * the factor/weight for a given layer/depth[dm] (layerNo).
 *
 * @param layerNo [1..NLAYER]
 * @param deprivationDepth [dm] maximum deprivation depth
 * @param zeta [0..40] shape factor
 * @param vs_LayerThickness
 */
double
SoilMoisture::get_DeprivationFactor(int layerNo, double deprivationDepth, double zeta, double vs_LayerThickness) {
  // factor (f(depth)) to distribute the PET along the soil profil/rooting zone

  double deprivationFactor;

  // factor to introduce layer thickness in this algorithm,
  // to allow layer thickness scaling (Claas Nendel)
  double layerThicknessFactor = deprivationDepth / (vs_LayerThickness * 10.0);

  if ((fabs(zeta)) < 0.0003) {

    deprivationFactor = (2.0 / layerThicknessFactor) - (1.0 / (layerThicknessFactor * layerThicknessFactor)) * (2
                                                                                                                *
                                                                                                                layerNo -
                                                                                                                1);
    return deprivationFactor;

  } else {

    double c2 = 0.0;
    double c3 = 0.0;
    c2 = log((layerThicknessFactor + zeta * layerNo) / (layerThicknessFactor + zeta * (layerNo - 1)));
    c3 = zeta / (layerThicknessFactor * (zeta + 1.0));
    deprivationFactor = (c2 - c3) / (log(zeta + 1.0) - zeta / (zeta + 1.0));
    return deprivationFactor;
  }
}
