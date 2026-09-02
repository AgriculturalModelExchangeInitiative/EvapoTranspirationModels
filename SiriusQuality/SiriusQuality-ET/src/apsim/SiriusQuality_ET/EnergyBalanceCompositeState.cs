using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the EnergyBalanceComposite component
/// </summary>
public class EnergyBalanceCompositeState
{
    private int _ih;
    private double _conductance;

    /// <summary>
    /// Constructor EnergyBalanceCompositeState domain class
    /// </summary>
    public EnergyBalanceCompositeState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public EnergyBalanceCompositeState(EnergyBalanceCompositeState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            ih = toCopy.ih;
            conductance = toCopy.conductance;
        }
    }

    /// <summary>
    /// Gets and sets the hour of the day if the component is hourly, -999 if the component is daily
    /// </summary>
    [Description("hour of the day if the component is hourly, -999 if the component is daily")] 
    [Units("")] 
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }

    /// <summary>
    /// Gets and sets the the boundary layer conductance
    /// </summary>
    [Description("the boundary layer conductance")] 
    [Units("m/d")] 
    public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }

}