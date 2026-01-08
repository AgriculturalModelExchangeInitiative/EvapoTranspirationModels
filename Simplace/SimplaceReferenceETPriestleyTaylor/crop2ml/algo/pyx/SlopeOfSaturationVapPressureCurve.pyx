#b'**\n\t * Calculates the slope  of saturation vapour pressure curve Delta as function of temperature T\n\t * Eq (13)\n\t *\n\t * @param T air temperature [\xc2\xb0C]\n\t * @return slope of saturation vapour pressure Delta [kPa \xc2\xb0C-1]\n\t */'

def SlopeOfSaturationVapPressureCurve(float T):
    cdef float tempT 
    tempT=T + 237.3
    return 4098 * (0.6108 * exp(17.27 * T / tempT)) / pow(tempT, 2)