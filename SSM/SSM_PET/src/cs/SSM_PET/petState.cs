using System;
using System.Collections.Generic;
public class PetState 
{
    private double _pet;
    
    /// <summary>
    /// Constructor of the petState component")
    /// </summary>  
    public petState() { }
    
    
    public petState(petState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            pet = toCopy.pet;
        }
    }
    public double pet
    {
        get { return this._pet; }
        set { this._pet= value; } 
    }
}