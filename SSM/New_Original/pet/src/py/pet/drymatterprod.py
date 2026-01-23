# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_drymatterprod(tmax:float,
         tmin:float,
         srad:float,
         lai:float,
         kpar:float,
         RUE:float,
         TBRUE:float,
         TP1RUE:float,
         TP2RUE:float,
         TCRUE:float):
    """
     - Name: DryMatterProd -Version: -, -Time step: 1
     - Description:
                 * Title: DryMatterProd
                 * Authors: -
                 * Reference: -
                 * Institution: -
                 * ExtendedDescription: Python implementation of an SSM Potential Dry Matter Production model that computes daily dry matter (g m-2 day-1) from daily solar radiation, LAI, and a temperature-adjusted Radiation Use Efficiency (RUE); uses Beer-Lambert extinction (fint = 1 - exp(-kpar * LAI)) to estimate intercepted PAR (assumes PAR = 0.48 * srad) and a piecewise linear temperature response for RUE with defaults for wheat (kpar=0.65, RUE=2.2 g MJ-1, TBRUE=0, TP1RUE=15, TP2RUE=22, TCRUE=35).
                 * ShortDescription: Daily dry matter production from intercepted PAR and temperature-modified RUE (Python).
     - inputs:
                 * name: tmax
                               ** description : Daily maximum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : degC
                               ** uri : -
                 * name: tmin
                               ** description : Daily minimum temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** default : 
                               ** unit : degC
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
                 * name: DDMP
                               ** description : Dry matter production rate.
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : -
                               ** min : -
                               ** unit : g m-2 day-1
                               ** uri : -
    """

    DDMP:float
    tmp:float
    coeff_RUE:float
    actual_RUE:float
    fint:float
    tmp = tmax + (0.4 * tmin)
    if tmp <= TBRUE or tmp >= TCRUE:
        coeff_RUE = 0.0
    elif TBRUE < tmp and tmp < TP1RUE:
        coeff_RUE = (tmp - TBRUE) / (TP1RUE - TBRUE)
    elif TP2RUE <= tmp and tmp <= TCRUE:
        coeff_RUE = (TCRUE - tmp) / (TCRUE - TP2RUE)
    else:
        coeff_RUE = 1.0
    actual_RUE = RUE * coeff_RUE
    fint = 1.0 - exp(-kpar * lai)
    DDMP = srad * 0.48 * fint * actual_RUE
    return DDMP
#%%CyML Model End%%