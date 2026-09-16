# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SiriusQuality_Priestly_Taylor.priestlytaylor import model_priestlytaylor

#%%CyML Model Begin%%
def model_potentialet_pt(lambdaV:float,
         psychrometricConstant:float,
         Alpha:float,
         solarRadiation:float,
         hslope:float,
         ih:int,
         netRadiation:float):
    """
     - Name: PotentialET_PT -Version: 1.0, -Time step: 1
     - Description:
                 * Title: PotentialET Component
                 * Authors: SQ
                 * Reference: None
                 * Institution: INRAE
                 * ExtendedDescription: https://pimlday26.sciencesconf.org/program?lang=en
                 * ShortDescription: Potential ET (based on Penman and Priestly-Taylor)
     - inputs:
                 * name: lambdaV
                               ** description : latent heat of vaporization of water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10.0
                               ** min : 0.0
                               ** default : 2.454
                               ** unit : MJ kg-1
                 * name: psychrometricConstant
                               ** description : psychrometric constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1.0
                               ** min : 0.0
                               ** default : 0.66
                               ** unit : 
                 * name: Alpha
                               ** description : Priestley-Taylor evapotranspiration proportionality constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 100.0
                               ** min : 0.0
                               ** default : 1.5
                               ** unit : 
                 * name: solarRadiation
                               ** description : solar Radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000.0
                               ** min : 0.0
                               ** default : 3.0
                               ** unit : MJ m-2 d-1
                 * name: hslope
                               ** description : the slope of saturated vapor pressure temperature curve at a given temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000.0
                               ** min : 0.0
                               ** default : 0.584
                               ** unit : hPa degC-1
                 * name: ih
                               ** description : hour of the day if the component is hourly, -999 if the component is daily
                               ** inputtype : variable
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 24
                               ** min : -999
                               ** default : -999
                               ** unit : 
                 * name: netRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 5000.0
                               ** min : 0.0
                               ** default : 1.566
                               ** unit : MJ m-2 d-1
     - outputs:
                 * name: evapoTranspirationPriestlyTaylor
                               ** description : evapoTranspiration of Priestly Taylor
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 10000.0
                               ** min : 0.0
                               ** unit : g m-2 d-1
    """

    evapoTranspirationPriestlyTaylor:float
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(lambdaV, netRadiation, psychrometricConstant, Alpha, solarRadiation, hslope, ih)
    return evapoTranspirationPriestlyTaylor
#%%CyML Model End%%