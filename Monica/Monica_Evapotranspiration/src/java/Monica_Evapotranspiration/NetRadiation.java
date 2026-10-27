import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class NetRadiation
{
    private double height_nn;
    public double getheight_nn()
    { return height_nn; }

    public void setheight_nn(double _height_nn)
    { this.height_nn= _height_nn; } 
    
    private double reference_albedo;
    public double getreference_albedo()
    { return reference_albedo; }

    public void setreference_albedo(double _reference_albedo)
    { this.reference_albedo= _reference_albedo; } 
    
    public NetRadiation() { }
    public void  Calculate_Model(ETState s, ETState s1, ETRate r, ETAuxiliary a,  ETExogenous ex)
    {
        //- Name: NetRadiation -Version: 1, -Time step: 1
        //- Description:
    //            * Title: MONICA net radiation calculation
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: None
        //- inputs:
    //            * name: height_nn
    //                          ** description : height above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : -9999
    //                          ** default : 0
    //                          ** unit : m
    //            * name: reference_albedo
    //                          ** description : reference albedo
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : dimensionless
    //            * name: global_radiation
    //                          ** description : global radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : MJ/m2
    //            * name: max_air_temperature
    //                          ** description : daily maximum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : -100
    //                          ** default : 0
    //                          ** unit : °C
    //            * name: min_air_temperature
    //                          ** description : daily minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : -100
    //                          ** default : 0
    //                          ** unit : °C
    //            * name: extraterrestrial_radiation
    //                          ** description : extraterrestrial_radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : MJ/m2
    //            * name: vapor_pressure
    //                          ** description : vapor pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : kPa
        //- outputs:
    //            * name: net_radiation
    //                          ** description : net_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
        double global_radiation = ex.getglobal_radiation();
        double max_air_temperature = ex.getmax_air_temperature();
        double min_air_temperature = ex.getmin_air_temperature();
        double extraterrestrial_radiation = a.getextraterrestrial_radiation();
        double vapor_pressure = a.getvapor_pressure();
        double net_radiation;
        double clear_sky_solar_radiation;
        clear_sky_solar_radiation = (0.75d + (0.00002d * height_nn)) * extraterrestrial_radiation;
        double relative_shortwave_radiation;
        relative_shortwave_radiation = clear_sky_solar_radiation > 0.0d ? Math.min(global_radiation / clear_sky_solar_radiation, 1.0d) : 1.0d;
        double bolzmann_constant = 0.0000000049;
        double shortwave_radiation;
        shortwave_radiation = (1.0d - reference_albedo) * global_radiation;
        double longwave_radiation;
        longwave_radiation = bolzmann_constant * ((Math.pow(min_air_temperature + 273.16d, 4.0d) + Math.pow(max_air_temperature + 273.16d, 4.0d)) / 2.0d) * (1.35d * relative_shortwave_radiation - 0.35d) * (0.34d - (0.14d * Math.sqrt(vapor_pressure)));
        net_radiation = shortwave_radiation - longwave_radiation;
        a.setnet_radiation(net_radiation);
    }
}