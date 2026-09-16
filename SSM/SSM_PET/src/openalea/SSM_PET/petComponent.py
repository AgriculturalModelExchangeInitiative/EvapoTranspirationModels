# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SSM_PET.potentialevapotranspiration import model_potentialevapotranspiration

#%%CyML Model Begin%%
def model_pet(tmax:float,
         tmin:float,
         srad:float,
         albedo:float):
    """
     - Name: pet -Version: 0.1, -Time step: 1
     - Description:
                 * Title: SSM Evapotranspiration
                 * Authors: Thomas Sinclair, 
                 * Reference: None
                 * Institution: CIRAD
                 * ExtendedDescription: PotentialEvapotranspiration — simplified Penman-style PET (EEQ from srad, tmax, tmin with albedo and Tmax adjustments; cites Sultani and Sinclair 2012)
                 * ShortDescription: Simplified Penman PET.
     - inputs:
                 * name: tmax
                               ** description : Daily maximum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60.0
                               ** min : -60.0
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: tmin
                               ** description : Daily minimum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60.0
                               ** min : -60.0
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: srad
                               ** description : Daily solar radiation.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 120.0
                               ** min : 0.0
                               ** default : 
                               ** unit : MJ m-2 day-1
                               ** uri : -
                 * name: albedo
                               ** description : Surface albedo.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10.0
                               ** min : 0.0
                               ** default : 1.0
                               ** unit : -
                               ** uri : -
     - outputs:
                 * name: pet
                               ** description : Potential evapotranspiration.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : mm day-1
                               ** uri : -
    """

    pet:float
    pet = model_potentialevapotranspiration(tmax, tmin, srad, albedo)
    return pet
#%%CyML Model End%%