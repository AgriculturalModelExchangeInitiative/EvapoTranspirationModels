# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Monica_Reference_Evapotranspiration.referenceevapotranspiration import model_referenceevapotranspiration

#%%CyML Model Begin%%
def model_ameirefet(height_nn:float,
         latent_heat_of_vaporization:float,
         mean_air_temperature:float,
         wind_speed:float,
         wind_speed_height:float,
         stomata_resistance:float,
         net_radiation:float,
         saturation_vapor_pressure_deficit:float):
    """
     - Name: AMEIRefET -Version: 1, -Time step: 1
     - Description:
                 * Title: AMEI ET MONICA reference evapotranspiration model
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the MONICA reference evapotranspiration for AMEI ET exercise
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
                 * name: latent_heat_of_vaporization
                               ** description : latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/kg
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
                               ** min : 0.1
                               ** default : 2
                               ** unit : m
                 * name: stomata_resistance
                               ** description : stomata resistance (FAO default value is 100)
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
                 * name: net_radiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/m2
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
    reference_evapotranspiration = model_referenceevapotranspiration(height_nn, latent_heat_of_vaporization, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit)
    return reference_evapotranspiration
#%%CyML Model End%%