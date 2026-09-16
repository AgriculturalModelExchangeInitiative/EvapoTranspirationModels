using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// rate variables class of the PotentialET_PT component
/// </summary>
public class PotentialET_PTRate
{
    private double _evapoTranspirationPriestlyTaylor;

    /// <summary>
    /// Constructor PotentialET_PTRate domain class
    /// </summary>
    public PotentialET_PTRate() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PTRate(PotentialET_PTRate toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
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

}