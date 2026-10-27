# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_potentialevapotranspiration(potential_evapotranspiration_cap:float,
         kc_factor:float,
         developmental_stage:int,
         crop_remaining_evapotranspiration:float,
         reference_evapotranspiration:float):
    """
     - Name: PotentialEvapotranspiration -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA potential evapotranspiration calculation
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the MONICA potential evapotranspiration
     - inputs:
                 * name: potential_evapotranspiration_cap
                               ** description : cap ET0 to this value
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 6.5
                               ** unit : mm
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
                 * name: reference_evapotranspiration
                               ** description : ET0 either from external ET0 or crop specific ET0
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
     - outputs:
                 * name: potential_evapotranspiration
                               ** description : the potential evapotranspiration
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
    """

    potential_evapotranspiration:float
    if developmental_stage > 0:
        potential_evapotranspiration = crop_remaining_evapotranspiration
    else:
        potential_evapotranspiration = reference_evapotranspiration * kc_factor
    if potential_evapotranspiration > potential_evapotranspiration_cap:
        potential_evapotranspiration = potential_evapotranspiration_cap
    return potential_evapotranspiration
#%%CyML Model End%%