using System;
using System.Collections.Generic;
using System.Linq;
public class ReferenceETPriestleyTaylor
{
    private double _cAltitude;
    public double cAltitude
    {
        get { return this._cAltitude; }
        set { this._cAltitude= value; } 
    }
    private double _cAlphaPT;
    public double cAlphaPT
    {
        get { return this._cAlphaPT; }
        set { this._cAlphaPT= value; } 
    }
    /// <summary>
    /// Constructor of the ReferenceETPriestleyTaylor component")
    /// </summary>  
    public ReferenceETPriestleyTaylor() { }
    
    public void  CalculateModel(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex)
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
        double iTMax = ex.iTMax;
        double iTMin = ex.iTMin;
        double iNetRadiation = ex.iNetRadiation;
        double ReferenceCropEvapotranspiration;
        double lambdav;
        double T;
        double Delta;
        double AtmPres;
        double Gamma;
        double G;
        lambdav = 2.45;
        T = (iTMax + iTMin) / 2.0;
        Delta = SlopeOfSaturationVapPressureCurve(T);
        AtmPres = AtmosphericPressure(cAltitude);
        Gamma = PsychrometricConstant(AtmPres);
        G = 0.0;
        ReferenceCropEvapotranspiration = Math.Max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav);
        a.ReferenceCropEvapotranspiration= ReferenceCropEvapotranspiration;
    }
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3;
        return 4098 * (0.6108 * Math.Exp(17.27 * T / tempT)) / Math.Pow(tempT, 2);
    }
    public static double AtmosphericPressure(double z)
    {
        return 101.3 * Math.Pow((293 - (0.0065 * z)) / 293, 5.26);
    }
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
}