using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the ET component
/// </summary>
public class ETExogenous
{
    private double _global_radiation;
    private int _julian_day;
    private double _sunshine_hours;
    private double _max_air_temperature;
    private double _min_air_temperature;
    private double _relative_humidity;
    private double _atmospheric_co2_concentration;
    private double _mean_air_temperature;
    private double _wind_speed;
    private double _wind_speed_height;
    private double _kc_factor;
    private int _developmental_stage;
    private double _crop_remaining_evapotranspiration;
    private bool _has_snow_cover;
    private double[] _crop_transpiration;
    private double _crop_evaporated_from_intercepted;
    private double _percentage_soil_coverage;

    /// <summary>
    /// Constructor ETExogenous domain class
    /// </summary>
    public ETExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ETExogenous(ETExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            global_radiation = toCopy.global_radiation;
            julian_day = toCopy.julian_day;
            sunshine_hours = toCopy.sunshine_hours;
            max_air_temperature = toCopy.max_air_temperature;
            min_air_temperature = toCopy.min_air_temperature;
            relative_humidity = toCopy.relative_humidity;
            atmospheric_co2_concentration = toCopy.atmospheric_co2_concentration;
            mean_air_temperature = toCopy.mean_air_temperature;
            wind_speed = toCopy.wind_speed;
            wind_speed_height = toCopy.wind_speed_height;
            kc_factor = toCopy.kc_factor;
            developmental_stage = toCopy.developmental_stage;
            crop_remaining_evapotranspiration = toCopy.crop_remaining_evapotranspiration;
            has_snow_cover = toCopy.has_snow_cover;
            crop_transpiration = new double[toCopy.crop_transpiration.Length];
        for (int i = 0; i < toCopy.crop_transpiration.Length; i++)
            { crop_transpiration[i] = toCopy.crop_transpiration[i]; }
    
            crop_evaporated_from_intercepted = toCopy.crop_evaporated_from_intercepted;
            percentage_soil_coverage = toCopy.percentage_soil_coverage;
        }
    }

    /// <summary>
    /// Gets and sets the global radiation
    /// </summary>
    [Description("global radiation")] 
    [Units("MJ/m2")] 
    public double global_radiation
    {
        get { return this._global_radiation; }
        set { this._global_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the day of year
    /// </summary>
    [Description("day of year")] 
    [Units("day")] 
    public int julian_day
    {
        get { return this._julian_day; }
        set { this._julian_day= value; } 
    }

    /// <summary>
    /// Gets and sets the number of sunshine hours
    /// </summary>
    [Description("number of sunshine hours")] 
    [Units("h")] 
    public double sunshine_hours
    {
        get { return this._sunshine_hours; }
        set { this._sunshine_hours= value; } 
    }

    /// <summary>
    /// Gets and sets the daily maximum air temperature
    /// </summary>
    [Description("daily maximum air temperature")] 
    [Units("°C")] 
    public double max_air_temperature
    {
        get { return this._max_air_temperature; }
        set { this._max_air_temperature= value; } 
    }

    /// <summary>
    /// Gets and sets the daily minimum air temperature
    /// </summary>
    [Description("daily minimum air temperature")] 
    [Units("°C")] 
    public double min_air_temperature
    {
        get { return this._min_air_temperature; }
        set { this._min_air_temperature= value; } 
    }

    /// <summary>
    /// Gets and sets the relative humidity
    /// </summary>
    [Description("relative humidity")] 
    [Units("fraction")] 
    public double relative_humidity
    {
        get { return this._relative_humidity; }
        set { this._relative_humidity= value; } 
    }

    /// <summary>
    /// Gets and sets the CO2 concentration in the atmosphere. Optional if no crop.
    /// </summary>
    [Description("CO2 concentration in the atmosphere. Optional if no crop.")] 
    [Units("ppm")] 
    public double atmospheric_co2_concentration
    {
        get { return this._atmospheric_co2_concentration; }
        set { this._atmospheric_co2_concentration= value; } 
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

    /// <summary>
    /// Gets and sets the is the soil covered by snow
    /// </summary>
    [Description("is the soil covered by snow")] 
    [Units("dimensionless")] 
    public bool has_snow_cover
    {
        get { return this._has_snow_cover; }
        set { this._has_snow_cover= value; } 
    }

    /// <summary>
    /// Gets and sets the crop transpiration array
    /// </summary>
    [Description("crop transpiration array")] 
    [Units("mm")] 
    public double[] crop_transpiration
    {
        get { return this._crop_transpiration; }
        set { this._crop_transpiration= value; } 
    }

    /// <summary>
    /// Gets and sets the crop evaporated water from intercepted water
    /// </summary>
    [Description("crop evaporated water from intercepted water")] 
    [Units("mm")] 
    public double crop_evaporated_from_intercepted
    {
        get { return this._crop_evaporated_from_intercepted; }
        set { this._crop_evaporated_from_intercepted= value; } 
    }

    /// <summary>
    /// Gets and sets the fraction of soil covered by crop
    /// </summary>
    [Description("fraction of soil covered by crop")] 
    [Units("m2/m2")] 
    public double percentage_soil_coverage
    {
        get { return this._percentage_soil_coverage; }
        set { this._percentage_soil_coverage= value; } 
    }

}