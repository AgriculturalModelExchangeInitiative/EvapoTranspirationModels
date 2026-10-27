import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class AMEIPotETExogenous
{
    private double mean_air_temperature;
    private double wind_speed;
    private double wind_speed_height;
    private double kc_factor;
    private Integer developmental_stage;
    private double crop_remaining_evapotranspiration;
    
    public AMEIPotETExogenous() { }
    
    public AMEIPotETExogenous(AMEIPotETExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.mean_air_temperature = toCopy.getmean_air_temperature();
            this.wind_speed = toCopy.getwind_speed();
            this.wind_speed_height = toCopy.getwind_speed_height();
            this.kc_factor = toCopy.getkc_factor();
            this.developmental_stage = toCopy.getdevelopmental_stage();
            this.crop_remaining_evapotranspiration = toCopy.getcrop_remaining_evapotranspiration();
        }
    }
    public double getmean_air_temperature()
    { return mean_air_temperature; }

    public void setmean_air_temperature(double _mean_air_temperature)
    { this.mean_air_temperature= _mean_air_temperature; } 
    
    public double getwind_speed()
    { return wind_speed; }

    public void setwind_speed(double _wind_speed)
    { this.wind_speed= _wind_speed; } 
    
    public double getwind_speed_height()
    { return wind_speed_height; }

    public void setwind_speed_height(double _wind_speed_height)
    { this.wind_speed_height= _wind_speed_height; } 
    
    public double getkc_factor()
    { return kc_factor; }

    public void setkc_factor(double _kc_factor)
    { this.kc_factor= _kc_factor; } 
    
    public Integer getdevelopmental_stage()
    { return developmental_stage; }

    public void setdevelopmental_stage(Integer _developmental_stage)
    { this.developmental_stage= _developmental_stage; } 
    
    public double getcrop_remaining_evapotranspiration()
    { return crop_remaining_evapotranspiration; }

    public void setcrop_remaining_evapotranspiration(double _crop_remaining_evapotranspiration)
    { this.crop_remaining_evapotranspiration= _crop_remaining_evapotranspiration; } 
    
}