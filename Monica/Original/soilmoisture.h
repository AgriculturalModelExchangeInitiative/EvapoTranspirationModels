#include <vector>

#include "monica-parameters.h"
#include "snow-component.h"

namespace monica 
{
class MonicaModel;
class SoilColumn;
class CropModule;

class SoilMoisture
{
public:
  SoilMoisture(MonicaModel& monica, const SoilMoistureModuleParameters& smPs);

  void step(double vs_DepthGroundwaterTable,
    double vw_Precipitation,
    double vw_MaxAirTemperature,
    double vw_MinAirTemperature,
    double vw_RelativeHumidity,
    double vw_MeanAirTemperature,
    double vw_WindSpeed,
    double vw_WindSpeedHeight,
    double vw_NetRadiation,
    int vs_JulianDay,
    double vw_ReferenceEvapotranspiration,
    double vaporPressure);

  double eReducer1(int layerIndex,
                        double percentageSoilCoverage,
                        double vm_PotentialEvapotranspiration,
                        int evaporationReductionMethod = 1);

  double get_DeprivationFactor(int layerNo, double deprivationDepth,
                                double zeta, double vs_LayerThickness);

  void fm_Evapotranspiration(double vs_HeightNN,
                              double vw_MaxAirTemperature,
                              double vw_MinAirTemperature,
                              double vw_RelativeHumidity,
                              double vw_MeanAirTemperature,
                              double vw_WindSpeed,
                              double vw_WindSpeedHeight,
                              double vw_NetRadiation,
                              int vc_DevelopmentalStage,
                              int vs_JulianDay,
                              double vs_Latitude,
                double externalReferenceEvapotranspiration);

  double referenceEvapotranspiration(double vs_HeightNN,
                                      double vw_MaxAirTemperature,
                                      double vw_MinAirTemperature,
                                      double vw_RelativeHumidity,
                                      double vw_MeanAirTemperature,
                                      double vw_WindSpeed,
                                      double vw_WindSpeedHeight,
                                      double vw_NetRadiation,
                                      int vs_JulianDay,
                                      double vs_Latitude);

  double vm_EvaporatedFromSurface{0.0}; //!< Amount of water evaporated from surface [mm]
  SoilColumn& soilColumn;
  const SiteParameters& siteParameters;
  MonicaModel& monica;
  SoilMoistureModuleParameters _params;
  const CropModuleParameters& cropPs;
  size_t numberOfMoistureLayers{0};
  size_t numberOfSoilLayers{0};
  double vm_ActualEvaporation{0.0}; //!< Sum of evaporation of all layers [mm]
  double vm_ActualEvapotranspiration{0.0}; //!< Sum of evaporation and transpiration of all layers [mm]
  double vm_ActualTranspiration{0.0}; //!< Sum of transpiration of all layers [mm]
  std::vector<double> vm_Evaporation; //!< Evaporation of layer [mm]
  std::vector<double> vm_Evapotranspiration; //!< Evapotranspiration of layer [mm]
  std::vector<double> vm_FieldCapacity; //!< Soil water content at Field Capacity
  double vm_Infiltration{0.0}; //!< Amount of water that infiltrates into top soil layer [mm]
  double vc_KcFactor{0.6};
  double vs_Latitude{0.0};
  std::vector<double> vm_LayerThickness;
  double pm_LayerThickness{0.0};
  double vw_NetRadiation{0.0}; //!< [MJ m-2]
  std::vector<double> vm_PermanentWiltingPoint; //!< Soil water content at permanent wilting point [m3 m-3]
  double vc_PercentageSoilCoverage{0.0}; //!< [m2 m-2]
  double vm_ReferenceEvapotranspiration{6.0}; //!< Evapotranspiration of a 12mm cut grass crop at sufficient water supply [mm]
  std::vector<double> vm_SoilMoisture; //!< Result - Soil moisture of layer [m3 m-3]
  double vc_StomataResistance{0.0};
  double vm_SurfaceWaterStorage{0.0}; //!<  Simulates a virtual layer that contains the surface water [mm]
  std::vector<double> vm_Transpiration; //!< Transpiration of layer [mm]
  double vm_XSACriticalSoilMoisture{0.0};
  kj::Own<SnowComponent> snowComponent;
  CropModule* cropModule{nullptr};
  double _vaporPressure{-1.0}; //[kPA]
}; 

} // namespace monica


