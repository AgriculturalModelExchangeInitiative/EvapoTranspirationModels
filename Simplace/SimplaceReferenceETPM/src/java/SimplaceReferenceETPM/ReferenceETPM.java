import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class ReferenceETPM
{
    private double cAltitude;
    public double getcAltitude()
    { return cAltitude; }

    public void setcAltitude(double _cAltitude)
    { this.cAltitude= _cAltitude; } 
    
    public ReferenceETPM() { }
    public void  Calculate_Model(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a,  ReferenceETPM_Exogenous ex)
    {
        //- Name: ReferenceETPM -Version: 001, -Time step: 1
        //- Description:
    //            * Title: ReferenceETPM model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
        //- inputs:
    //            * name: cAltitude
    //                          ** description : elevation above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: iTMax
    //                          ** description : maximum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iTMin
    //                          ** description : minimum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iActualVapourPressure
    //                          ** description : actual vapour pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    //            * name: iWindspeed
    //                          ** description : wind speed at 2m height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
        //- outputs:
    //            * name: ReferenceCropEvapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
        double iTMax = ex.getiTMax();
        double iTMin = ex.getiTMin();
        double iActualVapourPressure = ex.getiActualVapourPressure();
        double iNetRadiation = ex.getiNetRadiation();
        double iWindspeed = ex.getiWindspeed();
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
        a.setReferenceCropEvapotranspiration(ReferenceCropEvapotranspiration);
    }
    public static double SaturationVapourPressureAtTemperature(double T)
    {
        return 0.6108d * Math.exp(17.27d * T / (T + 237.3d));
    }
    public static double MeanSaturatedVapourPressure(double T_max, double T_min)
    {
        return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2;
    }
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3d;
        return 4098 * (0.6108d * Math.exp(17.27d * T / tempT)) / Math.pow(tempT, 2);
    }
    public static double PsychrometricConstant(double P)
    {
        double lambdav;
        double c_p;
        double epsilon;
        double factor;
        lambdav = 2.45d;
        c_p = 1.013E-3d;
        epsilon = 0.622d;
        factor = Math.round(c_p / (epsilon * lambdav) * 10E6d) / 10E6d;
        return factor * P;
    }
    public static double AtmosphericPressure(double z)
    {
        return 101.3d * Math.pow((293 - (0.0065d * z)) / 293, 5.26d);
    }
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
        ET0 = (0.408d * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34d * u_2))));
        return ET0;
    }
}