using System;
using System.Collections.Generic;

public class EnergyBalanceCompositeRate 
{
    private double _evapoTranspirationPriestlyTaylor;
    private double _evapoTranspirationPenman;
    private double _evapoTranspiration;
    private double _soilHeatFlux;
    private double _potentialTranspiration;
    private double _cropHeatFlux;
    
    /// <summary>
    /// Constructor of the EnergyBalanceCompositeRate component")
    /// </summary>  
    public EnergyBalanceCompositeRate() { }
    
    
    public EnergyBalanceCompositeRate(EnergyBalanceCompositeRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
            evapoTranspiration = toCopy.evapoTranspiration;
            soilHeatFlux = toCopy.soilHeatFlux;
            potentialTranspiration = toCopy.potentialTranspiration;
            cropHeatFlux = toCopy.cropHeatFlux;
        }
    }
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }
    public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }
    public double evapoTranspiration
    {
        get { return this._evapoTranspiration; }
        set { this._evapoTranspiration= value; } 
    }
    public double soilHeatFlux
    {
        get { return this._soilHeatFlux; }
        set { this._soilHeatFlux= value; } 
    }
    public double potentialTranspiration
    {
        get { return this._potentialTranspiration; }
        set { this._potentialTranspiration= value; } 
    }
    public double cropHeatFlux
    {
        get { return this._cropHeatFlux; }
        set { this._cropHeatFlux= value; } 
    }
}