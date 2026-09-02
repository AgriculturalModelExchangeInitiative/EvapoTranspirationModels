using System;
using System.Collections.Generic;

public class EnergyBalanceRate
{
    private double _evapoTranspirationPriestlyTaylor;
    private double _evapoTranspirationPenman;
    private double _evapoTranspiration;
    private double _potentialTranspiration;
    private double _soilHeatFlux;
    private double _cropHeatFlux;

    public EnergyBalanceRate() { }


    public EnergyBalanceRate(EnergyBalanceRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {

            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
            evapoTranspiration = toCopy.evapoTranspiration;
            potentialTranspiration = toCopy.potentialTranspiration;
            soilHeatFlux = toCopy.soilHeatFlux;
            cropHeatFlux = toCopy.cropHeatFlux;
        }
    }
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor = value; }
    }
    public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman = value; }
    }
    public double evapoTranspiration
    {
        get { return this._evapoTranspiration; }
        set { this._evapoTranspiration = value; }
    }
    public double potentialTranspiration
    {
        get { return this._potentialTranspiration; }
        set { this._potentialTranspiration = value; }
    }
    public double soilHeatFlux
    {
        get { return this._soilHeatFlux; }
        set { this._soilHeatFlux = value; }
    }
    public double cropHeatFlux
    {
        get { return this._cropHeatFlux; }
        set { this._cropHeatFlux = value; }
    }
}