
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPM_.DomainClass
                        {
                            public class ReferenceETPM_Exogenous : ICloneable, IDomainClass
                            {
                                private double _iNetRadiation;
                                private double _iActualVapourPressure;
                                private double _iTMax;
                                private double _iTMin;
                                private double _iWindspeed;
                                private ParametersIO _parametersIO;

                                public ReferenceETPM_Exogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public ReferenceETPM_Exogenous(ReferenceETPM_Exogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                iNetRadiation = toCopy.iNetRadiation;
                                                iActualVapourPressure = toCopy.iActualVapourPressure;
                                                iTMax = toCopy.iTMax;
                                                iTMin = toCopy.iTMin;
                                                iWindspeed = toCopy.iWindspeed;
                                            }
                                        }

                                        public double iNetRadiation
    {
        get { return this._iNetRadiation; }
        set { this._iNetRadiation= value; } 
    }
                                        public double iActualVapourPressure
    {
        get { return this._iActualVapourPressure; }
        set { this._iActualVapourPressure= value; } 
    }
                                        public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }
                                        public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }
                                        public double iWindspeed
    {
        get { return this._iWindspeed; }
        set { this._iWindspeed= value; } 
    }

                                        public string Description
                                        {
                                            get { return "ReferenceETPM_Exogenous of the component";}
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
                                             _iNetRadiation = default(double);
                                             _iActualVapourPressure = default(double);
                                             _iTMax = default(double);
                                             _iTMin = default(double);
                                             _iWindspeed = default(double);
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