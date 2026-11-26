using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the AMEIRefET component
/// </summary>
public class AMEIRefETExogenous
{
    private double _mean_air_temperature;
    private double _wind_speed;
    private double _wind_speed_height;

    /// <summary>
    /// Constructor AMEIRefETExogenous domain class
    /// </summary>
    public AMEIRefETExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIRefETExogenous(AMEIRefETExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            mean_air_temperature = toCopy.mean_air_temperature;
            wind_speed = toCopy.wind_speed;
            wind_speed_height = toCopy.wind_speed_height;
        }
    }

    /// <summary>
    /// Gets and sets the daily average air temperature
    /// </summary>
    [Description("daily average air temperature")] 
    [Units("°C")] 
    public double mean_air_temperature
    {
        get { return this._mean_air_temperature; }
        set { this._mean_air_temperature= value; } 
    }

    /// <summary>
    /// Gets and sets the wind speed measured at wind speed height
    /// </summary>
    [Description("wind speed measured at wind speed height")] 
    [Units("m/s")] 
    public double wind_speed
    {
        get { return this._wind_speed; }
        set { this._wind_speed= value; } 
    }

    /// <summary>
    /// Gets and sets the height at which the wind speed has been measured
    /// </summary>
    [Description("height at which the wind speed has been measured")] 
    [Units("m")] 
    public double wind_speed_height
    {
        get { return this._wind_speed_height; }
        set { this._wind_speed_height= value; } 
    }

}