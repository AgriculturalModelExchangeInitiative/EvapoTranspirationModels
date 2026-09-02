using System;
using System.Collections.Generic;
public class EnergyBalanceState
{
    private int _ih;
    private double _conductance;



    public EnergyBalanceState() { }

    public EnergyBalanceState(EnergyBalanceState toCopy, bool copyAll)
    {
        _ih = toCopy._ih;
        conductance = toCopy.conductance;

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


    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance = value; }
    }

}
