import numpy
from math import *

def model_calcstomataresistance(bool calc_stomata_resistance,
                                float calculated_stomata_resistance,
                                float fixed_stomata_resistance):
    """
    If Else unit 
    Author: Michael Berg-Mohnicke
    Reference: None
    Institution: ZALF e.V.
    ExtendedDescription: None
    ShortDescription: switches between two input values 
    """

    cdef float stomata_resistance
    if calc_stomata_resistance:
        stomata_resistance = calculated_stomata_resistance
    else:
        stomata_resistance = fixed_stomata_resistance
    return  stomata_resistance



