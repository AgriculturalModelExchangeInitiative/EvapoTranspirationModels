using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the ReferenceETHargreaves_ component
/// </summary>
public class ReferenceETHargreaves_Auxiliary
{
    private double _ReferenceCropEvapotranspiration;

    /// <summary>
    /// Constructor ReferenceETHargreaves_Auxiliary domain class
    /// </summary>
    public ReferenceETHargreaves_Auxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETHargreaves_Auxiliary(ReferenceETHargreaves_Auxiliary toCopy, bool copyAll) // copy constructor 
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