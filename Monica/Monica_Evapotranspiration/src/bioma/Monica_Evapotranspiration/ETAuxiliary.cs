
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
                {
                    public class ETAuxiliary : ICloneable, IDomainClass
                    {
                        private bool _use_external_vapor_pressure;
                        private double _external_vapor_pressure;
                        private bool _calc_stomata_resistance;
                        private double _fixed_stomata_resistance;
                        private double _gross_photosynthesis_reference_mol;
                        private double _stomata_resistance;
                        private double _net_radiation;
                        private bool _use_external_et0;
                        private double _external_et0;
                        private double _declination;
                        private double _astronomic_daylength;
                        private double _effective_daylength;
                        private double _photoperiodic_daylength;
                        private double _sunshine_hours_global_radiation;
                        private double _extraterrestrial_radiation;
                        private double _clear_day_radiation;
                        private double _overcast_day_radiation;
                        private double _phot_act_radiation_mean;
                        private double _reference_evapotranspiration;
                        private double _potential_evapotranspiration;
                        private double _vapor_pressure;
                        private double _internal_vapor_pressure;
                        private double _internal_et0;
                        private double _saturated_vapor_pressure;
                        private double _saturation_vapor_pressure_deficit;
                        private double _calculated_stomata_resistance;
                        private double _et0;
                        private ParametersIO _parametersIO;

                        public ETAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public ETAuxiliary(ETAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        use_external_vapor_pressure = toCopy.use_external_vapor_pressure;
                                        external_vapor_pressure = toCopy.external_vapor_pressure;
                                        calc_stomata_resistance = toCopy.calc_stomata_resistance;
                                        fixed_stomata_resistance = toCopy.fixed_stomata_resistance;
                                        gross_photosynthesis_reference_mol = toCopy.gross_photosynthesis_reference_mol;
                                        stomata_resistance = toCopy.stomata_resistance;
                                        net_radiation = toCopy.net_radiation;
                                        use_external_et0 = toCopy.use_external_et0;
                                        external_et0 = toCopy.external_et0;
                                        declination = toCopy.declination;
                                        astronomic_daylength = toCopy.astronomic_daylength;
                                        effective_daylength = toCopy.effective_daylength;
                                        photoperiodic_daylength = toCopy.photoperiodic_daylength;
                                        sunshine_hours_global_radiation = toCopy.sunshine_hours_global_radiation;
                                        extraterrestrial_radiation = toCopy.extraterrestrial_radiation;
                                        clear_day_radiation = toCopy.clear_day_radiation;
                                        overcast_day_radiation = toCopy.overcast_day_radiation;
                                        phot_act_radiation_mean = toCopy.phot_act_radiation_mean;
                                        reference_evapotranspiration = toCopy.reference_evapotranspiration;
                                        potential_evapotranspiration = toCopy.potential_evapotranspiration;
                                        vapor_pressure = toCopy.vapor_pressure;
                                        internal_vapor_pressure = toCopy.internal_vapor_pressure;
                                        internal_et0 = toCopy.internal_et0;
                                        saturated_vapor_pressure = toCopy.saturated_vapor_pressure;
                                        saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
                                        calculated_stomata_resistance = toCopy.calculated_stomata_resistance;
                                        et0 = toCopy.et0;
                                    }
                                }

                                public bool use_external_vapor_pressure
    {
        get { return this._use_external_vapor_pressure; }
        set { this._use_external_vapor_pressure= value; } 
    }
                                public double external_vapor_pressure
    {
        get { return this._external_vapor_pressure; }
        set { this._external_vapor_pressure= value; } 
    }
                                public bool calc_stomata_resistance
    {
        get { return this._calc_stomata_resistance; }
        set { this._calc_stomata_resistance= value; } 
    }
                                public double fixed_stomata_resistance
    {
        get { return this._fixed_stomata_resistance; }
        set { this._fixed_stomata_resistance= value; } 
    }
                                public double gross_photosynthesis_reference_mol
    {
        get { return this._gross_photosynthesis_reference_mol; }
        set { this._gross_photosynthesis_reference_mol= value; } 
    }
                                public double stomata_resistance
    {
        get { return this._stomata_resistance; }
        set { this._stomata_resistance= value; } 
    }
                                public double net_radiation
    {
        get { return this._net_radiation; }
        set { this._net_radiation= value; } 
    }
                                public bool use_external_et0
    {
        get { return this._use_external_et0; }
        set { this._use_external_et0= value; } 
    }
                                public double external_et0
    {
        get { return this._external_et0; }
        set { this._external_et0= value; } 
    }
                                public double declination
    {
        get { return this._declination; }
        set { this._declination= value; } 
    }
                                public double astronomic_daylength
    {
        get { return this._astronomic_daylength; }
        set { this._astronomic_daylength= value; } 
    }
                                public double effective_daylength
    {
        get { return this._effective_daylength; }
        set { this._effective_daylength= value; } 
    }
                                public double photoperiodic_daylength
    {
        get { return this._photoperiodic_daylength; }
        set { this._photoperiodic_daylength= value; } 
    }
                                public double sunshine_hours_global_radiation
    {
        get { return this._sunshine_hours_global_radiation; }
        set { this._sunshine_hours_global_radiation= value; } 
    }
                                public double extraterrestrial_radiation
    {
        get { return this._extraterrestrial_radiation; }
        set { this._extraterrestrial_radiation= value; } 
    }
                                public double clear_day_radiation
    {
        get { return this._clear_day_radiation; }
        set { this._clear_day_radiation= value; } 
    }
                                public double overcast_day_radiation
    {
        get { return this._overcast_day_radiation; }
        set { this._overcast_day_radiation= value; } 
    }
                                public double phot_act_radiation_mean
    {
        get { return this._phot_act_radiation_mean; }
        set { this._phot_act_radiation_mean= value; } 
    }
                                public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }
                                public double potential_evapotranspiration
    {
        get { return this._potential_evapotranspiration; }
        set { this._potential_evapotranspiration= value; } 
    }
                                public double vapor_pressure
    {
        get { return this._vapor_pressure; }
        set { this._vapor_pressure= value; } 
    }
                                public double internal_vapor_pressure
    {
        get { return this._internal_vapor_pressure; }
        set { this._internal_vapor_pressure= value; } 
    }
                                public double internal_et0
    {
        get { return this._internal_et0; }
        set { this._internal_et0= value; } 
    }
                                public double saturated_vapor_pressure
    {
        get { return this._saturated_vapor_pressure; }
        set { this._saturated_vapor_pressure= value; } 
    }
                                public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }
                                public double calculated_stomata_resistance
    {
        get { return this._calculated_stomata_resistance; }
        set { this._calculated_stomata_resistance= value; } 
    }
                                public double et0
    {
        get { return this._et0; }
        set { this._et0= value; } 
    }

                                public string Description
                                {
                                    get { return "ETAuxiliary of the component";}
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
                                     _use_external_vapor_pressure = default(bool);
                                     _external_vapor_pressure = default(double);
                                     _calc_stomata_resistance = default(bool);
                                     _fixed_stomata_resistance = default(double);
                                     _gross_photosynthesis_reference_mol = default(double);
                                     _stomata_resistance = default(double);
                                     _net_radiation = default(double);
                                     _use_external_et0 = default(bool);
                                     _external_et0 = default(double);
                                     _declination = default(double);
                                     _astronomic_daylength = default(double);
                                     _effective_daylength = default(double);
                                     _photoperiodic_daylength = default(double);
                                     _sunshine_hours_global_radiation = default(double);
                                     _extraterrestrial_radiation = default(double);
                                     _clear_day_radiation = default(double);
                                     _overcast_day_radiation = default(double);
                                     _phot_act_radiation_mean = default(double);
                                     _reference_evapotranspiration = default(double);
                                     _potential_evapotranspiration = default(double);
                                     _vapor_pressure = default(double);
                                     _internal_vapor_pressure = default(double);
                                     _internal_et0 = default(double);
                                     _saturated_vapor_pressure = default(double);
                                     _saturation_vapor_pressure_deficit = default(double);
                                     _calculated_stomata_resistance = default(double);
                                     _et0 = default(double);
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