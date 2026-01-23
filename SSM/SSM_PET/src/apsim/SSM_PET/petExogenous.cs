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
    private double _etlai;

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
            etlai = toCopy.etlai;
        }
    }

    /// <summary>
    /// Gets and sets the Daily maximum temperature
    /// </summary>
    [Description("Daily maximum temperature")] 
    [Units("degC")] 
    public double tmax
    {
        get { return this._tmax; }
        set { this._tmax= value; } 
    }

    /// <summary>
    /// Gets and sets the Daily minimum temperature
    /// </summary>
    [Description("Daily minimum temperature")] 
    [Units("degC")] 
    public double tmin
    {
        get { return this._tmin; }
        set { this._tmin= value; } 
    }

    /// <summary>
    /// Gets and sets the Daily solar radiation
    /// </summary>
    [Description("Daily solar radiation")] 
    [Units("MJ m-2 day-1")] 
    public double srad
    {
        get { return this._srad; }
        set { this._srad= value; } 
    }

    /// <summary>
    /// Gets and sets the Leaf area index effective in evapotranspiration
    /// </summary>
    [Description("Leaf area index effective in evapotranspiration")] 
    [Units("m2 m-2")] 
    public double etlai
    {
        get { return this._etlai; }
        set { this._etlai= value; } 
    }

}