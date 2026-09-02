import numpy
from math import *

def model_soilheatflux(int ih,
                       float soilEvaporation,
                       float solarRadiation,
                       float tau,
                       float netRadiationEquivalentEvaporation):
    """
    SoilHeatFlux Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: The available energy in the soil
    ShortDescription: The available energy in the soil
    """

    cdef float soilHeatFlux
    if ih == -999:
        soilHeatFlux=tau * netRadiationEquivalentEvaporation - soilEvaporation
    else:
        if solarRadiation < 0.001:
            soilHeatFlux=netRadiationEquivalentEvaporation * 0.50
        else:
            soilHeatFlux=netRadiationEquivalentEvaporation * 0.10
    return  soilHeatFlux



