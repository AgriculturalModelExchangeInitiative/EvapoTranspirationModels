
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIPotET.DomainClass
                                {
                                    public class AMEIPotETExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _mean_air_temperature = new VarInfo();
                                        static VarInfo _wind_speed = new VarInfo();
                                        static VarInfo _wind_speed_height = new VarInfo();
                                        static VarInfo _kc_factor = new VarInfo();
                                        static VarInfo _developmental_stage = new VarInfo();
                                        static VarInfo _crop_remaining_evapotranspiration = new VarInfo();

                                        static AMEIPotETExogenousVarInfo()
                                        {
                                            AMEIPotETExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIPotETExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIPotETExogenous";}
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

                                        static void DescribeVariables()
                                        {
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

                                        }

                                    }
                                }