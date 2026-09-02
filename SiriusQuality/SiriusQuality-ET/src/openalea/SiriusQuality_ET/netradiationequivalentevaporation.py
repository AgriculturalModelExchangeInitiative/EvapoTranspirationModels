# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_netradiationequivalentevaporation(lambdaV:float,
         netRadiation:float):
    """
     - Name: NetRadiationEquivalentEvaporation -Version: 1.0, -Time step: 1
     - Description:
                 * Title: NetRadiationEquivalentEvaporation Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: It is given by dividing net radiation by latent heat of vaporization of water
                 * ShortDescription: It is given by dividing net radiation by latent heat of vaporization of water
     - inputs:
                 * name: lambdaV
                               ** description : latent heat of vaporization of water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : MJ kg-1
                 * name: netRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 5000
                               ** min : 0
                               ** default : 1.566
                               ** unit : MJ m-2 d-1
     - outputs:
                 * name: netRadiationEquivalentEvaporation
                               ** description : net Radiation in Equivalent Evaporation
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 5000
                               ** min : 0
                               ** unit : g m-2 d-1
    """

    netRadiationEquivalentEvaporation:float
    netRadiationEquivalentEvaporation = netRadiation / lambdaV * 1000.00
    return netRadiationEquivalentEvaporation
#%%CyML Model End%%