if ih == -999:
    soilEvaporation=min(diffusionLimitedEvaporation, energyLimitedEvaporation)
else:
    soilEvaporation=0.0