import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class PotentialET_PTAuxiliary
{
    private double solarRadiation;
    private double hslope;
    private double netRadiation;
    
    public PotentialET_PTAuxiliary() { }
    
    public PotentialET_PTAuxiliary(PotentialET_PTAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.solarRadiation = toCopy.getsolarRadiation();
            this.hslope = toCopy.gethslope();
            this.netRadiation = toCopy.getnetRadiation();
        }
    }
    public double getsolarRadiation()
    { return solarRadiation; }

    public void setsolarRadiation(double _solarRadiation)
    { this.solarRadiation= _solarRadiation; } 
    
    public double gethslope()
    { return hslope; }

    public void sethslope(double _hslope)
    { this.hslope= _hslope; } 
    
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
}