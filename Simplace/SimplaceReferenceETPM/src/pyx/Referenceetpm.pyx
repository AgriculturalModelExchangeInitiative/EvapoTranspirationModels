import numpy
from math import *

def model_referenceetpm(float cAltitude,
                        float iTMax,
                        float iTMin,
                        float iActualVapourPressure,
                        float iNetRadiation,
                        float iWindspeed):
    """
    ReferenceETPM model
    Author: Gunther Krauss
    Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    Institution: INRES Pflanzenbau, Uni Bonn
    ExtendedDescription: as given in the documentation
    ShortDescription: None
    """

    cdef float ReferenceCropEvapotranspiration
    cdef float T 
    cdef float e_s 
    T=(iTMax + iTMin) / 2
    e_s=MeanSaturatedVapourPressure(iTMax, iTMin)
    if iActualVapourPressure > e_s:
        #b'/checkCondition(true, "Actual vapour pressure e_a:"+e_a+" is bigger than mean saturated vapour pressure e_s:"+e_s+". Setting e_a to e_s.");'
        iActualVapourPressure=e_s
    ReferenceCropEvapotranspiration=ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude)
    return  ReferenceCropEvapotranspiration



def SaturationVapourPressureAtTemperature(float T):
    return 0.6108 * exp(17.27 * T / (T + 237.3))
#b'**\n\t * Mean vapour pressure of a period\n\t * Eq. (12)\n\t *\n\t * @param T_max maximum air temperature during period [\xc2\xb0C]\n\t * @param T_min minimum air temperature during period [\xc2\xb0C]\n\t * @return mean vapour pressure e_s [kPa]\n\t */'


def MeanSaturatedVapourPressure(float T_max,
         float T_min):
    return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2

def SlopeOfSaturationVapPressureCurve(float T):
    cdef float tempT 
    tempT=T + 237.3
    return 4098 * (0.6108 * exp(17.27 * T / tempT)) / pow(tempT, 2)


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
#b'**\n\t\t * Calculates the atmospheric Pressure P\n\t\t * Eq. (7)\n\t\t *\n\t\t * @param z elevation above sea level [m]\n\t\t * @return atmospheric pressure P [kPa]\n\t\t */'


def AtmosphericPressure(float z):
    return 101.3 * pow((293 - (0.0065 * z)) / 293, 5.26)
#b'**\n\t * Calculates the daily crop evapotranspiration with the FAO-Penman-Montheith method\n\t * Eq. (6)\n\t *\n\t * FAO Penman-Monteith equation determines the evapotranspiration from the hypothetical\n\t * grass reference surface and provides a standard to which evapotranspiration in\n\t * different periods of the year or in other regions can be compared and to which the\n\t * evapotranspiration from other crops can be related. [FAO 56, p.65f]\n\t *\n\t * @param T air temperature at 2 m height [\xc2\xb0C]\n\t * @param R_n net radiation at the crop surface [MJ m-2 day-1]\n\t * @param u_2 wind speed at 2m height [m s-1]\n\t * @param e_s saturation vapour pressure [kPa]\n\t * @param e_a actual vapour pressure [kPa]\n\t * @param z elevation above sea level [m]\n\t * @return crop reference evapotranspiration ET0 [mm day-1]\n\t */'


def ReferenceEvapotranspiration(float T,
         float R_n,
         float u_2,
         float e_s,
         float e_a,
         float z):
    cdef float P 
    cdef float gamma 
    cdef float Delta 
    cdef float G 
    cdef float ET0 
    P=AtmosphericPressure(z)
    gamma=PsychrometricConstant(P)
    Delta=SlopeOfSaturationVapPressureCurve(T)
    #b'/ soil heat flux density [MJ m-2 day-1] can be neglected for daily calculations'
    G=float(0)
    ET0=(0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))))
    return ET0

