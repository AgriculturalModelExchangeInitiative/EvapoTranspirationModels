
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityAMEIRefET.DomainClass
                {
                    public class AMEIRefETAuxiliary : ICloneable, IDomainClass
                    {
                        private double _stomata_resistance;
                        private double _net_radiation;
                        private double _saturation_vapor_pressure_deficit;
                        private double _saturated_vapor_pressure_slope;
                        private double _psychrometric_constant;
                        private double _reference_evapotranspiration;
                        private ParametersIO _parametersIO;

                        public AMEIRefETAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public AMEIRefETAuxiliary(AMEIRefETAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        stomata_resistance = toCopy.stomata_resistance;
                                        net_radiation = toCopy.net_radiation;
                                        saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
                                        saturated_vapor_pressure_slope = toCopy.saturated_vapor_pressure_slope;
                                        psychrometric_constant = toCopy.psychrometric_constant;
                                        reference_evapotranspiration = toCopy.reference_evapotranspiration;
                                    }
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
                                public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }
                                public double saturated_vapor_pressure_slope
    {
        get { return this._saturated_vapor_pressure_slope; }
        set { this._saturated_vapor_pressure_slope= value; } 
    }
                                public double psychrometric_constant
    {
        get { return this._psychrometric_constant; }
        set { this._psychrometric_constant= value; } 
    }
                                public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }

                                public string Description
                                {
                                    get { return "AMEIRefETAuxiliary of the component";}
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
                                     _stomata_resistance = default(double);
                                     _net_radiation = default(double);
                                     _saturation_vapor_pressure_deficit = default(double);
                                     _saturated_vapor_pressure_slope = default(double);
                                     _psychrometric_constant = default(double);
                                     _reference_evapotranspiration = default(double);
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