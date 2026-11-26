using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the AMEIRefET component
/// </summary>
public class AMEIRefETAuxiliary
{
    private double _stomata_resistance;
    private double _net_radiation;
    private double _saturation_vapor_pressure_deficit;
    private double _reference_evapotranspiration;

    /// <summary>
    /// Constructor AMEIRefETAuxiliary domain class
    /// </summary>
    public AMEIRefETAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIRefETAuxiliary(AMEIRefETAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            stomata_resistance = toCopy.stomata_resistance;
            net_radiation = toCopy.net_radiation;
            saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
            reference_evapotranspiration = toCopy.reference_evapotranspiration;
        }
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
    /// Gets and sets the saturation_vapor_pressure_deficit
    /// </summary>
    [Description("saturation_vapor_pressure_deficit")] 
    [Units("kPa")] 
    public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
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

}