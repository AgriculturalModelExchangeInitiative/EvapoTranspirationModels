
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
                        {
                            public class ETExogenous : ICloneable, IDomainClass
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
                                private ParametersIO _parametersIO;

                                public ETExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

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

                                        public double global_radiation
    {
        get { return this._global_radiation; }
        set { this._global_radiation= value; } 
    }
                                        public int julian_day
    {
        get { return this._julian_day; }
        set { this._julian_day= value; } 
    }
                                        public double sunshine_hours
    {
        get { return this._sunshine_hours; }
        set { this._sunshine_hours= value; } 
    }
                                        public double max_air_temperature
    {
        get { return this._max_air_temperature; }
        set { this._max_air_temperature= value; } 
    }
                                        public double min_air_temperature
    {
        get { return this._min_air_temperature; }
        set { this._min_air_temperature= value; } 
    }
                                        public double relative_humidity
    {
        get { return this._relative_humidity; }
        set { this._relative_humidity= value; } 
    }
                                        public double atmospheric_co2_concentration
    {
        get { return this._atmospheric_co2_concentration; }
        set { this._atmospheric_co2_concentration= value; } 
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
                                        public double kc_factor
    {
        get { return this._kc_factor; }
        set { this._kc_factor= value; } 
    }
                                        public int developmental_stage
    {
        get { return this._developmental_stage; }
        set { this._developmental_stage= value; } 
    }
                                        public double crop_remaining_evapotranspiration
    {
        get { return this._crop_remaining_evapotranspiration; }
        set { this._crop_remaining_evapotranspiration= value; } 
    }
                                        public bool has_snow_cover
    {
        get { return this._has_snow_cover; }
        set { this._has_snow_cover= value; } 
    }
                                        public double[] crop_transpiration
    {
        get { return this._crop_transpiration; }
        set { this._crop_transpiration= value; } 
    }
                                        public double crop_evaporated_from_intercepted
    {
        get { return this._crop_evaporated_from_intercepted; }
        set { this._crop_evaporated_from_intercepted= value; } 
    }
                                        public double percentage_soil_coverage
    {
        get { return this._percentage_soil_coverage; }
        set { this._percentage_soil_coverage= value; } 
    }

                                        public string Description
                                        {
                                            get { return "ETExogenous of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
                                        {
                                            get { return _parametersIO.GetCachedProperties(typeof(IDomainClass));}
                                        }

                                        public virtual Boolean ClearValues()
                                        {
                                             _global_radiation = default(double);
                                             _julian_day = default(int);
                                             _sunshine_hours = default(double);
                                             _max_air_temperature = default(double);
                                             _min_air_temperature = default(double);
                                             _relative_humidity = default(double);
                                             _atmospheric_co2_concentration = default(double);
                                             _mean_air_temperature = default(double);
                                             _wind_speed = default(double);
                                             _wind_speed_height = default(double);
                                             _kc_factor = default(double);
                                             _developmental_stage = default(int);
                                             _crop_remaining_evapotranspiration = default(double);
                                             _has_snow_cover = default(bool);
                                             _crop_transpiration = new double[no_of_soil_moisture_layers];
                                             _crop_evaporated_from_intercepted = default(double);
                                             _percentage_soil_coverage = default(double);
                                            return true;
                                        }

                                        public virtual Object Clone()
                                        {
                                            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
                                            _parametersIO.PopulateClonedCopy(myclass);
                                            return myclass;
                                        }
                                    }
                                }