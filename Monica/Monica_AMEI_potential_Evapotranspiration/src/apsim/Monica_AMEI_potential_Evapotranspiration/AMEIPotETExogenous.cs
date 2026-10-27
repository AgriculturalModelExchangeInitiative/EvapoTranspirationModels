using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the AMEIPotET component
/// </summary>
public class AMEIPotETExogenous
{
    private double _mean_air_temperature;
    private double _wind_speed;
    private double _wind_speed_height;
    private double _kc_factor;
    private int _developmental_stage;
    private double _crop_remaining_evapotranspiration;

    /// <summary>
    /// Constructor AMEIPotETExogenous domain class
    /// </summary>
    public AMEIPotETExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIPotETExogenous(AMEIPotETExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            mean_air_temperature = toCopy.mean_air_temperature;
            wind_speed = toCopy.wind_speed;
            wind_speed_height = toCopy.wind_speed_height;
            kc_factor = toCopy.kc_factor;
            developmental_stage = toCopy.developmental_stage;
            crop_remaining_evapotranspiration = toCopy.crop_remaining_evapotranspiration;
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

    /// <summary>
    /// Gets and sets the crop coefficient ETc/ET0
    /// </summary>
    [Description("crop coefficient ETc/ET0")] 
    [Units("dimensionless")] 
    public double kc_factor
    {
        get { return this._kc_factor; }
        set { this._kc_factor= value; } 
    }

    /// <summary>
    /// Gets and sets the MONICA crop developmental stage
    /// </summary>
    [Description("MONICA crop developmental stage")] 
    [Units("dimensionless")] 
    public int developmental_stage
    {
        get { return this._developmental_stage; }
        set { this._developmental_stage= value; } 
    }

    /// <summary>
    /// Gets and sets the crop remaining evapotranspiration
    /// </summary>
    [Description("crop remaining evapotranspiration")] 
    [Units("mm")] 
    public double crop_remaining_evapotranspiration
    {
        get { return this._crop_remaining_evapotranspiration; }
        set { this._crop_remaining_evapotranspiration= value; } 
    }

}