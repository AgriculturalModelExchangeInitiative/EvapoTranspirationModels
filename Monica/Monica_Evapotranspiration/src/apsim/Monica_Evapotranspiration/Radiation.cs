using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: Radiation -Version: 1, -Time step: 1
///- Description:
///            * Title: MONICA radiation calculations
///            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
///            * Reference: 
///            Taken from the original HERMES model, Kersebaum, K.C. and Richter J.
///            (1991): Modelling nitrogen dynamics in a plant-soil system with a
///            simple model for advisory purposes. Fert. Res. 27 (2-3), 273 - 281.
///        
///            * Institution: ZALF e.V.
///            * ExtendedDescription: 
///        
///            * ShortDescription: Calculates the MONICA reference evapotranspiration
///- inputs:
///            * name: latitude
///                          ** description : latitude
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 90
///                          ** min : -90
///                          ** default : 0
///                          ** unit : degree
///            * name: global_radiation
///                          ** description : global radiation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 50
///                          ** min : 0
///                          ** default : 0
///                          ** unit : MJ/m2
///            * name: julian_day
///                          ** description : day of year
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : INT
///                          ** max : 366
///                          ** min : 1
///                          ** default : 1
///                          ** unit : day
///            * name: sunshine_hours
///                          ** description : number of sunshine hours
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 24
///                          ** min : 0
///                          ** default : 0
///                          ** unit : h
///- outputs:
///            * name: declination
///                          ** description : declination
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : 
///            * name: astronomic_daylength
///                          ** description : astronomic_daylength
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
///            * name: effective_daylength
///                          ** description : effective_daylength
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
///            * name: photoperiodic_daylength
///                          ** description : photoperiodic_daylength
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
///            * name: sunshine_hours_global_radiation
///                          ** description : global radiation calculated from sunshine hours
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : MJ/m2
///            * name: extraterrestrial_radiation
///                          ** description : extraterrestrial_radiation
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : MJ/m2
///            * name: clear_day_radiation
///                          ** description : clear_day_radiation
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : MJ/m2
///            * name: overcast_day_radiation
///                          ** description : overcast_day_radiation
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : MJ/m2
///            * name: phot_act_radiation_mean
///                          ** description : phot_act_radiation_mean
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : J/m2
/// </summary>
public class Radiation
{

    private double _latitude;
    /// <summary>
    /// Gets and sets the latitude
    /// </summary>
    [Description("latitude")] 
    [Units("degree")] 
    //[Crop2ML(datatype="DOUBLE", min=-90, max=90, default=0, parametercategory=constant, inputtype="parameter")] 
    public double latitude
    {
        get { return this._latitude; }
        set { this._latitude= value; } 
    }

    
    /// <summary>
    /// Constructor of the Radiation component")
    /// </summary>  
    public Radiation() { }
    
    /// <summary>
    /// Algorithm of the Radiation component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        double global_radiation = ex.global_radiation;
        int julian_day = ex.julian_day;
        double sunshine_hours = ex.sunshine_hours;
        double declination;
        double astronomic_daylength;
        double effective_daylength;
        double photoperiodic_daylength;
        double sunshine_hours_global_radiation;
        double extraterrestrial_radiation;
        double clear_day_radiation;
        double overcast_day_radiation;
        double phot_act_radiation_mean;
        double decl_sin;
        double decl_cos;
        calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
        astronomic_daylength = calc_astronomic_daylength(latitude, julian_day);
        effective_daylength = calc_effective_daylength(latitude, julian_day);
        photoperiodic_daylength = calc_photoperiodic_daylength(latitude, julian_day);
        double arg_phot_act;
        arg_phot_act = Math.Min(1.0, decl_sin / decl_cos * (decl_sin / decl_cos));
        phot_act_radiation_mean = 3600.0 * (decl_sin * astronomic_daylength + (24.0 / Math.PI * decl_cos * Math.Sqrt((1.0 - arg_phot_act))));
        if (phot_act_radiation_mean > 0.0 && astronomic_daylength > 0.0)
        {
            clear_day_radiation = 0.5 * 1300.0 * phot_act_radiation_mean * Math.Exp(-0.14 / (phot_act_radiation_mean / (astronomic_daylength * 3600.0)));
        }
        overcast_day_radiation = 0.2 * clear_day_radiation;
        double solar_constant;
        solar_constant = 0.082;
        double SC;
        SC = 24.0 * 60.0 / Math.PI * solar_constant * (1.0 + (0.033 * Math.Cos(2.0 * Math.PI * julian_day / 365.0)));
        double solar_angle;
        solar_angle = -Math.Tan((latitude * Math.PI / 180.0)) * Math.Tan(declination * Math.PI / 180.0);
        solar_angle = bound(-1.0, solar_angle, 1.0);
        double sunset_solar_angle;
        sunset_solar_angle = Math.Acos(solar_angle);
        extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * Math.Sin(sunset_solar_angle)));
        if (sunshine_hours > 0.0)
        {
            if (global_radiation <= 0.0 && astronomic_daylength > 0.0)
            {
                sunshine_hours_global_radiation = extraterrestrial_radiation * (0.19 + (0.55 * sunshine_hours / astronomic_daylength));
            }
            else
            {
                sunshine_hours_global_radiation = 0.0;
            }
        }
        a.declination= declination;
        a.astronomic_daylength= astronomic_daylength;
        a.effective_daylength= effective_daylength;
        a.photoperiodic_daylength= photoperiodic_daylength;
        a.sunshine_hours_global_radiation= sunshine_hours_global_radiation;
        a.extraterrestrial_radiation= extraterrestrial_radiation;
        a.clear_day_radiation= clear_day_radiation;
        a.overcast_day_radiation= overcast_day_radiation;
        a.phot_act_radiation_mean= phot_act_radiation_mean;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double bound(double lower, double value, double upper)
    {
        if (value < lower)
        {
            return lower;
        }
        if (value > upper)
        {
            return upper;
        }
        return value;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  calc_declinations(double latitude, int julian_day)
    {
        declination = -23.4 * Math.Cos(2.0 * Math.PI * ((julian_day + 10.0) / 365.0));
        decl_sin = Math.Sin(declination * Math.PI / 180.0) * Math.Sin(latitude * Math.PI / 180.0);
        decl_cos = Math.Cos(declination * Math.PI / 180.0) * Math.Cos(latitude * Math.PI / 180.0);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double calc_astronomic_daylength(double latitude, int julian_day)
    {
        double declination;
        double decl_sin;
        double decl_cos;
        calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
        double astro_daylength;
        astro_daylength = decl_sin / decl_cos;
        astro_daylength = bound(-1.0, astro_daylength, 1.0);
        double astronomic_daylength;
        astronomic_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(astro_daylength))) / Math.PI;
        return astronomic_daylength;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double calc_effective_daylength(double latitude, int julian_day)
    {
        double declination;
        double decl_sin;
        double decl_cos;
        calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
        double eff_daylength;
        eff_daylength = (-Math.Sin((8.0 * Math.PI / 180.0)) + decl_sin) / decl_cos;
        eff_daylength = bound(-1.0, eff_daylength, 1.0);
        double effective_daylength;
        effective_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(eff_daylength))) / Math.PI;
        return effective_daylength;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double calc_photoperiodic_daylength(double latitude, int julian_day)
    {
        double declination;
        double decl_sin;
        double decl_cos;
        calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
        double photo_daylength;
        photo_daylength = (-Math.Sin((-6.0 * Math.PI / 180.0)) + decl_sin) / decl_cos;
        photo_daylength = bound(-1.0, photo_daylength, 1.0);
        double photoperiodic_daylength;
        photoperiodic_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(photo_daylength))) / Math.PI;
        return photoperiodic_daylength;
    }
}