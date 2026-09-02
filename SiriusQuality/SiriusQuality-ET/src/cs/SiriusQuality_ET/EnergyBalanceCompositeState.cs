using System;
using System.Collections.Generic;
public class EnergyBalanceCompositeState 
{
    private int _ih;
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
            conductance = toCopy.conductance;
        }
    }
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }
}