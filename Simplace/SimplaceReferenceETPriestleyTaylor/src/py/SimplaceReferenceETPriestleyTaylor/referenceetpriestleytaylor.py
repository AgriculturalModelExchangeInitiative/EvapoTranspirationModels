# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_referenceetpriestleytaylor(cAltitude:float,
         cAlphaPT:float,
         iTMax:float,
         iTMin:float,
         iNetRadiation:float):
    """
     - Name: ReferenceETPriestleyTaylor -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETPriestleyTaylor model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: cAltitude
                               ** description : altitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
                 * name: cAlphaPT
                               ** description : Priestley-Taylor coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 1.26
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
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
                 * name: iNetRadiation
                               ** description : net radiation
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
    lambdav:float
    T:float
    Delta:float
    AtmPres:float
    Gamma:float
    G:float
    lambdav = 2.45
    T = (iTMax + iTMin) / 2.0
    Delta = SlopeOfSaturationVapPressureCurve(T)
    AtmPres = AtmosphericPressure(cAltitude)
    Gamma = PsychrometricConstant(AtmPres)
    G = 0.0
    ReferenceCropEvapotranspiration = max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav)
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%

def SlopeOfSaturationVapPressureCurve(T:float):
    tempT:float
    tempT = T + 237.3
    return 4098 * (0.6108 * exp(17.27 * T / tempT)) / pow(tempT, 2)

def AtmosphericPressure(z:float):
    return 101.3 * pow((293 - (0.0065 * z)) / 293, 5.26)

def PsychrometricConstant(P:float):
    lambdav:float
    c_p:float
    epsilon:float
    factor:float
    lambdav = 2.45
    c_p = 1.013E-3
    epsilon = 0.622
    factor = round(c_p / (epsilon * lambdav) * 10E6) / 10E6
    return factor * P