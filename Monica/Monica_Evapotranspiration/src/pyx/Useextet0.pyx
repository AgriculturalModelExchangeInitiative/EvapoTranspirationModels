import numpy
from math import *

def model_useextet0(bool use_external_et0,
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
    # This Source Code Form is subject to the terms of the Mozilla Public
    # License, v. 2.0. If a copy of the MPL was not distributed with this
    # file, You can obtain one at https://mozilla.org/MPL/2.0/.
    if use_external_et0:
        et0 = external_et0
    else:
        et0 = internal_et0
    return  et0



