# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_canopytemperature(minTair:float,
         cropHeatFlux:float,
         rhoDensityAir:float,
         maxTair:float,
         lambdaV:float,
         specificHeatCapacityAir:float,
         conductance:float):
    """
     - Name: CanopyTemperature -Version: 1.0, -Time step: 1
     - Description:
                 * Title: CanopyTemperature Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: It is calculated from the crop heat flux and the boundary layer conductance
                 * ShortDescription: It is calculated from the crop heat flux and the boundary layer conductance
     - inputs:
                 * name: minTair
                               ** description : minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 45
                               ** min : 30
                               ** default : 0.7
                               ** unit : degC
                 * name: cropHeatFlux
                               ** description : Crop heat flux
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 447.912
                               ** unit : g/m**2/d
                 * name: rhoDensityAir
                               ** description : Density of air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : None
                               ** min : None
                               ** default : 1.225
                               ** unit : kg/m**3
                 * name: maxTair
                               ** description : maximum air Temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 45
                               ** min : 30
                               ** default : 7.2
                               ** unit : degC
                 * name: lambdaV
                               ** description : latent heat of vaporization of water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : MJ/kg
                 * name: specificHeatCapacityAir
                               ** description : Specific heat capacity of dry air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : None
                               ** min : None
                               ** default : 0.00101
                               ** unit : MJ/kg/degC
                 * name: conductance
                               ** description : the boundary layer conductance
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 598.685
                               ** unit : m/d
     - outputs:
                 * name: minCanopyTemperature
                               ** description : minimal Canopy Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 45
                               ** min : 30
                               ** unit : degC
                 * name: maxCanopyTemperature
                               ** description : maximal Canopy Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 45
                               ** min : 30
                               ** unit : degC
    """

    minCanopyTemperature:float
    maxCanopyTemperature:float
    if minTair == float(999) and maxTair == float(-999):
        minCanopyTemperature = float(999)
        maxCanopyTemperature = float(-999)
    else:
        minCanopyTemperature = minTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))
        maxCanopyTemperature = maxTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))
    return (minCanopyTemperature, maxCanopyTemperature)
#%%CyML Model End%%