# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Monica_Evapotranspiration.radiation import model_radiation
from Monica_Evapotranspiration.netradiation import model_netradiation
from Monica_Evapotranspiration.stomataresistance import model_stomataresistance
from Monica_Evapotranspiration.calcstomataresistance import model_calcstomataresistance
from Monica_Evapotranspiration.saturatedvaporpressure import model_saturatedvaporpressure
from Monica_Evapotranspiration.saturationvaporpressuredeficit import model_saturationvaporpressuredeficit
from Monica_Evapotranspiration.referenceevapotranspiration import model_referenceevapotranspiration
from Monica_Evapotranspiration.potentialevapotranspiration import model_potentialevapotranspiration
from Monica_Evapotranspiration.evapotranspiration import model_evapotranspiration, init_evapotranspiration
from Monica_Evapotranspiration.useextet0 import model_useextet0
from Monica_Evapotranspiration.useextvaporpressure import model_useextvaporpressure

#%%CyML Model Begin%%
def model_et(latitude:float,
         global_radiation:float,
         julian_day:int,
         sunshine_hours:float,
         reference_albedo:float,
         height_nn:float,
         max_air_temperature:float,
         min_air_temperature:float,
         use_external_vapor_pressure:bool,
         external_vapor_pressure:float,
         relative_humidity:float,
         calc_stomata_resistance:bool,
         fixed_stomata_resistance:float,
         saturation_beta:float,
         stomata_conductance_alpha:float,
         carboxylation_pathway:int,
         gross_photosynthesis_reference_mol:float,
         atmospheric_co2_concentration:float,
         mean_air_temperature:float,
         wind_speed:float,
         wind_speed_height:float,
         stomata_resistance:float,
         net_radiation:float,
         kc_factor:float,
         developmental_stage:int,
         crop_remaining_evapotranspiration:float,
         evaporation_zeta:float,
         maximum_evaporation_impact_depth:float,
         evaporation_reduction_method:int,
         xsa_critical_soil_moisture:float,
         no_of_soil_layers:int,
         no_of_soil_moisture_layers:int,
         layer_thickness:'Array[float]',
         permanent_wilting_point:'Array[float]',
         field_capacity:'Array[float]',
         has_snow_cover:bool,
         crop_transpiration:'Array[float]',
         crop_evaporated_from_intercepted:float,
         percentage_soil_coverage:float,
         surface_water_storage:float,
         evaporated_from_surface:float,
         actual_evaporation:float,
         actual_transpiration:float,
         soil_moisture:'Array[float]',
         evaporation:'Array[float]',
         transpiration:'Array[float]',
         evapotranspiration:'Array[float]',
         actual_evapotranspiration:float,
         use_external_et0:bool,
         external_et0:float):
    """
     - Name: ET -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA evapotranspiration model
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the MONICA evapotranspiration
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
                 * name: reference_albedo
                               ** description : reference albedo
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0
                               ** unit : dimensionless
                 * name: height_nn
                               ** description : height above sea level
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : -9999
                               ** default : 0
                               ** unit : m
                 * name: max_air_temperature
                               ** description : daily maximum air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: min_air_temperature
                               ** description : daily minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: use_external_vapor_pressure
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : mm
                 * name: external_vapor_pressure
                               ** description : value to be returned if condition is true
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : kPa
                 * name: relative_humidity
                               ** description : relative humidity
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0
                               ** unit : fraction
                 * name: calc_stomata_resistance
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : 
                 * name: fixed_stomata_resistance
                               ** description : value to be returned if condition is false
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
                 * name: saturation_beta
                               ** description : Original: Yu et al. 2001; beta = 3.5
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 2.5
                               ** unit : 
                 * name: stomata_conductance_alpha
                               ** description : Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 40
                               ** unit : mmol/m2/s
                 * name: carboxylation_pathway
                               ** description : Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 2
                               ** min : 0
                               ** default : 0
                               ** unit : dimensionless
                 * name: gross_photosynthesis_reference_mol
                               ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : -1
                               ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
                 * name: atmospheric_co2_concentration
                               ** description : CO2 concentration in the atmosphere. Optional if no crop.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 430
                               ** unit : ppm
                 * name: mean_air_temperature
                               ** description : daily average air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 0
                               ** unit : °C
                 * name: wind_speed
                               ** description : wind speed measured at wind speed height
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : 0
                               ** default : 0
                               ** unit : m/s
                 * name: wind_speed_height
                               ** description : height at which the wind speed has been measured
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 9999
                               ** min : -9999
                               ** default : 2
                               ** unit : m
                 * name: stomata_resistance
                               ** description : stomata resistance (FAO default value is 100)
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** default : 100
                               ** unit : s/m
                 * name: net_radiation
                               ** description : net radiation
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : MJ/m2
                 * name: kc_factor
                               ** description : crop coefficient ETc/ET0
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0.75
                               ** unit : dimensionless
                 * name: developmental_stage
                               ** description : MONICA crop developmental stage
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 6
                               ** min : 0
                               ** default : 0
                               ** unit : dimensionless
                 * name: crop_remaining_evapotranspiration
                               ** description : crop remaining evapotranspiration
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: evaporation_zeta
                               ** description : shape factor
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 40
                               ** min : 0
                               ** default : 40
                               ** unit : dimensionless
                 * name: maximum_evaporation_impact_depth
                               ** description : maximumEvaporationImpactDepth
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 5
                               ** unit : dm
                 * name: evaporation_reduction_method
                               ** description : THESEUS (0) or HERMES (1) evaporation reduction method
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 1
                               ** min : 0
                               ** default : 1
                               ** unit : dimensionless
                 * name: xsa_critical_soil_moisture
                               ** description : XSACriticalSoilMoisture
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1.5
                               ** min : 0
                               ** default : 0.1
                               ** unit : m3/m3
                 * name: no_of_soil_layers
                               ** description : number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 0
                               ** default : 20
                               ** unit : dimensionless
                 * name: no_of_soil_moisture_layers
                               ** description : number of soil layers + 1
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 0
                               ** default : 21
                               ** unit : dimensionless
                 * name: layer_thickness
                               ** description : layer thickness array
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m
                 * name: permanent_wilting_point
                               ** description : permanent wilting point array
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m3/m3
                 * name: field_capacity
                               ** description : field capacity array
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m3/m3
                 * name: has_snow_cover
                               ** description : is the soil covered by snow
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : dimensionless
                 * name: crop_transpiration
                               ** description : crop transpiration array
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: crop_evaporated_from_intercepted
                               ** description : crop evaporated water from intercepted water
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: percentage_soil_coverage
                               ** description : fraction of soil covered by crop
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0
                               ** unit : m2/m2
                 * name: surface_water_storage
                               ** description : Simulates a virtual layer that contains the surface water
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: evaporated_from_surface
                               ** description : evaporated_from_surface
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: actual_evaporation
                               ** description : actual evaporation
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: actual_transpiration
                               ** description : actual transpiration
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: soil_moisture
                               ** description : soil moisture array
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m3/m3
                 * name: evaporation
                               ** description : evaporation array
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: transpiration
                               ** description : transpiration array
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: evapotranspiration
                               ** description : evapotranspiration array
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: actual_evapotranspiration
                               ** description : actual evapotranspiration
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
                 * name: use_external_et0
                               ** description : boolean condition to be met
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : BOOLEAN
                               ** default : false
                               ** unit : 
                 * name: external_et0
                               ** description : value to be returned if condition is true
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
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
                 * name: reference_evapotranspiration
                               ** description : reference evapotranspiration (ET0)
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: potential_evapotranspiration
                               ** description : the potential evapotranspiration
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
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
    vapor_pressure:float
    saturation_vapor_pressure_deficit:float
    calculated_stomata_resistance:float
    saturated_vapor_pressure:float
    reference_evapotranspiration:float
    potential_evapotranspiration_cap:float
    potential_evapotranspiration:float
    internal_et0:float
    et0:float
    internal_vapor_pressure:float
    (declination, astronomic_daylength, effective_daylength, photoperiodic_daylength, sunshine_hours_global_radiation, extraterrestrial_radiation, clear_day_radiation, overcast_day_radiation, phot_act_radiation_mean) = model_radiation(latitude, global_radiation, julian_day, sunshine_hours)
    (saturated_vapor_pressure, vapor_pressure) = model_saturatedvaporpressure(max_air_temperature, min_air_temperature, relative_humidity)
    internal_vapor_pressure = vapor_pressure
    vapor_pressure = model_useextvaporpressure(use_external_vapor_pressure, external_vapor_pressure, internal_vapor_pressure)
    net_radiation = model_netradiation(height_nn, reference_albedo, global_radiation, max_air_temperature, min_air_temperature, extraterrestrial_radiation, vapor_pressure)
    saturation_vapor_pressure_deficit = model_saturationvaporpressuredeficit(saturated_vapor_pressure, vapor_pressure)
    stomata_resistance = model_stomataresistance(saturation_beta, stomata_conductance_alpha, carboxylation_pathway, atmospheric_co2_concentration, saturation_vapor_pressure_deficit, gross_photosynthesis_reference_mol)
    calculated_stomata_resistance = stomata_resistance
    stomata_resistance = model_calcstomataresistance(calc_stomata_resistance, calculated_stomata_resistance, fixed_stomata_resistance)
    reference_evapotranspiration = model_referenceevapotranspiration(height_nn, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit)
    internal_et0 = reference_evapotranspiration
    et0 = model_useextet0(use_external_et0, external_et0, internal_et0)
    reference_evapotranspiration = et0
    potential_evapotranspiration = model_potentialevapotranspiration(potential_evapotranspiration_cap, kc_factor, developmental_stage, crop_remaining_evapotranspiration, reference_evapotranspiration)
    (evaporated_from_surface, actual_evapotranspiration, actual_evaporation, actual_transpiration, surface_water_storage, soil_moisture) = model_evapotranspiration(evaporation_zeta, maximum_evaporation_impact_depth, evaporation_reduction_method, xsa_critical_soil_moisture, no_of_soil_layers, no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point, field_capacity, kc_factor, has_snow_cover, developmental_stage, crop_transpiration, crop_evaporated_from_intercepted, percentage_soil_coverage, potential_evapotranspiration, surface_water_storage, evaporated_from_surface, actual_evaporation, actual_transpiration, soil_moisture, evaporation, transpiration, evapotranspiration, actual_evapotranspiration)
    return (declination, astronomic_daylength, effective_daylength, photoperiodic_daylength, sunshine_hours_global_radiation, extraterrestrial_radiation, clear_day_radiation, overcast_day_radiation, phot_act_radiation_mean, reference_evapotranspiration, potential_evapotranspiration)
#%%CyML Model End%%

#%%CyML Init Begin%%
def init_et(latitude:float,
         global_radiation:float,
         julian_day:int,
         sunshine_hours:float,
         height_nn:float,
         reference_albedo:float,
         max_air_temperature:float,
         min_air_temperature:float,
         saturation_beta:float,
         stomata_conductance_alpha:float,
         carboxylation_pathway:int,
         atmospheric_co2_concentration:float,
         relative_humidity:float,
         mean_air_temperature:float,
         wind_speed:float,
         wind_speed_height:float,
         potential_evapotranspiration_cap:float,
         kc_factor:float,
         developmental_stage:int,
         crop_remaining_evapotranspiration:float,
         evaporation_zeta:float,
         maximum_evaporation_impact_depth:float,
         evaporation_reduction_method:int,
         xsa_critical_soil_moisture:float,
         no_of_soil_layers:int,
         no_of_soil_moisture_layers:int,
         layer_thickness:'Array[float]',
         permanent_wilting_point:'Array[float]',
         field_capacity:'Array[float]',
         has_snow_cover:bool,
         crop_transpiration:'Array[float]',
         crop_evaporated_from_intercepted:float,
         percentage_soil_coverage:float):
    surface_water_storage:float = 0.0
    evaporated_from_surface:float = 0.0
    actual_evaporation:float = 0.0
    actual_transpiration:float = 0.0
    soil_moisture:'array[float]' = array('f',[0.0]*(no_of_soil_moisture_layers))
    evaporation:'array[float]' = array('f',[0.0]*(no_of_soil_moisture_layers))
    transpiration:'array[float]' = array('f',[0.0]*(no_of_soil_moisture_layers))
    evapotranspiration:'array[float]' = array('f',[0.0]*(no_of_soil_moisture_layers))
    actual_evapotranspiration:float = 0.0
    (surface_water_storage, evaporated_from_surface, actual_evaporation, actual_transpiration, soil_moisture, evaporation, transpiration, evapotranspiration, actual_evapotranspiration) = init_evapotranspiration(evaporation_zeta, maximum_evaporation_impact_depth, evaporation_reduction_method, xsa_critical_soil_moisture, no_of_soil_layers, no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point, field_capacity, kc_factor, has_snow_cover, developmental_stage, crop_transpiration, crop_evaporated_from_intercepted, percentage_soil_coverage)
    return (surface_water_storage, evaporated_from_surface, actual_evaporation, actual_transpiration, soil_moisture, evaporation, transpiration, evapotranspiration, actual_evapotranspiration)
#%%CyML Init End%%