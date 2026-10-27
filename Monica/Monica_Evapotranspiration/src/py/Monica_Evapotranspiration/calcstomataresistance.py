# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_calcstomataresistance(calc_stomata_resistance:bool,
         calculated_stomata_resistance:float,
         fixed_stomata_resistance:float):
    """
     - Name: CalcStomataResistance -Version: 1, -Time step: 1
     - Description:
                 * Title: If Else unit 
                 * Authors: Michael Berg-Mohnicke
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: switches between two input values 
     - inputs:
                 * name: calc_stomata_resistance
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : 
                 * name: calculated_stomata_resistance
                               ** description : value to be returned if condition is true
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
                 * name: fixed_stomata_resistance
                               ** description : value to be returned if condition is false
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
     - outputs:
                 * name: stomata_resistance
                               ** description : the output value
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** unit : s/m
    """

    stomata_resistance:float
    if calc_stomata_resistance:
        stomata_resistance = calculated_stomata_resistance
    else:
        stomata_resistance = fixed_stomata_resistance
    return stomata_resistance
#%%CyML Model End%%