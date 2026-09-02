# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_evapotranspiration(isWindVpDefined:int,
         evapoTranspirationPenman:float,
         evapoTranspirationPriestlyTaylor:float):
    """
     - Name: EvapoTranspiration -Version: 1.0, -Time step: 1
     - Description:
                 * Title: Evapotranspiration Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: According to the availability of wind and/or vapor pressure daily data, the
     SiriusQuality2 model calculates the evapotranspiration rate using the Penman (if wind
     and vapor pressure data are available) (Penman 1948) or the Priestly-Taylor
     (Priestley and Taylor 1972) method
                 * ShortDescription: It uses to choose evapotranspiration of Penmann or Priestly-Taylor
     - inputs:
                 * name: isWindVpDefined
                               ** description : if wind and vapour pressure are defined
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 1
                               ** min : 0
                               ** default : 1
                               ** unit : 
                 * name: evapoTranspirationPenman
                               ** description : evapoTranspiration of Penman
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 830.958
                               ** unit : mm
                 * name: evapoTranspirationPriestlyTaylor
                               ** description : evapoTranspiration of Priestly Taylor
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 449.367
                               ** unit : mm
     - outputs:
                 * name: evapoTranspiration
                               ** description : evapoTranspiration
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 10000
                               ** min : 0
                               ** unit : mm
    """

    evapoTranspiration:float
    if isWindVpDefined == 1:
        evapoTranspiration = evapoTranspirationPenman
    else:
        evapoTranspiration = evapoTranspirationPriestlyTaylor
    return evapoTranspiration
#%%CyML Model End%%