# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

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

#%%CyML Model Begin%%
def model_energybalancecomposite(minTair:float,
         maxTair:float,
         ih:int,
         tau:float,
         albedoCoefficientCan:float,
         elevation:float,
         stefanBoltzman:float,
         vaporPressure:float,
         solarRadiation:float,
         extraSolarRadiation:float,
         albedoCoefficient:float,
         vonKarman:float,
         heightWeatherMeasurements:float,
         wind:float,
         d:float,
         zm:float,
         zh:float,
         plantHeight:float,
         deficitOnTopLayers:float,
         soilDiffusionConstant:float,
         lambdaV:float,
         psychrometricConstant:float,
         hslope:float,
         Alpha:float,
         tauAlpha:float,
         rhoDensityAir:float,
         VPDair:float,
         specificHeatCapacityAir:float,
         isWindVpDefined:int):
    """
     - Name: EnergyBalanceComposite -Version: 1.0, -Time step: 1
     - Description:
                 * Title: EnergyBalance Component
                 * Authors: SQ
                 * Reference: None
                 * Institution: INRAE
                 * ExtendedDescription: https://pimlday26.sciencesconf.org/program?lang=en
                 * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
     - inputs:
                 * name: minTair
                               ** description : minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 45
                               ** min : 30
                               ** default : 0.7
                               ** unit : degC
                 * name: maxTair
                               ** description : maximum air Temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 45
                               ** min : 30
                               ** default : 7.2
                               ** unit : degC
                 * name: ih
                               ** description : hour of the day if the component is hourly, -999 if the component is daily
                               ** inputtype : variable
                               ** parametercategory : state
                               ** datatype : INT
                               ** max : 24
                               ** min : 999
                               ** default : 999
                               ** unit : 
                 * name: tau
                               ** description : plant cover factor
                               ** inputtype : parameter
                               ** parametercategory : species
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 0.9983
                               ** unit : 
                 * name: albedoCoefficientCan
                               ** description : albedo Coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.23
                               ** unit : 
                 * name: elevation
                               ** description : elevation
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 500
                               ** default : 0
                               ** unit : m
                 * name: stefanBoltzman
                               ** description : stefan Boltzman constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 4.903E-09
                               ** unit : 
                 * name: vaporPressure
                               ** description : vapor Pressure
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 6.1
                               ** unit : hPa
                 * name: solarRadiation
                               ** description : solar Radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 3
                               ** unit : MJ m-2 d-1
                 * name: extraSolarRadiation
                               ** description : extra Solar Radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 11.7
                               ** unit : MJ m2 d-1
                 * name: albedoCoefficient
                               ** description : albedo Coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.23
                               ** unit : 
                 * name: vonKarman
                               ** description : von Karman constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.42
                               ** unit : dimensionless
                 * name: heightWeatherMeasurements
                               ** description : reference height of wind and humidity measurements
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2
                               ** unit : m
                 * name: wind
                               ** description : wind
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000000
                               ** min : 0
                               ** default : 124000
                               ** unit : m/d
                 * name: d
                               ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.67
                               ** unit : dimensionless
                 * name: zm
                               ** description : roughness length governing momentum transfer, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.13
                               ** unit : m
                 * name: zh
                               ** description : roughness length governing transfer of heat and vapour, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.013
                               ** unit : m
                 * name: plantHeight
                               ** description : plant Height
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: deficitOnTopLayers
                               ** description : deficit On TopLayers
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 5341
                               ** unit : g m-2 d-1
                 * name: soilDiffusionConstant
                               ** description : soil Diffusion Constant
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 4.2
                               ** unit : 
                 * name: lambdaV
                               ** description : latent heat of vaporization of water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : MJ kg-1
                 * name: psychrometricConstant
                               ** description : psychrometric constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.66
                               ** unit : 
                 * name: hslope
                               ** description : the slope of saturated vapor pressure temperature curve at a given temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 0.584
                               ** unit : hPa degC-1
                 * name: Alpha
                               ** description : Priestley-Taylor evapotranspiration proportionality constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 1.5
                               ** unit : 
                 * name: tauAlpha
                               ** description : Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.3
                               ** unit : 
                 * name: rhoDensityAir
                               ** description : Density of air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : None
                               ** min : None
                               ** default : 1.225
                               ** unit : 
                 * name: VPDair
                               ** description : vapour pressure density
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 2.19
                               ** unit : hPa
                 * name: specificHeatCapacityAir
                               ** description : Specific heat capacity of dry air
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.00101
                               ** unit : 
                 * name: isWindVpDefined
                               ** description : if wind and vapour pressure are defined
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 1
                               ** min : 0
                               ** default : 1
                               ** unit : 
     - outputs:
                 * name: maxCanopyTemperature
                               ** description : maximal Canopy Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 45
                               ** min : 30
                               ** unit : degC
                 * name: diffusionLimitedEvaporation
                               ** description : the evaporation from the diffusion limited soil
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 5000
                               ** min : 0
                               ** unit : g m-2 d-1
                 * name: netOutGoingLongWaveRadiation
                               ** description : net OutGoing Long Wave Radiation
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 5000
                               ** min : 0
                               ** unit : g m-2 d-1
                 * name: minCanopyTemperature
                               ** description : minimal Canopy Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 45
                               ** min : 30
                               ** unit : degC
                 * name: conductance
                               ** description : the boundary layer conductance
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 10000
                               ** min : 0
                               ** unit : m/d
    """

    netRadiation:float
    netOutGoingLongWaveRadiation:float
    conductance:float
    diffusionLimitedEvaporation:float
    netRadiationEquivalentEvaporation:float
    evapoTranspirationPriestlyTaylor:float
    energyLimitedEvaporation:float
    evapoTranspirationPenman:float
    soilEvaporation:float
    evapoTranspiration:float
    soilHeatFlux:float
    potentialTranspiration:float
    cropHeatFlux:float
    minCanopyTemperature:float
    maxCanopyTemperature:float
    (netRadiation, netOutGoingLongWaveRadiation) = model_netradiation(minTair, maxTair, ih, tau, albedoCoefficientCan, elevation, stefanBoltzman, vaporPressure, solarRadiation, extraSolarRadiation, albedoCoefficient)
    conductance = model_conductance(ih, vonKarman, heightWeatherMeasurements, wind, d, zm, zh, plantHeight)
    diffusionLimitedEvaporation = model_diffusionlimitedevaporation(ih, deficitOnTopLayers, soilDiffusionConstant)
    netRadiationEquivalentEvaporation = model_netradiationequivalentevaporation(netRadiation, lambdaV)
    evapoTranspirationPriestlyTaylor = model_priestlytaylor(ih, psychrometricConstant, solarRadiation, hslope, Alpha, netRadiationEquivalentEvaporation)
    energyLimitedEvaporation = model_ptsoil(ih, tau, evapoTranspirationPriestlyTaylor, tauAlpha, Alpha)
    evapoTranspirationPenman = model_penman(rhoDensityAir, psychrometricConstant, hslope, evapoTranspirationPriestlyTaylor, VPDair, lambdaV, Alpha, specificHeatCapacityAir, conductance)
    soilEvaporation = model_soilevaporation(ih, energyLimitedEvaporation, diffusionLimitedEvaporation)
    evapoTranspiration = model_evapotranspiration(isWindVpDefined, evapoTranspirationPriestlyTaylor, evapoTranspirationPenman)
    soilHeatFlux = model_soilheatflux(ih, tau, soilEvaporation, solarRadiation, netRadiationEquivalentEvaporation)
    potentialTranspiration = model_potentialtranspiration(tau, evapoTranspiration)
    cropHeatFlux = model_cropheatflux(ih, soilHeatFlux, potentialTranspiration, netRadiationEquivalentEvaporation)
    (minCanopyTemperature, maxCanopyTemperature) = model_canopytemperature(minTair, cropHeatFlux, rhoDensityAir, maxTair, lambdaV, specificHeatCapacityAir, conductance)
    return (maxCanopyTemperature, diffusionLimitedEvaporation, netOutGoingLongWaveRadiation, minCanopyTemperature, conductance)
#%%CyML Model End%%