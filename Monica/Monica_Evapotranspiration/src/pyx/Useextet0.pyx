import numpy
from math import *

def model_useextet0(float use_external_et0,
                    float external_et0,
                    float internal_et0):
    """
    If Else unit 
    Author: Michael Berg-Mohnicke
    Reference: None
    Institution: ZALF e.V.
    ExtendedDescription: None
    ShortDescription: switches between two input values 
    """

    cdef float et0
    if use_external_et0:
        et0 = external_et0
    else:
        et0 = internal_et0
    return  et0



