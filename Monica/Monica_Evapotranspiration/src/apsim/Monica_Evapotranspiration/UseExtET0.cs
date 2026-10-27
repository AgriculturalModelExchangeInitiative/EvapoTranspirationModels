using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: UseExtET0 -Version: 1, -Time step: 1
///- Description:
///            * Title: If Else unit 
///            * Authors: Michael Berg-Mohnicke
///            * Reference: None
///            * Institution: ZALF e.V.
///            * ExtendedDescription: None
///            * ShortDescription: switches between two input values 
///- inputs:
///            * name: use_external_et0
///                          ** description : boolean condition to be met
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : BOOLEAN
///                          ** default : false
///                          ** unit : 
///            * name: external_et0
///                          ** description : value to be returned if condition is true
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : mm
///            * name: internal_et0
///                          ** description : value to be returned if condition is false
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : mm
///- outputs:
///            * name: et0
///                          ** description : the output value
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
/// </summary>
public class UseExtET0
{

    
    /// <summary>
    /// Constructor of the UseExtET0 component")
    /// </summary>  
    public UseExtET0() { }
    
    /// <summary>
    /// Algorithm of the UseExtET0 component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        bool use_external_et0 = a.use_external_et0;
        double external_et0 = a.external_et0;
        double internal_et0 = a.internal_et0;
        double et0;
        if (use_external_et0)
        {
            et0 = external_et0;
        }
        else
        {
            et0 = internal_et0;
        }
        a.et0= et0;
    }
}