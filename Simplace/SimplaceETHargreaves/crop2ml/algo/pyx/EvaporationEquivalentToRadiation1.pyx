#b'**\n\t * Converts radiation [energy/surface] to equivalent evaporation [depth of water]\n\t * \n\t * Correction by daily mean temperature (for 21.18\xc2\xb0C it yields a conversion factor of 0.408)\n\t * See (Harrison)\n\t *\n\t * @param Radiation [MJ m-2 day-1]\n\t * @param DailyMeanTemperature [\xc2\xb0C]\n\t * @return equivalent evaporation [mm day-1]\n\t */'

def EvaporationEquivalentToRadiation1(float Radiation,
         float DailyMeanTemperature):
    return 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation