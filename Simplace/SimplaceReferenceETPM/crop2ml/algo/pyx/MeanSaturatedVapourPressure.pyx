#b'**\n\t * Saturation vapour pressure at air temperature T\n\t * Eq. (11)\n\t *\n\t * @param T air temperature [\xc2\xb0C]\n\t * @return vapour pressure e_0_T [kPa]\n\t */'

def SaturationVapourPressureAtTemperature(float T):
    return 0.6108 * exp(17.27 * T / (T + 237.3))
#b'**\n\t * Mean vapour pressure of a period\n\t * Eq. (12)\n\t *\n\t * @param T_max maximum air temperature during period [\xc2\xb0C]\n\t * @param T_min minimum air temperature during period [\xc2\xb0C]\n\t * @return mean vapour pressure e_s [kPa]\n\t */'

def MeanSaturatedVapourPressure(float T_max,
         float T_min):
    return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2