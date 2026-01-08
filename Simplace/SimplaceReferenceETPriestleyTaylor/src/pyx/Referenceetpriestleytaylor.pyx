import numpy
from math import *

def model_referenceetpriestleytaylor(float cAltitude,
                                     float cAlphaPT,
                                     float iTMax,
                                     float iTMin,
                                     float iNetRadiation):
    """
    ReferenceETPriestleyTaylor model
    Author: Gunther Krauss
    Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    Institution: INRES Pflanzenbau, Uni Bonn
    ExtendedDescription: as given in the documentation
    ShortDescription: None
    """

    cdef float ReferenceCropEvapotranspiration
    cdef float lambdav 
    cdef float T 
    cdef float Delta 
    cdef float AtmPres 
    cdef float Gamma 
    cdef float G 
    lambdav=2.45
    #b'/ Average temperature'
    T=(iTMax + iTMin) / 2.0
    #b'/slope of saturation vapour pressure curve [kPa \xc2\xb0C-1] Allen et al. (1998) Eq[13]'
    Delta=SlopeOfSaturationVapPressureCurve(T)
    #b'/ atmospheric pressure [kPa] Allen et al. (1998) Eq[7]'
    AtmPres=AtmosphericPressure(cAltitude)
    #b'/psychrometric constant [kPa \xc2\xb0C-1] Allen et al. (1998) Eq[8]'
    Gamma=PsychrometricConstant(AtmPres)
    #b'/ Soil heat flux (Allen et al, 1998) [W m-2] Eq[45] and Eq[46] \t'
    G=0.0
    ReferenceCropEvapotranspiration=max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav)
    return  ReferenceCropEvapotranspiration



def SlopeOfSaturationVapPressureCurve(float T):
    cdef float tempT 
    tempT=T + 237.3
    return 4098 * (0.6108 * exp(17.27 * T / tempT)) / pow(tempT, 2)

def AtmosphericPressure(float z):
    return 101.3 * pow((293 - (0.0065 * z)) / 293, 5.26)

def PsychrometricConstant(float P):
    cdef float lambdav 
    cdef float c_p 
    cdef float epsilon 
    cdef float factor 
    lambdav=2.45
    #b'/ specific heat at constant pressure (for average atmospheric conditions) [MJ kg-1 \xc2\xb0C-1]'
    c_p=1.013E-3
    #b'/ ratio molecular weight of water vapour/dry air'
    epsilon=0.622
    factor=round(c_p / (epsilon * lambdav) * 10E6) / 10E6
    return factor * P

