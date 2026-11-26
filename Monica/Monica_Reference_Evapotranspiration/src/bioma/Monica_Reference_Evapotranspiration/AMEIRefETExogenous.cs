
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIRefET.DomainClass
                        {
                            public class AMEIRefETExogenous : ICloneable, IDomainClass
                            {
                                private double _mean_air_temperature;
                                private double _wind_speed;
                                private double _wind_speed_height;
                                private ParametersIO _parametersIO;

                                public AMEIRefETExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public AMEIRefETExogenous(AMEIRefETExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                mean_air_temperature = toCopy.mean_air_temperature;
                                                wind_speed = toCopy.wind_speed;
                                                wind_speed_height = toCopy.wind_speed_height;
                                            }
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

                                        public string Description
                                        {
                                            get { return "AMEIRefETExogenous of the component";}
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
                                             _mean_air_temperature = default(double);
                                             _wind_speed = default(double);
                                             _wind_speed_height = default(double);
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