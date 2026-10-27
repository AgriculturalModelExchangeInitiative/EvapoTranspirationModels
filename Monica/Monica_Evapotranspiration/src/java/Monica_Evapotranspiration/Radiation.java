import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Radiation
{
    private double latitude;
    public double getlatitude()
    { return latitude; }

    public void setlatitude(double _latitude)
    { this.latitude= _latitude; } 
    
    public Radiation() { }
    public void  Calculate_Model(ETState s, ETState s1, ETRate r, ETAuxiliary a,  ETExogenous ex)
    {
        //- Name: Radiation -Version: 1, -Time step: 1
        //- Description:
    //            * Title: MONICA radiation calculations
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //            Taken from the original HERMES model, Kersebaum, K.C. and Richter J.
    //            (1991): Modelling nitrogen dynamics in a plant-soil system with a
    //            simple model for advisory purposes. Fert. Res. 27 (2-3), 273 - 281.
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: Calculates the MONICA reference evapotranspiration
        //- inputs:
    //            * name: latitude
    //                          ** description : latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 90
    //                          ** min : -90
    //                          ** default : 0
    //                          ** unit : degree
    //            * name: global_radiation
    //                          ** description : global radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : MJ/m2
    //            * name: julian_day
    //                          ** description : day of year
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 366
    //                          ** min : 1
    //                          ** default : 1
    //                          ** unit : day
    //            * name: sunshine_hours
    //                          ** description : number of sunshine hours
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : h
        //- outputs:
    //            * name: declination
    //                          ** description : declination
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : 
    //            * name: astronomic_daylength
    //                          ** description : astronomic_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: effective_daylength
    //                          ** description : effective_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: photoperiodic_daylength
    //                          ** description : photoperiodic_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: sunshine_hours_global_radiation
    //                          ** description : global radiation calculated from sunshine hours
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: extraterrestrial_radiation
    //                          ** description : extraterrestrial_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: clear_day_radiation
    //                          ** description : clear_day_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: overcast_day_radiation
    //                          ** description : overcast_day_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: phot_act_radiation_mean
    //                          ** description : phot_act_radiation_mean
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : J/m2
        calc_declinations zz_calc_declinations;
        double global_radiation = ex.getglobal_radiation();
        Integer julian_day = ex.getjulian_day();
        double sunshine_hours = ex.getsunshine_hours();
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
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        astronomic_daylength = calc_astronomic_daylength(latitude, julian_day);
        effective_daylength = calc_effective_daylength(latitude, julian_day);
        photoperiodic_daylength = calc_photoperiodic_daylength(latitude, julian_day);
        double arg_phot_act;
        arg_phot_act = Math.min(1.0d, decl_sin / decl_cos * (decl_sin / decl_cos));
        phot_act_radiation_mean = 3600.0d * (decl_sin * astronomic_daylength + (24.0d / Math.PI * decl_cos * Math.sqrt((1.0d - arg_phot_act))));
        if (phot_act_radiation_mean > 0.0d && astronomic_daylength > 0.0d)
        {
            clear_day_radiation = 0.5d * 1300.0d * phot_act_radiation_mean * Math.exp(-0.14d / (phot_act_radiation_mean / (astronomic_daylength * 3600.0d)));
        }
        overcast_day_radiation = 0.2d * clear_day_radiation;
        double solar_constant;
        solar_constant = 0.082d;
        double SC;
        SC = 24.0d * 60.0d / Math.PI * solar_constant * (1.0d + (0.033d * Math.cos(2.0d * Math.PI * julian_day / 365.0d)));
        double solar_angle;
        solar_angle = -Math.tan((latitude * Math.PI / 180.0d)) * Math.tan(declination * Math.PI / 180.0d);
        solar_angle = bound(-1.0d, solar_angle, 1.0d);
        double sunset_solar_angle;
        sunset_solar_angle = Math.acos(solar_angle);
        extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * Math.sin(sunset_solar_angle)));
        if (sunshine_hours > 0.0d)
        {
            if (global_radiation <= 0.0d && astronomic_daylength > 0.0d)
            {
                sunshine_hours_global_radiation = extraterrestrial_radiation * (0.19d + (0.55d * sunshine_hours / astronomic_daylength));
            }
            else
            {
                sunshine_hours_global_radiation = 0.0d;
            }
        }
        a.setdeclination(declination);
        a.setastronomic_daylength(astronomic_daylength);
        a.seteffective_daylength(effective_daylength);
        a.setphotoperiodic_daylength(photoperiodic_daylength);
        a.setsunshine_hours_global_radiation(sunshine_hours_global_radiation);
        a.setextraterrestrial_radiation(extraterrestrial_radiation);
        a.setclear_day_radiation(clear_day_radiation);
        a.setovercast_day_radiation(overcast_day_radiation);
        a.setphot_act_radiation_mean(phot_act_radiation_mean);
    }
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
    public calc_declinations Calculate_calc_declinations (double latitude, Integer julian_day)
    {
        double declination;
        declination = -23.4d * Math.cos(2.0d * Math.PI * ((julian_day + 10.0d) / 365.0d));
        double decl_sin;
        decl_sin = Math.sin(declination * Math.PI / 180.0d) * Math.sin(latitude * Math.PI / 180.0d);
        double decl_cos;
        decl_cos = Math.cos(declination * Math.PI / 180.0d) * Math.cos(latitude * Math.PI / 180.0d);
        return new calc_declinations(declination, decl_sin, decl_cos);
    }
    public static double calc_astronomic_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double astro_daylength;
        astro_daylength = decl_sin / decl_cos;
        astro_daylength = bound(-1.0d, astro_daylength, 1.0d);
        double astronomic_daylength;
        astronomic_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(astro_daylength))) / Math.PI;
        return astronomic_daylength;
    }
    public static double calc_effective_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double eff_daylength;
        eff_daylength = (-Math.sin((8.0d * Math.PI / 180.0d)) + decl_sin) / decl_cos;
        eff_daylength = bound(-1.0d, eff_daylength, 1.0d);
        double effective_daylength;
        effective_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(eff_daylength))) / Math.PI;
        return effective_daylength;
    }
    public static double calc_photoperiodic_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double photo_daylength;
        photo_daylength = (-Math.sin((-6.0d * Math.PI / 180.0d)) + decl_sin) / decl_cos;
        photo_daylength = bound(-1.0d, photo_daylength, 1.0d);
        double photoperiodic_daylength;
        photoperiodic_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(photo_daylength))) / Math.PI;
        return photoperiodic_daylength;
    }
}
final class calc_declinations {
    private double declination;
    public double getdeclination()
    { return declination; }

    public void setdeclination(double _declination)
    { this.declination= _declination; } 
    
    private double decl_sin;
    public double getdecl_sin()
    { return decl_sin; }

    public void setdecl_sin(double _decl_sin)
    { this.decl_sin= _decl_sin; } 
    
    private double decl_cos;
    public double getdecl_cos()
    { return decl_cos; }

    public void setdecl_cos(double _decl_cos)
    { this.decl_cos= _decl_cos; } 
    
    public calc_declinations(double declination,double decl_sin,double decl_cos)
    {
        this.declination = declination;
        this.decl_sin = decl_sin;
        this.decl_cos = decl_cos;
    }
}