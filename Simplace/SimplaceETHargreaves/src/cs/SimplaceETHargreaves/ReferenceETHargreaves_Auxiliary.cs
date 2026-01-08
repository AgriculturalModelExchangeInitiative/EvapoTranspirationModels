using System;
using System.Collections.Generic;

public class ReferenceETHargreaves_Auxiliary 
{
    private double _ReferenceCropEvapotranspiration;
    
    /// <summary>
    /// Constructor of the ReferenceETHargreaves_Auxiliary component")
    /// </summary>  
    public ReferenceETHargreaves_Auxiliary() { }
    
    
    public ReferenceETHargreaves_Auxiliary(ReferenceETHargreaves_Auxiliary toCopy, bool copyAll) // copy constructor 
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