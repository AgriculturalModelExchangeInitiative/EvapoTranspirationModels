import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class petExogenous
{
    private double tmax;
    private double tmin;
    private double srad;
    
    public petExogenous() { }
    
    public petExogenous(petExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.tmax = toCopy.gettmax();
            this.tmin = toCopy.gettmin();
            this.srad = toCopy.getsrad();
        }
    }
    public double gettmax()
    { return tmax; }

    public void settmax(double _tmax)
    { this.tmax= _tmax; } 
    
    public double gettmin()
    { return tmin; }

    public void settmin(double _tmin)
    { this.tmin= _tmin; } 
    
    public double getsrad()
    { return srad; }

    public void setsrad(double _srad)
    { this.srad= _srad; } 
    
}