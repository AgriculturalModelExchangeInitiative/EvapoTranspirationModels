# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_penman(rhoDensityAir:float,
         psychrometricConstant:float,
         hslope:float,
         evapoTranspirationPriestlyTaylor:float,
         VPDair:float,
         lambdaV:float,
         Alpha:float,
         specificHeatCapacityAir:float,
         conductance:float):
    """
     - Name: Penman -Version: 1.0, -Time step: 1
     - Description:
                 * Title: Penman Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
                 * ShortDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
     - inputs:
                 * name: rhoDensityAir
                               ** description : Density of air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : None
                               ** min : None
                               ** default : 1.225
                               ** unit : 
                 * name: psychrometricConstant
                               ** description : psychrometric constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.66
                               ** unit : 
                 * name: hslope
                               ** description : the slope of saturated vapor pressure temperature curve at a given temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 0.584
                               ** unit : hPa degC-1
                 * name: evapoTranspirationPriestlyTaylor
                               ** description : evapoTranspiration of Priestly Taylor
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 449.367
                               ** unit : g m-2 d-1
                 * name: VPDair
                               ** description : vapour pressure density
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 2.19
                               ** unit : hPa
                 * name: lambdaV
                               ** description : latent heat of vaporization of water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : 
                 * name: Alpha
                               ** description : Priestley-Taylor evapotranspiration proportionality constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 1.5
                               ** unit : 
                 * name: specificHeatCapacityAir
                               ** description : Specific heat capacity of dry air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.00101
                               ** unit : 
                 * name: conductance
                               ** description : conductance
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 598.685
                               ** unit : m d-1
     - outputs:
                 * name: evapoTranspirationPenman
                               ** description : evapoTranspiration of Penman Monteith
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 5000
                               ** min : 0
                               ** unit : g m-2 d-1
    """

    evapoTranspirationPenman:float
    evapoTranspirationPenman = evapoTranspirationPriestlyTaylor / Alpha + (1000.00 * (rhoDensityAir * specificHeatCapacityAir * VPDair * conductance / (lambdaV * (hslope + psychrometricConstant))))
    return evapoTranspirationPenman
#%%CyML Model End%%