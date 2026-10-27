using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: NetRadiation -Version: 1, -Time step: 1
///- Description:
///            * Title: MONICA net radiation calculation
///            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
///            * Reference: 
///        
///            * Institution: ZALF e.V.
///            * ExtendedDescription: 
///        
///            * ShortDescription: None
///- inputs:
///            * name: height_nn
///                          ** description : height above sea level
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 9999
///                          ** min : -9999
///                          ** default : 0
///                          ** unit : m
///            * name: reference_albedo
///                          ** description : reference albedo
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0
///                          ** unit : dimensionless
///            * name: global_radiation
///                          ** description : global radiation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 50
///                          ** min : 0
///                          ** default : 0
///                          ** unit : MJ/m2
///            * name: max_air_temperature
///                          ** description : daily maximum air temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 100
///                          ** min : -100
///                          ** default : 0
///                          ** unit : °C
///            * name: min_air_temperature
///                          ** description : daily minimum air temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 100
///                          ** min : -100
///                          ** default : 0
///                          ** unit : °C
///            * name: extraterrestrial_radiation
///                          ** description : extraterrestrial_radiation
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 50
///                          ** min : 0
///                          ** default : 0
///                          ** unit : MJ/m2
///            * name: vapor_pressure
///                          ** description : vapor pressure
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : kPa
///- outputs:
///            * name: net_radiation
///                          ** description : net_radiation
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : MJ/m2
/// </summary>
public class NetRadiation
{

    private double _height_nn;
    /// <summary>
    /// Gets and sets the height above sea level
    /// </summary>
    [Description("height above sea level")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=-9999, max=9999, default=0, parametercategory=constant, inputtype="parameter")] 
    public double height_nn
    {
        get { return this._height_nn; }
        set { this._height_nn= value; } 
    }

    private double _reference_albedo;
    /// <summary>
    /// Gets and sets the reference albedo
    /// </summary>
    [Description("reference albedo")] 
    [Units("dimensionless")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0, parametercategory=constant, inputtype="parameter")] 
    public double reference_albedo
    {
        get { return this._reference_albedo; }
        set { this._reference_albedo= value; } 
    }

    
    /// <summary>
    /// Constructor of the NetRadiation component")
    /// </summary>  
    public NetRadiation() { }
    
    /// <summary>
    /// Algorithm of the NetRadiation component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        double global_radiation = ex.global_radiation;
        double max_air_temperature = ex.max_air_temperature;
        double min_air_temperature = ex.min_air_temperature;
        double extraterrestrial_radiation = a.extraterrestrial_radiation;
        double vapor_pressure = a.vapor_pressure;
        double net_radiation;
        double clear_sky_solar_radiation;
        clear_sky_solar_radiation = (0.75 + (0.00002 * height_nn)) * extraterrestrial_radiation;
        double relative_shortwave_radiation;
        relative_shortwave_radiation = clear_sky_solar_radiation > 0.0 ? Math.Min(global_radiation / clear_sky_solar_radiation, 1.0) : 1.0;
        double bolzmann_constant = 0.0000000049;
        double shortwave_radiation;
        shortwave_radiation = (1.0 - reference_albedo) * global_radiation;
        double longwave_radiation;
        longwave_radiation = bolzmann_constant * ((Math.Pow(min_air_temperature + 273.16, 4.0) + Math.Pow(max_air_temperature + 273.16, 4.0)) / 2.0) * (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 * Math.Sqrt(vapor_pressure)));
        net_radiation = shortwave_radiation - longwave_radiation;
        a.net_radiation= net_radiation;
    }
}