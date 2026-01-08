
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPriestleyTaylor_.DomainClass
                {
                    public class ReferenceETPriestleyTaylor_Auxiliary : ICloneable, IDomainClass
                    {
                        private double _ReferenceCropEvapotranspiration;
                        private ParametersIO _parametersIO;

                        public ReferenceETPriestleyTaylor_Auxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public ReferenceETPriestleyTaylor_Auxiliary(ReferenceETPriestleyTaylor_Auxiliary toCopy, bool copyAll) // copy constructor 
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
                                    get { return "ReferenceETPriestleyTaylor_Auxiliary of the component";}
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