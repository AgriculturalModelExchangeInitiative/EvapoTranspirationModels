using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: UseExtVaporPressure -Version: 1, -Time step: 1
///- Description:
///            * Title: If Else unit 
///            * Authors: Michael Berg-Mohnicke
///            * Reference: None
///            * Institution: ZALF e.V.
///            * ExtendedDescription: None
///            * ShortDescription: switches between two input values 
///- inputs:
///            * name: use_external_vapor_pressure
///                          ** description : boolean condition to be met
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : BOOLEAN
///                          ** default : false
///                          ** unit : mm
///            * name: external_vapor_pressure
///                          ** description : value to be returned if condition is true
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : kPa
///            * name: internal_vapor_pressure
///                          ** description : value to be returned if condition is false
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : kPa
///- outputs:
///            * name: vapor_pressure
///                          ** description : the output value
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
/// </summary>
public class UseExtVaporPressure
{

    
    /// <summary>
    /// Constructor of the UseExtVaporPressure component")
    /// </summary>  
    public UseExtVaporPressure() { }
    
    /// <summary>
    /// Algorithm of the UseExtVaporPressure component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        bool use_external_vapor_pressure = a.use_external_vapor_pressure;
        double external_vapor_pressure = a.external_vapor_pressure;
        double internal_vapor_pressure = a.internal_vapor_pressure;
        double vapor_pressure;
        if (use_external_vapor_pressure)
        {
            vapor_pressure = external_vapor_pressure;
        }
        else
        {
            vapor_pressure = internal_vapor_pressure;
        }
        a.vapor_pressure= vapor_pressure;
    }
}