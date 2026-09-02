import numpy
from math import *

def model_cropheatflux(float netRadiationEquivalentEvaporation,
                       float soilHeatFlux,
                       float potentialTranspiration,
                       int ih):
    """
    CropHeatFlux Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: It is calculated from net Radiation, soil heat flux and potential transpiration
    ShortDescription: It calculates the crop heat flux

    """

    cdef float cropHeatFlux
    cdef float cHfliminf 
    cdef float cHflimsup 
    cHfliminf=-100.00
    if ih == -999:
        cHfliminf=-10E6
    cHflimsup=100.00
    if ih == -999:
        cHflimsup=10E6
    cropHeatFlux=netRadiationEquivalentEvaporation - soilHeatFlux - potentialTranspiration
    cropHeatFlux=min(cHflimsup, max(cHfliminf, cropHeatFlux))
    return  cropHeatFlux



