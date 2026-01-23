import numpy
from math import *

def model_potentialtranspiration(float tmax,
                                 float tmin,
                                 float ddmp,
                                 float TEC,
                                 float VPDF):
    """
    PotentialTranspiration
    Author: -
    Reference: -
    Institution: -
    ExtendedDescription: Calculates daily potential transpiration (mm/day) from daily maximum and minimum temperatures and daily dry matter production using vapor pressure deficit computed from saturation vapor pressures (Tetens formula) and scaled by a Vapor Pressure Deficit Factor (VPDF) and a Transpiration Efficiency Coefficient (TEC).
    ShortDescription: Compute daily potential transpiration from temperatures and dry matter via VPD, TEC and VPDF.
    """

    cdef float TR
    cdef float vptmin
    cdef float vptmax
    cdef float VPD
    #cdef float TR
    vptmin = 0.6108 * exp((17.27 * tmin) / (tmin + 237.3))
    vptmax = 0.6108 * exp((17.27 * tmax) / (tmax + 237.3))
    VPD = VPDF * (vptmax - vptmin)
    TR = ddmp * VPD / TEC
    return  TR



