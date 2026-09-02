if ih == -999:
    if deficitOnTopLayers / 1000.00 <= 0.00:
        diffusionLimitedEvaporation=8.30 * 1000.00
    else:
        if deficitOnTopLayers / 1000.00 < 25.00:
            diffusionLimitedEvaporation=2.00 * soilDiffusionConstant * soilDiffusionConstant / (deficitOnTopLayers / 1000.00) * 1000.00
        else:
            diffusionLimitedEvaporation=0.00
else:
    diffusionLimitedEvaporation=0.00