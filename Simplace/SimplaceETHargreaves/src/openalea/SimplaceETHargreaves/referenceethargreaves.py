# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_referenceethargreaves(cConvertLeByTemp:bool,
         iTMax:float,
         iTMin:float,
         iSolarRadiation:float):
    """
     - Name: ReferenceETHargreaves -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETHargreaves model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: cConvertLeByTemp
                               ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** default : false
                               ** unit : 
                 * name: iTMax
                               ** description : maximum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
                 * name: iTMin
                               ** description : minimum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
                 * name: iSolarRadiation
                               ** description : solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
     - outputs:
                 * name: ReferenceCropEvapotranspiration
                               ** description : reference evapotranspiration (ET0)
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 
                               ** min : 
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
    """

    ReferenceCropEvapotranspiration:float
    R_s_eveq:float
    if cConvertLeByTemp:
        R_s_eveq = EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 * (iTMax + iTMin))
    else:
        R_s_eveq = EvaporationEquivalentToRadiation2(iSolarRadiation)
    ReferenceCropEvapotranspiration = max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin))
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%

def EvaporationEquivalentToRadiation1(Radiation:float,
         DailyMeanTemperature:float):
    return 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation

def EvaporationEquivalentToRadiation2(Radiation:float):
    return 0.408 * Radiation

def ReferenceEvapoTranspirationFromSolarRadiation(R_s:float,
         T_max:float,
         T_min:float):
    T_mean:float
    T_mean = (T_max + T_min) / 2
    return 0.0135 * (T_mean + 17.8) * R_s