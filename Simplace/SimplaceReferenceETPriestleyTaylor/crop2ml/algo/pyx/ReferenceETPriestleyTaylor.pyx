cdef float lambdav 
cdef float T 
cdef float Delta 
cdef float AtmPres 
cdef float Gamma 
cdef float G 
lambdav=2.45
#b'/ Average temperature'
T=(iTMax + iTMin) / 2.0
#b'/slope of saturation vapour pressure curve [kPa \xc2\xb0C-1] Allen et al. (1998) Eq[13]'
Delta=SlopeOfSaturationVapPressureCurve(T)
#b'/ atmospheric pressure [kPa] Allen et al. (1998) Eq[7]'
AtmPres=AtmosphericPressure(cAltitude)
#b'/psychrometric constant [kPa \xc2\xb0C-1] Allen et al. (1998) Eq[8]'
Gamma=PsychrometricConstant(AtmPres)
#b'/ Soil heat flux (Allen et al, 1998) [W m-2] Eq[45] and Eq[46] \t'
G=0.0
ReferenceCropEvapotranspiration=max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav)