using System;
using System.Collections.Generic;

public class PotentialET_PenmanAuxiliary 
{
    private double _netRadiation;
    private double _solarRadiation;
    private double _hslope;
    private double _VPDair;
    private double _conductance;
    
    /// <summary>
    /// Constructor of the PotentialET_PenmanAuxiliary component")
    /// </summary>  
    public PotentialET_PenmanAuxiliary() { }
    
    
    public PotentialET_PenmanAuxiliary(PotentialET_PenmanAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            netRadiation = toCopy.netRadiation;
            solarRadiation = toCopy.solarRadiation;
            hslope = toCopy.hslope;
            VPDair = toCopy.VPDair;
            conductance = toCopy.conductance;
        }
    }
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
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
    public double VPDair
    {
        get { return this._VPDair; }
        set { this._VPDair= value; } 
    }
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }
}