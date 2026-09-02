using System;
using System.Collections.Generic;
public class EnergyBalanceCompositeState 
{
    private int _ih;
    private double _maxCanopyTemperature;
    private double _diffusionLimitedEvaporation;
    private double _minCanopyTemperature;
    private double _conductance;
    
    /// <summary>
    /// Constructor of the EnergyBalanceCompositeState component")
    /// </summary>  
    public EnergyBalanceCompositeState() { }
    
    
    public EnergyBalanceCompositeState(EnergyBalanceCompositeState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            ih = toCopy.ih;
            maxCanopyTemperature = toCopy.maxCanopyTemperature;
            diffusionLimitedEvaporation = toCopy.diffusionLimitedEvaporation;
            minCanopyTemperature = toCopy.minCanopyTemperature;
            conductance = toCopy.conductance;
        }
    }
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    public double maxCanopyTemperature
    {
        get { return this._maxCanopyTemperature; }
        set { this._maxCanopyTemperature= value; } 
    }
    public double diffusionLimitedEvaporation
    {
        get { return this._diffusionLimitedEvaporation; }
        set { this._diffusionLimitedEvaporation= value; } 
    }
    public double minCanopyTemperature
    {
        get { return this._minCanopyTemperature; }
        set { this._minCanopyTemperature= value; } 
    }
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }
}