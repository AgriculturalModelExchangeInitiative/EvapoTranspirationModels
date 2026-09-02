# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_diffusionlimitedevaporation(ih:int,
         deficitOnTopLayers:float,
         soilDiffusionConstant:float):
    """
     - Name: DiffusionLimitedEvaporation -Version: 1.0, -Time step: 1
     - Description:
                 * Title: DiffusionLimitedEvaporation Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: the evaporation from the diffusion limited soil
                 * ShortDescription: It calculates the diffusion limited evaropration
     
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
                 * name: deficitOnTopLayers
                               ** description : deficit On TopLayers
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 5341
                               ** unit : g m-2 d-1
                 * name: soilDiffusionConstant
                               ** description : soil Diffusion Constant
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 4.2
                               ** unit : 
     - outputs:
                 * name: diffusionLimitedEvaporation
                               ** description : the evaporation from the diffusion limited soil
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 5000
                               ** min : 0
                               ** unit : g m-2 d-1
    """

    diffusionLimitedEvaporation:float
    if ih == -999:
        if deficitOnTopLayers / 1000.00 <= 0.00:
            diffusionLimitedEvaporation = 8.30 * 1000.00
        else:
            if deficitOnTopLayers / 1000.00 < 25.00:
                diffusionLimitedEvaporation = 2.00 * soilDiffusionConstant * soilDiffusionConstant / (deficitOnTopLayers / 1000.00) * 1000.00
            else:
                diffusionLimitedEvaporation = 0.00
    else:
        diffusionLimitedEvaporation = 0.00
    return diffusionLimitedEvaporation
#%%CyML Model End%%