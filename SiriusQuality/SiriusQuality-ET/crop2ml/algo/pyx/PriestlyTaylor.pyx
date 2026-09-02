cdef float a_G_Rn 
a_G_Rn=1.00
if ih != -999:
    if solarRadiation < 0.001:
        a_G_Rn=0.50
    else:
        a_G_Rn=0.90
evapoTranspirationPriestlyTaylor=max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00)