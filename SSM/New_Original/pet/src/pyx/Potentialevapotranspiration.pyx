import numpy
from math import *

def model_potentialevapotranspiration(float tmax,
                                      float tmin,
                                      float srad,
                                      float albedo):
    """
    PotentialEvapotranspiration
    Author: -
    Reference: -
    Institution: -
    ExtendedDescription: Python implementation of a simplified Penman-style PET model (from Sultani & Sinclair 2012) computing equilibrium evaporation EEQ = SRAD*(0.004876-0.004374*ALBEDO)*(TD+29) with TD = 0.6*TMAX+0.4*TMIN, PET adjusted by Tmax-dependent multipliers (including low-temperature and high-advection corrections) and intended to be combined with an exponential Beer–Bouguer–Lambert factor for fraction of uncovered soil.
    ShortDescription: Simplified Penman-based PET calculator using EEQ, Tmax adjustments, and optional Beer–Lambert uncovered-soil albedo weighting.
    """

    cdef float pet
    cdef float td
    cdef float eeq
    #cdef float pet
    td = 0.6 * tmax + 0.4 * tmin
    eeq = srad * (0.004876 - 0.004374 * albedo) * (td + 29.0)
    if (tmax > 5.0) and (tmax < 34.0):
        pet = eeq * 1.1
    elif tmax >= 34.0:
        pet = eeq * ((tmax - 34.0) * 0.05 + 1.1)
    else:
        pet = eeq * 0.01 * exp(0.18 * (tmax + 20.0))
    return  pet



