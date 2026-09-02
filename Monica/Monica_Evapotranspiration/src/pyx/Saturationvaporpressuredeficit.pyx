import numpy
from math import *

def model_saturationvaporpressuredeficit(float saturated_vapor_pressure,
                                         float vapor_pressure):
    """
    MONICA saturation vapor pressure deficit
    Author: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    Reference: 
        
    Institution: ZALF e.V.
    ExtendedDescription: 
        
    ShortDescription: Calculates saturation vapor pressure deficit as in the MONICA model
    """

    cdef float saturation_vapor_pressure_deficit
    # This Source Code Form is subject to the terms of the Mozilla Public
    # License, v. 2.0. If a copy of the MPL was not distributed with this
    # file, You can obtain one at https://mozilla.org/MPL/2.0/.
    # Calculation of the air saturation deficit [kPA]
    saturation_vapor_pressure_deficit = saturated_vapor_pressure - vapor_pressure
    return  saturation_vapor_pressure_deficit



