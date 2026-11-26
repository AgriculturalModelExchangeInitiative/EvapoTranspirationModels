import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class AMEIRefETExogenous
{
    private double mean_air_temperature;
    private double wind_speed;
    private double wind_speed_height;
    
    public AMEIRefETExogenous() { }
    
    public AMEIRefETExogenous(AMEIRefETExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.mean_air_temperature = toCopy.getmean_air_temperature();
            this.wind_speed = toCopy.getwind_speed();
            this.wind_speed_height = toCopy.getwind_speed_height();
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
    
}