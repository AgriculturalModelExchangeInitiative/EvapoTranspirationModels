using System;
using System.Collections.Generic;

public class ReferenceETPM_Auxiliary 
{
    private double _ReferenceCropEvapotranspiration;
    
    /// <summary>
    /// Constructor of the ReferenceETPM_Auxiliary component")
    /// </summary>  
    public ReferenceETPM_Auxiliary() { }
    
    
    public ReferenceETPM_Auxiliary(ReferenceETPM_Auxiliary toCopy, bool copyAll) // copy constructor 
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