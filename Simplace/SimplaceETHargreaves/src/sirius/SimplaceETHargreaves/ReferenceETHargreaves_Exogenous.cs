
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETHargreaves_.DomainClass
                        {
                            public class ReferenceETHargreaves_Exogenous : ICloneable, IDomainClass
                            {
                                private double _iTMax;
                                private double _iSolarRadiation;
                                private double _iTMin;
                                private ParametersIO _parametersIO;

                                public ReferenceETHargreaves_Exogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public ReferenceETHargreaves_Exogenous(ReferenceETHargreaves_Exogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                iTMax = toCopy.iTMax;
                                                iSolarRadiation = toCopy.iSolarRadiation;
                                                iTMin = toCopy.iTMin;
                                            }
                                        }

                                        public double iTMax
    {
        get { return this._iTMax; }
        set { this._iTMax= value; } 
    }
                                        public double iSolarRadiation
    {
        get { return this._iSolarRadiation; }
        set { this._iSolarRadiation= value; } 
    }
                                        public double iTMin
    {
        get { return this._iTMin; }
        set { this._iTMin= value; } 
    }

                                        public string Description
                                        {
                                            get { return "ReferenceETHargreaves_Exogenous of the component";}
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
                                             _iTMax = default(double);
                                             _iSolarRadiation = default(double);
                                             _iTMin = default(double);
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