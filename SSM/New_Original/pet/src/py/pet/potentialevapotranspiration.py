# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_potentialevapotranspiration(tmax:float,
         tmin:float,
         srad:float,
         albedo:float):
    """
     - Name: PotentialEvapotranspiration -Version: -, -Time step: 1
     - Description:
                 * Title: PotentialEvapotranspiration
                 * Authors: -
                 * Reference: -
                 * Institution: -
                 * ExtendedDescription: Python implementation of a simplified Penman-style PET model (from Sultani & Sinclair 2012) computing equilibrium evaporation EEQ = SRAD*(0.004876-0.004374*ALBEDO)*(TD+29) with TD = 0.6*TMAX+0.4*TMIN, PET adjusted by Tmax-dependent multipliers (including low-temperature and high-advection corrections) and intended to be combined with an exponential Beer–Bouguer–Lambert factor for fraction of uncovered soil.
                 * ShortDescription: Simplified Penman-based PET calculator using EEQ, Tmax adjustments, and optional Beer–Lambert uncovered-soil albedo weighting.
     - inputs:
                 * name: tmax
                               ** description : Daily maximum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: tmin
                               ** description : Daily minimum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: srad
                               ** description : Daily solar radiation.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : MJ m-2 day-1
                               ** uri : -
                 * name: albedo
                               ** description : Surface albedo.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 1
                               ** unit : -
                               ** uri : -
     - outputs:
                 * name: pet
                               ** description : Potential evapotranspiration.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : mm day-1
                               ** uri : -
    """

    pet:float
    td:float
    eeq:float
    td = 0.6 * tmax + (0.4 * tmin)
    eeq = srad * (0.004876 - (0.004374 * albedo)) * (td + 29.0)
    if tmax > 5.0 and tmax < 34.0:
        pet = eeq * 1.1
    elif tmax >= 34.0:
        pet = eeq * ((tmax - 34.0) * 0.05 + 1.1)
    else:
        pet = eeq * 0.01 * exp(0.18 * (tmax + 20.0))
    return pet
#%%CyML Model End%%