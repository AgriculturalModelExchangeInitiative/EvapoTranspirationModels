
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETHargreaves_.DomainClass
                {
                    public class ReferenceETHargreaves_Auxiliary : ICloneable, IDomainClass
                    {
                        private double _ReferenceCropEvapotranspiration;
                        private ParametersIO _parametersIO;

                        public ReferenceETHargreaves_Auxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public ReferenceETHargreaves_Auxiliary(ReferenceETHargreaves_Auxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        ReferenceCropEvapotranspiration = toCopy.ReferenceCropEvapotranspiration;
                                    }
                                }

                                public double ReferenceCropEvapotranspiration
    {
        get { return this._ReferenceCropEvapotranspiration; }
        set { this._ReferenceCropEvapotranspiration= value; } 
    }

                                public string Description
                                {
                                    get { return "ReferenceETHargreaves_Auxiliary of the component";}
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
                                     _ReferenceCropEvapotranspiration = default(double);
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