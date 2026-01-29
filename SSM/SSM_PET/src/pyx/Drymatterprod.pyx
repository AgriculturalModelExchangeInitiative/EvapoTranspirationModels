import numpy
from math import *

def model_drymatterprod(float tmax,
                        float tmin,
                        float srad,
                        float lai,
                        float kpar,
                        float RUE,
                        float TBRUE,
                        float TP1RUE,
                        float TP2RUE,
                        float TCRUE):
    """
    DryMatterProd
    Author: -
    Reference: -
    Institution: -
    ExtendedDescription: Python implementation of an SSM Potential Dry Matter Production model that computes daily dry matter (g m-2 day-1) from daily solar radiation, LAI, and a temperature-adjusted Radiation Use Efficiency (RUE); uses Beer-Lambert extinction (fint = 1 - exp(-kpar * LAI)) to estimate intercepted PAR (assumes PAR = 0.48 * srad) and a piecewise linear temperature response for RUE with defaults for wheat (kpar=0.65, RUE=2.2 g MJ-1, TBRUE=0, TP1RUE=15, TP2RUE=22, TCRUE=35).
    ShortDescription: Daily dry matter production from intercepted PAR and temperature-modified RUE (Python).
    """

    cdef float DDMP
    cdef float tmp
    cdef float coeff_RUE
    cdef float actual_RUE
    cdef float fint
    #cdef float DDMP
    tmp = tmax + 0.4 * tmin
    if tmp <= TBRUE or tmp >= TCRUE:
        coeff_RUE = 0.0
    elif TBRUE < tmp and tmp < TP1RUE:
        coeff_RUE = (tmp - TBRUE) / (TP1RUE - TBRUE)
    elif TP2RUE <= tmp and tmp <= TCRUE:
        coeff_RUE = (TCRUE - tmp) / (TCRUE - TP2RUE)
    else:
        coeff_RUE = 1.0
    actual_RUE = RUE * coeff_RUE
    fint = 1.0 - exp(-kpar * lai)
    DDMP = srad * 0.48 * fint * actual_RUE
    return  DDMP



