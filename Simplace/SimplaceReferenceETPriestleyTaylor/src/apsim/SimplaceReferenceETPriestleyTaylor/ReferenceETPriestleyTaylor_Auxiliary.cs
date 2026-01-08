using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the ReferenceETPriestleyTaylor_ component
/// </summary>
public class ReferenceETPriestleyTaylor_Auxiliary
{
    private double _ReferenceCropEvapotranspiration;

    /// <summary>
    /// Constructor ReferenceETPriestleyTaylor_Auxiliary domain class
    /// </summary>
    public ReferenceETPriestleyTaylor_Auxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETPriestleyTaylor_Auxiliary(ReferenceETPriestleyTaylor_Auxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            ReferenceCropEvapotranspiration = toCopy.ReferenceCropEvapotranspiration;
        }
    }

    /// <summary>
    /// Gets and sets the reference evapotranspiration (ET0)
    /// </summary>
    [Description("reference evapotranspiration (ET0)")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day")] 
    public double ReferenceCropEvapotranspiration
    {
        get { return this._ReferenceCropEvapotranspiration; }
        set { this._ReferenceCropEvapotranspiration= value; } 
    }

}