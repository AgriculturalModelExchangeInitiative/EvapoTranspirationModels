from datetime import datetime
from math import *
from SiriusQuality_ET.netradiation import model_netradiation
from SiriusQuality_ET.conductance import model_conductance
from SiriusQuality_ET.netradiationequivalentevaporation import model_netradiationequivalentevaporation
from SiriusQuality_ET.priestlytaylor import model_priestlytaylor
from SiriusQuality_ET.penman import model_penman
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
      float lambdaV,
      float psychrometricConstant,
      float Alpha,
      float hslope,
      float VPDair,
      float specificHeatCapacityAir,
      float rhoDensityAir):
    cdef float netRadiation
    cdef float netOutGoingLongWaveRadiation
    cdef float conductance
    cdef float netRadiationEquivalentEvaporation
    cdef float evapoTranspirationPriestlyTaylor
    cdef float evapoTranspirationPenman
    netRadiation, netOutGoingLongWaveRadiation = model_netradiation(albedoCoefficient,maxTair,minTair,vaporPressure,ih,extraSolarRadiation,solarRadiation,tau,elevation,stefanBoltzman,albedoCoefficientCan)
    conductance = model_conductance(d,heightWeatherMeasurements,plantHeight,zh,zm,vonKarman,ih,wind)
    netRadiationEquivalentEvaporation = model_netradiationequivalentevaporation(lambdaV,netRadiation)
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(netRadiationEquivalentEvaporation,psychrometricConstant,Alpha,solarRadiation,hslope,ih)
    evapoTranspirationPenman = model_penman(VPDair,specificHeatCapacityAir,psychrometricConstant,rhoDensityAir,Alpha,evapoTranspirationPriestlyTaylor,lambdaV,hslope,conductance)

    return (netOutGoingLongWaveRadiation, conductance, netRadiation, evapoTranspirationPriestlyTaylor, evapoTranspirationPenman)