using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: PotentialEvapotranspiration -Version: 1, -Time step: 1
///- Description:
///            * Title: MONICA potential evapotranspiration calculation
///            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
///            * Reference: None
///            * Institution: ZALF e.V.
///            * ExtendedDescription: None
///            * ShortDescription: Calculates the MONICA potential evapotranspiration
///- inputs:
///            * name: potential_evapotranspiration_cap
///                          ** description : cap ET0 to this value
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 6.5
///                          ** unit : mm
///            * name: kc_factor
///                          ** description : crop coefficient ETc/ET0
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0.75
///                          ** unit : dimensionless
///            * name: developmental_stage
///                          ** description : MONICA crop developmental stage
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : INT
///                          ** max : 6
///                          ** min : 0
///                          ** default : 0
///                          ** unit : dimensionless
///            * name: crop_remaining_evapotranspiration
///                          ** description : crop remaining evapotranspiration
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: reference_evapotranspiration
///                          ** description : ET0 either from external ET0 or crop specific ET0
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 0
///                          ** unit : mm
///- outputs:
///            * name: potential_evapotranspiration
///                          ** description : the potential evapotranspiration
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : mm
/// </summary>
public class PotentialEvapotranspiration
{

    private double _potential_evapotranspiration_cap;
    /// <summary>
    /// Gets and sets the cap ET0 to this value
    /// </summary>
    [Description("cap ET0 to this value")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=null, default=6.5, parametercategory=constant, inputtype="parameter")] 
    public double potential_evapotranspiration_cap
    {
        get { return this._potential_evapotranspiration_cap; }
        set { this._potential_evapotranspiration_cap= value; } 
    }

    
    /// <summary>
    /// Constructor of the PotentialEvapotranspiration component")
    /// </summary>  
    public PotentialEvapotranspiration() { }
    
    /// <summary>
    /// Algorithm of the PotentialEvapotranspiration component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        double kc_factor = ex.kc_factor;
        int developmental_stage = ex.developmental_stage;
        double crop_remaining_evapotranspiration = ex.crop_remaining_evapotranspiration;
        double reference_evapotranspiration = a.reference_evapotranspiration;
        double potential_evapotranspiration;
        if (developmental_stage > 0)
        {
            potential_evapotranspiration = crop_remaining_evapotranspiration;
        }
        else
        {
            potential_evapotranspiration = reference_evapotranspiration * kc_factor;
        }
        if (potential_evapotranspiration > potential_evapotranspiration_cap)
        {
            potential_evapotranspiration = potential_evapotranspiration_cap;
        }
        a.potential_evapotranspiration= potential_evapotranspiration;
    }
}