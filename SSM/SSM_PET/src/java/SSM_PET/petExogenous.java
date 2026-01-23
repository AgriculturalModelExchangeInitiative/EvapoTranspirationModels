import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class petExogenous
{
    private double tmax;
    private double tmin;
    private double srad;
    private double etlai;
    
    public petExogenous() { }
    
    public petExogenous(petExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.tmax = toCopy.gettmax();
            this.tmin = toCopy.gettmin();
            this.srad = toCopy.getsrad();
            this.etlai = toCopy.getetlai();
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
    
    public double getetlai()
    { return etlai; }

    public void setetlai(double _etlai)
    { this.etlai= _etlai; } 
    
}