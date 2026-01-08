# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SimplaceETHargreaves.referenceethargreaves import model_referenceethargreaves

#%%CyML Model Begin%%
def model_referenceethargreaves_(iTMax:float,
         iSolarRadiation:float,
         iTMin:float,
         cConvertLeByTemp:bool):
    """
     - Name: ReferenceETHargreaves_ -Version: 001, -Time step: 1
     - Description:
                 * Title: ReferenceETHargreaves_ model
                 * Authors: Gunther Krauss
                 * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
                 * Institution: INRES Pflanzenbau, Uni Bonn
                 * ExtendedDescription: as given in the documentation
                 * ShortDescription: None
     - inputs:
                 * name: iTMax
                               ** description : maximum daily temperature
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
                 * name: iTMin
                               ** description : minimum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
                 * name: cConvertLeByTemp
                               ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** default : false
                               ** unit : 
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
    ReferenceCropEvapotranspiration = model_referenceethargreaves(cConvertLeByTemp, iTMax, iTMin, iSolarRadiation)
    return ReferenceCropEvapotranspiration
#%%CyML Model End%%