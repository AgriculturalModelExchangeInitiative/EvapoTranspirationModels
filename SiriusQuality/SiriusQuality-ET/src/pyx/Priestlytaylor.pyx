import numpy
from math import *

def model_priestlytaylor(float netRadiationEquivalentEvaporation,
                         float psychrometricConstant,
                         float Alpha,
                         float solarRadiation,
                         float hslope,
                         int ih):
    """
    evapoTranspirationPriestlyTaylor  Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: Calculate Energy Balance
    ShortDescription: It uses Priestly-Taylor method
    """

    cdef float evapoTranspirationPriestlyTaylor
    cdef float a_G_Rn 
    a_G_Rn=1.00
    if ih != -999:
        if solarRadiation < 0.001:
            a_G_Rn=0.50
        else:
            a_G_Rn=0.90
    evapoTranspirationPriestlyTaylor=max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00)
    return  evapoTranspirationPriestlyTaylor



