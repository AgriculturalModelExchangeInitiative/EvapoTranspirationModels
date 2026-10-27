# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_stomataresistance(saturation_beta:float,
         stomata_conductance_alpha:float,
         carboxylation_pathway:int,
         atmospheric_co2_concentration:float,
         saturation_vapor_pressure_deficit:float,
         gross_photosynthesis_reference_mol:float):
    """
     - Name: StomataResistance -Version: 1, -Time step: 1
     - Description:
                 * Title: MONICA stomata resistance
                 * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
                 * Reference: 
             
                 * Institution: ZALF e.V.
                 * ExtendedDescription: 
             
                 * ShortDescription: Calculates the MONICA reference evapotranspiration
     - inputs:
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
                 * name: atmospheric_co2_concentration
                               ** description : CO2 concentration in the atmosphere. Optional if no crop.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 430
                               ** unit : ppm
                 * name: saturation_vapor_pressure_deficit
                               ** description : saturation_vapor_pressure_deficit
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** unit : kPa
                 * name: gross_photosynthesis_reference_mol
                               ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : -1
                               ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
     - outputs:
                 * name: stomata_resistance
                               ** description : stomata resistance (FAO default value is 100)
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 10000
                               ** min : 0
                               ** unit : s/m
    """

    stomata_resistance:float
    if carboxylation_pathway > 0:
        if gross_photosynthesis_reference_mol <= 0.0:
            stomata_resistance = 999999.9
        elif carboxylation_pathway == 1:
            stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
        else:
            stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
    return stomata_resistance
#%%CyML Model End%%