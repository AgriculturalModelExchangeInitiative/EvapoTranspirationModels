import numpy
from math import *

def model_netradiationequivalentevaporation(float lambdaV,
                                            float netRadiation):
    """
    NetRadiationEquivalentEvaporation Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: It is given by dividing net radiation by latent heat of vaporization of water
    ShortDescription: It is given by dividing net radiation by latent heat of vaporization of water
    """

    cdef float netRadiationEquivalentEvaporation
    netRadiationEquivalentEvaporation=netRadiation / lambdaV * 1000.00
    return  netRadiationEquivalentEvaporation



