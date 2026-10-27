using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: CalcStomataResistance -Version: 1, -Time step: 1
///- Description:
///            * Title: If Else unit 
///            * Authors: Michael Berg-Mohnicke
///            * Reference: None
///            * Institution: ZALF e.V.
///            * ExtendedDescription: None
///            * ShortDescription: switches between two input values 
///- inputs:
///            * name: calc_stomata_resistance
///                          ** description : boolean condition to be met
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : BOOLEAN
///                          ** default : false
///                          ** unit : 
///            * name: calculated_stomata_resistance
///                          ** description : value to be returned if condition is true
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** default : 100
///                          ** unit : s/m
///            * name: fixed_stomata_resistance
///                          ** description : value to be returned if condition is false
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** default : 100
///                          ** unit : s/m
///- outputs:
///            * name: stomata_resistance
///                          ** description : the output value
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** unit : s/m
/// </summary>
public class CalcStomataResistance
{

    
    /// <summary>
    /// Constructor of the CalcStomataResistance component")
    /// </summary>  
    public CalcStomataResistance() { }
    
    /// <summary>
    /// Algorithm of the CalcStomataResistance component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        bool calc_stomata_resistance = a.calc_stomata_resistance;
        double calculated_stomata_resistance = a.calculated_stomata_resistance;
        double fixed_stomata_resistance = a.fixed_stomata_resistance;
        double stomata_resistance;
        if (calc_stomata_resistance)
        {
            stomata_resistance = calculated_stomata_resistance;
        }
        else
        {
            stomata_resistance = fixed_stomata_resistance;
        }
        a.stomata_resistance= stomata_resistance;
    }
}