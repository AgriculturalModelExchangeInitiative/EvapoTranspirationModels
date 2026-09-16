using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// rate variables class of the PotentialET_Penman component
/// </summary>
public class PotentialET_PenmanRate
{
    private double _evapoTranspirationPenman;
    private double _evapoTranspirationPriestlyTaylor;

    /// <summary>
    /// Constructor PotentialET_PenmanRate domain class
    /// </summary>
    public PotentialET_PenmanRate() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PenmanRate(PotentialET_PenmanRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
        }
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

}