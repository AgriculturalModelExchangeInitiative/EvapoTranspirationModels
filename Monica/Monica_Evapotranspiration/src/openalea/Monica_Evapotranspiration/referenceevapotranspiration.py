# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_referenceevapotranspiration(height_nn:float,
         mean_air_temperature:float,
         wind_speed:float,
         wind_speed_height:float,
         net_radiation:float,
         stomata_resistance:float,
         saturation_vapor_pressure_deficit:float):
    """
     - Name: ReferenceEvapotranspiration -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA reference evapotranspiration
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: 
                 Allen RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration. Guidelines for computing crop water requirements. FAO Irrigation and
                 Drainage Paper 56, FAO, Roma
             
                 * Institution: ZALF e.V.
                 * ExtendedDescription: 
                 A method following Penman-Monteith as described by the FAO in Allen
                 RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.
                 Guidelines for computing crop water requirements. FAO Irrigation and
                 Drainage Paper 56, FAO, Roma
             
                 * ShortDescription: Calculates the MONICA reference evapotranspiration
     - inputs:
                 * name: height_nn
                               ** description : height above sea level
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : -9999
                               ** default : 0
                               ** unit : m
                 * name: mean_air_temperature
                               ** description : daily average air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: wind_speed
                               ** description : wind speed measured at wind speed height
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : 0
                               ** default : 0
                               ** unit : m/s
                 * name: wind_speed_height
                               ** description : height at which the wind speed has been measured
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : -9999
                               ** default : 2
                               ** unit : m
                 * name: net_radiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: stomata_resistance
                               ** description : stomata resistance (FAO default value is 100)
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
                 * name: saturation_vapor_pressure_deficit
                               ** description : saturation_vapor_pressure_deficit
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
     - outputs:
                 * name: reference_evapotranspiration
                               ** description : reference evapotranspiration (ET0)
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
    """

    reference_evapotranspiration:float
    atmospheric_pressure:float
    atmospheric_pressure = 101.3 * pow((293.0 - (0.0065 * height_nn)) / 293.0, 5.26)
    psycrometer_constant:float
    psycrometer_constant = 0.000665 * atmospheric_pressure
    saturated_vapour_pressure_slope:float
    saturated_vapour_pressure_slope = 4098.0 * (0.6108 * exp(17.27 * mean_air_temperature / (mean_air_temperature + 237.3))) / ((mean_air_temperature + 237.3) * (mean_air_temperature + 237.3))
    wind_speed_2m:float
    wind_speed_2m = max(0.5, wind_speed * (4.87 / log((67.8 * wind_speed_height - 5.42))))
    aerodynamic_resistance:float
    aerodynamic_resistance = 208.0 / wind_speed_2m
    surface_resistance:float
    surface_resistance = stomata_resistance / 1.44
    reference_evapotranspiration = (0.408 * saturated_vapour_pressure_slope * net_radiation + (psycrometer_constant * (900.0 / (mean_air_temperature + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))))
    if reference_evapotranspiration < 0.0:
        reference_evapotranspiration = 0.0
    return reference_evapotranspiration
#%%CyML Model End%%