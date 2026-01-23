def potential_evapotranspiration(
    tmax: float,
    tmin: float,
    srad: float,
    etlai: float,
    ket: float = 0.5,
    calb: float = 0.23,
    salb: float = 0.13,
) -> float:
    """
    Calculate Potential Evapotranspiration (PET) using a simplified Penman-based method adjusted
    for canopy effects via an exponential Beer–Bouguer–Lambert approach.

    Inputs:
    - tmax: float, daily maximum temperature (°C)
    - tmin: float, daily minimum temperature (°C)
    - srad: float, daily solar radiation (MJ m-2 day-1)
    - etlai: float, leaf area index effective in evapotranspiration (m2 m-2)
    - ket: float, extinction coefficient for canopy (default 0.5)
    - calb: float, crop albedo (default 0.23)
    - salb: float, soil albedo (default 0.13)

    Returns:
    - pet: float, potential evapotranspiration (mm day-1)

    Method:
    - TD = 0.6*TMAX + 0.4*TMIN
    - Fraction of energy reaching soil = exp(-KET * ETLAI)
    - Surface albedo = CALB * (1 - frac_soil) + SALB * frac_soil
    - EEQ = SRAD * (0.004876 - 0.004374 * ALBEDO) * (TD + 29)
    - PET:
        if 5 < TMAX < 34: PET = EEQ * 1.1
        elif TMAX >= 34:  PET = EEQ * ((TMAX - 34) * 0.05 + 1.1)
        else:             PET = EEQ * 0.01 * exp(0.18 * (TMAX + 20))
    """
    from math import exp

    td = 0.6 * tmax + 0.4 * tmin

    fraction_nrj_soil = exp(-ket * etlai)
    albedo = calb * (1 - fraction_nrj_soil) + salb * fraction_nrj_soil

    eeq = srad * (0.004876 - 0.004374 * albedo) * (td + 29)

    if 5 < tmax < 34:
        pet = eeq * 1.1
    elif tmax >= 34:
        pet = eeq * ((tmax - 34) * 0.05 + 1.1)
    else:
        pet = eeq * 0.01 * exp(0.18 * (tmax + 20))

    return pet