# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_referenceetpm(cAltitude:float,
         iTMax:float,
         iTMin:float,
         iActualVapourPressure:float,
         iNetRadiation:float,
         iWindspeed:float):
    """
     - Name: ReferenceETPM -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETPM model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: cAltitude
                               ** description : elevation above sea level
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
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
                 * name: iActualVapourPressure
                               ** description : actual vapour pressure
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
                 * name: iNetRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
                 * name: iWindspeed
                               ** description : wind speed at 2m height
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
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
    T:float
    e_s:float
    T = (iTMax + iTMin) / 2
    e_s = MeanSaturatedVapourPressure(iTMax, iTMin)
    if iActualVapourPressure > e_s:
        iActualVapourPressure = e_s
    ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude)
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%

def SaturationVapourPressureAtTemperature(T:float):
    return 0.6108 * exp(17.27 * T / (T + 237.3))

def MeanSaturatedVapourPressure(T_max:float,
         T_min:float):
    return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2

def SlopeOfSaturationVapPressureCurve(T:float):
    tempT:float
    tempT = T + 237.3
    return 4098 * (0.6108 * exp(17.27 * T / tempT)) / pow(tempT, 2)

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

def AtmosphericPressure(z:float):
    return 101.3 * pow((293 - (0.0065 * z)) / 293, 5.26)

def ReferenceEvapotranspiration(T:float,
         R_n:float,
         u_2:float,
         e_s:float,
         e_a:float,
         z:float):
    P:float
    gamma:float
    Delta:float
    G:float
    ET0:float
    P = AtmosphericPressure(z)
    gamma = PsychrometricConstant(P)
    Delta = SlopeOfSaturationVapPressureCurve(T)
    G = float(0)
    ET0 = (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))))
    return ET0