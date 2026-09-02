import numpy
from math import *

def model_conductance(float d,
                      float heightWeatherMeasurements,
                      float plantHeight,
                      float zh,
                      float zm,
                      float vonKarman,
                      int ih,
                      float wind):
    """
    Conductance Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5

    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
canopy and the canopy structure. The approach does not take into account buoyancy
effects.

    ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
canopy and the canopy structure. The approach does not take into account buoyancy
effects.

    """

    cdef float conductance
    cdef float h 
    cdef float clim 
    clim=0.10
    if ih != -999:
        clim=36.00
    h=max(10.00, plantHeight) / 100.00
    conductance=wind * pow(vonKarman, 2) / (log((heightWeatherMeasurements - (d * h)) / (zm * h)) * log((heightWeatherMeasurements - (d * h)) / (zh * h)))
    conductance=max(clim, conductance)
    return  conductance



