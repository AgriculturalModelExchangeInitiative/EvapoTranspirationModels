using System;
using System.Collections.Generic;

public class EnergyBalanceRate
{
    private double _evapoTranspirationPriestlyTaylor;
    private double _evapoTranspirationPenman;

    public EnergyBalanceRate() { }


    public EnergyBalanceRate(EnergyBalanceRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {

            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
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

}