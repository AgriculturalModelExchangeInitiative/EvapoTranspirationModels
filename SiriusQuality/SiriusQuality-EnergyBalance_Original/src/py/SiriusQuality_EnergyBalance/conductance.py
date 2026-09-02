# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_conductance(ih:int,
         wind:float,
         heightWeatherMeasurements:float,
         vonKarman:float,
         plantHeight:float,
         zh:float,
         zm:float,
         d:float):
    """
     - Name: Conductance -Version: 1.0, -Time step: 1
     - Description:
                 * Title: Conductance Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
     
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.,
     New Zealand Institute for Crop and Food Research Ltd.
     
                 * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
     canopy and the canopy structure. The approach does not take into account buoyancy
     effects.
     
                 * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
     canopy and the canopy structure. The approach does not take into account buoyancy
     effects.
     
     - inputs:
                 * name: ih
                               ** description : hour of the day if the component is hourly, -999 if the component is daily
                               ** inputtype : variable
                               ** parametercategory : state
                               ** datatype : INT
                               ** max : 24
                               ** min : 999
                               ** default : 999
                               ** unit : 
                 * name: wind
                               ** description : wind
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000000
                               ** min : 0
                               ** default : 124000
                               ** unit : m/d
                 * name: heightWeatherMeasurements
                               ** description : reference height of wind and humidity measurements
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2
                               ** unit : m
                 * name: vonKarman
                               ** description : von Karman constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.42
                               ** unit : dimensionless
                 * name: plantHeight
                               ** description : plant Height
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1000
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: zh
                               ** description : roughness length governing transfer of heat and vapour, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.013
                               ** unit : m
                 * name: zm
                               ** description : roughness length governing momentum transfer, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.13
                               ** unit : m
                 * name: d
                               ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.67
                               ** unit : dimensionless
     - outputs:
                 * name: conductance
                               ** description : the boundary layer conductance
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 10000
                               ** min : 0
                               ** unit : m/d
    """

    conductance:float
    h:float
    clim:float
    clim = 0.10
    if ih != -999:
        clim = 36.00
    h = max(10.00, plantHeight) / 100.00
    conductance = wind * pow(vonKarman, 2) / (log((heightWeatherMeasurements - (d * h)) / (zm * h)) * log((heightWeatherMeasurements - (d * h)) / (zh * h)))
    conductance = max(clim, conductance)
    return conductance
#%%CyML Model End%%