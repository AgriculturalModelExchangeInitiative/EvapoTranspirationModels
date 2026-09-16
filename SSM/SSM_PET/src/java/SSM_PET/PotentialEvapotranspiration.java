import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class PotentialEvapotranspiration
{
    private double albedo;
    public double getalbedo()
    { return albedo; }

    public void setalbedo(double _albedo)
    { this.albedo= _albedo; } 
    
    public PotentialEvapotranspiration() { }
    public void  Calculate_Model(petState s, petState s1, petRate r, petAuxiliary a,  petExogenous ex)
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
        double tmax = ex.gettmax();
        double tmin = ex.gettmin();
        double srad = ex.getsrad();
        double pet;
        double td;
        double eeq;
        td = 0.6d * tmax + (0.4d * tmin);
        eeq = srad * (0.004876d - (0.004374d * albedo)) * (td + 29.0d);
        if (tmax > 5.0d && tmax < 34.0d)
        {
            pet = eeq * 1.1d;
        }
        else if ( tmax >= 34.0d)
        {
            pet = eeq * ((tmax - 34.0d) * 0.05d + 1.1d);
        }
        else
        {
            pet = eeq * 0.01d * Math.exp(0.18d * (tmax + 20.0d));
        }
        s.setpet(pet);
    }
}