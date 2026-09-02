import numpy
from math import *

def model_canopytemperature(float specificHeatCapacityAir,
                            float maxTair,
                            float cropHeatFlux,
                            float lambdaV,
                            float minTair,
                            float rhoDensityAir,
                            float conductance):
    """
    CanopyTemperature Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: It is calculated from the crop heat flux and the boundary layer conductance
    ShortDescription: It is calculated from the crop heat flux and the boundary layer conductance
    """

    cdef float maxCanopyTemperature
    cdef float minCanopyTemperature
    if minTair == float(999) and maxTair == float(-999):
        minCanopyTemperature=float(999)
        maxCanopyTemperature=float(-999)
    else:
        minCanopyTemperature=minTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))
        maxCanopyTemperature=maxTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))
    return  maxCanopyTemperature, minCanopyTemperature



