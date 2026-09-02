import numpy
from math import *

def model_penman(float VPDair,
                 float specificHeatCapacityAir,
                 float psychrometricConstant,
                 float rhoDensityAir,
                 float Alpha,
                 float evapoTranspirationPriestlyTaylor,
                 float lambdaV,
                 float hslope,
                 float conductance):
    """
    Penman Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
    ShortDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
    """

    cdef float evapoTranspirationPenman
    evapoTranspirationPenman=evapoTranspirationPriestlyTaylor / Alpha + (1000.00 * (rhoDensityAir * specificHeatCapacityAir * VPDair * conductance / (lambdaV * (hslope + psychrometricConstant))))
    return  evapoTranspirationPenman



