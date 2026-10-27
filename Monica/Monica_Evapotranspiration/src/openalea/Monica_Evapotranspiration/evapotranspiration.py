# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_evapotranspiration(evaporation_zeta:float,
         maximum_evaporation_impact_depth:float,
         evaporation_reduction_method:int,
         xsa_critical_soil_moisture:float,
         no_of_soil_layers:int,
         no_of_soil_moisture_layers:int,
         layer_thickness:'Array[float]',
         permanent_wilting_point:'Array[float]',
         field_capacity:'Array[float]',
         kc_factor:float,
         has_snow_cover:bool,
         developmental_stage:int,
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
    soil_moisture = array('f', [0.0]*(no_of_soil_moisture_layers))
    evaporation = array('f', [0.0]*(no_of_soil_moisture_layers))
    transpiration = array('f', [0.0]*(no_of_soil_moisture_layers))
    evapotranspiration = array('f', [0.0]*(no_of_soil_moisture_layers))
    return (surface_water_storage, evaporated_from_surface, actual_evaporation, actual_transpiration, soil_moisture, evaporation, transpiration, evapotranspiration, actual_evapotranspiration)
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_evapotranspiration(evaporation_zeta:float,
         maximum_evaporation_impact_depth:float,
         evaporation_reduction_method:int,
         xsa_critical_soil_moisture:float,
         no_of_soil_layers:int,
         no_of_soil_moisture_layers:int,
         layer_thickness:'Array[float]',
         permanent_wilting_point:'Array[float]',
         field_capacity:'Array[float]',
         kc_factor:float,
         has_snow_cover:bool,
         developmental_stage:int,
         crop_transpiration:'Array[float]',
         crop_evaporated_from_intercepted:float,
         percentage_soil_coverage:float,
         potential_evapotranspiration:float,
         surface_water_storage:float,
         evaporated_from_surface:float,
         actual_evaporation:float,
         actual_transpiration:float,
         soil_moisture:'Array[float]',
         evaporation:'Array[float]',
         transpiration:'Array[float]',
         evapotranspiration:'Array[float]',
         actual_evapotranspiration:float):
    """
     - Name: Evapotranspiration -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA evapotranspiration model
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the MONICA evapotranspiration
     - inputs:
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
                 * name: kc_factor
                               ** description : crop coefficient ETc/ET0
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0.75
                               ** unit : dimensionless
                 * name: has_snow_cover
                               ** description : is the soil covered by snow
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : BOOLEAN
                               ** default : false
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
                 * name: potential_evapotranspiration
                               ** description : the potential evapotranspiration
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 0
                               ** unit : mm
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
     - outputs:
                 * name: evaporated_from_surface
                               ** description : 
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: actual_evapotranspiration
                               ** description : actual evapotranspiration
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 200
                               ** min : 0
                               ** unit : mm
                 * name: actual_evaporation
                               ** description : actual evaporation
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: actual_transpiration
                               ** description : actual transpiration
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: surface_water_storage
                               ** description : Simulates a virtual layer that contains the surface water
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : mm
                 * name: soil_moisture
                               ** description : soil moisture array
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : no_of_soil_moisture_layers
                               ** max : 
                               ** min : 
                               ** unit : m3/m3
    """

    evaporated_from_intercept:float
    if developmental_stage > 0:
        evaporated_from_intercept = crop_evaporated_from_intercepted
    else:
        evaporated_from_intercept = 0.0
    evaporated_from_surface = 0.0
    actual_evaporation = 0.0
    actual_transpiration = 0.0
    evaporation_from_surface:bool = False
    eRed1:float
    eRed2:float
    eRed3:float
    eReducer:float
    i:int
    if potential_evapotranspiration > 0.0:
        evaporation_from_surface = False
        if surface_water_storage > 0.0:
            evaporation_from_surface = True
            potential_evapotranspiration = potential_evapotranspiration * (1.1 / kc_factor)
            if has_snow_cover:
                evaporated_from_surface = 0.0
            elif surface_water_storage < potential_evapotranspiration:
                potential_evapotranspiration = potential_evapotranspiration - surface_water_storage
                evaporated_from_surface = surface_water_storage
                surface_water_storage = 0.0
            else:
                surface_water_storage = surface_water_storage - potential_evapotranspiration
                evaporated_from_surface = potential_evapotranspiration
                potential_evapotranspiration = 0.0
            potential_evapotranspiration = potential_evapotranspiration * (kc_factor / 1.1)
        if potential_evapotranspiration > 0.0:
            for i in range(0 , no_of_soil_layers , 1):
                eRed1 = e_reducer_1(permanent_wilting_point[i], field_capacity[i], soil_moisture[i], percentage_soil_coverage, potential_evapotranspiration, evaporation_reduction_method, xsa_critical_soil_moisture)
                eRed2 = 0.0
                if float(i) >= maximum_evaporation_impact_depth:
                    eRed2 = 0.0
                else:
                    eRed2 = get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i])
                eRed3 = 0.0
                if i > 0 and soil_moisture[i] < soil_moisture[i - 1]:
                    eRed3 = 0.1
                else:
                    eRed3 = 1.0
                eReducer = eRed1 * eRed2 * eRed3
                if developmental_stage > 0:
                    if percentage_soil_coverage >= 0.0 and percentage_soil_coverage < 1.0:
                        evaporation[i] = (1.0 - percentage_soil_coverage) * eReducer * potential_evapotranspiration
                    elif percentage_soil_coverage >= 1.0:
                        evaporation[i] = 0.0
                    if has_snow_cover:
                        evaporation[i] = 0.0
                    transpiration[i] = crop_transpiration[i]
                    if evaporation_from_surface:
                        transpiration[i] = percentage_soil_coverage * eReducer * potential_evapotranspiration
                else:
                    if has_snow_cover:
                        evaporation[i] = 0.0
                    else:
                        evaporation[i] = potential_evapotranspiration * eReducer
                    transpiration[i] = 0.0
                evapotranspiration[i] = evaporation[i] + transpiration[i]
                soil_moisture[i] = soil_moisture[i] - (evapotranspiration[i] / 1000.0 / layer_thickness[i])
                if soil_moisture[i] < 0.01:
                    soil_moisture[i] = 0.01
                actual_transpiration = actual_transpiration + transpiration[i]
                actual_evaporation = actual_evaporation + evaporation[i]
    actual_evapotranspiration = actual_transpiration + actual_evaporation + evaporated_from_intercept + evaporated_from_surface
    return (evaporated_from_surface, actual_evapotranspiration, actual_evaporation, actual_transpiration, surface_water_storage, soil_moisture)
#%%CyML Model End%%

def bound(lower:float,
         value:float,
         upper:float):
    if value < lower:
        return lower
    if value > upper:
        return upper
    return value

def get_deprivation_factor(layer_no:int,
         deprivation_depth:float,
         zeta:float,
         layer_thickness:float):
    ltf:float
    ltf = deprivation_depth / (layer_thickness * 10.0)
    deprivation_factor:float
    c2:float
    c3:float
    if abs(zeta) < 0.0003:
        deprivation_factor = 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no - 1))
    else:
        c2 = log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))))
        c3 = zeta / (ltf * (zeta + 1.0))
        deprivation_factor = (c2 - c3) / (log(zeta + 1.0) - (zeta / (zeta + 1.0)))
    return deprivation_factor

def e_reducer_1(pwp:float,
         fc:float,
         sm:float,
         percentage_soil_coverage:float,
         reference_evapotranspiration:float,
         evaporation_reduction_method:int,
         xsa_critical_soil_moisture:float):
    sm = max(0.33 * pwp, sm)
    relative_evaporable_water:float
    relative_evaporable_water = min(1.0, (sm - (0.33 * pwp)) / (fc - (0.33 * pwp)))
    e_reduction_factor:float = 0.0
    critical_soil_moisture:float
    reducer:float
    xsa:float
    if evaporation_reduction_method == 0:
        critical_soil_moisture = 0.65 * fc
        if percentage_soil_coverage > 0.0:
            reducer = 1.0
            if reference_evapotranspiration > 2.5:
                xsa = (0.65 * fc - pwp) * (fc - pwp)
                reducer = xsa + ((1 - xsa) / 17.5 * (reference_evapotranspiration - 2.5))
            else:
                reducer = xsa_critical_soil_moisture / 2.5 * reference_evapotranspiration
            critical_soil_moisture = fc * reducer
        if sm > critical_soil_moisture:
            e_reduction_factor = 1.0
        elif sm > (0.33 * pwp):
            e_reduction_factor = relative_evaporable_water
        else:
            e_reduction_factor = 0.0
    else:
        if relative_evaporable_water > 0.33:
            e_reduction_factor = 1.0 - (0.1 * (1.0 - relative_evaporable_water) / (1.0 - 0.33))
        elif relative_evaporable_water > 0.22:
            e_reduction_factor = 0.9 - (0.625 * (0.33 - relative_evaporable_water) / (0.33 - 0.22))
        elif relative_evaporable_water > 0.2:
            e_reduction_factor = 0.275 - (0.225 * (0.22 - relative_evaporable_water) / (0.22 - 0.2))
        else:
            e_reduction_factor = 0.05 - (0.05 * (0.2 - relative_evaporable_water) / 0.2)
    return e_reduction_factor