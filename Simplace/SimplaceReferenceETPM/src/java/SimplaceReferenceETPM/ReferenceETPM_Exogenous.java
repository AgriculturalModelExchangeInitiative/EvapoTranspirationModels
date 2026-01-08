import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETPM_Exogenous
{
    private double iNetRadiation;
    private double iActualVapourPressure;
    private double iTMax;
    private double iTMin;
    private double iWindspeed;
    
    public ReferenceETPM_Exogenous() { }
    
    public ReferenceETPM_Exogenous(ReferenceETPM_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.iNetRadiation = toCopy.getiNetRadiation();
            this.iActualVapourPressure = toCopy.getiActualVapourPressure();
            this.iTMax = toCopy.getiTMax();
            this.iTMin = toCopy.getiTMin();
            this.iWindspeed = toCopy.getiWindspeed();
        }
    }
    public double getiNetRadiation()
    { return iNetRadiation; }

    public void setiNetRadiation(double _iNetRadiation)
    { this.iNetRadiation= _iNetRadiation; } 
    
    public double getiActualVapourPressure()
    { return iActualVapourPressure; }

    public void setiActualVapourPressure(double _iActualVapourPressure)
    { this.iActualVapourPressure= _iActualVapourPressure; } 
    
    public double getiTMax()
    { return iTMax; }

    public void setiTMax(double _iTMax)
    { this.iTMax= _iTMax; } 
    
    public double getiTMin()
    { return iTMin; }

    public void setiTMin(double _iTMin)
    { this.iTMin= _iTMin; } 
    
    public double getiWindspeed()
    { return iWindspeed; }

    public void setiWindspeed(double _iWindspeed)
    { this.iWindspeed= _iWindspeed; } 
    
}