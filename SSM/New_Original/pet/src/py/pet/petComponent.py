# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from pet.potentialevapotranspiration import model_potentialevapotranspiration
from pet.potentialtranspiration import model_potentialtranspiration
from pet.drymatterprod import model_drymatterprod

#%%CyML Model Begin%%
def model_pet(tmax:float,
         tmin:float,
         srad:float,
         albedo:float,
         ddmp:float,
         TEC:float,
         VPDF:float,
         lai:float,
         kpar:float,
         RUE:float,
         TBRUE:float,
         TP1RUE:float,
         TP2RUE:float,
         TCRUE:float):
    """
     - Name: pet -Version: -, -Time step: 1
     - Description:
                 * Title: pet
                 * Authors: -
                 * Reference: None
                 * Institution: -
                 * ExtendedDescription: Composite of three Python/Cython model units: PotentialEvapotranspiration — simplified Penman-style PET (EEQ from srad, tmax, tmin with albedo and Tmax adjustments; cites Sultani & Sinclair 2012), DryMatterProd — SSM potential dry matter production from intercepted PAR with temperature-modified RUE (outputs DDMP, g m-2 day-1), and PotentialTranspiration — VPD-based potential transpiration using temperatures and daily dry matter (ddmp) scaled by VPDF and TEC.
                 * ShortDescription: Composite of simplified Penman PET, RUE-based dry matter production (DDMP), and VPD/TEC-based potential transpiration (TR).
     - inputs:
                 * name: tmax
                               ** description : Daily maximum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: tmin
                               ** description : Daily minimum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : °C
                               ** uri : -
                 * name: srad
                               ** description : Daily solar radiation.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : MJ m-2 day-1
                               ** uri : -
                 * name: albedo
                               ** description : Surface albedo.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 1
                               ** unit : -
                               ** uri : -
                 * name: ddmp
                               ** description : Daily dry matter production.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : g m-2 day-1
                               ** uri : -
                 * name: TEC
                               ** description : Transpiration efficiency coefficient.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 5.8
                               ** unit : g mm-1
                               ** uri : -
                 * name: VPDF
                               ** description : Vapor pressure deficit factor.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 0.75
                               ** unit : -
                               ** uri : -
                 * name: lai
                               ** description : Leaf Area Index.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : m2 m-2
                               ** uri : -
                 * name: kpar
                               ** description : Canopy extinction coefficient.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 0.65
                               ** unit : -
                               ** uri : -
                 * name: RUE
                               ** description : Potential radiation use efficiency at optimal temperature.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 2.2
                               ** unit : g MJ-1
                               ** uri : -
                 * name: TBRUE
                               ** description : Base temperature for RUE adjustment.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 0.0
                               ** unit : degC
                               ** uri : -
                 * name: TP1RUE
                               ** description : Lower optimal temperature for RUE adjustment.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 15.0
                               ** unit : degC
                               ** uri : -
                 * name: TP2RUE
                               ** description : Upper optimal temperature for RUE adjustment.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 22.0
                               ** unit : degC
                               ** uri : -
                 * name: TCRUE
                               ** description : Ceiling temperature for RUE adjustment.
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 35.0
                               ** unit : degC
                               ** uri : -
     - outputs:
                 * name: pet
                               ** description : Potential evapotranspiration.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : mm day-1
                               ** uri : -
                 * name: TR
                               ** description : Potential transpiration.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : mm day-1
                               ** uri : -
                 * name: DDMP
                               ** description : Dry matter production rate.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : g m-2 day-1
                               ** uri : -
    """

    pet:float
    TR:float
    DDMP:float
    DDMP = model_drymatterprod(tmax, tmin, srad, lai, kpar, RUE, TBRUE, TP1RUE, TP2RUE, TCRUE)
    ddmp = DDMP
    TR = model_potentialtranspiration(tmax, tmin, ddmp, TEC, VPDF)
    return (pet, TR, DDMP)
#%%CyML Model End%%