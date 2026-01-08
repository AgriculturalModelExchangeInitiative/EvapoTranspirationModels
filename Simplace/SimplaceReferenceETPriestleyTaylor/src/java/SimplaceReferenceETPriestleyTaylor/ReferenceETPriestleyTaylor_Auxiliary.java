import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETPriestleyTaylor_Auxiliary
{
    private double ReferenceCropEvapotranspiration;
    
    public ReferenceETPriestleyTaylor_Auxiliary() { }
    
    public ReferenceETPriestleyTaylor_Auxiliary(ReferenceETPriestleyTaylor_Auxiliary toCopy, boolean copyAll) // copy constructor 
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