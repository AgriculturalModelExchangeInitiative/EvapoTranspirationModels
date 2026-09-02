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
    # This Source Code Form is subject to the terms of the Mozilla Public
    # License, v. 2.0. If a copy of the MPL was not distributed with this
    # file, You can obtain one at https://mozilla.org/MPL/2.0/.
    if calc_stomata_resistance:
        stomata_resistance = calculated_stomata_resistance
    else:
        stomata_resistance = fixed_stomata_resistance
    return  stomata_resistance



