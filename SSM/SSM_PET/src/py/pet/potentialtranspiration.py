# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_potentialtranspiration(tmax:float,
         tmin:float,
         ddmp:float,
         TEC:float,
         VPDF:float):
    """
     - Name: PotentialTranspiration -Version: -, -Time step: 1
     - Description:
                 * Title: PotentialTranspiration
                 * Authors: -
                 * Reference: -
                 * Institution: -
                 * ExtendedDescription: Calculates daily potential transpiration (mm/day) from daily maximum and minimum temperatures and daily dry matter production using vapor pressure deficit computed from saturation vapor pressures (Tetens formula) and scaled by a Vapor Pressure Deficit Factor (VPDF) and a Transpiration Efficiency Coefficient (TEC).
                 * ShortDescription: Compute daily potential transpiration from temperatures and dry matter via VPD, TEC and VPDF.
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
                 * name: ddmp
                               ** description : Daily dry matter production.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : g m-2 day-1
                               ** uri : -
                 * name: TEC
                               ** description : Transpiration efficiency coefficient.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 5.8
                               ** unit : g mm-1
                               ** uri : -
                 * name: VPDF
                               ** description : Vapor pressure deficit factor.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 0.75
                               ** unit : -
                               ** uri : -
     - outputs:
                 * name: TR
                               ** description : Potential transpiration.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : mm day-1
                               ** uri : -
    """

    TR:float
    vptmin:float
    vptmax:float
    VPD:float
    vptmin = 0.6108 * exp(17.27 * tmin / (tmin + 237.3))
    vptmax = 0.6108 * exp(17.27 * tmax / (tmax + 237.3))
    VPD = VPDF * (vptmax - vptmin)
    TR = ddmp * VPD / TEC
    return TR
#%%CyML Model End%%