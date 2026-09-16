using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the PotentialET_Penman component
/// </summary>
public class PotentialET_PenmanAuxiliary
{
    private double _netRadiation;
    private double _solarRadiation;
    private double _hslope;
    private double _VPDair;
    private double _conductance;

    /// <summary>
    /// Constructor PotentialET_PenmanAuxiliary domain class
    /// </summary>
    public PotentialET_PenmanAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PenmanAuxiliary(PotentialET_PenmanAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            netRadiation = toCopy.netRadiation;
            solarRadiation = toCopy.solarRadiation;
            hslope = toCopy.hslope;
            VPDair = toCopy.VPDair;
            conductance = toCopy.conductance;
        }
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
    /// Gets and sets the vapour pressure density
    /// </summary>
    [Description("vapour pressure density")] 
    [Units("hPa")] 
    public double VPDair
    {
        get { return this._VPDair; }
        set { this._VPDair= value; } 
    }

    /// <summary>
    /// Gets and sets the conductance
    /// </summary>
    [Description("conductance")] 
    [Units("m d-1")] 
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }

}