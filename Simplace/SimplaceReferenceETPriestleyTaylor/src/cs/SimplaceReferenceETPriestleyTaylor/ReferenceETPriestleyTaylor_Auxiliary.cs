using System;
using System.Collections.Generic;

public class ReferenceETPriestleyTaylor_Auxiliary 
{
    private double _ReferenceCropEvapotranspiration;
    
    /// <summary>
    /// Constructor of the ReferenceETPriestleyTaylor_Auxiliary component")
    /// </summary>  
    public ReferenceETPriestleyTaylor_Auxiliary() { }
    
    
    public ReferenceETPriestleyTaylor_Auxiliary(ReferenceETPriestleyTaylor_Auxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            ReferenceCropEvapotranspiration = toCopy.ReferenceCropEvapotranspiration;
        }
    }
    public double ReferenceCropEvapotranspiration
    {
        get { return this._ReferenceCropEvapotranspiration; }
        set { this._ReferenceCropEvapotranspiration= value; } 
    }
}