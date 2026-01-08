using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the ReferenceETHargreaves_ component
/// </summary>
public class ReferenceETHargreaves_Exogenous
{
    private double _iTMax;
    private double _iSolarRadiation;
    private double _iTMin;

    /// <summary>
    /// Constructor ReferenceETHargreaves_Exogenous domain class
    /// </summary>
    public ReferenceETHargreaves_Exogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETHargreaves_Exogenous(ReferenceETHargreaves_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            iTMax = toCopy.iTMax;
            iSolarRadiation = toCopy.iSolarRadiation;
            iTMin = toCopy.iTMin;
        }
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

    /// <summary>
    /// Gets and sets the solar radiation
    /// </summary>
    [Description("solar radiation")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day")] 
    public double iSolarRadiation
    {
        get { return this._iSolarRadiation; }
        set { this._iSolarRadiation= value; } 
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

}