import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class ReferenceETPriestleyTaylor
{
    private double cAltitude;
    public double getcAltitude()
    { return cAltitude; }

    public void setcAltitude(double _cAltitude)
    { this.cAltitude= _cAltitude; } 
    
    private double cAlphaPT;
    public double getcAlphaPT()
    { return cAlphaPT; }

    public void setcAlphaPT(double _cAlphaPT)
    { this.cAlphaPT= _cAlphaPT; } 
    
    public ReferenceETPriestleyTaylor() { }
    public void  Calculate_Model(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a,  ReferenceETPriestleyTaylor_Exogenous ex)
    {
        //- Name: ReferenceETPriestleyTaylor -Version: 001, -Time step: 1
        //- Description:
    //            * Title: ReferenceETPriestleyTaylor model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
        //- inputs:
    //            * name: cAltitude
    //                          ** description : altitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: cAlphaPT
    //                          ** description : Priestley-Taylor coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 1.26
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
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
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
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
        double iNetRadiation = ex.getiNetRadiation();
        double ReferenceCropEvapotranspiration;
        double lambdav;
        double T;
        double Delta;
        double AtmPres;
        double Gamma;
        double G;
        lambdav = 2.45d;
        T = (iTMax + iTMin) / 2.0d;
        Delta = SlopeOfSaturationVapPressureCurve(T);
        AtmPres = AtmosphericPressure(cAltitude);
        Gamma = PsychrometricConstant(AtmPres);
        G = 0.0d;
        ReferenceCropEvapotranspiration = Math.max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav);
        a.setReferenceCropEvapotranspiration(ReferenceCropEvapotranspiration);
    }
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3d;
        return 4098 * (0.6108d * Math.exp(17.27d * T / tempT)) / Math.pow(tempT, 2);
    }
    public static double AtmosphericPressure(double z)
    {
        return 101.3d * Math.pow((293 - (0.0065d * z)) / 293, 5.26d);
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
}