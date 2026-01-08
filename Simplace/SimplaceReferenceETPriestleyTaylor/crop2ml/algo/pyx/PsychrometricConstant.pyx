#b'**\n\t * Calculates the psychrometric constant gamma as function of atmospheric pressure P\n\t * Eq. (8)\n\t *\n\t * The factor is calculated from parameters for average atmospheric conditions and is\n\t * rounded to 3 decimals to be consistent with the reference.\n\t *\n\t * @param P atmospheric pressure [kPa]\n\t * @return psychrometric constant gamma [kPa \xc2\xb0C-1]\n\t */'

def PsychrometricConstant(float P):
    cdef float lambdav 
    cdef float c_p 
    cdef float epsilon 
    cdef float factor 
    lambdav=2.45
    #b'/ specific heat at constant pressure (for average atmospheric conditions) [MJ kg-1 \xc2\xb0C-1]'
    c_p=1.013E-3
    #b'/ ratio molecular weight of water vapour/dry air'
    epsilon=0.622
    factor=round(c_p / (epsilon * lambdav) * 10E6) / 10E6
    return factor * P