cdef float T 
cdef float e_s 
T=(iTMax + iTMin) / 2
e_s=MeanSaturatedVapourPressure(iTMax, iTMin)
if iActualVapourPressure > e_s:
    #b'/checkCondition(true, "Actual vapour pressure e_a:"+e_a+" is bigger than mean saturated vapour pressure e_s:"+e_s+". Setting e_a to e_s.");'
    iActualVapourPressure=e_s
ReferenceCropEvapotranspiration=ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude)