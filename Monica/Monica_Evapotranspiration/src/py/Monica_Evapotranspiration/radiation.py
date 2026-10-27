# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_radiation(latitude:float,
         global_radiation:float,
         julian_day:int,
         sunshine_hours:float):
    """
     - Name: Radiation -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA radiation calculations
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: 
                 Taken from the original HERMES model, Kersebaum, K.C. and Richter J.
                 (1991): Modelling nitrogen dynamics in a plant-soil system with a
                 simple model for advisory purposes. Fert. Res. 27 (2-3), 273 - 281.
             
                 * Institution: ZALF e.V.
                 * ExtendedDescription: 
             
                 * ShortDescription: Calculates the MONICA reference evapotranspiration
     - inputs:
                 * name: latitude
                               ** description : latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 90
                               ** min : -90
                               ** default : 0
                               ** unit : degree
                 * name: global_radiation
                               ** description : global radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/m2
                 * name: julian_day
                               ** description : day of year
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 366
                               ** min : 1
                               ** default : 1
                               ** unit : day
                 * name: sunshine_hours
                               ** description : number of sunshine hours
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 0
                               ** unit : h
     - outputs:
                 * name: declination
                               ** description : declination
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : 
                 * name: astronomic_daylength
                               ** description : astronomic_daylength
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: effective_daylength
                               ** description : effective_daylength
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: photoperiodic_daylength
                               ** description : photoperiodic_daylength
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: sunshine_hours_global_radiation
                               ** description : global radiation calculated from sunshine hours
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: extraterrestrial_radiation
                               ** description : extraterrestrial_radiation
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: clear_day_radiation
                               ** description : clear_day_radiation
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: overcast_day_radiation
                               ** description : overcast_day_radiation
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: phot_act_radiation_mean
                               ** description : phot_act_radiation_mean
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : J/m2
    """

    declination:float
    astronomic_daylength:float
    effective_daylength:float
    photoperiodic_daylength:float
    sunshine_hours_global_radiation:float
    extraterrestrial_radiation:float
    clear_day_radiation:float
    overcast_day_radiation:float
    phot_act_radiation_mean:float
    decl_sin:float
    decl_cos:float
    (declination, decl_sin, decl_cos) = calc_declinations(latitude, julian_day)
    astronomic_daylength = calc_astronomic_daylength(latitude, julian_day)
    effective_daylength = calc_effective_daylength(latitude, julian_day)
    photoperiodic_daylength = calc_photoperiodic_daylength(latitude, julian_day)
    arg_phot_act:float
    arg_phot_act = min(1.0, decl_sin / decl_cos * (decl_sin / decl_cos))
    phot_act_radiation_mean = 3600.0 * (decl_sin * astronomic_daylength + (24.0 / pi * decl_cos * sqrt((1.0 - arg_phot_act))))
    if phot_act_radiation_mean > 0.0 and astronomic_daylength > 0.0:
        clear_day_radiation = 0.5 * 1300.0 * phot_act_radiation_mean * exp(-0.14 / (phot_act_radiation_mean / (astronomic_daylength * 3600.0)))
    overcast_day_radiation = 0.2 * clear_day_radiation
    solar_constant:float
    solar_constant = 0.082
    SC:float
    SC = 24.0 * 60.0 / pi * solar_constant * (1.0 + (0.033 * cos(2.0 * pi * julian_day / 365.0)))
    solar_angle:float
    solar_angle = -tan((latitude * pi / 180.0)) * tan(declination * pi / 180.0)
    solar_angle = bound(-1.0, solar_angle, 1.0)
    sunset_solar_angle:float
    sunset_solar_angle = acos(solar_angle)
    extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * sin(sunset_solar_angle)))
    if sunshine_hours > 0.0:
        if global_radiation <= 0.0 and astronomic_daylength > 0.0:
            sunshine_hours_global_radiation = extraterrestrial_radiation * (0.19 + (0.55 * sunshine_hours / astronomic_daylength))
        else:
            sunshine_hours_global_radiation = 0.0
    return (declination, astronomic_daylength, effective_daylength, photoperiodic_daylength, sunshine_hours_global_radiation, extraterrestrial_radiation, clear_day_radiation, overcast_day_radiation, phot_act_radiation_mean)
#%%CyML Model End%%

def bound(lower:float,
         value:float,
         upper:float):
    if value < lower:
        return lower
    if value > upper:
        return upper
    return value

def calc_declinations(latitude:float,
         julian_day:int):
    declination:float
    declination = -23.4 * cos(2.0 * pi * ((julian_day + 10.0) / 365.0))
    decl_sin:float
    decl_sin = sin(declination * pi / 180.0) * sin(latitude * pi / 180.0)
    decl_cos:float
    decl_cos = cos(declination * pi / 180.0) * cos(latitude * pi / 180.0)
    return (declination, decl_sin, decl_cos)

def calc_astronomic_daylength(latitude:float,
         julian_day:int):
    declination:float
    decl_sin:float
    decl_cos:float
    (declination, decl_sin, decl_cos) = calc_declinations(latitude, julian_day)
    astro_daylength:float
    astro_daylength = decl_sin / decl_cos
    astro_daylength = bound(-1.0, astro_daylength, 1.0)
    astronomic_daylength:float
    astronomic_daylength = 12.0 * (pi + (2.0 * asin(astro_daylength))) / pi
    return astronomic_daylength

def calc_effective_daylength(latitude:float,
         julian_day:int):
    declination:float
    decl_sin:float
    decl_cos:float
    (declination, decl_sin, decl_cos) = calc_declinations(latitude, julian_day)
    eff_daylength:float
    eff_daylength = (-sin((8.0 * pi / 180.0)) + decl_sin) / decl_cos
    eff_daylength = bound(-1.0, eff_daylength, 1.0)
    effective_daylength:float
    effective_daylength = 12.0 * (pi + (2.0 * asin(eff_daylength))) / pi
    return effective_daylength

def calc_photoperiodic_daylength(latitude:float,
         julian_day:int):
    declination:float
    decl_sin:float
    decl_cos:float
    (declination, decl_sin, decl_cos) = calc_declinations(latitude, julian_day)
    photo_daylength:float
    photo_daylength = (-sin((-6.0 * pi / 180.0)) + decl_sin) / decl_cos
    photo_daylength = bound(-1.0, photo_daylength, 1.0)
    photoperiodic_daylength:float
    photoperiodic_daylength = 12.0 * (pi + (2.0 * asin(photo_daylength))) / pi
    return photoperiodic_daylength