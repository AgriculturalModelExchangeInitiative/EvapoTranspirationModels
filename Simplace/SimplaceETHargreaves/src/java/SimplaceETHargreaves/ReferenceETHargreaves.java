import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class ReferenceETHargreaves
{
    private Boolean cConvertLeByTemp;
    public Boolean getcConvertLeByTemp()
    { return cConvertLeByTemp; }

    public void setcConvertLeByTemp(Boolean _cConvertLeByTemp)
    { this.cConvertLeByTemp= _cConvertLeByTemp; } 
    
    public ReferenceETHargreaves() { }
    public void  Calculate_Model(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a,  ReferenceETHargreaves_Exogenous ex)
    {
        //- Name: ReferenceETHargreaves -Version: 001, -Time step: 1
        //- Description:
    //            * Title: ReferenceETHargreaves model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
        //- inputs:
    //            * name: cConvertLeByTemp
    //                          ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** default : false
    //                          ** unit : 
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
    //            * name: iSolarRadiation
    //                          ** description : solar radiation
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
        double iSolarRadiation = ex.getiSolarRadiation();
        double ReferenceCropEvapotranspiration;
        double R_s_eveq;
        if (cConvertLeByTemp)
        {
            R_s_eveq = EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5d * (iTMax + iTMin));
        }
        else
        {
            R_s_eveq = EvaporationEquivalentToRadiation2(iSolarRadiation);
        }
        ReferenceCropEvapotranspiration = Math.max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin));
        a.setReferenceCropEvapotranspiration(ReferenceCropEvapotranspiration);
    }
    public static double EvaporationEquivalentToRadiation1(double Radiation, double DailyMeanTemperature)
    {
        return 1 / (2.501d - (0.002361d * DailyMeanTemperature)) * Radiation;
    }
    public static double EvaporationEquivalentToRadiation2(double Radiation)
    {
        return 0.408d * Radiation;
    }
    public static double ReferenceEvapoTranspirationFromSolarRadiation(double R_s, double T_max, double T_min)
    {
        double T_mean;
        T_mean = (T_max + T_min) / 2;
        return 0.0135d * (T_mean + 17.8d) * R_s;
    }
}