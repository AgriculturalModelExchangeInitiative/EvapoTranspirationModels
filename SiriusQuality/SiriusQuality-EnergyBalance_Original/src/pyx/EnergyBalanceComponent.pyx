from datetime import datetime
from math import *
from SiriusQuality_EnergyBalance.netradiation import model_netradiation
from SiriusQuality_EnergyBalance.conductance import model_conductance
from SiriusQuality_EnergyBalance.diffusionlimitedevaporation import model_diffusionlimitedevaporation
from SiriusQuality_EnergyBalance.netradiationequivalentevaporation import model_netradiationequivalentevaporation
from SiriusQuality_EnergyBalance.priestlytaylor import model_priestlytaylor
from SiriusQuality_EnergyBalance.ptsoil import model_ptsoil
from SiriusQuality_EnergyBalance.penman import model_penman
from SiriusQuality_EnergyBalance.soilevaporation import model_soilevaporation
from SiriusQuality_EnergyBalance.evapotranspiration import model_evapotranspiration
from SiriusQuality_EnergyBalance.soilheatflux import model_soilheatflux
from SiriusQuality_EnergyBalance.potentialtranspiration import model_potentialtranspiration
from SiriusQuality_EnergyBalance.cropheatflux import model_cropheatflux
from SiriusQuality_EnergyBalance.canopytemperature import model_canopytemperature
def model_energybalance(float albedoCoefficientCan,
      float vaporPressure,
      float stefanBoltzman,
      float maxTair,
      float solarRadiation,
      int ih,
      float minTair,
      float extraSolarRadiation,
      float tau,
      float elevation,
      float albedoCoefficient,
      float wind,
      float heightWeatherMeasurements,
      float vonKarman,
      float plantHeight,
      float zh,
      float zm,
      float d,
      float soilDiffusionConstant,
      float deficitOnTopLayers,
      float lambdaV,
      float psychrometricConstant,
      float Alpha,
      float hslope,
      float tauAlpha,
      float specificHeatCapacityAir,
      float rhoDensityAir,
      float VPDair,
      int isWindVpDefined):
    cdef float netRadiation
    cdef float netOutGoingLongWaveRadiation
    cdef float conductance
    cdef float diffusionLimitedEvaporation
    cdef float netRadiationEquivalentEvaporation
    cdef float evapoTranspirationPriestlyTaylor
    cdef float energyLimitedEvaporation
    cdef float evapoTranspirationPenman
    cdef float soilEvaporation
    cdef float evapoTranspiration
    cdef float soilHeatFlux
    cdef float potentialTranspiration
    cdef float cropHeatFlux
    cdef float minCanopyTemperature
    cdef float maxCanopyTemperature
    netRadiation, netOutGoingLongWaveRadiation = model_netradiation(minTair,maxTair,ih,tau,albedoCoefficientCan,elevation,stefanBoltzman,vaporPressure,solarRadiation,extraSolarRadiation,albedoCoefficient)
    conductance = model_conductance(ih,vonKarman,heightWeatherMeasurements,wind,d,zm,zh,plantHeight)
    diffusionLimitedEvaporation = model_diffusionlimitedevaporation(ih,deficitOnTopLayers,soilDiffusionConstant)
    netRadiationEquivalentEvaporation = model_netradiationequivalentevaporation(netRadiation,lambdaV)
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(ih,psychrometricConstant,solarRadiation,hslope,Alpha,netRadiationEquivalentEvaporation)
    energyLimitedEvaporation = model_ptsoil(ih,tau,evapoTranspirationPriestlyTaylor,tauAlpha,Alpha)
    evapoTranspirationPenman = model_penman(rhoDensityAir,psychrometricConstant,hslope,evapoTranspirationPriestlyTaylor,VPDair,lambdaV,Alpha,specificHeatCapacityAir,conductance)
    soilEvaporation = model_soilevaporation(ih,energyLimitedEvaporation,diffusionLimitedEvaporation)
    evapoTranspiration = model_evapotranspiration(isWindVpDefined,evapoTranspirationPriestlyTaylor,evapoTranspirationPenman)
    soilHeatFlux = model_soilheatflux(ih,tau,soilEvaporation,solarRadiation,netRadiationEquivalentEvaporation)
    potentialTranspiration = model_potentialtranspiration(tau,evapoTranspiration)
    cropHeatFlux = model_cropheatflux(ih,soilHeatFlux,potentialTranspiration,netRadiationEquivalentEvaporation)
    minCanopyTemperature, maxCanopyTemperature = model_canopytemperature(minTair,cropHeatFlux,rhoDensityAir,maxTair,lambdaV,specificHeatCapacityAir,conductance)

    return (conductance, netOutGoingLongWaveRadiation, maxCanopyTemperature, minCanopyTemperature, diffusionLimitedEvaporation)