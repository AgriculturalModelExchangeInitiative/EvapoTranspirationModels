import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETPriestleyTaylor_Exogenous
{
    private double iTMin;
    private double iNetRadiation;
    private double iTMax;
    
    public ReferenceETPriestleyTaylor_Exogenous() { }
    
    public ReferenceETPriestleyTaylor_Exogenous(ReferenceETPriestleyTaylor_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.iTMin = toCopy.getiTMin();
            this.iNetRadiation = toCopy.getiNetRadiation();
            this.iTMax = toCopy.getiTMax();
        }
    }
    public double getiTMin()
    { return iTMin; }

    public void setiTMin(double _iTMin)
    { this.iTMin= _iTMin; } 
    
    public double getiNetRadiation()
    { return iNetRadiation; }

    public void setiNetRadiation(double _iNetRadiation)
    { this.iNetRadiation= _iNetRadiation; } 
    
    public double getiTMax()
    { return iTMax; }

    public void setiTMax(double _iTMax)
    { this.iTMax= _iTMax; } 
    
}