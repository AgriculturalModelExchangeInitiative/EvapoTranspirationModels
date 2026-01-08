
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPriestleyTaylor_.DomainClass
                        {
                            public class ReferenceETPriestleyTaylor_Exogenous : ICloneable, IDomainClass
                            {
                                private double _iTMin;
                                private double _iNetRadiation;
                                private double _iTMax;
                                private ParametersIO _parametersIO;

                                public ReferenceETPriestleyTaylor_Exogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public ReferenceETPriestleyTaylor_Exogenous(ReferenceETPriestleyTaylor_Exogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                iTMin = toCopy.iTMin;
                                                iNetRadiation = toCopy.iNetRadiation;
                                                iTMax = toCopy.iTMax;
                                            }
                                        }

                                        public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }
                                        public double iNetRadiation
    {
        get { return this._iNetRadiation; }
        set { this._iNetRadiation= value; } 
    }
                                        public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }

                                        public string Description
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Exogenous of the component";}
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
                                             _iTMin = default(double);
                                             _iNetRadiation = default(double);
                                             _iTMax = default(double);
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