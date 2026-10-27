# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_netradiation(height_nn:float,
         reference_albedo:float,
         global_radiation:float,
         max_air_temperature:float,
         min_air_temperature:float,
         extraterrestrial_radiation:float,
         vapor_pressure:float):
    """
     - Name: NetRadiation -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA net radiation calculation
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: 
             
                 * Institution: ZALF e.V.
                 * ExtendedDescription: 
             
                 * ShortDescription: None
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
                 * name: reference_albedo
                               ** description : reference albedo
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0
                               ** unit : dimensionless
                 * name: global_radiation
                               ** description : global radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/m2
                 * name: max_air_temperature
                               ** description : daily maximum air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: min_air_temperature
                               ** description : daily minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: extraterrestrial_radiation
                               ** description : extraterrestrial_radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/m2
                 * name: vapor_pressure
                               ** description : vapor pressure
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
     - outputs:
                 * name: net_radiation
                               ** description : net_radiation
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
    """

    net_radiation:float
    clear_sky_solar_radiation:float
    clear_sky_solar_radiation = (0.75 + (0.00002 * height_nn)) * extraterrestrial_radiation
    relative_shortwave_radiation:float
    relative_shortwave_radiation = min(global_radiation / clear_sky_solar_radiation, 1.0) if clear_sky_solar_radiation > 0.0 else 1.0
    bolzmann_constant:float = 0.0000000049
    shortwave_radiation:float
    shortwave_radiation = (1.0 - reference_albedo) * global_radiation
    longwave_radiation:float
    longwave_radiation = bolzmann_constant * ((pow(min_air_temperature + 273.16, 4.0) + pow(max_air_temperature + 273.16, 4.0)) / 2.0) * (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 * sqrt(vapor_pressure)))
    net_radiation = shortwave_radiation - longwave_radiation
    return net_radiation
#%%CyML Model End%%