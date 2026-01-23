import numpy
from math import *

def model_useextvaporpressure(bool use_external_vapor_pressure,
                              float external_vapor_pressure,
                              float internal_vapor_pressure):
    """
    If Else unit 
    Author: Michael Berg-Mohnicke
    Reference: None
    Institution: ZALF e.V.
    ExtendedDescription: None
    ShortDescription: switches between two input values 
    """

    cdef float vapor_pressure
    if use_external_vapor_pressure:
        vapor_pressure = external_vapor_pressure
    else:
        vapor_pressure = internal_vapor_pressure
    return  vapor_pressure



