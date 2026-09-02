import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class EnergyBalanceCompositeAuxiliary
{
    private double maxTair;
    private double minTair;
    private double vaporPressure;
    private double extraSolarRadiation;
    private double solarRadiation;
    private double plantHeight;
    private double wind;
    private double hslope;
    private double VPDair;
    private double netOutGoingLongWaveRadiation;
    private double netRadiation;
    private double netRadiationEquivalentEvaporation;
    
    public EnergyBalanceCompositeAuxiliary() { }
    
    public EnergyBalanceCompositeAuxiliary(EnergyBalanceCompositeAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.maxTair = toCopy.getmaxTair();
            this.minTair = toCopy.getminTair();
            this.vaporPressure = toCopy.getvaporPressure();
            this.extraSolarRadiation = toCopy.getextraSolarRadiation();
            this.solarRadiation = toCopy.getsolarRadiation();
            this.plantHeight = toCopy.getplantHeight();
            this.wind = toCopy.getwind();
            this.hslope = toCopy.gethslope();
            this.VPDair = toCopy.getVPDair();
            this.netOutGoingLongWaveRadiation = toCopy.getnetOutGoingLongWaveRadiation();
            this.netRadiation = toCopy.getnetRadiation();
            this.netRadiation = toCopy.getnetRadiation();
            this.netRadiationEquivalentEvaporation = toCopy.getnetRadiationEquivalentEvaporation();
        }
    }
    public double getmaxTair()
    { return maxTair; }

    public void setmaxTair(double _maxTair)
    { this.maxTair= _maxTair; } 
    
    public double getminTair()
    { return minTair; }

    public void setminTair(double _minTair)
    { this.minTair= _minTair; } 
    
    public double getvaporPressure()
    { return vaporPressure; }

    public void setvaporPressure(double _vaporPressure)
    { this.vaporPressure= _vaporPressure; } 
    
    public double getextraSolarRadiation()
    { return extraSolarRadiation; }

    public void setextraSolarRadiation(double _extraSolarRadiation)
    { this.extraSolarRadiation= _extraSolarRadiation; } 
    
    public double getsolarRadiation()
    { return solarRadiation; }

    public void setsolarRadiation(double _solarRadiation)
    { this.solarRadiation= _solarRadiation; } 
    
    public double getplantHeight()
    { return plantHeight; }

    public void setplantHeight(double _plantHeight)
    { this.plantHeight= _plantHeight; } 
    
    public double getwind()
    { return wind; }

    public void setwind(double _wind)
    { this.wind= _wind; } 
    
    public double gethslope()
    { return hslope; }

    public void sethslope(double _hslope)
    { this.hslope= _hslope; } 
    
    public double getVPDair()
    { return VPDair; }

    public void setVPDair(double _VPDair)
    { this.VPDair= _VPDair; } 
    
    public double getnetOutGoingLongWaveRadiation()
    { return netOutGoingLongWaveRadiation; }

    public void setnetOutGoingLongWaveRadiation(double _netOutGoingLongWaveRadiation)
    { this.netOutGoingLongWaveRadiation= _netOutGoingLongWaveRadiation; } 
    
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    public double getnetRadiationEquivalentEvaporation()
    { return netRadiationEquivalentEvaporation; }

    public void setnetRadiationEquivalentEvaporation(double _netRadiationEquivalentEvaporation)
    { this.netRadiationEquivalentEvaporation= _netRadiationEquivalentEvaporation; } 
    
}