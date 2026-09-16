using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the PotentialET_PT component
/// </summary>
public class PotentialET_PTAuxiliary
{
    private double _solarRadiation;
    private double _hslope;
    private double _netRadiation;

    /// <summary>
    /// Constructor PotentialET_PTAuxiliary domain class
    /// </summary>
    public PotentialET_PTAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PTAuxiliary(PotentialET_PTAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            solarRadiation = toCopy.solarRadiation;
            hslope = toCopy.hslope;
            netRadiation = toCopy.netRadiation;
        }
    }

    /// <summary>
    /// Gets and sets the solar Radiation
    /// </summary>
    [Description("solar Radiation")] 
    [Units("MJ m-2 d-1")] 
    public double solarRadiation
    {
        get { return this._solarRadiation; }
        set { this._solarRadiation= value; } 
    }

    /// <summary>
    /// Gets and sets the the slope of saturated vapor pressure temperature curve at a given temperature
    /// </summary>
    [Description("the slope of saturated vapor pressure temperature curve at a given temperature")] 
    [Units("hPa degC-1")] 
    public double hslope
    {
        get { return this._hslope; }
        set { this._hslope= value; } 
    }

    /// <summary>
    /// Gets and sets the net radiation
    /// </summary>
    [Description("net radiation")] 
    [Units("MJ m-2 d-1")] 
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }

}