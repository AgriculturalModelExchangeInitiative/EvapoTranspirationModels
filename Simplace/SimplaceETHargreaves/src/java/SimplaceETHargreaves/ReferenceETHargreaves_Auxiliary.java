import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETHargreaves_Auxiliary
{
    private double ReferenceCropEvapotranspiration;
    
    public ReferenceETHargreaves_Auxiliary() { }
    
    public ReferenceETHargreaves_Auxiliary(ReferenceETHargreaves_Auxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.ReferenceCropEvapotranspiration = toCopy.getReferenceCropEvapotranspiration();
        }
    }
    public double getReferenceCropEvapotranspiration()
    { return ReferenceCropEvapotranspiration; }

    public void setReferenceCropEvapotranspiration(double _ReferenceCropEvapotranspiration)
    { this.ReferenceCropEvapotranspiration= _ReferenceCropEvapotranspiration; } 
    
}