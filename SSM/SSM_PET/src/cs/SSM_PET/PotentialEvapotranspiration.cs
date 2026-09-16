using System;
using System.Collections.Generic;
using System.Linq;
public class PotentialEvapotranspiration
{
    private double _albedo;
    public double albedo
    {
        get { return this._albedo; }
        set { this._albedo= value; } 
    }
    /// <summary>
    /// Constructor of the PotentialEvapotranspiration component")
    /// </summary>  
    public PotentialEvapotranspiration() { }
    
    public void  CalculateModel(petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex)
    {
        //- Name: PotentialEvapotranspiration -Version: 0.1, -Time step: 1
        //- Description:
    //            * Title: PotentialEvapotranspiration
    //            * Authors: -
    //            * Reference: -
    //            * Institution: -
    //            * ExtendedDescription: Python implementation of a simplified Penman-style PET model (from Sultani and Sinclair 2012) computing equilibrium evaporation EEQ = SRAD*(0.004876-0.004374*ALBEDO)*(TD+29) with TD = 0.6*TMAX+0.4*TMIN, PET adjusted by Tmax-dependent multipliers (including low-temperature and high-advection corrections) and intended to be combined with an exponential Beer–Bouguer–Lambert factor for fraction of uncovered soil.
    //            * ShortDescription: Simplified Penman-based PET calculator using EEQ, Tmax adjustments, and optional Beer–Lambert uncovered-soil albedo weighting.
        //- inputs:
    //            * name: tmax
    //                          ** description : Daily maximum temperature.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60.0
    //                          ** min : -60.0
    //                          ** default : 
    //                          ** unit : °C
    //                          ** uri : -
    //            * name: tmin
    //                          ** description : Daily minimum temperature.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60.0
    //                          ** min : -60.0
    //                          ** default : 
    //                          ** unit : °C
    //                          ** uri : -
    //            * name: srad
    //                          ** description : Daily solar radiation.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 120.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : MJ m-2 day-1
    //                          ** uri : -
    //            * name: albedo
    //                          ** description : Surface albedo.
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10.0
    //                          ** min : 0.0
    //                          ** default : 1.0
    //                          ** unit : -
    //                          ** uri : -
        //- outputs:
    //            * name: pet
    //                          ** description : Potential evapotranspiration.
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm day-1
    //                          ** uri : -
        double tmax = ex.tmax;
        double tmin = ex.tmin;
        double srad = ex.srad;
        double pet;
        double td;
        double eeq;
        td = 0.6 * tmax + (0.4 * tmin);
        eeq = srad * (0.004876 - (0.004374 * albedo)) * (td + 29.0);
        if (tmax > 5.0 && tmax < 34.0)
        {
            pet = eeq * 1.1;
        }
        else if ( tmax >= 34.0)
        {
            pet = eeq * ((tmax - 34.0) * 0.05 + 1.1);
        }
        else
        {
            pet = eeq * 0.01 * Math.Exp(0.18 * (tmax + 20.0));
        }
        s.pet= pet;
    }
}