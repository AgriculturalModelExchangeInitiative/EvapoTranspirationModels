using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the pet component
/// </summary>
public class PetState
{
    private double _pet;

    /// <summary>
    /// Constructor PetState domain class
    /// </summary>
    public PetState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PetState(PetState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            pet = toCopy.pet;
        }
    }

    /// <summary>
    /// Gets and sets the Potential evapotranspiration
    /// </summary>
    [Description("Potential evapotranspiration")] 
    [Units("mm day-1")] 
    public double pet
    {
        get { return this._pet; }
        set { this._pet= value; } 
    }

}