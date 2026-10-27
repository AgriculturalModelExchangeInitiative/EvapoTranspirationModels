import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ETExogenous
{
    private double global_radiation;
    private Integer julian_day;
    private double sunshine_hours;
    private double max_air_temperature;
    private double min_air_temperature;
    private double relative_humidity;
    private double atmospheric_co2_concentration;
    private double mean_air_temperature;
    private double wind_speed;
    private double wind_speed_height;
    private double kc_factor;
    private Integer developmental_stage;
    private double crop_remaining_evapotranspiration;
    private Boolean has_snow_cover;
    private Double [] crop_transpiration;
    private double crop_evaporated_from_intercepted;
    private double percentage_soil_coverage;
    
    public ETExogenous() { }
    
    public ETExogenous(ETExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.global_radiation = toCopy.getglobal_radiation();
            this.julian_day = toCopy.getjulian_day();
            this.sunshine_hours = toCopy.getsunshine_hours();
            this.max_air_temperature = toCopy.getmax_air_temperature();
            this.min_air_temperature = toCopy.getmin_air_temperature();
            this.relative_humidity = toCopy.getrelative_humidity();
            this.atmospheric_co2_concentration = toCopy.getatmospheric_co2_concentration();
            this.mean_air_temperature = toCopy.getmean_air_temperature();
            this.wind_speed = toCopy.getwind_speed();
            this.wind_speed_height = toCopy.getwind_speed_height();
            this.kc_factor = toCopy.getkc_factor();
            this.developmental_stage = toCopy.getdevelopmental_stage();
            this.crop_remaining_evapotranspiration = toCopy.getcrop_remaining_evapotranspiration();
            this.has_snow_cover = toCopy.gethas_snow_cover();
            crop_transpiration = new Double[toCopy.getcrop_transpiration().length];
        for (int i = 0; i < toCopy.getcrop_transpiration().length; i++)
        {
            crop_transpiration[i] = toCopy.getcrop_transpiration()[i];
        }
            this.crop_evaporated_from_intercepted = toCopy.getcrop_evaporated_from_intercepted();
            this.percentage_soil_coverage = toCopy.getpercentage_soil_coverage();
        }
    }
    public double getglobal_radiation()
    { return global_radiation; }

    public void setglobal_radiation(double _global_radiation)
    { this.global_radiation= _global_radiation; } 
    
    public Integer getjulian_day()
    { return julian_day; }

    public void setjulian_day(Integer _julian_day)
    { this.julian_day= _julian_day; } 
    
    public double getsunshine_hours()
    { return sunshine_hours; }

    public void setsunshine_hours(double _sunshine_hours)
    { this.sunshine_hours= _sunshine_hours; } 
    
    public double getmax_air_temperature()
    { return max_air_temperature; }

    public void setmax_air_temperature(double _max_air_temperature)
    { this.max_air_temperature= _max_air_temperature; } 
    
    public double getmin_air_temperature()
    { return min_air_temperature; }

    public void setmin_air_temperature(double _min_air_temperature)
    { this.min_air_temperature= _min_air_temperature; } 
    
    public double getrelative_humidity()
    { return relative_humidity; }

    public void setrelative_humidity(double _relative_humidity)
    { this.relative_humidity= _relative_humidity; } 
    
    public double getatmospheric_co2_concentration()
    { return atmospheric_co2_concentration; }

    public void setatmospheric_co2_concentration(double _atmospheric_co2_concentration)
    { this.atmospheric_co2_concentration= _atmospheric_co2_concentration; } 
    
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
    
    public Boolean gethas_snow_cover()
    { return has_snow_cover; }

    public void sethas_snow_cover(Boolean _has_snow_cover)
    { this.has_snow_cover= _has_snow_cover; } 
    
    public Double [] getcrop_transpiration()
    { return crop_transpiration; }

    public void setcrop_transpiration(Double [] _crop_transpiration)
    { this.crop_transpiration= _crop_transpiration; } 
    
    public double getcrop_evaporated_from_intercepted()
    { return crop_evaporated_from_intercepted; }

    public void setcrop_evaporated_from_intercepted(double _crop_evaporated_from_intercepted)
    { this.crop_evaporated_from_intercepted= _crop_evaporated_from_intercepted; } 
    
    public double getpercentage_soil_coverage()
    { return percentage_soil_coverage; }

    public void setpercentage_soil_coverage(double _percentage_soil_coverage)
    { this.percentage_soil_coverage= _percentage_soil_coverage; } 
    
}