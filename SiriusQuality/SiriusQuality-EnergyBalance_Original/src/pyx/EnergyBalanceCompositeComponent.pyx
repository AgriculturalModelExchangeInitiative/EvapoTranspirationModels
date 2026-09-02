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
def model_energybalancecomposite(float albedoCoefficient,
      float maxTair,
      float minTair,
      float vaporPressure,
      int ih,
      float extraSolarRadiation,
      float solarRadiation,
      float tau,
      float elevation,
      float stefanBoltzman,
      float albedoCoefficientCan,
      float d,
      float heightWeatherMeasurements,
      float plantHeight,
      float zh,
      float zm,
      float vonKarman,
      float wind,
      float soilDiffusionConstant,
      float deficitOnTopLayers,
      float lambdaV,
      float psychrometricConstant,
      float Alpha,
      float hslope,
      float tauAlpha,
      float VPDair,
      float specificHeatCapacityAir,
      float rhoDensityAir,
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
    cdef float maxCanopyTemperature
    cdef float minCanopyTemperature
    netRadiation, netOutGoingLongWaveRadiation = model_netradiation(albedoCoefficient,maxTair,minTair,vaporPressure,ih,extraSolarRadiation,solarRadiation,tau,elevation,stefanBoltzman,albedoCoefficientCan)
    conductance = model_conductance(d,heightWeatherMeasurements,plantHeight,zh,zm,vonKarman,ih,wind)
    diffusionLimitedEvaporation = model_diffusionlimitedevaporation(ih,soilDiffusionConstant,deficitOnTopLayers)
    netRadiationEquivalentEvaporation = model_netradiationequivalentevaporation(lambdaV,netRadiation)
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(netRadiationEquivalentEvaporation,psychrometricConstant,Alpha,solarRadiation,hslope,ih)
    energyLimitedEvaporation = model_ptsoil(tauAlpha,Alpha,evapoTranspirationPriestlyTaylor,tau,ih)
    evapoTranspirationPenman = model_penman(VPDair,specificHeatCapacityAir,psychrometricConstant,rhoDensityAir,Alpha,evapoTranspirationPriestlyTaylor,lambdaV,hslope,conductance)
    soilEvaporation = model_soilevaporation(ih,energyLimitedEvaporation,diffusionLimitedEvaporation)
    evapoTranspiration = model_evapotranspiration(evapoTranspirationPenman,isWindVpDefined,evapoTranspirationPriestlyTaylor)
    soilHeatFlux = model_soilheatflux(ih,soilEvaporation,solarRadiation,tau,netRadiationEquivalentEvaporation)
    potentialTranspiration = model_potentialtranspiration(evapoTranspiration,tau)
    cropHeatFlux = model_cropheatflux(netRadiationEquivalentEvaporation,soilHeatFlux,potentialTranspiration,ih)
    maxCanopyTemperature, minCanopyTemperature = model_canopytemperature(specificHeatCapacityAir,maxTair,cropHeatFlux,lambdaV,minTair,rhoDensityAir,conductance)

    return (maxCanopyTemperature, netOutGoingLongWaveRadiation, diffusionLimitedEvaporation, minCanopyTemperature, conductance)