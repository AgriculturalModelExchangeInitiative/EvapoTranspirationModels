# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_saturationvaporpressuredeficit(saturated_vapor_pressure:float,
         vapor_pressure:float):
    """
     - Name: SaturationVaporPressureDeficit -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA saturation vapor pressure deficit
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: 
             
                 * Institution: ZALF e.V.
                 * ExtendedDescription: 
             
                 * ShortDescription: Calculates saturation vapor pressure deficit as in the MONICA model
     - inputs:
                 * name: saturated_vapor_pressure
                               ** description : saturated vapor pressure
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : kPa
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
                 * name: saturation_vapor_pressure_deficit
                               ** description : saturation vapor pressure deficit
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : kPa
    """

    saturation_vapor_pressure_deficit:float
    saturation_vapor_pressure_deficit = saturated_vapor_pressure - vapor_pressure
    return saturation_vapor_pressure_deficit
#%%CyML Model End%%