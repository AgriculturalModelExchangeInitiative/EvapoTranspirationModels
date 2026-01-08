using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: ReferenceETPM -Version: 001, -Time step: 1
///- Description:
///            * Title: ReferenceETPM model
///            * Authors: Gunther Krauss
///            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
///            * Institution: INRES Pflanzenbau, Uni Bonn
///            * ExtendedDescription: as given in the documentation
///            * ShortDescription: None
///- inputs:
///            * name: cAltitude
///                          ** description : elevation above sea level
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
///            * name: iTMax
///                          ** description : maximum daily temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
///            * name: iTMin
///                          ** description : minimum daily temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
///            * name: iActualVapourPressure
///                          ** description : actual vapour pressure
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
///            * name: iNetRadiation
///                          ** description : net radiation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
///            * name: iWindspeed
///                          ** description : wind speed at 2m height
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
///- outputs:
///            * name: ReferenceCropEvapotranspiration
///                          ** description : reference evapotranspiration (ET0)
///                          ** datatype : DOUBLE
///                          ** variablecategory : auxiliary
///                          ** max : 
///                          ** min : 
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
/// </summary>
public class ReferenceETPM
{

    private double _cAltitude;
    /// <summary>
    /// Gets and sets the elevation above sea level
    /// </summary>
    [Description("elevation above sea level")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/metre")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=0.0, parametercategory=constant, inputtype="parameter")] 
    public double cAltitude
    {
        get { return this._cAltitude; }
        set { this._cAltitude= value; } 
    }

    
    /// <summary>
    /// Constructor of the ReferenceETPM component")
    /// </summary>  
    public ReferenceETPM() { }
    
    /// <summary>
    /// Algorithm of the ReferenceETPM component
    /// </summary>
    public void  CalculateModel(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
    {
        double iTMax = ex.iTMax;
        double iTMin = ex.iTMin;
        double iActualVapourPressure = ex.iActualVapourPressure;
        double iNetRadiation = ex.iNetRadiation;
        double iWindspeed = ex.iWindspeed;
        double ReferenceCropEvapotranspiration;
        double T;
        double e_s;
        T = (iTMax + iTMin) / 2;
        e_s = MeanSaturatedVapourPressure(iTMax, iTMin);
        if (iActualVapourPressure > e_s)
        {
            iActualVapourPressure = e_s;
        }
        ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude);
        a.ReferenceCropEvapotranspiration= ReferenceCropEvapotranspiration;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double SaturationVapourPressureAtTemperature(double T)
    {
        return 0.6108 * Math.Exp(17.27 * T / (T + 237.3));
    }
    /// <summary>
    /// 
    /// </summary>
    public static double MeanSaturatedVapourPressure(double T_max, double T_min)
    {
        return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3;
        return 4098 * (0.6108 * Math.Exp(17.27 * T / tempT)) / Math.Pow(tempT, 2);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double PsychrometricConstant(double P)
    {
        double lambdav;
        double c_p;
        double epsilon;
        double factor;
        lambdav = 2.45;
        c_p = 1.0130E-3;
        epsilon = 0.622;
        factor = Math.Round(c_p / (epsilon * lambdav) * 100E6) / 100E6;
        return factor * P;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double AtmosphericPressure(double z)
    {
        return 101.3 * Math.Pow((293 - (0.0065 * z)) / 293, 5.26);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z)
    {
        double P;
        double gamma;
        double Delta;
        double G;
        double ET0;
        P = AtmosphericPressure(z);
        gamma = PsychrometricConstant(P);
        Delta = SlopeOfSaturationVapPressureCurve(T);
        G = (double)(0);
        ET0 = (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))));
        return ET0;
    }
}