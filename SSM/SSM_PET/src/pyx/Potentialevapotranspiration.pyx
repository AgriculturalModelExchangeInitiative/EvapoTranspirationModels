import numpy
from math import *

def model_potentialevapotranspiration(float tmax,
                                      float tmin,
                                      float srad,
                                      float etlai,
                                      float ket,
                                      float calb,
                                      float salb):
    """
    PotentialEvapoTranspiration
    Author: -
    Reference: -
    Institution: -
    ExtendedDescription: Computes daily potential evapotranspiration (PET, mm d-1) following Soltani and Sinclair (2012) using an equilibrium evaporation (EEQ) term adjusted by temperature-dependent multipliers. Average daytime temperature is TD = 0.6·Tmax + 0.4·Tmin. The surface albedo blends crop and soil albedos weighted by the fraction of surface energy reaching soil, exp(-KET·ETLAI): ALBEDO = CALB·(1 - exp(-KET·ETLAI)) + SALB·exp(-KET·ETLAI). EEQ is then EEQ = SRAD·(0.004876 - 0.004374·ALBEDO)·(TD + 29). PET is derived from EEQ with three regimes: PET = 1.1·EEQ for 5 < Tmax < 34; PET = EEQ·((Tmax - 34)·0.05 + 1.1) for Tmax ≥ 34 (advection); PET = EEQ·0.01·exp(0.18·(Tmax + 20)) for Tmax ≤ 5 (cold/frozen conditions). The uncovered-soil fraction follows the Beer–Bouguer–Lambert law via ETLAI and KET. Methodology relates to Priestley–Taylor (1972) and the modifications summarized by Ritchie (1998) as presented in Soltani and Sinclair (2012).
    ShortDescription: PET component using EEQ with Beer–Lambert canopy attenuation and temperature-based modifiers per Soltani and Sinclair (2012).
    """

    cdef float pet
    # def potential_evapotranspiration(float tmax, float tmin, float srad, float etlai, float ket=0.5, float calb=0.23, float salb=0.13):
    cdef float td
    cdef float fraction_nrj_soil
    cdef float albedo
    cdef float eeq
    # cdef float pet
    td = 0.6 * tmax + 0.4 * tmin
    fraction_nrj_soil = exp(-(ket * etlai))
    albedo = calb * (1.0 - fraction_nrj_soil) + salb * fraction_nrj_soil
    eeq = srad * (0.004876 - 0.004374 * albedo) * (td + 29.0)
    if tmax > 5.0 and tmax < 34.0:
        pet = eeq * 1.1
    else:
        if tmax >= 34.0:
            pet = eeq * ((tmax - 34.0) * 0.05 + 1.1)
        else:
            pet = eeq * 0.01 * exp(0.18 * (tmax + 20.0))
    # return pet
    # Changes: removed math import, used exp directly; replaced chained comparison with explicit and for compatibility.
    # Manual changes (CP) : Comment
    # - def function
    # - pet from variable definition
    # - return pet 
    return  pet



