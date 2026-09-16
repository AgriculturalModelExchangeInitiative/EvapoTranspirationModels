using System;
using System.Collections.Generic;

public class PotentialET_PTRate 
{
    private double _evapoTranspirationPriestlyTaylor;
    
    /// <summary>
    /// Constructor of the PotentialET_PTRate component")
    /// </summary>  
    public PotentialET_PTRate() { }
    
    
    public PotentialET_PTRate(PotentialET_PTRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
        }
    }
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }
}