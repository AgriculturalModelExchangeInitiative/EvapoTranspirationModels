using System;
using System.Collections.Generic;

public class AMEIRefETExogenous 
{
    private double _mean_air_temperature;
    private double _wind_speed;
    private double _wind_speed_height;
    
    /// <summary>
    /// Constructor of the AMEIRefETExogenous component")
    /// </summary>  
    public AMEIRefETExogenous() { }
    
    
    public AMEIRefETExogenous(AMEIRefETExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            mean_air_temperature = toCopy.mean_air_temperature;
            wind_speed = toCopy.wind_speed;
            wind_speed_height = toCopy.wind_speed_height;
        }
    }
    public double mean_air_temperature
    {
        get { return this._mean_air_temperature; }
        set { this._mean_air_temperature= value; } 
    }
    public double wind_speed
    {
        get { return this._wind_speed; }
        set { this._wind_speed= value; } 
    }
    public double wind_speed_height
    {
        get { return this._wind_speed_height; }
        set { this._wind_speed_height= value; } 
    }
}