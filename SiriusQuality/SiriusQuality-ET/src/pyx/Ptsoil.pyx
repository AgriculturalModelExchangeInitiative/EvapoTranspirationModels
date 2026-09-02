import numpy
from math import *

def model_ptsoil(float tauAlpha,
                 float Alpha,
                 float evapoTranspirationPriestlyTaylor,
                 float tau,
                 int ih):
    """
    PtSoil EnergyLimitedEvaporation Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: Evaporation from the soil in the energy-limited stage
    ShortDescription: Evaporation from the soil in the energy-limited stage
    """

    cdef float energyLimitedEvaporation
    cdef float AlphaE 
    if ih == -999:
        if tau < tauAlpha:
            AlphaE=1.00
        else:
            AlphaE=Alpha - ((Alpha - 1.00) * (1.00 - tau) / (1.00 - tauAlpha))
        energyLimitedEvaporation=evapoTranspirationPriestlyTaylor / Alpha * AlphaE * tau
    else:
        energyLimitedEvaporation=0.00
    return  energyLimitedEvaporation



