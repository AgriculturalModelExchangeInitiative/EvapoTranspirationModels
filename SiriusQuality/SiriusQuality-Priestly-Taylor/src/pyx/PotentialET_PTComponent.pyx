from datetime import datetime
from math import *
from SiriusQuality_Priestly_Taylor.priestlytaylor import model_priestlytaylor
def model_potentialet_pt(float lambdaV,
      float psychrometricConstant,
      float Alpha,
      float solarRadiation,
      float hslope,
      int ih,
      float netRadiation):
    cdef float evapoTranspirationPriestlyTaylor
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(lambdaV,netRadiation,psychrometricConstant,Alpha,solarRadiation,hslope,ih)

    return (evapoTranspirationPriestlyTaylor)