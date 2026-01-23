
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
                        {
                            public class petExogenous : ICloneable, IDomainClass
                            {
                                private double _tmax;
                                private double _tmin;
                                private double _srad;
                                private double _etlai;
                                private ParametersIO _parametersIO;

                                public petExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public petExogenous(petExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                tmax = toCopy.tmax;
                                                tmin = toCopy.tmin;
                                                srad = toCopy.srad;
                                                etlai = toCopy.etlai;
                                            }
                                        }

                                        public double tmax
    {
        get { return this._tmax; }
        set { this._tmax= value; } 
    }
                                        public double tmin
    {
        get { return this._tmin; }
        set { this._tmin= value; } 
    }
                                        public double srad
    {
        get { return this._srad; }
        set { this._srad= value; } 
    }
                                        public double etlai
    {
        get { return this._etlai; }
        set { this._etlai= value; } 
    }

                                        public string Description
                                        {
                                            get { return "petExogenous of the component";}
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
                                             _tmax = default(double);
                                             _tmin = default(double);
                                             _srad = default(double);
                                             _etlai = default(double);
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