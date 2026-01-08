#b'**\n\t * Calculates the atmospheric Pressure P\n\t * Eq. (7)\n\t *\n\t * @param z elevation above sea level [m]\n\t * @return atmospheric pressure P [kPa]\n\t */'

def AtmosphericPressure(float z):
    return 101.3 * pow((293 - (0.0065 * z)) / 293, 5.26)