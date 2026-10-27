
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIPotET.DomainClass
                        {
                            public class AMEIPotETExogenous : ICloneable, IDomainClass
                            {
                                private double _mean_air_temperature;
                                private double _wind_speed;
                                private double _wind_speed_height;
                                private double _kc_factor;
                                private int _developmental_stage;
                                private double _crop_remaining_evapotranspiration;
                                private ParametersIO _parametersIO;

                                public AMEIPotETExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public AMEIPotETExogenous(AMEIPotETExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                mean_air_temperature = toCopy.mean_air_temperature;
                                                wind_speed = toCopy.wind_speed;
                                                wind_speed_height = toCopy.wind_speed_height;
                                                kc_factor = toCopy.kc_factor;
                                                developmental_stage = toCopy.developmental_stage;
                                                crop_remaining_evapotranspiration = toCopy.crop_remaining_evapotranspiration;
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
                                        public double kc_factor
    {
        get { return this._kc_factor; }
        set { this._kc_factor= value; } 
    }
                                        public int developmental_stage
    {
        get { return this._developmental_stage; }
        set { this._developmental_stage= value; } 
    }
                                        public double crop_remaining_evapotranspiration
    {
        get { return this._crop_remaining_evapotranspiration; }
        set { this._crop_remaining_evapotranspiration= value; } 
    }

                                        public string Description
                                        {
                                            get { return "AMEIPotETExogenous of the component";}
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
                                             _kc_factor = default(double);
                                             _developmental_stage = default(int);
                                             _crop_remaining_evapotranspiration = default(double);
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