
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                {
                    public class PotentialET_PTAuxiliary : ICloneable, IDomainClass
                    {
                        private double _solarRadiation;
                        private double _hslope;
                        private double _netRadiation;
                        private ParametersIO _parametersIO;

                        public PotentialET_PTAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public PotentialET_PTAuxiliary(PotentialET_PTAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        solarRadiation = toCopy.solarRadiation;
                                        hslope = toCopy.hslope;
                                        netRadiation = toCopy.netRadiation;
                                    }
                                }

                                public double solarRadiation
    {
        get { return this._solarRadiation; }
        set { this._solarRadiation= value; } 
    }
                                public double hslope
    {
        get { return this._hslope; }
        set { this._hslope= value; } 
    }
                                public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }

                                public string Description
                                {
                                    get { return "PotentialET_PTAuxiliary of the component";}
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
                                     _solarRadiation = default(double);
                                     _hslope = default(double);
                                     _netRadiation = default(double);
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