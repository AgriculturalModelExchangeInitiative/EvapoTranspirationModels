# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SimplaceReferenceETPM.referenceetpm import model_referenceetpm

#%%CyML Model Begin%%
def model_referenceetpm_(iNetRadiation:float,
         cAltitude:float,
         iActualVapourPressure:float,
         iTMax:float,
         iTMin:float,
         iWindspeed:float):
    """
     - Name: ReferenceETPM_ -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETPM_ model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: iNetRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
                 * name: cAltitude
                               ** description : elevation above sea level
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
                 * name: iActualVapourPressure
                               ** description : actual vapour pressure
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
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
    ReferenceCropEvapotranspiration = model_referenceetpm(cAltitude, iTMax, iTMin, iActualVapourPressure, iNetRadiation, iWindspeed)
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%