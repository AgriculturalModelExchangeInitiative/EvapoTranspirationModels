#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <set>
#include <tuple>
#include "ReferenceEvapotranspiration.h"
using namespace Monica_Evapotranspiration;
ReferenceEvapotranspiration::ReferenceEvapotranspiration() {}
double ReferenceEvapotranspiration::getheight_nn() { return this->height_nn; }
void ReferenceEvapotranspiration::setheight_nn(double _height_nn) { this->height_nn = _height_nn; }
void ReferenceEvapotranspiration::Calculate_Model(ETState &s, ETState &s1, ETRate &r, ETAuxiliary &a, ETExogenous &ex)
{
    //- Name: ReferenceEvapotranspiration -Version: 1, -Time step: 1
    //- Description:
    //            * Title: MONICA reference evapotranspiration
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //            Allen RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration. Guidelines for computing crop water requirements. FAO Irrigation and
    //            Drainage Paper 56, FAO, Roma
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //            A method following Penman-Monteith as described by the FAO in Allen
    //            RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.
    //            Guidelines for computing crop water requirements. FAO Irrigation and
    //            Drainage Paper 56, FAO, Roma
    //        
    //            * ShortDescription: Calculates the MONICA reference evapotranspiration
    //- inputs:
    //            * name: height_nn
    //                          ** description : height above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : -9999
    //                          ** default : 0
    //                          ** unit : m
    //            * name: mean_air_temperature
    //                          ** description : daily average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : -100
    //                          ** default : 0
    //                          ** unit : °C
    //            * name: wind_speed
    //                          ** description : wind speed measured at wind speed height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : m/s
    //            * name: wind_speed_height
    //                          ** description : height at which the wind speed has been measured
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : -9999
    //                          ** default : 2
    //                          ** unit : m
    //            * name: net_radiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: stomata_resistance
    //                          ** description : stomata resistance (FAO default value is 100)
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 100
    //                          ** unit : s/m
    //            * name: saturation_vapor_pressure_deficit
    //                          ** description : saturation_vapor_pressure_deficit
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : kPa
    //- outputs:
    //            * name: reference_evapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    double mean_air_temperature = ex.getmean_air_temperature();
    double wind_speed = ex.getwind_speed();
    double wind_speed_height = ex.getwind_speed_height();
    double net_radiation = a.getnet_radiation();
    double stomata_resistance = a.getstomata_resistance();
    double saturation_vapor_pressure_deficit = a.getsaturation_vapor_pressure_deficit();
    double reference_evapotranspiration;
    double atmospheric_pressure;
    atmospheric_pressure = 101.3 * std::pow((293.0 - (0.0065 * height_nn)) / 293.0, 5.26);
    double psycrometer_constant;
    psycrometer_constant = 0.000665 * atmospheric_pressure;
    double saturated_vapour_pressure_slope;
    saturated_vapour_pressure_slope = 4098.0 * (0.6108 * std::exp(17.27 * mean_air_temperature / (mean_air_temperature + 237.3))) / ((mean_air_temperature + 237.3) * (mean_air_temperature + 237.3));
    double wind_speed_2m;
    wind_speed_2m = std::max(0.5, wind_speed * (4.87 / std::log((67.8 * wind_speed_height - 5.42))));
    double aerodynamic_resistance;
    aerodynamic_resistance = 208.0 / wind_speed_2m;
    double surface_resistance;
    surface_resistance = stomata_resistance / 1.44;
    reference_evapotranspiration = (0.408 * saturated_vapour_pressure_slope * net_radiation + (psycrometer_constant * (900.0 / (mean_air_temperature + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))));
    if (reference_evapotranspiration < 0.0)
    {
        reference_evapotranspiration = 0.0;
    }
    a.setreference_evapotranspiration(reference_evapotranspiration);
}