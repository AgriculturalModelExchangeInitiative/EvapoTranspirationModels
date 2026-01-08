using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: ReferenceETHargreaves -Version: 001, -Time step: 1
///- Description:
///            * Title: ReferenceETHargreaves model
///            * Authors: Gunther Krauss
///            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
///            * Institution: INRES Pflanzenbau, Uni Bonn
///            * ExtendedDescription: as given in the documentation
///            * ShortDescription: None
///- inputs:
///            * name: cConvertLeByTemp
///                          ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : BOOLEAN
///                          ** max : 
///                          ** min : 
///                          ** default : false
///                          ** unit : 
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
///            * name: iSolarRadiation
///                          ** description : solar radiation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
///- outputs:
///            * name: ReferenceCropEvapotranspiration
///                          ** description : reference evapotranspiration (ET0)
///                          ** datatype : DOUBLE
///                          ** variablecategory : auxiliary
///                          ** max : 
///                          ** min : 
///                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
/// </summary>
public class ReferenceETHargreaves
{

    private bool _cConvertLeByTemp;
    /// <summary>
    /// Gets and sets the Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
    /// </summary>
    [Description("Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.")] 
    [Units("")] 
    //[Crop2ML(datatype="BOOLEAN", min=null, max=null, default=false, parametercategory=constant, inputtype="parameter")] 
    public bool cConvertLeByTemp
    {
        get { return this._cConvertLeByTemp; }
        set { this._cConvertLeByTemp= value; } 
    }

    
    /// <summary>
    /// Constructor of the ReferenceETHargreaves component")
    /// </summary>  
    public ReferenceETHargreaves() { }
    
    /// <summary>
    /// Algorithm of the ReferenceETHargreaves component
    /// </summary>
    public void  CalculateModel(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex)
    {
        double iTMax = ex.iTMax;
        double iTMin = ex.iTMin;
        double iSolarRadiation = ex.iSolarRadiation;
        double ReferenceCropEvapotranspiration;
        double R_s_eveq;
        if (cConvertLeByTemp)
        {
            R_s_eveq = EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 * (iTMax + iTMin));
        }
        else
        {
            R_s_eveq = EvaporationEquivalentToRadiation2(iSolarRadiation);
        }
        ReferenceCropEvapotranspiration = Math.Max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin));
        a.ReferenceCropEvapotranspiration= ReferenceCropEvapotranspiration;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double EvaporationEquivalentToRadiation1(double Radiation, double DailyMeanTemperature)
    {
        return 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double EvaporationEquivalentToRadiation2(double Radiation)
    {
        return 0.408 * Radiation;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double ReferenceEvapoTranspirationFromSolarRadiation(double R_s, double T_max, double T_min)
    {
        double T_mean;
        T_mean = (T_max + T_min) / 2;
        return 0.0135 * (T_mean + 17.8) * R_s;
    }
}