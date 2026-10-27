# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_useextvaporpressure(use_external_vapor_pressure:bool,
         external_vapor_pressure:float,
         internal_vapor_pressure:float):
    """
     - Name: UseExtVaporPressure -Version: 1, -Time step: 1
     - Description:
                 * Title: If Else unit 
                 * Authors: Michael Berg-Mohnicke
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: switches between two input values 
     - inputs:
                 * name: use_external_vapor_pressure
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : mm
                 * name: external_vapor_pressure
                               ** description : value to be returned if condition is true
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
                 * name: internal_vapor_pressure
                               ** description : value to be returned if condition is false
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
     - outputs:
                 * name: vapor_pressure
                               ** description : the output value
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
    """

    vapor_pressure:float
    if use_external_vapor_pressure:
        vapor_pressure = external_vapor_pressure
    else:
        vapor_pressure = internal_vapor_pressure
    return vapor_pressure
#%%CyML Model End%%