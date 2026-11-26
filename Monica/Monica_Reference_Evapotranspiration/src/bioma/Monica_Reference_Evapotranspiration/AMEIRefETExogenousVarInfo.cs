
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIRefET.DomainClass
                                {
                                    public class AMEIRefETExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _mean_air_temperature = new VarInfo();
                                        static VarInfo _wind_speed = new VarInfo();
                                        static VarInfo _wind_speed_height = new VarInfo();

                                        static AMEIRefETExogenousVarInfo()
                                        {
                                            AMEIRefETExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIRefETExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIRefETExogenous";}
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
                                            _wind_speed_height.MinValue = 0.1;
                                            _wind_speed_height.DefaultValue = 2;
                                            _wind_speed_height.Units = "m";
                                            _wind_speed_height.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }