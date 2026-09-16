from datetime import datetime
from math import *
from SiriusQuality_Penman.priestlytaylor import model_priestlytaylor
from SiriusQuality_Penman.penman import model_penman
def model_potentialet_penman(float netRadiation,
      float lambdaV,
      float psychrometricConstant,
      float Alpha,
      float solarRadiation,
      float hslope,
      int ih,
      float VPDair,
      float specificHeatCapacityAir,
      float rhoDensityAir,
      float conductance):
    cdef float evapoTranspirationPriestlyTaylor
    cdef float evapoTranspirationPenman
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(lambdaV,netRadiation,psychrometricConstant,Alpha,solarRadiation,hslope,ih)
    evapoTranspirationPenman = model_penman(VPDair,specificHeatCapacityAir,psychrometricConstant,rhoDensityAir,Alpha,evapoTranspirationPriestlyTaylor,lambdaV,hslope,conductance)

    return (evapoTranspirationPenman)