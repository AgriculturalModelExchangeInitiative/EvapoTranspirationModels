import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class PotentialET_PenmanAuxiliary
{
    private double netRadiation;
    private double solarRadiation;
    private double hslope;
    private double VPDair;
    private double conductance;
    
    public PotentialET_PenmanAuxiliary() { }
    
    public PotentialET_PenmanAuxiliary(PotentialET_PenmanAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.netRadiation = toCopy.getnetRadiation();
            this.solarRadiation = toCopy.getsolarRadiation();
            this.hslope = toCopy.gethslope();
            this.VPDair = toCopy.getVPDair();
            this.conductance = toCopy.getconductance();
        }
    }
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    public double getsolarRadiation()
    { return solarRadiation; }

    public void setsolarRadiation(double _solarRadiation)
    { this.solarRadiation= _solarRadiation; } 
    
    public double gethslope()
    { return hslope; }

    public void sethslope(double _hslope)
    { this.hslope= _hslope; } 
    
    public double getVPDair()
    { return VPDair; }

    public void setVPDair(double _VPDair)
    { this.VPDair= _VPDair; } 
    
    public double getconductance()
    { return conductance; }

    public void setconductance(double _conductance)
    { this.conductance= _conductance; } 
    
}