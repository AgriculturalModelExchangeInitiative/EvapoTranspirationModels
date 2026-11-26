using System;
using System.Collections.Generic;

public class AMEIRefETAuxiliary 
{
    private double _stomata_resistance;
    private double _net_radiation;
    private double _saturation_vapor_pressure_deficit;
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
    public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }
}