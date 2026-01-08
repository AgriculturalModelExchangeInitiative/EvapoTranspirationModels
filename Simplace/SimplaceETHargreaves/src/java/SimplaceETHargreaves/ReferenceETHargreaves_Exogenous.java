import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ReferenceETHargreaves_Exogenous
{
    private double iTMax;
    private double iSolarRadiation;
    private double iTMin;
    
    public ReferenceETHargreaves_Exogenous() { }
    
    public ReferenceETHargreaves_Exogenous(ReferenceETHargreaves_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.iTMax = toCopy.getiTMax();
            this.iSolarRadiation = toCopy.getiSolarRadiation();
            this.iTMin = toCopy.getiTMin();
        }
    }
    public double getiTMax()
    { return iTMax; }

    public void setiTMax(double _iTMax)
    { this.iTMax= _iTMax; } 
    
    public double getiSolarRadiation()
    { return iSolarRadiation; }

    public void setiSolarRadiation(double _iSolarRadiation)
    { this.iSolarRadiation= _iSolarRadiation; } 
    
    public double getiTMin()
    { return iTMin; }

    public void setiTMin(double _iTMin)
    { this.iTMin= _iTMin; } 
    
}