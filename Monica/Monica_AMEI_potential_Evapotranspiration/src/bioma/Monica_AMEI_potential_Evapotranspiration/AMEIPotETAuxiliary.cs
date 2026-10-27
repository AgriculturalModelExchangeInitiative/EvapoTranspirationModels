
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIPotET.DomainClass
                {
                    public class AMEIPotETAuxiliary : ICloneable, IDomainClass
                    {
                        private double _vapor_pressure;
                        private double _saturated_vapor_pressure;
                        private double _stomata_resistance;
                        private double _net_radiation;
                        private double _reference_evapotranspiration;
                        private double _potential_evapotranspiration;
                        private double _saturation_vapor_pressure_deficit;
                        private ParametersIO _parametersIO;

                        public AMEIPotETAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public AMEIPotETAuxiliary(AMEIPotETAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        vapor_pressure = toCopy.vapor_pressure;
                                        saturated_vapor_pressure = toCopy.saturated_vapor_pressure;
                                        stomata_resistance = toCopy.stomata_resistance;
                                        net_radiation = toCopy.net_radiation;
                                        reference_evapotranspiration = toCopy.reference_evapotranspiration;
                                        potential_evapotranspiration = toCopy.potential_evapotranspiration;
                                        saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
                                    }
                                }

                                public double vapor_pressure
    {
        get { return this._vapor_pressure; }
        set { this._vapor_pressure= value; } 
    }
                                public double saturated_vapor_pressure
    {
        get { return this._saturated_vapor_pressure; }
        set { this._saturated_vapor_pressure= value; } 
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
                                public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }

                                public string Description
                                {
                                    get { return "AMEIPotETAuxiliary of the component";}
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
                                     _vapor_pressure = default(double);
                                     _saturated_vapor_pressure = default(double);
                                     _stomata_resistance = default(double);
                                     _net_radiation = default(double);
                                     _reference_evapotranspiration = default(double);
                                     _potential_evapotranspiration = default(double);
                                     _saturation_vapor_pressure_deficit = default(double);
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