using System;
using System.Collections.Generic;

public class PotentialET_PenmanRate 
{
    private double _evapoTranspirationPenman;
    private double _evapoTranspirationPriestlyTaylor;
    
    /// <summary>
    /// Constructor of the PotentialET_PenmanRate component")
    /// </summary>  
    public PotentialET_PenmanRate() { }
    
    
    public PotentialET_PenmanRate(PotentialET_PenmanRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
        }
    }
    public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }
}