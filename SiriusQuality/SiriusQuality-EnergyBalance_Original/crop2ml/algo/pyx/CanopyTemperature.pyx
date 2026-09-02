if minTair == float(999) and maxTair == float(-999):
    minCanopyTemperature=float(999)
    maxCanopyTemperature=float(-999)
else:
    minCanopyTemperature=minTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))
    maxCanopyTemperature=maxTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00))