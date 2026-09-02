# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_cropheatflux(ih:int,
         potentialTranspiration:float,
         netRadiationEquivalentEvaporation:float,
         soilHeatFlux:float):
    """
     - Name: CropHeatFlux -Version: 1.0, -Time step: 1
     - Description:
                 * Title: CropHeatFlux Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: It is calculated from net Radiation, soil heat flux and potential transpiration
                 * ShortDescription: It calculates the crop heat flux
     
     - inputs:
                 * name: ih
                               ** description : hour of the day if the component is hourly, -999 if the component is daily
                               ** inputtype : variable
                               ** parametercategory : state
                               ** datatype : INT
                               ** max : 24
                               ** min : 999
                               ** default : 999
                               ** unit : 
                 * name: potentialTranspiration
                               ** description : potential Transpiration
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 1.413
                               ** unit : g m-2 d-1
                 * name: netRadiationEquivalentEvaporation
                               ** description : net Radiation Equivalent Evaporation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 638.142
                               ** unit : g m-2 d-1
                 * name: soilHeatFlux
                               ** description : soil Heat Flux
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 188.817
                               ** unit : g m-2 d-1
     - outputs:
                 * name: cropHeatFlux
                               ** description : crop Heat Flux
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 10000
                               ** min : 0
                               ** unit : g m-2 d-1
    """

    cropHeatFlux:float
    cHfliminf:float
    cHflimsup:float
    cHfliminf = -100.00
    if ih == -999:
        cHfliminf = -10E6
    cHflimsup = 100.00
    if ih == -999:
        cHflimsup = 10E6
    cropHeatFlux = netRadiationEquivalentEvaporation - soilHeatFlux - potentialTranspiration
    cropHeatFlux = min(cHflimsup, max(cHfliminf, cropHeatFlux))
    return cropHeatFlux
#%%CyML Model End%%