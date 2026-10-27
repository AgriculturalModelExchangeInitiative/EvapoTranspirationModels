using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the ET component
/// </summary>
public class ETState
{
    private double _surface_water_storage;
    private double _evaporated_from_surface;
    private double _actual_evaporation;
    private double _actual_transpiration;
    private double[] _soil_moisture;
    private double[] _evaporation;
    private double[] _transpiration;
    private double[] _evapotranspiration;
    private double _actual_evapotranspiration;

    /// <summary>
    /// Constructor ETState domain class
    /// </summary>
    public ETState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ETState(ETState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            surface_water_storage = toCopy.surface_water_storage;
            evaporated_from_surface = toCopy.evaporated_from_surface;
            actual_evaporation = toCopy.actual_evaporation;
            actual_transpiration = toCopy.actual_transpiration;
            soil_moisture = new double[toCopy.soil_moisture.Length];
        for (int i = 0; i < toCopy.soil_moisture.Length; i++)
            { soil_moisture[i] = toCopy.soil_moisture[i]; }
    
            evaporation = new double[toCopy.evaporation.Length];
        for (int i = 0; i < toCopy.evaporation.Length; i++)
            { evaporation[i] = toCopy.evaporation[i]; }
    
            transpiration = new double[toCopy.transpiration.Length];
        for (int i = 0; i < toCopy.transpiration.Length; i++)
            { transpiration[i] = toCopy.transpiration[i]; }
    
            evapotranspiration = new double[toCopy.evapotranspiration.Length];
        for (int i = 0; i < toCopy.evapotranspiration.Length; i++)
            { evapotranspiration[i] = toCopy.evapotranspiration[i]; }
    
            actual_evapotranspiration = toCopy.actual_evapotranspiration;
        }
    }

    /// <summary>
    /// Gets and sets the Simulates a virtual layer that contains the surface water
    /// </summary>
    [Description("Simulates a virtual layer that contains the surface water")] 
    [Units("mm")] 
    public double surface_water_storage
    {
        get { return this._surface_water_storage; }
        set { this._surface_water_storage= value; } 
    }

    /// <summary>
    /// Gets and sets the evaporated_from_surface
    /// </summary>
    [Description("evaporated_from_surface")] 
    [Units("mm")] 
    public double evaporated_from_surface
    {
        get { return this._evaporated_from_surface; }
        set { this._evaporated_from_surface= value; } 
    }

    /// <summary>
    /// Gets and sets the actual evaporation
    /// </summary>
    [Description("actual evaporation")] 
    [Units("mm")] 
    public double actual_evaporation
    {
        get { return this._actual_evaporation; }
        set { this._actual_evaporation= value; } 
    }

    /// <summary>
    /// Gets and sets the actual transpiration
    /// </summary>
    [Description("actual transpiration")] 
    [Units("mm")] 
    public double actual_transpiration
    {
        get { return this._actual_transpiration; }
        set { this._actual_transpiration= value; } 
    }

    /// <summary>
    /// Gets and sets the soil moisture array
    /// </summary>
    [Description("soil moisture array")] 
    [Units("m3/m3")] 
    public double[] soil_moisture
    {
        get { return this._soil_moisture; }
        set { this._soil_moisture= value; } 
    }

    /// <summary>
    /// Gets and sets the evaporation array
    /// </summary>
    [Description("evaporation array")] 
    [Units("mm")] 
    public double[] evaporation
    {
        get { return this._evaporation; }
        set { this._evaporation= value; } 
    }

    /// <summary>
    /// Gets and sets the transpiration array
    /// </summary>
    [Description("transpiration array")] 
    [Units("mm")] 
    public double[] transpiration
    {
        get { return this._transpiration; }
        set { this._transpiration= value; } 
    }

    /// <summary>
    /// Gets and sets the evapotranspiration array
    /// </summary>
    [Description("evapotranspiration array")] 
    [Units("mm")] 
    public double[] evapotranspiration
    {
        get { return this._evapotranspiration; }
        set { this._evapotranspiration= value; } 
    }

    /// <summary>
    /// Gets and sets the actual evapotranspiration
    /// </summary>
    [Description("actual evapotranspiration")] 
    [Units("mm")] 
    public double actual_evapotranspiration
    {
        get { return this._actual_evapotranspiration; }
        set { this._actual_evapotranspiration= value; } 
    }

}