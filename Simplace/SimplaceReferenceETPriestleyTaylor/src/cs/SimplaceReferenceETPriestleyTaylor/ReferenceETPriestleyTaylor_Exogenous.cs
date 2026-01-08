using System;
using System.Collections.Generic;

public class ReferenceETPriestleyTaylor_Exogenous 
{
    private double _iTMin;
    private double _iNetRadiation;
    private double _iTMax;
    
    /// <summary>
    /// Constructor of the ReferenceETPriestleyTaylor_Exogenous component")
    /// </summary>  
    public ReferenceETPriestleyTaylor_Exogenous() { }
    
    
    public ReferenceETPriestleyTaylor_Exogenous(ReferenceETPriestleyTaylor_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            iTMin = toCopy.iTMin;
            iNetRadiation = toCopy.iNetRadiation;
            iTMax = toCopy.iTMax;
        }
    }
    public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }
    public double iNetRadiation
    {
        get { return this._iNetRadiation; }
        set { this._iNetRadiation= value; } 
    }
    public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }
}