using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// rate variables class of the EnergyBalanceComposite component
/// </summary>
public class EnergyBalanceCompositeRate
{
    private double _evapoTranspirationPriestlyTaylor;
    private double _evapoTranspirationPenman;

    /// <summary>
    /// Constructor EnergyBalanceCompositeRate domain class
    /// </summary>
    public EnergyBalanceCompositeRate() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public EnergyBalanceCompositeRate(EnergyBalanceCompositeRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
        }
    }

    /// <summary>
    /// Gets and sets the evapoTranspiration of Priestly Taylor
    /// </summary>
    [Description("evapoTranspiration of Priestly Taylor")] 
    [Units("g m-2 d-1")] 
    public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }

    /// <summary>
    /// Gets and sets the evapoTranspiration of Penman Monteith
    /// </summary>
    [Description("evapoTranspiration of Penman Monteith")] 
    [Units("g m-2 d-1")] 
    public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }

}