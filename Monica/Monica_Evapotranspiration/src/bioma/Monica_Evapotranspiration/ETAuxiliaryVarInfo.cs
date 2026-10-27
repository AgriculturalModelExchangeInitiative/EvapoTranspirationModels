
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
                                {
                                    public class ETAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _use_external_vapor_pressure = new VarInfo();
                                        static VarInfo _external_vapor_pressure = new VarInfo();
                                        static VarInfo _calc_stomata_resistance = new VarInfo();
                                        static VarInfo _fixed_stomata_resistance = new VarInfo();
                                        static VarInfo _gross_photosynthesis_reference_mol = new VarInfo();
                                        static VarInfo _stomata_resistance = new VarInfo();
                                        static VarInfo _net_radiation = new VarInfo();
                                        static VarInfo _use_external_et0 = new VarInfo();
                                        static VarInfo _external_et0 = new VarInfo();
                                        static VarInfo _declination = new VarInfo();
                                        static VarInfo _astronomic_daylength = new VarInfo();
                                        static VarInfo _effective_daylength = new VarInfo();
                                        static VarInfo _photoperiodic_daylength = new VarInfo();
                                        static VarInfo _sunshine_hours_global_radiation = new VarInfo();
                                        static VarInfo _extraterrestrial_radiation = new VarInfo();
                                        static VarInfo _clear_day_radiation = new VarInfo();
                                        static VarInfo _overcast_day_radiation = new VarInfo();
                                        static VarInfo _phot_act_radiation_mean = new VarInfo();
                                        static VarInfo _reference_evapotranspiration = new VarInfo();
                                        static VarInfo _potential_evapotranspiration = new VarInfo();
                                        static VarInfo _vapor_pressure = new VarInfo();
                                        static VarInfo _internal_vapor_pressure = new VarInfo();
                                        static VarInfo _internal_et0 = new VarInfo();
                                        static VarInfo _saturated_vapor_pressure = new VarInfo();
                                        static VarInfo _saturation_vapor_pressure_deficit = new VarInfo();
                                        static VarInfo _calculated_stomata_resistance = new VarInfo();
                                        static VarInfo _et0 = new VarInfo();

                                        static ETAuxiliaryVarInfo()
                                        {
                                            ETAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ETAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ETAuxiliary";}
                                        }

                                        public static  VarInfo use_external_vapor_pressure
                                        {
                                            get { return _use_external_vapor_pressure;}
                                        }

                                        public static  VarInfo external_vapor_pressure
                                        {
                                            get { return _external_vapor_pressure;}
                                        }

                                        public static  VarInfo calc_stomata_resistance
                                        {
                                            get { return _calc_stomata_resistance;}
                                        }

                                        public static  VarInfo fixed_stomata_resistance
                                        {
                                            get { return _fixed_stomata_resistance;}
                                        }

                                        public static  VarInfo gross_photosynthesis_reference_mol
                                        {
                                            get { return _gross_photosynthesis_reference_mol;}
                                        }

                                        public static  VarInfo stomata_resistance
                                        {
                                            get { return _stomata_resistance;}
                                        }

                                        public static  VarInfo net_radiation
                                        {
                                            get { return _net_radiation;}
                                        }

                                        public static  VarInfo use_external_et0
                                        {
                                            get { return _use_external_et0;}
                                        }

                                        public static  VarInfo external_et0
                                        {
                                            get { return _external_et0;}
                                        }

                                        public static  VarInfo declination
                                        {
                                            get { return _declination;}
                                        }

                                        public static  VarInfo astronomic_daylength
                                        {
                                            get { return _astronomic_daylength;}
                                        }

                                        public static  VarInfo effective_daylength
                                        {
                                            get { return _effective_daylength;}
                                        }

                                        public static  VarInfo photoperiodic_daylength
                                        {
                                            get { return _photoperiodic_daylength;}
                                        }

                                        public static  VarInfo sunshine_hours_global_radiation
                                        {
                                            get { return _sunshine_hours_global_radiation;}
                                        }

                                        public static  VarInfo extraterrestrial_radiation
                                        {
                                            get { return _extraterrestrial_radiation;}
                                        }

                                        public static  VarInfo clear_day_radiation
                                        {
                                            get { return _clear_day_radiation;}
                                        }

                                        public static  VarInfo overcast_day_radiation
                                        {
                                            get { return _overcast_day_radiation;}
                                        }

                                        public static  VarInfo phot_act_radiation_mean
                                        {
                                            get { return _phot_act_radiation_mean;}
                                        }

                                        public static  VarInfo reference_evapotranspiration
                                        {
                                            get { return _reference_evapotranspiration;}
                                        }

                                        public static  VarInfo potential_evapotranspiration
                                        {
                                            get { return _potential_evapotranspiration;}
                                        }

                                        public static  VarInfo vapor_pressure
                                        {
                                            get { return _vapor_pressure;}
                                        }

                                        public static  VarInfo internal_vapor_pressure
                                        {
                                            get { return _internal_vapor_pressure;}
                                        }

                                        public static  VarInfo internal_et0
                                        {
                                            get { return _internal_et0;}
                                        }

                                        public static  VarInfo saturated_vapor_pressure
                                        {
                                            get { return _saturated_vapor_pressure;}
                                        }

                                        public static  VarInfo saturation_vapor_pressure_deficit
                                        {
                                            get { return _saturation_vapor_pressure_deficit;}
                                        }

                                        public static  VarInfo calculated_stomata_resistance
                                        {
                                            get { return _calculated_stomata_resistance;}
                                        }

                                        public static  VarInfo et0
                                        {
                                            get { return _et0;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _use_external_vapor_pressure.Name = "use_external_vapor_pressure";
                                            _use_external_vapor_pressure.Description = "boolean condition to be met";
                                            _use_external_vapor_pressure.MaxValue = -1D;
                                            _use_external_vapor_pressure.MinValue = -1D;
                                            _use_external_vapor_pressure.DefaultValue = -1D;
                                            _use_external_vapor_pressure.Units = "mm";
                                            _use_external_vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");

                                            _external_vapor_pressure.Name = "external_vapor_pressure";
                                            _external_vapor_pressure.Description = "value to be returned if condition is true";
                                            _external_vapor_pressure.MaxValue = -1D;
                                            _external_vapor_pressure.MinValue = 0;
                                            _external_vapor_pressure.DefaultValue = 0;
                                            _external_vapor_pressure.Units = "kPa";
                                            _external_vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _calc_stomata_resistance.Name = "calc_stomata_resistance";
                                            _calc_stomata_resistance.Description = "boolean condition to be met";
                                            _calc_stomata_resistance.MaxValue = -1D;
                                            _calc_stomata_resistance.MinValue = -1D;
                                            _calc_stomata_resistance.DefaultValue = -1D;
                                            _calc_stomata_resistance.Units = "";
                                            _calc_stomata_resistance.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");

                                            _fixed_stomata_resistance.Name = "fixed_stomata_resistance";
                                            _fixed_stomata_resistance.Description = "value to be returned if condition is false";
                                            _fixed_stomata_resistance.MaxValue = 10000;
                                            _fixed_stomata_resistance.MinValue = 0;
                                            _fixed_stomata_resistance.DefaultValue = 100;
                                            _fixed_stomata_resistance.Units = "s/m";
                                            _fixed_stomata_resistance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _gross_photosynthesis_reference_mol.Name = "gross_photosynthesis_reference_mol";
                                            _gross_photosynthesis_reference_mol.Description = "gross_photosynthesis_reference_mol (-1 = not supplied = no crop)";
                                            _gross_photosynthesis_reference_mol.MaxValue = -1D;
                                            _gross_photosynthesis_reference_mol.MinValue = 0;
                                            _gross_photosynthesis_reference_mol.DefaultValue = -1;
                                            _gross_photosynthesis_reference_mol.Units = "[mol m-2 s-1] or [cm3 cm-2 s-1]";
                                            _gross_photosynthesis_reference_mol.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

                                            _use_external_et0.Name = "use_external_et0";
                                            _use_external_et0.Description = "boolean condition to be met";
                                            _use_external_et0.MaxValue = -1D;
                                            _use_external_et0.MinValue = -1D;
                                            _use_external_et0.DefaultValue = -1D;
                                            _use_external_et0.Units = "";
                                            _use_external_et0.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");

                                            _external_et0.Name = "external_et0";
                                            _external_et0.Description = "value to be returned if condition is true";
                                            _external_et0.MaxValue = -1D;
                                            _external_et0.MinValue = 0;
                                            _external_et0.DefaultValue = 0;
                                            _external_et0.Units = "mm";
                                            _external_et0.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _declination.Name = "declination";
                                            _declination.Description = "declination";
                                            _declination.MaxValue = -1D;
                                            _declination.MinValue = 0;
                                            _declination.DefaultValue = -1D;
                                            _declination.Units = "";
                                            _declination.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _astronomic_daylength.Name = "astronomic_daylength";
                                            _astronomic_daylength.Description = "astronomic_daylength";
                                            _astronomic_daylength.MaxValue = -1D;
                                            _astronomic_daylength.MinValue = 0;
                                            _astronomic_daylength.DefaultValue = -1D;
                                            _astronomic_daylength.Units = "mm";
                                            _astronomic_daylength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _effective_daylength.Name = "effective_daylength";
                                            _effective_daylength.Description = "effective_daylength";
                                            _effective_daylength.MaxValue = -1D;
                                            _effective_daylength.MinValue = 0;
                                            _effective_daylength.DefaultValue = -1D;
                                            _effective_daylength.Units = "mm";
                                            _effective_daylength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _photoperiodic_daylength.Name = "photoperiodic_daylength";
                                            _photoperiodic_daylength.Description = "photoperiodic_daylength";
                                            _photoperiodic_daylength.MaxValue = -1D;
                                            _photoperiodic_daylength.MinValue = 0;
                                            _photoperiodic_daylength.DefaultValue = -1D;
                                            _photoperiodic_daylength.Units = "mm";
                                            _photoperiodic_daylength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _sunshine_hours_global_radiation.Name = "sunshine_hours_global_radiation";
                                            _sunshine_hours_global_radiation.Description = "global radiation calculated from sunshine hours";
                                            _sunshine_hours_global_radiation.MaxValue = -1D;
                                            _sunshine_hours_global_radiation.MinValue = 0;
                                            _sunshine_hours_global_radiation.DefaultValue = -1D;
                                            _sunshine_hours_global_radiation.Units = "MJ/m2";
                                            _sunshine_hours_global_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _extraterrestrial_radiation.Name = "extraterrestrial_radiation";
                                            _extraterrestrial_radiation.Description = "extraterrestrial_radiation";
                                            _extraterrestrial_radiation.MaxValue = -1D;
                                            _extraterrestrial_radiation.MinValue = 0;
                                            _extraterrestrial_radiation.DefaultValue = -1D;
                                            _extraterrestrial_radiation.Units = "MJ/m2";
                                            _extraterrestrial_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _clear_day_radiation.Name = "clear_day_radiation";
                                            _clear_day_radiation.Description = "clear_day_radiation";
                                            _clear_day_radiation.MaxValue = -1D;
                                            _clear_day_radiation.MinValue = 0;
                                            _clear_day_radiation.DefaultValue = -1D;
                                            _clear_day_radiation.Units = "MJ/m2";
                                            _clear_day_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _overcast_day_radiation.Name = "overcast_day_radiation";
                                            _overcast_day_radiation.Description = "overcast_day_radiation";
                                            _overcast_day_radiation.MaxValue = -1D;
                                            _overcast_day_radiation.MinValue = 0;
                                            _overcast_day_radiation.DefaultValue = -1D;
                                            _overcast_day_radiation.Units = "MJ/m2";
                                            _overcast_day_radiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _phot_act_radiation_mean.Name = "phot_act_radiation_mean";
                                            _phot_act_radiation_mean.Description = "phot_act_radiation_mean";
                                            _phot_act_radiation_mean.MaxValue = -1D;
                                            _phot_act_radiation_mean.MinValue = 0;
                                            _phot_act_radiation_mean.DefaultValue = -1D;
                                            _phot_act_radiation_mean.Units = "J/m2";
                                            _phot_act_radiation_mean.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

                                            _vapor_pressure.Name = "vapor_pressure";
                                            _vapor_pressure.Description = "vapor pressure from relative humidity and saturated vapor pressure";
                                            _vapor_pressure.MaxValue = -1D;
                                            _vapor_pressure.MinValue = 0;
                                            _vapor_pressure.DefaultValue = -1D;
                                            _vapor_pressure.Units = "kPa";
                                            _vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _internal_vapor_pressure.Name = "internal_vapor_pressure";
                                            _internal_vapor_pressure.Description = "value to be returned if condition is false";
                                            _internal_vapor_pressure.MaxValue = -1D;
                                            _internal_vapor_pressure.MinValue = 0;
                                            _internal_vapor_pressure.DefaultValue = 0;
                                            _internal_vapor_pressure.Units = "kPa";
                                            _internal_vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _internal_et0.Name = "internal_et0";
                                            _internal_et0.Description = "value to be returned if condition is false";
                                            _internal_et0.MaxValue = -1D;
                                            _internal_et0.MinValue = 0;
                                            _internal_et0.DefaultValue = 0;
                                            _internal_et0.Units = "mm";
                                            _internal_et0.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _saturated_vapor_pressure.Name = "saturated_vapor_pressure";
                                            _saturated_vapor_pressure.Description = "saturated vapor pressure";
                                            _saturated_vapor_pressure.MaxValue = -1D;
                                            _saturated_vapor_pressure.MinValue = 0;
                                            _saturated_vapor_pressure.DefaultValue = -1D;
                                            _saturated_vapor_pressure.Units = "kPa";
                                            _saturated_vapor_pressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _saturation_vapor_pressure_deficit.Name = "saturation_vapor_pressure_deficit";
                                            _saturation_vapor_pressure_deficit.Description = "saturation vapor pressure deficit";
                                            _saturation_vapor_pressure_deficit.MaxValue = -1D;
                                            _saturation_vapor_pressure_deficit.MinValue = 0;
                                            _saturation_vapor_pressure_deficit.DefaultValue = -1D;
                                            _saturation_vapor_pressure_deficit.Units = "kPa";
                                            _saturation_vapor_pressure_deficit.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _calculated_stomata_resistance.Name = "calculated_stomata_resistance";
                                            _calculated_stomata_resistance.Description = "value to be returned if condition is true";
                                            _calculated_stomata_resistance.MaxValue = 10000;
                                            _calculated_stomata_resistance.MinValue = 0;
                                            _calculated_stomata_resistance.DefaultValue = 100;
                                            _calculated_stomata_resistance.Units = "s/m";
                                            _calculated_stomata_resistance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _et0.Name = "et0";
                                            _et0.Description = "the output value";
                                            _et0.MaxValue = -1D;
                                            _et0.MinValue = 0;
                                            _et0.DefaultValue = -1D;
                                            _et0.Units = "mm";
                                            _et0.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }