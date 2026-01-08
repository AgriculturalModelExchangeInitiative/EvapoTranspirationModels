using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the ReferenceETPriestleyTaylor_ component
/// </summary>
public class ReferenceETPriestleyTaylor_Exogenous
{
    private double _iTMin;
    private double _iNetRadiation;
    private double _iTMax;

    /// <summary>
    /// Constructor ReferenceETPriestleyTaylor_Exogenous domain class
    /// </summary>
    public ReferenceETPriestleyTaylor_Exogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETPriestleyTaylor_Exogenous(ReferenceETPriestleyTaylor_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            iTMin = toCopy.iTMin;
            iNetRadiation = toCopy.iNetRadiation;
            iTMax = toCopy.iTMax;
        }
    }

    /// <summary>
    /// Gets and sets the minimum daily temperature
    /// </summary>
    [Description("minimum daily temperature")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")] 
    public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }

    /// <summary>
    /// Gets and sets the net radiation
    /// </summary>
    [Description("net radiation")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day")] 
    public double iNetRadiation
    {
        get { return this._iNetRadiation; }
        set { this._iNetRadiation= value; } 
    }

    /// <summary>
    /// Gets and sets the maximum daily temperature
    /// </summary>
    [Description("maximum daily temperature")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")] 
    public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }

}