import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class AMEIRefETAuxiliary
{
    private double stomata_resistance;
    private double net_radiation;
    private double saturation_vapor_pressure_deficit;
    private double reference_evapotranspiration;
    
    public AMEIRefETAuxiliary() { }
    
    public AMEIRefETAuxiliary(AMEIRefETAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.stomata_resistance = toCopy.getstomata_resistance();
            this.net_radiation = toCopy.getnet_radiation();
            this.saturation_vapor_pressure_deficit = toCopy.getsaturation_vapor_pressure_deficit();
            this.reference_evapotranspiration = toCopy.getreference_evapotranspiration();
        }
    }
    public double getstomata_resistance()
    { return stomata_resistance; }

    public void setstomata_resistance(double _stomata_resistance)
    { this.stomata_resistance= _stomata_resistance; } 
    
    public double getnet_radiation()
    { return net_radiation; }

    public void setnet_radiation(double _net_radiation)
    { this.net_radiation= _net_radiation; } 
    
    public double getsaturation_vapor_pressure_deficit()
    { return saturation_vapor_pressure_deficit; }

    public void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit)
    { this.saturation_vapor_pressure_deficit= _saturation_vapor_pressure_deficit; } 
    
    public double getreference_evapotranspiration()
    { return reference_evapotranspiration; }

    public void setreference_evapotranspiration(double _reference_evapotranspiration)
    { this.reference_evapotranspiration= _reference_evapotranspiration; } 
    
}