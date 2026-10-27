
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIPotET.DomainClass
                                {
                                    public class AMEIPotETAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _vapor_pressure = new VarInfo();
                                        static VarInfo _saturated_vapor_pressure = new VarInfo();
                                        static VarInfo _stomata_resistance = new VarInfo();
                                        static VarInfo _net_radiation = new VarInfo();
                                        static VarInfo _reference_evapotranspiration = new VarInfo();
                                        static VarInfo _potential_evapotranspiration = new VarInfo();
                                        static VarInfo _saturation_vapor_pressure_deficit = new VarInfo();

                                        static AMEIPotETAuxiliaryVarInfo()
                                        {
                                            AMEIPotETAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIPotETAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIPotETAuxiliary";}
                                        }

                                        public static  VarInfo vapor_pressure
                                        {
                                            get { return _vapor_pressure;}
                                        }

                                        public static  VarInfo saturated_vapor_pressure
                                        {
                                            get { return _saturated_vapor_pressure;}
                                        }

                                        public static  VarInfo stomata_resistance
                                        {
                                            get { return _stomata_resistance;}
                                        }

                                        public static  VarInfo net_radiation
                                        {
                                            get { return _net_radiation;}
                                        }

                                        public static  VarInfo reference_evapotranspiration
                                        {
                                            get { return _reference_evapotranspiration;}
                                        }

                                        public static  VarInfo potential_evapotranspiration
                                        {
                                            get { return _potential_evapotranspiration;}
                                        }

                                        public static  VarInfo saturation_vapor_pressure_deficit
                                        {
                                            get { return _saturation_vapor_pressure_deficit;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _vapor_pressure.Name = "vapor_pressure";
                                            _vapor_pressure.Description = "vapor pressure";
                                            _vapor_pressure.MaxValue = -1D;
                                            _vapor_pressure.MinValue = 0;
                                            _vapor_pressure.DefaultValue = 0;
                                            _vapor_pressure.Units = "kPa";
                                            _vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _saturated_vapor_pressure.Name = "saturated_vapor_pressure";
                                            _saturated_vapor_pressure.Description = "saturated vapor pressure";
                                            _saturated_vapor_pressure.MaxValue = -1D;
                                            _saturated_vapor_pressure.MinValue = 0;
                                            _saturated_vapor_pressure.DefaultValue = -1D;
                                            _saturated_vapor_pressure.Units = "kPa";
                                            _saturated_vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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
                                            _net_radiation.DefaultValue = -1D;
                                            _net_radiation.Units = "MJ/m2";
                                            _net_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _reference_evapotranspiration.Name = "reference_evapotranspiration";
                                            _reference_evapotranspiration.Description = "reference evapotranspiration (ET0)";
                                            _reference_evapotranspiration.MaxValue = -1D;
                                            _reference_evapotranspiration.MinValue = 0;
                                            _reference_evapotranspiration.DefaultValue = -1D;
                                            _reference_evapotranspiration.Units = "mm";
                                            _reference_evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _potential_evapotranspiration.Name = "potential_evapotranspiration";
                                            _potential_evapotranspiration.Description = "the potential evapotranspiration";
                                            _potential_evapotranspiration.MaxValue = -1D;
                                            _potential_evapotranspiration.MinValue = 0;
                                            _potential_evapotranspiration.DefaultValue = -1D;
                                            _potential_evapotranspiration.Units = "mm";
                                            _potential_evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _saturation_vapor_pressure_deficit.Name = "saturation_vapor_pressure_deficit";
                                            _saturation_vapor_pressure_deficit.Description = "saturation vapor pressure deficit";
                                            _saturation_vapor_pressure_deficit.MaxValue = -1D;
                                            _saturation_vapor_pressure_deficit.MinValue = 0;
                                            _saturation_vapor_pressure_deficit.DefaultValue = -1D;
                                            _saturation_vapor_pressure_deficit.Units = "kPa";
                                            _saturation_vapor_pressure_deficit.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }