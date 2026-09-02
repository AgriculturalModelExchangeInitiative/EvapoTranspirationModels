# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_soilheatflux(ih:int,
         tau:float,
         soilEvaporation:float,
         solarRadiation:float,
         netRadiationEquivalentEvaporation:float):
    """
     - Name: SoilHeatFlux -Version: 1.0, -Time step: 1
     - Description:
                 * Title: SoilHeatFlux Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: The available energy in the soil
                 * ShortDescription: The available energy in the soil
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
                 * name: tau
                               ** description : plant cover factor
                               ** inputtype : parameter
                               ** parametercategory : species
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 0.9983
                               ** unit : 
                 * name: soilEvaporation
                               ** description : soil Evaporation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 448.240
                               ** unit : g m-2 d-1
                 * name: solarRadiation
                               ** description : solar Radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 3
                               ** unit : MJ m-2 d-1
                 * name: netRadiationEquivalentEvaporation
                               ** description : net Radiation Equivalent Evaporation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 5000
                               ** min : 0
                               ** default : 638.142
                               ** unit : g m-2 d-1
     - outputs:
                 * name: soilHeatFlux
                               ** description : soil Heat Flux
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 10000
                               ** min : 0
                               ** unit : g m-2 d-1
    """

    soilHeatFlux:float
    if ih == -999:
        soilHeatFlux = tau * netRadiationEquivalentEvaporation - soilEvaporation
    else:
        if solarRadiation < 0.001:
            soilHeatFlux = netRadiationEquivalentEvaporation * 0.50
        else:
            soilHeatFlux = netRadiationEquivalentEvaporation * 0.10
    return soilHeatFlux
#%%CyML Model End%%