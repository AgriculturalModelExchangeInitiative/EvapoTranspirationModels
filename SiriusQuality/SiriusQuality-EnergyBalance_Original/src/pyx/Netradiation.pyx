import numpy
from math import *

def model_netradiation(float albedoCoefficient,
                       float maxTair,
                       float minTair,
                       float vaporPressure,
                       int ih,
                       float extraSolarRadiation,
                       float solarRadiation,
                       float tau,
                       float elevation,
                       float stefanBoltzman,
                       float albedoCoefficientCan):
    """
    NetRadiation Model
    Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    Institution: New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.,
New Zealand Institute for Crop and Food Research Ltd.

    ExtendedDescription: It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both short
and long wavelength radiation
    ShortDescription: It refers as difference between incoming and outgoing radiation of both short
and long wavelength radiation
    """

    cdef float netRadiation
    cdef float netOutGoingLongWaveRadiation
    cdef float Nsr 
    cdef float clearSkySolarRadiation 
    cdef float averageT 
    cdef float surfaceEmissivity 
    cdef float cloudCoverFactor 
    cdef float Nolr 
    cdef float cov 
    if ih == -999:
        Nsr=solarRadiation * (1 - (albedoCoefficientCan * tau + (albedoCoefficient * (1.00 - tau))))
    else:
        cov=float(1)
        if solarRadiation > 0.01:
            if ih <= 7:
                cov=0.30
            elif ih > 7 and ih < 11:
                cov=0.30 - (0.09 / 3.00 * (ih - 7.00))
            elif ih == 11:
                cov=0.21
            elif ih > 11 and ih < 15:
                cov=0.21 + (0.09 / 3.00 * (ih - 11.00))
            else:
                cov=0.30
        Nsr=(1 - cov) * solarRadiation
    clearSkySolarRadiation=(0.750 + (2 * pow(10.00, -5) * elevation)) * extraSolarRadiation
    averageT=(pow(maxTair + 273.160, 4) + pow(minTair + 273.160, 4)) / 2.00
    surfaceEmissivity=0.340 - (0.140 * sqrt(vaporPressure / 10.00))
    cloudCoverFactor=1.350 * (solarRadiation / clearSkySolarRadiation) - 0.350
    Nolr=stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor
    if ih != -999:
        Nolr/=24.00
    netRadiation=Nsr - Nolr
    netOutGoingLongWaveRadiation=Nolr
    return  netRadiation, netOutGoingLongWaveRadiation



