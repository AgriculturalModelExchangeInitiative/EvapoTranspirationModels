import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class ETState
{
    private double surface_water_storage;
    private double evaporated_from_surface;
    private double actual_evaporation;
    private double actual_transpiration;
    private Double [] soil_moisture;
    private Double [] evaporation;
    private Double [] transpiration;
    private Double [] evapotranspiration;
    private double actual_evapotranspiration;
    
    public ETState() { }
    
    public ETState(ETState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.surface_water_storage = toCopy.getsurface_water_storage();
            this.evaporated_from_surface = toCopy.getevaporated_from_surface();
            this.actual_evaporation = toCopy.getactual_evaporation();
            this.actual_transpiration = toCopy.getactual_transpiration();
            soil_moisture = new Double[toCopy.getsoil_moisture().length];
        for (int i = 0; i < toCopy.getsoil_moisture().length; i++)
        {
            soil_moisture[i] = toCopy.getsoil_moisture()[i];
        }
            evaporation = new Double[toCopy.getevaporation().length];
        for (int i = 0; i < toCopy.getevaporation().length; i++)
        {
            evaporation[i] = toCopy.getevaporation()[i];
        }
            transpiration = new Double[toCopy.gettranspiration().length];
        for (int i = 0; i < toCopy.gettranspiration().length; i++)
        {
            transpiration[i] = toCopy.gettranspiration()[i];
        }
            evapotranspiration = new Double[toCopy.getevapotranspiration().length];
        for (int i = 0; i < toCopy.getevapotranspiration().length; i++)
        {
            evapotranspiration[i] = toCopy.getevapotranspiration()[i];
        }
            this.actual_evapotranspiration = toCopy.getactual_evapotranspiration();
        }
    }
    public double getsurface_water_storage()
    { return surface_water_storage; }

    public void setsurface_water_storage(double _surface_water_storage)
    { this.surface_water_storage= _surface_water_storage; } 
    
    public double getevaporated_from_surface()
    { return evaporated_from_surface; }

    public void setevaporated_from_surface(double _evaporated_from_surface)
    { this.evaporated_from_surface= _evaporated_from_surface; } 
    
    public double getactual_evaporation()
    { return actual_evaporation; }

    public void setactual_evaporation(double _actual_evaporation)
    { this.actual_evaporation= _actual_evaporation; } 
    
    public double getactual_transpiration()
    { return actual_transpiration; }

    public void setactual_transpiration(double _actual_transpiration)
    { this.actual_transpiration= _actual_transpiration; } 
    
    public Double [] getsoil_moisture()
    { return soil_moisture; }

    public void setsoil_moisture(Double [] _soil_moisture)
    { this.soil_moisture= _soil_moisture; } 
    
    public Double [] getevaporation()
    { return evaporation; }

    public void setevaporation(Double [] _evaporation)
    { this.evaporation= _evaporation; } 
    
    public Double [] gettranspiration()
    { return transpiration; }

    public void settranspiration(Double [] _transpiration)
    { this.transpiration= _transpiration; } 
    
    public Double [] getevapotranspiration()
    { return evapotranspiration; }

    public void setevapotranspiration(Double [] _evapotranspiration)
    { this.evapotranspiration= _evapotranspiration; } 
    
    public double getactual_evapotranspiration()
    { return actual_evapotranspiration; }

    public void setactual_evapotranspiration(double _actual_evapotranspiration)
    { this.actual_evapotranspiration= _actual_evapotranspiration; } 
    
}