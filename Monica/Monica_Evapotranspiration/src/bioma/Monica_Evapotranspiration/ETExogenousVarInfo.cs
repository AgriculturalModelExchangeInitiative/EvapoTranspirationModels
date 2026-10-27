
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
                                {
                                    public class ETExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _global_radiation = new VarInfo();
                                        static VarInfo _julian_day = new VarInfo();
                                        static VarInfo _sunshine_hours = new VarInfo();
                                        static VarInfo _max_air_temperature = new VarInfo();
                                        static VarInfo _min_air_temperature = new VarInfo();
                                        static VarInfo _relative_humidity = new VarInfo();
                                        static VarInfo _atmospheric_co2_concentration = new VarInfo();
                                        static VarInfo _mean_air_temperature = new VarInfo();
                                        static VarInfo _wind_speed = new VarInfo();
                                        static VarInfo _wind_speed_height = new VarInfo();
                                        static VarInfo _kc_factor = new VarInfo();
                                        static VarInfo _developmental_stage = new VarInfo();
                                        static VarInfo _crop_remaining_evapotranspiration = new VarInfo();
                                        static VarInfo _has_snow_cover = new VarInfo();
                                        static VarInfo _crop_transpiration = new VarInfo();
                                        static VarInfo _crop_evaporated_from_intercepted = new VarInfo();
                                        static VarInfo _percentage_soil_coverage = new VarInfo();

                                        static ETExogenousVarInfo()
                                        {
                                            ETExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ETExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ETExogenous";}
                                        }

                                        public static  VarInfo global_radiation
                                        {
                                            get { return _global_radiation;}
                                        }

                                        public static  VarInfo julian_day
                                        {
                                            get { return _julian_day;}
                                        }

                                        public static  VarInfo sunshine_hours
                                        {
                                            get { return _sunshine_hours;}
                                        }

                                        public static  VarInfo max_air_temperature
                                        {
                                            get { return _max_air_temperature;}
                                        }

                                        public static  VarInfo min_air_temperature
                                        {
                                            get { return _min_air_temperature;}
                                        }

                                        public static  VarInfo relative_humidity
                                        {
                                            get { return _relative_humidity;}
                                        }

                                        public static  VarInfo atmospheric_co2_concentration
                                        {
                                            get { return _atmospheric_co2_concentration;}
                                        }

                                        public static  VarInfo mean_air_temperature
                                        {
                                            get { return _mean_air_temperature;}
                                        }

                                        public static  VarInfo wind_speed
                                        {
                                            get { return _wind_speed;}
                                        }

                                        public static  VarInfo wind_speed_height
                                        {
                                            get { return _wind_speed_height;}
                                        }

                                        public static  VarInfo kc_factor
                                        {
                                            get { return _kc_factor;}
                                        }

                                        public static  VarInfo developmental_stage
                                        {
                                            get { return _developmental_stage;}
                                        }

                                        public static  VarInfo crop_remaining_evapotranspiration
                                        {
                                            get { return _crop_remaining_evapotranspiration;}
                                        }

                                        public static  VarInfo has_snow_cover
                                        {
                                            get { return _has_snow_cover;}
                                        }

                                        public static  VarInfo crop_transpiration
                                        {
                                            get { return _crop_transpiration;}
                                        }

                                        public static  VarInfo crop_evaporated_from_intercepted
                                        {
                                            get { return _crop_evaporated_from_intercepted;}
                                        }

                                        public static  VarInfo percentage_soil_coverage
                                        {
                                            get { return _percentage_soil_coverage;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _global_radiation.Name = "global_radiation";
                                            _global_radiation.Description = "global radiation";
                                            _global_radiation.MaxValue = 50;
                                            _global_radiation.MinValue = 0;
                                            _global_radiation.DefaultValue = 0;
                                            _global_radiation.Units = "MJ/m2";
                                            _global_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _julian_day.Name = "julian_day";
                                            _julian_day.Description = "day of year";
                                            _julian_day.MaxValue = 366;
                                            _julian_day.MinValue = 1;
                                            _julian_day.DefaultValue = 1;
                                            _julian_day.Units = "day";
                                            _julian_day.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _sunshine_hours.Name = "sunshine_hours";
                                            _sunshine_hours.Description = "number of sunshine hours";
                                            _sunshine_hours.MaxValue = 24;
                                            _sunshine_hours.MinValue = 0;
                                            _sunshine_hours.DefaultValue = 0;
                                            _sunshine_hours.Units = "h";
                                            _sunshine_hours.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _max_air_temperature.Name = "max_air_temperature";
                                            _max_air_temperature.Description = "daily maximum air temperature";
                                            _max_air_temperature.MaxValue = 100;
                                            _max_air_temperature.MinValue = -100;
                                            _max_air_temperature.DefaultValue = 0;
                                            _max_air_temperature.Units = "°C";
                                            _max_air_temperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _min_air_temperature.Name = "min_air_temperature";
                                            _min_air_temperature.Description = "daily minimum air temperature";
                                            _min_air_temperature.MaxValue = 100;
                                            _min_air_temperature.MinValue = -100;
                                            _min_air_temperature.DefaultValue = 0;
                                            _min_air_temperature.Units = "°C";
                                            _min_air_temperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _relative_humidity.Name = "relative_humidity";
                                            _relative_humidity.Description = "relative humidity";
                                            _relative_humidity.MaxValue = 1;
                                            _relative_humidity.MinValue = 0;
                                            _relative_humidity.DefaultValue = 0;
                                            _relative_humidity.Units = "fraction";
                                            _relative_humidity.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _atmospheric_co2_concentration.Name = "atmospheric_co2_concentration";
                                            _atmospheric_co2_concentration.Description = "CO2 concentration in the atmosphere. Optional if no crop.";
                                            _atmospheric_co2_concentration.MaxValue = -1D;
                                            _atmospheric_co2_concentration.MinValue = 0;
                                            _atmospheric_co2_concentration.DefaultValue = 430;
                                            _atmospheric_co2_concentration.Units = "ppm";
                                            _atmospheric_co2_concentration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _mean_air_temperature.Name = "mean_air_temperature";
                                            _mean_air_temperature.Description = "daily average air temperature";
                                            _mean_air_temperature.MaxValue = 100;
                                            _mean_air_temperature.MinValue = -100;
                                            _mean_air_temperature.DefaultValue = 0;
                                            _mean_air_temperature.Units = "°C";
                                            _mean_air_temperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _wind_speed.Name = "wind_speed";
                                            _wind_speed.Description = "wind speed measured at wind speed height";
                                            _wind_speed.MaxValue = 9999;
                                            _wind_speed.MinValue = 0;
                                            _wind_speed.DefaultValue = 0;
                                            _wind_speed.Units = "m/s";
                                            _wind_speed.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _wind_speed_height.Name = "wind_speed_height";
                                            _wind_speed_height.Description = "height at which the wind speed has been measured";
                                            _wind_speed_height.MaxValue = 9999;
                                            _wind_speed_height.MinValue = -9999;
                                            _wind_speed_height.DefaultValue = 2;
                                            _wind_speed_height.Units = "m";
                                            _wind_speed_height.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _kc_factor.Name = "kc_factor";
                                            _kc_factor.Description = "crop coefficient ETc/ET0";
                                            _kc_factor.MaxValue = -1D;
                                            _kc_factor.MinValue = 0;
                                            _kc_factor.DefaultValue = 0.75;
                                            _kc_factor.Units = "dimensionless";
                                            _kc_factor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _developmental_stage.Name = "developmental_stage";
                                            _developmental_stage.Description = "MONICA crop developmental stage";
                                            _developmental_stage.MaxValue = 6;
                                            _developmental_stage.MinValue = 0;
                                            _developmental_stage.DefaultValue = 0;
                                            _developmental_stage.Units = "dimensionless";
                                            _developmental_stage.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _crop_remaining_evapotranspiration.Name = "crop_remaining_evapotranspiration";
                                            _crop_remaining_evapotranspiration.Description = "crop remaining evapotranspiration";
                                            _crop_remaining_evapotranspiration.MaxValue = -1D;
                                            _crop_remaining_evapotranspiration.MinValue = -1D;
                                            _crop_remaining_evapotranspiration.DefaultValue = -1D;
                                            _crop_remaining_evapotranspiration.Units = "mm";
                                            _crop_remaining_evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _has_snow_cover.Name = "has_snow_cover";
                                            _has_snow_cover.Description = "is the soil covered by snow";
                                            _has_snow_cover.MaxValue = -1D;
                                            _has_snow_cover.MinValue = -1D;
                                            _has_snow_cover.DefaultValue = -1D;
                                            _has_snow_cover.Units = "dimensionless";
                                            _has_snow_cover.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");

                                            _crop_transpiration.Name = "crop_transpiration";
                                            _crop_transpiration.Description = "crop transpiration array";
                                            _crop_transpiration.MaxValue = -1D;
                                            _crop_transpiration.MinValue = -1D;
                                            _crop_transpiration.DefaultValue = -1D;
                                            _crop_transpiration.Units = "mm";
                                            _crop_transpiration.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _crop_evaporated_from_intercepted.Name = "crop_evaporated_from_intercepted";
                                            _crop_evaporated_from_intercepted.Description = "crop evaporated water from intercepted water";
                                            _crop_evaporated_from_intercepted.MaxValue = -1D;
                                            _crop_evaporated_from_intercepted.MinValue = -1D;
                                            _crop_evaporated_from_intercepted.DefaultValue = -1D;
                                            _crop_evaporated_from_intercepted.Units = "mm";
                                            _crop_evaporated_from_intercepted.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _percentage_soil_coverage.Name = "percentage_soil_coverage";
                                            _percentage_soil_coverage.Description = "fraction of soil covered by crop";
                                            _percentage_soil_coverage.MaxValue = 1;
                                            _percentage_soil_coverage.MinValue = 0;
                                            _percentage_soil_coverage.DefaultValue = 0;
                                            _percentage_soil_coverage.Units = "m2/m2";
                                            _percentage_soil_coverage.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }