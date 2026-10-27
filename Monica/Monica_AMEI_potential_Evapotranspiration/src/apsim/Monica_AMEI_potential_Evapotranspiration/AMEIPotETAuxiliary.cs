using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the AMEIPotET component
/// </summary>
public class AMEIPotETAuxiliary
{
    private double _vapor_pressure;
    private double _saturated_vapor_pressure;
    private double _stomata_resistance;
    private double _net_radiation;
    private double _reference_evapotranspiration;
    private double _potential_evapotranspiration;
    private double _saturation_vapor_pressure_deficit;

    /// <summary>
    /// Constructor AMEIPotETAuxiliary domain class
    /// </summary>
    public AMEIPotETAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIPotETAuxiliary(AMEIPotETAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            vapor_pressure = toCopy.vapor_pressure;
            saturated_vapor_pressure = toCopy.saturated_vapor_pressure;
            stomata_resistance = toCopy.stomata_resistance;
            net_radiation = toCopy.net_radiation;
            reference_evapotranspiration = toCopy.reference_evapotranspiration;
            potential_evapotranspiration = toCopy.potential_evapotranspiration;
            saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
        }
    }

    /// <summary>
    /// Gets and sets the vapor pressure
    /// </summary>
    [Description("vapor pressure")] 
    [Units("kPa")] 
    public double vapor_pressure
    {
        get { return this._vapor_pressure; }
        set { this._vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the saturated vapor pressure
    /// </summary>
    [Description("saturated vapor pressure")] 
    [Units("kPa")] 
    public double saturated_vapor_pressure
    {
        get { return this._saturated_vapor_pressure; }
        set { this._saturated_vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the stomata resistance (FAO default value is 100)
    /// </summary>
    [Description("stomata resistance (FAO default value is 100)")] 
    [Units("s/m")] 
    public double stomata_resistance
    {
        get { return this._stomata_resistance; }
        set { this._stomata_resistance= value; } 
    }

    /// <summary>
    /// Gets and sets the net radiation
    /// </summary>
    [Description("net radiation")] 
    [Units("MJ/m2")] 
    public double net_radiation
    {
        get { return this._net_radiation; }
        set { this._net_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the reference evapotranspiration (ET0)
    /// </summary>
    [Description("reference evapotranspiration (ET0)")] 
    [Units("mm")] 
    public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }

    /// <summary>
    /// Gets and sets the the potential evapotranspiration
    /// </summary>
    [Description("the potential evapotranspiration")] 
    [Units("mm")] 
    public double potential_evapotranspiration
    {
        get { return this._potential_evapotranspiration; }
        set { this._potential_evapotranspiration= value; } 
    }

    /// <summary>
    /// Gets and sets the saturation vapor pressure deficit
    /// </summary>
    [Description("saturation vapor pressure deficit")] 
    [Units("kPa")] 
    public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }

}