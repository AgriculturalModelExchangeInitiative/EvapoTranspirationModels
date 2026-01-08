using System;
using System.Collections.Generic;

public class ReferenceETPM_Exogenous 
{
    private double _iNetRadiation;
    private double _iActualVapourPressure;
    private double _iTMax;
    private double _iTMin;
    private double _iWindspeed;
    
    /// <summary>
    /// Constructor of the ReferenceETPM_Exogenous component")
    /// </summary>  
    public ReferenceETPM_Exogenous() { }
    
    
    public ReferenceETPM_Exogenous(ReferenceETPM_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            iNetRadiation = toCopy.iNetRadiation;
            iActualVapourPressure = toCopy.iActualVapourPressure;
            iTMax = toCopy.iTMax;
            iTMin = toCopy.iTMin;
            iWindspeed = toCopy.iWindspeed;
        }
    }
    public double iNetRadiation
    {
        get { return this._iNetRadiation; }
        set { this._iNetRadiation= value; } 
    }
    public double iActualVapourPressure
    {
        get { return this._iActualVapourPressure; }
        set { this._iActualVapourPressure= value; } 
    }
    public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }
    public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }
    public double iWindspeed
    {
        get { return this._iWindspeed; }
        set { this._iWindspeed= value; } 
    }
}