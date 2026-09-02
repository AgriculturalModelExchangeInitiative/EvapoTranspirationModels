cdef float cHfliminf 
cdef float cHflimsup 
cHfliminf=-100.00
if ih == -999:
    cHfliminf=-10E6
cHflimsup=100.00
if ih == -999:
    cHflimsup=10E6
cropHeatFlux=netRadiationEquivalentEvaporation - soilHeatFlux - potentialTranspiration
cropHeatFlux=min(cHflimsup, max(cHfliminf, cropHeatFlux))