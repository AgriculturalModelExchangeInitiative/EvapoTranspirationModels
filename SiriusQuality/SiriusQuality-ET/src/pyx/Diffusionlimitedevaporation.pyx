import numpy
from math import *

def model_diffusionlimitedevaporation(int ih,
                                      float soilDiffusionConstant,
                                      float deficitOnTopLayers):
    """
    DiffusionLimitedEvaporation Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: the evaporation from the diffusion limited soil
    ShortDescription: It calculates the diffusion limited evaropration

    """

    cdef float diffusionLimitedEvaporation
    if ih == -999:
        if deficitOnTopLayers / 1000.00 <= 0.00:
            diffusionLimitedEvaporation=8.30 * 1000.00
        else:
            if deficitOnTopLayers / 1000.00 < 25.00:
                diffusionLimitedEvaporation=2.00 * soilDiffusionConstant * soilDiffusionConstant / (deficitOnTopLayers / 1000.00) * 1000.00
            else:
                diffusionLimitedEvaporation=0.00
    else:
        diffusionLimitedEvaporation=0.00
    return  diffusionLimitedEvaporation



