import numpy
from math import *

def model_referenceethargreaves(bool cConvertLeByTemp,
                                float iTMax,
                                float iTMin,
                                float iSolarRadiation):
    """
    ReferenceETHargreaves model
    Author: Gunther Krauss
    Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    Institution: INRES Pflanzenbau, Uni Bonn
    ExtendedDescription: as given in the documentation
    ShortDescription: None
    """

    cdef float ReferenceCropEvapotranspiration
    cdef float R_s_eveq 
    #b'*double R_s_eveq = (cConvertLeByTemp.getValue()) \n\t\t\t\t? EvaporationEquivalentToRadiation(iSolarRadiation.getValue(),\n\t\t\t\t\t\t0.5*(iTMax.getValue()+iTMin.getValue()))\n\t\t\t\t: EvaporationEquivalentToRadiation(iSolarRadiation.getValue());\t*/'
    if cConvertLeByTemp:
        R_s_eveq=EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 * (iTMax + iTMin))
    else:
        R_s_eveq=EvaporationEquivalentToRadiation2(iSolarRadiation)
    ReferenceCropEvapotranspiration=max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin))
    return  ReferenceCropEvapotranspiration



def EvaporationEquivalentToRadiation1(float Radiation,
         float DailyMeanTemperature):
    return 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation

def EvaporationEquivalentToRadiation2(float Radiation):
    return 0.408 * Radiation

def ReferenceEvapoTranspirationFromSolarRadiation(float R_s,
         float T_max,
         float T_min):
    cdef float T_mean 
    T_mean=(T_max + T_min) / 2
    return 0.0135 * (T_mean + 17.8) * R_s

