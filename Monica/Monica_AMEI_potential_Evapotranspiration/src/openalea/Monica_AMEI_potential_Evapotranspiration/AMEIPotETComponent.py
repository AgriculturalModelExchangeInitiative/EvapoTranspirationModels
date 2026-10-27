# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Monica_AMEI_potential_Evapotranspiration.saturationvaporpressuredeficit import model_saturationvaporpressuredeficit
from Monica_AMEI_potential_Evapotranspiration.referenceevapotranspiration import model_referenceevapotranspiration
from Monica_AMEI_potential_Evapotranspiration.potentialevapotranspiration import model_potentialevapotranspiration

#%%CyML Model Begin%%
def model_ameipotet(vapor_pressure:float,
         saturated_vapor_pressure:float,
         height_nn:float,
         mean_air_temperature:float,
         wind_speed:float,
         wind_speed_height:float,
         stomata_resistance:float,
         net_radiation:float,
         kc_factor:float,
         developmental_stage:int,
         crop_remaining_evapotranspiration:float):
    """
     - Name: AMEIPotET -Version: 1, -Time step: 1
     - Description:
                 * Title: AMEI ET MONICA potential evapotranspiration model
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the MONICA potential evapotranspiration for AMEI ET exercise
     - inputs:
                 * name: vapor_pressure
                               ** description : vapor pressure
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
                 * name: saturated_vapor_pressure
                               ** description : saturated vapor pressure
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : kPa
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
                               ** unit : MJ/m2
                 * name: kc_factor
                               ** description : crop coefficient ETc/ET0
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0.75
                               ** unit : dimensionless
                 * name: developmental_stage
                               ** description : MONICA crop developmental stage
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 6
                               ** min : 0
                               ** default : 0
                               ** unit : dimensionless
                 * name: crop_remaining_evapotranspiration
                               ** description : crop remaining evapotranspiration
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
     - outputs:
                 * name: reference_evapotranspiration
                               ** description : reference evapotranspiration (ET0)
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: potential_evapotranspiration
                               ** description : the potential evapotranspiration
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
    """

    saturation_vapor_pressure_deficit:float
    reference_evapotranspiration:float
    potential_evapotranspiration_cap:float
    potential_evapotranspiration:float
    saturation_vapor_pressure_deficit = model_saturationvaporpressuredeficit(saturated_vapor_pressure, vapor_pressure)
    reference_evapotranspiration = model_referenceevapotranspiration(height_nn, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit)
    potential_evapotranspiration = model_potentialevapotranspiration(potential_evapotranspiration_cap, kc_factor, developmental_stage, crop_remaining_evapotranspiration, reference_evapotranspiration)
    return (reference_evapotranspiration, potential_evapotranspiration)
#%%CyML Model End%%