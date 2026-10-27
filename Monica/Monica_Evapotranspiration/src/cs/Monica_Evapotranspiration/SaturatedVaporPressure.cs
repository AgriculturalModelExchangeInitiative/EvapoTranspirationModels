using System;
using System.Collections.Generic;
using System.Linq;
public class SaturatedVaporPressure
{
    
    /// <summary>
    /// Constructor of the SaturatedVaporPressure component")
    /// </summary>  
    public SaturatedVaporPressure() { }
    
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        //- Name: SaturatedVaporPressure -Version: 1, -Time step: 1
        //- Description:
    //            * Title: MONICA saturated vapor pressure
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: Calculates saturated vapor pressure as in the MONICA model
        //- inputs:
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
    //            * name: relative_humidity
    //                          ** description : relative humidity
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : fraction
        //- outputs:
    //            * name: saturated_vapor_pressure
    //                          ** description : saturated vapor pressure
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : kPa
    //            * name: vapor_pressure
    //                          ** description : vapor pressure from relative humidity and saturated vapor pressure
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : kPa
        double max_air_temperature = ex.max_air_temperature;
        double min_air_temperature = ex.min_air_temperature;
        double relative_humidity = ex.relative_humidity;
        double saturated_vapor_pressure;
        double vapor_pressure;
        double saturated_vapor_pressure_max;
        saturated_vapor_pressure_max = 0.6108 * Math.Exp(17.27 * max_air_temperature / (237.3 + max_air_temperature));
        double saturated_vapor_pressure_min;
        saturated_vapor_pressure_min = 0.6108 * Math.Exp(17.27 * min_air_temperature / (237.3 + min_air_temperature));
        saturated_vapor_pressure = (saturated_vapor_pressure_max + saturated_vapor_pressure_min) / 2.0;
        if (relative_humidity <= 0.0)
        {
            vapor_pressure = saturated_vapor_pressure_min;
        }
        else
        {
            vapor_pressure = relative_humidity * saturated_vapor_pressure;
        }
        a.saturated_vapor_pressure= saturated_vapor_pressure;
        a.vapor_pressure= vapor_pressure;
    }
}