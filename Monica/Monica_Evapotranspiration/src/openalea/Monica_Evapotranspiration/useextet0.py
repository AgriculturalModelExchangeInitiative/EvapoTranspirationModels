# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_useextet0(use_external_et0:bool,
         external_et0:float,
         internal_et0:float):
    """
     - Name: UseExtET0 -Version: 1, -Time step: 1
     - Description:
                 * Title: If Else unit 
                 * Authors: Michael Berg-Mohnicke
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: switches between two input values 
     - inputs:
                 * name: use_external_et0
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : 
                 * name: external_et0
                               ** description : value to be returned if condition is true
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: internal_et0
                               ** description : value to be returned if condition is false
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
     - outputs:
                 * name: et0
                               ** description : the output value
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
    """

    et0:float
    if use_external_et0:
        et0 = external_et0
    else:
        et0 = internal_et0
    return et0
#%%CyML Model End%%