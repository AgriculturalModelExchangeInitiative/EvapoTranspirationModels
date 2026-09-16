using System;
using System.Collections.Generic;

public class PotentialET_PTAuxiliary 
{
    private double _solarRadiation;
    private double _hslope;
    private double _netRadiation;
    
    /// <summary>
    /// Constructor of the PotentialET_PTAuxiliary component")
    /// </summary>  
    public PotentialET_PTAuxiliary() { }
    
    
    public PotentialET_PTAuxiliary(PotentialET_PTAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            solarRadiation = toCopy.solarRadiation;
            hslope = toCopy.hslope;
            netRadiation = toCopy.netRadiation;
        }
    }
    public double solarRadiation
    {
        get { return this._solarRadiation; }
        set { this._solarRadiation= value; } 
    }
    public double hslope
    {
        get { return this._hslope; }
        set { this._hslope= value; } 
    }
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }
}