using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the EnergyBalanceComposite component
/// </summary>
public class EnergyBalanceCompositeAuxiliary
{
    private double _maxTair;
    private double _minTair;
    private double _vaporPressure;
    private double _extraSolarRadiation;
    private double _solarRadiation;
    private double _plantHeight;
    private double _wind;
    private double _hslope;
    private double _VPDair;
    private double _netOutGoingLongWaveRadiation;
    private double _netRadiation;
    private double _netRadiationEquivalentEvaporation;

    /// <summary>
    /// Constructor EnergyBalanceCompositeAuxiliary domain class
    /// </summary>
    public EnergyBalanceCompositeAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public EnergyBalanceCompositeAuxiliary(EnergyBalanceCompositeAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            maxTair = toCopy.maxTair;
            minTair = toCopy.minTair;
            vaporPressure = toCopy.vaporPressure;
            extraSolarRadiation = toCopy.extraSolarRadiation;
            solarRadiation = toCopy.solarRadiation;
            plantHeight = toCopy.plantHeight;
            wind = toCopy.wind;
            hslope = toCopy.hslope;
            VPDair = toCopy.VPDair;
            netOutGoingLongWaveRadiation = toCopy.netOutGoingLongWaveRadiation;
            netRadiation = toCopy.netRadiation;
            netRadiationEquivalentEvaporation = toCopy.netRadiationEquivalentEvaporation;
        }
    }

    /// <summary>
    /// Gets and sets the maximum air Temperature
    /// </summary>
    [Description("maximum air Temperature")] 
    [Units("degC")] 
    public double maxTair
    {
        get { return this._maxTair; }
        set { this._maxTair= value; } 
    }

    /// <summary>
    /// Gets and sets the minimum air temperature
    /// </summary>
    [Description("minimum air temperature")] 
    [Units("degC")] 
    public double minTair
    {
        get { return this._minTair; }
        set { this._minTair= value; } 
    }

    /// <summary>
    /// Gets and sets the vapor Pressure
    /// </summary>
    [Description("vapor Pressure")] 
    [Units("hPa")] 
    public double vaporPressure
    {
        get { return this._vaporPressure; }
        set { this._vaporPressure= value; } 
    }

    /// <summary>
    /// Gets and sets the extra Solar Radiation
    /// </summary>
    [Description("extra Solar Radiation")] 
    [Units("MJ m2 d-1")] 
    public double extraSolarRadiation
    {
        get { return this._extraSolarRadiation; }
        set { this._extraSolarRadiation= value; } 
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
    /// Gets and sets the plant Height
    /// </summary>
    [Description("plant Height")] 
    [Units("mm")] 
    public double plantHeight
    {
        get { return this._plantHeight; }
        set { this._plantHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the wind
    /// </summary>
    [Description("wind")] 
    [Units("m/d")] 
    public double wind
    {
        get { return this._wind; }
        set { this._wind= value; } 
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
    /// Gets and sets the net OutGoing Long Wave Radiation
    /// </summary>
    [Description("net OutGoing Long Wave Radiation")] 
    [Units("g m-2 d-1")] 
    public double netOutGoingLongWaveRadiation
    {
        get { return this._netOutGoingLongWaveRadiation; }
        set { this._netOutGoingLongWaveRadiation= value; } 
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
    /// Gets and sets the net Radiation in Equivalent Evaporation
    /// </summary>
    [Description("net Radiation in Equivalent Evaporation")] 
    [Units("g m-2 d-1")] 
    public double netRadiationEquivalentEvaporation
    {
        get { return this._netRadiationEquivalentEvaporation; }
        set { this._netRadiationEquivalentEvaporation= value; } 
    }

}