using System;
using System.Collections.Generic;

public class PetExogenous 
{
    private double _tmax;
    private double _tmin;
    private double _srad;
    
    /// <summary>
    /// Constructor of the petExogenous component")
    /// </summary>  
    public petExogenous() { }
    
    
    public petExogenous(petExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            tmax = toCopy.tmax;
            tmin = toCopy.tmin;
            srad = toCopy.srad;
        }
    }
    public double tmax
    {
        get { return this._tmax; }
        set { this._tmax= value; } 
    }
    public double tmin
    {
        get { return this._tmin; }
        set { this._tmin= value; } 
    }
    public double srad
    {
        get { return this._srad; }
        set { this._srad= value; } 
    }
}