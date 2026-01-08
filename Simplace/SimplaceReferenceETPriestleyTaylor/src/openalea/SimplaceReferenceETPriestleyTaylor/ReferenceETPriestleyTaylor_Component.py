# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SimplaceReferenceETPriestleyTaylor.referenceetpriestleytaylor import model_referenceetpriestleytaylor

#%%CyML Model Begin%%
def model_referenceetpriestleytaylor_(iTMin:float,
         cAlphaPT:float,
         iNetRadiation:float,
         iTMax:float,
         cAltitude:float):
    """
     - Name: ReferenceETPriestleyTaylor_ -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETPriestleyTaylor_ model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: iTMin
                               ** description : minimum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
                 * name: cAlphaPT
                               ** description : Priestley-Taylor coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 1.26
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
                 * name: iNetRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
                 * name: iTMax
                               ** description : maximum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
                 * name: cAltitude
                               ** description : altitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
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
    ReferenceCropEvapotranspiration = model_referenceetpriestleytaylor(cAltitude, cAlphaPT, iTMax, iTMin, iNetRadiation)
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%