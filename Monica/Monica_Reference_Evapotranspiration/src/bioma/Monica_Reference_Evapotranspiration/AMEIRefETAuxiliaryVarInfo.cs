
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIRefET.DomainClass
                                {
                                    public class AMEIRefETAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _stomata_resistance = new VarInfo();
                                        static VarInfo _net_radiation = new VarInfo();
                                        static VarInfo _saturation_vapor_pressure_deficit = new VarInfo();
                                        static VarInfo _reference_evapotranspiration = new VarInfo();

                                        static AMEIRefETAuxiliaryVarInfo()
                                        {
                                            AMEIRefETAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIRefETAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIRefETAuxiliary";}
                                        }

                                        public static  VarInfo stomata_resistance
                                        {
                                            get { return _stomata_resistance;}
                                        }

                                        public static  VarInfo net_radiation
                                        {
                                            get { return _net_radiation;}
                                        }

                                        public static  VarInfo saturation_vapor_pressure_deficit
                                        {
                                            get { return _saturation_vapor_pressure_deficit;}
                                        }

                                        public static  VarInfo reference_evapotranspiration
                                        {
                                            get { return _reference_evapotranspiration;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _stomata_resistance.Name = "stomata_resistance";
                                            _stomata_resistance.Description = "stomata resistance (FAO default value is 100)";
                                            _stomata_resistance.MaxValue = 10000;
                                            _stomata_resistance.MinValue = 0;
                                            _stomata_resistance.DefaultValue = 100;
                                            _stomata_resistance.Units = "s/m";
                                            _stomata_resistance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _net_radiation.Name = "net_radiation";
                                            _net_radiation.Description = "net radiation";
                                            _net_radiation.MaxValue = -1D;
                                            _net_radiation.MinValue = 0;
                                            _net_radiation.DefaultValue = 0;
                                            _net_radiation.Units = "MJ/m2";
                                            _net_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _saturation_vapor_pressure_deficit.Name = "saturation_vapor_pressure_deficit";
                                            _saturation_vapor_pressure_deficit.Description = "saturation_vapor_pressure_deficit";
                                            _saturation_vapor_pressure_deficit.MaxValue = -1D;
                                            _saturation_vapor_pressure_deficit.MinValue = 0;
                                            _saturation_vapor_pressure_deficit.DefaultValue = 0;
                                            _saturation_vapor_pressure_deficit.Units = "kPa";
                                            _saturation_vapor_pressure_deficit.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _reference_evapotranspiration.Name = "reference_evapotranspiration";
                                            _reference_evapotranspiration.Description = "reference evapotranspiration (ET0)";
                                            _reference_evapotranspiration.MaxValue = -1D;
                                            _reference_evapotranspiration.MinValue = 0;
                                            _reference_evapotranspiration.DefaultValue = -1D;
                                            _reference_evapotranspiration.Units = "mm";
                                            _reference_evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }