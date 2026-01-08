#b'**\n\t * Converts radiation [energy/surface] to equivalent evaporation [depth of water]\n\t * Eq. (20)\n\t *\n\t * @param Radiation [MJ m-2 day-1]\n\t * @return equivalent evaporation [mm day-1]\n\t */'

def EvaporationEquivalentToRadiation2(float Radiation):
    return 0.408 * Radiation