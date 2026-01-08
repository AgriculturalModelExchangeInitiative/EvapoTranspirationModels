cdef float R_s_eveq 
#b'*double R_s_eveq = (cConvertLeByTemp.getValue()) \n\t\t\t\t? EvaporationEquivalentToRadiation(iSolarRadiation.getValue(),\n\t\t\t\t\t\t0.5*(iTMax.getValue()+iTMin.getValue()))\n\t\t\t\t: EvaporationEquivalentToRadiation(iSolarRadiation.getValue());\t*/'
if cConvertLeByTemp:
    R_s_eveq=EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 * (iTMax + iTMin))
else:
    R_s_eveq=EvaporationEquivalentToRadiation2(iSolarRadiation)
ReferenceCropEvapotranspiration=max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin))