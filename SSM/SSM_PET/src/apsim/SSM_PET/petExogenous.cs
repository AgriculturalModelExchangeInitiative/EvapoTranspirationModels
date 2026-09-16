using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the pet component
/// </summary>
public class PetExogenous
{
    private double _tmax;
    private double _tmin;
    private double _srad;

    /// <summary>
    /// Constructor PetExogenous domain class
    /// </summary>
    public PetExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PetExogenous(PetExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            tmax = toCopy.tmax;
            tmin = toCopy.tmin;
            srad = toCopy.srad;
        }
    }

    /// <summary>
    /// Gets and sets the Daily maximum temperature.
    /// </summary>
    [Description("Daily maximum temperature.")] 
    [Units("°C")] 
    public double tmax
    {
        get { return this._tmax; }
        set { this._tmax= value; } 
    }

    /// <summary>
    /// Gets and sets the Daily minimum temperature.
    /// </summary>
    [Description("Daily minimum temperature.")] 
    [Units("°C")] 
    public double tmin
    {
        get { return this._tmin; }
        set { this._tmin= value; } 
    }

    /// <summary>
    /// Gets and sets the Daily solar radiation.
    /// </summary>
    [Description("Daily solar radiation.")] 
    [Units("MJ m-2 day-1")] 
    public double srad
    {
        get { return this._srad; }
        set { this._srad= value; } 
    }

}