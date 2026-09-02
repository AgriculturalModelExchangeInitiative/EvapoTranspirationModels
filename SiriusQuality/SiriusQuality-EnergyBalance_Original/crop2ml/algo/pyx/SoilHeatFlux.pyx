if ih == -999:
    soilHeatFlux=tau * netRadiationEquivalentEvaporation - soilEvaporation
else:
    if solarRadiation < 0.001:
        soilHeatFlux=netRadiationEquivalentEvaporation * 0.50
    else:
        soilHeatFlux=netRadiationEquivalentEvaporation * 0.10