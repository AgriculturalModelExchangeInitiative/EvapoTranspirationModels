using System;
using System.Collections.Generic;
public class EnergyBalanceState
{
    private int _ih;
    private double _diffusionLimitedEvaporation;
    private double _conductance;
    private double _minCanopyTemperature;
    private double _maxCanopyTemperature;



    public EnergyBalanceState() { }

    public EnergyBalanceState(EnergyBalanceState toCopy, bool copyAll)
    {
        _ih = toCopy._ih;
        diffusionLimitedEvaporation = toCopy.diffusionLimitedEvaporation;
        conductance = toCopy.conductance;
        minCanopyTemperature = toCopy.minCanopyTemperature;
        maxCanopyTemperature = toCopy.maxCanopyTemperature;

    }

    public int ih
    {
        get
        {
            return this._ih;
        }
        set
        {
            this._ih = value;
        }
    }


    public double diffusionLimitedEvaporation
    {
        get { return this._diffusionLimitedEvaporation; }
        set { this._diffusionLimitedEvaporation = value; }
    }
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance = value; }
    }
    public double minCanopyTemperature
    {
        get { return this._minCanopyTemperature; }
        set { this._minCanopyTemperature = value; }
    }
    public double maxCanopyTemperature
    {
        get { return this._maxCanopyTemperature; }
        set { this._maxCanopyTemperature = value; }
    }
}
