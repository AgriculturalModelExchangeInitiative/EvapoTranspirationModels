using System;
using System.Collections.Generic;

public class EnergyBalanceCompositeRate 
{
    private double _evapoTranspirationPriestlyTaylor;
    private double _evapoTranspirationPenman;
    
    /// <summary>
    /// Constructor of the EnergyBalanceCompositeRate component")
    /// </summary>  
    public EnergyBalanceCompositeRate() { }
    
    
    public EnergyBalanceCompositeRate(EnergyBalanceCompositeRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
        }
    }
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }
    public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }
}