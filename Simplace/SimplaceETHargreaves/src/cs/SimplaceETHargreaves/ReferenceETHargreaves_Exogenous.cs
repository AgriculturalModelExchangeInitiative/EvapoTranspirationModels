using System;
using System.Collections.Generic;

public class ReferenceETHargreaves_Exogenous 
{
    private double _iTMax;
    private double _iSolarRadiation;
    private double _iTMin;
    
    /// <summary>
    /// Constructor of the ReferenceETHargreaves_Exogenous component")
    /// </summary>  
    public ReferenceETHargreaves_Exogenous() { }
    
    
    public ReferenceETHargreaves_Exogenous(ReferenceETHargreaves_Exogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            iTMax = toCopy.iTMax;
            iSolarRadiation = toCopy.iSolarRadiation;
            iTMin = toCopy.iTMin;
        }
    }
    public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }
    public double iSolarRadiation
    {
        get { return this._iSolarRadiation; }
        set { this._iSolarRadiation= value; } 
    }
    public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }
}