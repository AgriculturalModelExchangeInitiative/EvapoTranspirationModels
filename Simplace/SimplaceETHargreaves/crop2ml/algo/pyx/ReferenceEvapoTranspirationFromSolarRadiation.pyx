#b'**\n\t * Estimates the reference evapotranspiration by solar radiation and temperature\n\t * Eq. (52) & Eq. (50) with k_Rs=0.17\n\t * see: Hargreaves, Allen, 2003, History and Evaluation of Hargreaves Evapotranspiration Equation: Eq. (3)\n\t *\n\t * @param R_s solar radiation (evaporation equivalent) [mm day-1]\n\t * @param T_max maximum of day temperature [\xc2\xb0C]\n\t * @param T_min minimum of day temperature [\xc2\xb0C]\n\t * @return ET0 crop reference evapotranspiration ET0 [mm day-1]\n\t */'

def ReferenceEvapoTranspirationFromSolarRadiation(float R_s,
         float T_max,
         float T_min):
    cdef float T_mean 
    T_mean=(T_max + T_min) / 2
    return 0.0135 * (T_mean + 17.8) * R_s