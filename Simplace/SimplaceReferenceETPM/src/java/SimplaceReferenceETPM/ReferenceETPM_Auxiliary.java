import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETPM_Auxiliary
{
    private double ReferenceCropEvapotranspiration;
    
    public ReferenceETPM_Auxiliary() { }
    
    public ReferenceETPM_Auxiliary(ReferenceETPM_Auxiliary toCopy, boolean copyAll) // copy constructor 
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