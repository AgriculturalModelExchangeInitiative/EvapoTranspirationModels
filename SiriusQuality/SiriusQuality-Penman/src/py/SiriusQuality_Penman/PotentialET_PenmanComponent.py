# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SiriusQuality_Penman.priestlytaylor import model_priestlytaylor
from SiriusQuality_Penman.penman import model_penman

#%%CyML Model Begin%%
def model_potentialet_penman(netRadiation:float,
         lambdaV:float,
         psychrometricConstant:float,
         Alpha:float,
         solarRadiation:float,
         hslope:float,
         ih:int,
         VPDair:float,
         specificHeatCapacityAir:float,
         rhoDensityAir:float,
         conductance:float):
    """
     - Name: PotentialET_Penman -Version: 1.0, -Time step: 1
     - Description:
                 * Title: PotentialET Component
                 * Authors: SQ
                 * Reference: None
                 * Institution: INRAE
                 * ExtendedDescription: https://pimlday26.sciencesconf.org/program?lang=en
                 * ShortDescription: Potential ET (based on Penman and Priestly-Taylor)
     - inputs:
                 * name: netRadiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 5000.0
                               ** min : 0.0
                               ** default : 1.566
                               ** unit : MJ m-2 d-1
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
                 * name: VPDair
                               ** description : vapour pressure density
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000.0
                               ** min : 0.0
                               ** default : 2.19
                               ** unit : hPa
                 * name: specificHeatCapacityAir
                               ** description : Specific heat capacity of dry air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1.0
                               ** min : 0.0
                               ** default : 0.00101
                               ** unit : 
                 * name: rhoDensityAir
                               ** description : Density of air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1.225
                               ** unit : 
                 * name: conductance
                               ** description : conductance
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000.0
                               ** min : 0.0
                               ** default : 598.685
                               ** unit : m d-1
     - outputs:
                 * name: evapoTranspirationPenman
                               ** description : evapoTranspiration of Penman Monteith
                               ** datatype : DOUBLE
                               ** variablecategory : rate
                               ** max : 5000.0
                               ** min : 0.0
                               ** unit : g m-2 d-1
    """

    evapoTranspirationPriestlyTaylor:float
    evapoTranspirationPenman:float
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(lambdaV, netRadiation, psychrometricConstant, Alpha, solarRadiation, hslope, ih)
    evapoTranspirationPenman = model_penman(VPDair, specificHeatCapacityAir, psychrometricConstant, rhoDensityAir, Alpha, evapoTranspirationPriestlyTaylor, lambdaV, hslope, conductance)
    return evapoTranspirationPenman
#%%CyML Model End%%