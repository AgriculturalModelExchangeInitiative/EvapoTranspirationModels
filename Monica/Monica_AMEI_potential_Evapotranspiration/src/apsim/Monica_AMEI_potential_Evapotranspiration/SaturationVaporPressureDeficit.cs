using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: SaturationVaporPressureDeficit -Version: 1, -Time step: 1
///- Description:
///            * Title: MONICA saturation vapor pressure deficit
///            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
///            * Reference: 
///        
///            * Institution: ZALF e.V.
///            * ExtendedDescription: 
///        
///            * ShortDescription: Calculates saturation vapor pressure deficit as in the MONICA model
///- inputs:
///            * name: saturated_vapor_pressure
///                          ** description : saturated vapor pressure
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : kPa
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
///            * name: saturation_vapor_pressure_deficit
///                          ** description : saturation vapor pressure deficit
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : kPa
/// </summary>
public class SaturationVaporPressureDeficit
{

    
    /// <summary>
    /// Constructor of the SaturationVaporPressureDeficit component")
    /// </summary>  
    public SaturationVaporPressureDeficit() { }
    
    /// <summary>
    /// Algorithm of the SaturationVaporPressureDeficit component
    /// </summary>
    public void  CalculateModel(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
    {
        double saturated_vapor_pressure = a.saturated_vapor_pressure;
        double vapor_pressure = a.vapor_pressure;
        double saturation_vapor_pressure_deficit;
        saturation_vapor_pressure_deficit = saturated_vapor_pressure - vapor_pressure;
        a.saturation_vapor_pressure_deficit= saturation_vapor_pressure_deficit;
    }
}