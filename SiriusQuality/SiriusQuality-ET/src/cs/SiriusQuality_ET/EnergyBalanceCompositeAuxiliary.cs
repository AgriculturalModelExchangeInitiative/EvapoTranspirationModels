using System;
using System.Collections.Generic;

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
    /// Constructor of the EnergyBalanceCompositeAuxiliary component")
    /// </summary>  
    public EnergyBalanceCompositeAuxiliary() { }
    
    
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
    public double maxTair
    {
        get { return this._maxTair; }
        set { this._maxTair= value; } 
    }
    public double minTair
    {
        get { return this._minTair; }
        set { this._minTair= value; } 
    }
    public double vaporPressure
    {
        get { return this._vaporPressure; }
        set { this._vaporPressure= value; } 
    }
    public double extraSolarRadiation
    {
        get { return this._extraSolarRadiation; }
        set { this._extraSolarRadiation= value; } 
    }
    public double solarRadiation
    {
        get { return this._solarRadiation; }
        set { this._solarRadiation= value; } 
    }
    public double plantHeight
    {
        get { return this._plantHeight; }
        set { this._plantHeight= value; } 
    }
    public double wind
    {
        get { return this._wind; }
        set { this._wind= value; } 
    }
    public double hslope
    {
        get { return this._hslope; }
        set { this._hslope= value; } 
    }
    public double VPDair
    {
        get { return this._VPDair; }
        set { this._VPDair= value; } 
    }
    public double netOutGoingLongWaveRadiation
    {
        get { return this._netOutGoingLongWaveRadiation; }
        set { this._netOutGoingLongWaveRadiation= value; } 
    }
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }
    public double netRadiationEquivalentEvaporation
    {
        get { return this._netRadiationEquivalentEvaporation; }
        set { this._netRadiationEquivalentEvaporation= value; } 
    }
}