import numpy
from math import *

def model_potentialtranspiration(float evapoTranspiration,
                                 float tau):
    """
    PotentialTranspiration Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: SiriusQuality2 uses availability of water from the soil reservoir as a method to restrict
transpiration as soil moisture is depleted
    ShortDescription: It uses the availability of water from the soil reservoir as a method to restrict
transpiration as soil moisture is depleted
    """

    cdef float potentialTranspiration
    potentialTranspiration=evapoTranspiration * (1.00 - tau)
    return  potentialTranspiration



