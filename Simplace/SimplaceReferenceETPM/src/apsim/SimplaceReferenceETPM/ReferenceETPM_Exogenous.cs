using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the ReferenceETPM_ component
/// </summary>
public class ReferenceETPM_Exogenous
{
    private double _iNetRadiation;
    private double _iActualVapourPressure;
    private double _iTMax;
    private double _iTMin;
    private double _iWindspeed;

    /// <summary>
    /// Constructor ReferenceETPM_Exogenous domain class
    /// </summary>
    public ReferenceETPM_Exogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETPM_Exogenous(ReferenceETPM_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            iNetRadiation = toCopy.iNetRadiation;
            iActualVapourPressure = toCopy.iActualVapourPressure;
            iTMax = toCopy.iTMax;
            iTMin = toCopy.iTMin;
            iWindspeed = toCopy.iWindspeed;
        }
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
    /// Gets and sets the actual vapour pressure
    /// </summary>
    [Description("actual vapour pressure")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/kilopascal")] 
    public double iActualVapourPressure
    {
        get { return this._iActualVapourPressure; }
        set { this._iActualVapourPressure= value; } 
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
    /// Gets and sets the wind speed at 2m height
    /// </summary>
    [Description("wind speed at 2m height")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time")] 
    public double iWindspeed
    {
        get { return this._iWindspeed; }
        set { this._iWindspeed= value; } 
    }

}