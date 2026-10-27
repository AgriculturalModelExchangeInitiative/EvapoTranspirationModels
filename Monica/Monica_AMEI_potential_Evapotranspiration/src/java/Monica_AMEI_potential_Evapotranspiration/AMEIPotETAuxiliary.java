import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class AMEIPotETAuxiliary
{
    private double vapor_pressure;
    private double saturated_vapor_pressure;
    private double stomata_resistance;
    private double net_radiation;
    private double reference_evapotranspiration;
    private double potential_evapotranspiration;
    private double saturation_vapor_pressure_deficit;
    
    public AMEIPotETAuxiliary() { }
    
    public AMEIPotETAuxiliary(AMEIPotETAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.vapor_pressure = toCopy.getvapor_pressure();
            this.saturated_vapor_pressure = toCopy.getsaturated_vapor_pressure();
            this.stomata_resistance = toCopy.getstomata_resistance();
            this.net_radiation = toCopy.getnet_radiation();
            this.reference_evapotranspiration = toCopy.getreference_evapotranspiration();
            this.potential_evapotranspiration = toCopy.getpotential_evapotranspiration();
            this.saturation_vapor_pressure_deficit = toCopy.getsaturation_vapor_pressure_deficit();
            this.reference_evapotranspiration = toCopy.getreference_evapotranspiration();
        }
    }
    public double getvapor_pressure()
    { return vapor_pressure; }

    public void setvapor_pressure(double _vapor_pressure)
    { this.vapor_pressure= _vapor_pressure; } 
    
    public double getsaturated_vapor_pressure()
    { return saturated_vapor_pressure; }

    public void setsaturated_vapor_pressure(double _saturated_vapor_pressure)
    { this.saturated_vapor_pressure= _saturated_vapor_pressure; } 
    
    public double getstomata_resistance()
    { return stomata_resistance; }

    public void setstomata_resistance(double _stomata_resistance)
    { this.stomata_resistance= _stomata_resistance; } 
    
    public double getnet_radiation()
    { return net_radiation; }

    public void setnet_radiation(double _net_radiation)
    { this.net_radiation= _net_radiation; } 
    
    public double getreference_evapotranspiration()
    { return reference_evapotranspiration; }

    public void setreference_evapotranspiration(double _reference_evapotranspiration)
    { this.reference_evapotranspiration= _reference_evapotranspiration; } 
    
    public double getpotential_evapotranspiration()
    { return potential_evapotranspiration; }

    public void setpotential_evapotranspiration(double _potential_evapotranspiration)
    { this.potential_evapotranspiration= _potential_evapotranspiration; } 
    
    public double getsaturation_vapor_pressure_deficit()
    { return saturation_vapor_pressure_deficit; }

    public void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit)
    { this.saturation_vapor_pressure_deficit= _saturation_vapor_pressure_deficit; } 
    
}