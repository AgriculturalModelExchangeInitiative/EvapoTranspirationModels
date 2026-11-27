using System;
using System.Collections.Generic;

public class AMEIRefETAuxiliary 
{
    private double _stomata_resistance;
    private double _net_radiation;
    private double _saturation_vapor_pressure_deficit;
    private double _saturated_vapor_pressure_slope;
    private double _psychrometric_constant;
    private double _reference_evapotranspiration;
    
    /// <summary>
    /// Constructor of the AMEIRefETAuxiliary component")
    /// </summary>  
    public AMEIRefETAuxiliary() { }
    
    
    public AMEIRefETAuxiliary(AMEIRefETAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            stomata_resistance = toCopy.stomata_resistance;
            net_radiation = toCopy.net_radiation;
            saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
            saturated_vapor_pressure_slope = toCopy.saturated_vapor_pressure_slope;
            psychrometric_constant = toCopy.psychrometric_constant;
            reference_evapotranspiration = toCopy.reference_evapotranspiration;
        }
    }
    public double stomata_resistance
    {
        get { return this._stomata_resistance; }
        set { this._stomata_resistance= value; } 
    }
    public double net_radiation
    {
        get { return this._net_radiation; }
        set { this._net_radiation= value; } 
    }
    public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }
    public double saturated_vapor_pressure_slope
    {
        get { return this._saturated_vapor_pressure_slope; }
        set { this._saturated_vapor_pressure_slope= value; } 
    }
    public double psychrometric_constant
    {
        get { return this._psychrometric_constant; }
        set { this._psychrometric_constant= value; } 
    }
    public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }
}