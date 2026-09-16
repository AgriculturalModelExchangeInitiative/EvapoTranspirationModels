
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                {
                    public class PotentialET_PenmanAuxiliary : ICloneable, IDomainClass
                    {
                        private double _netRadiation;
                        private double _solarRadiation;
                        private double _hslope;
                        private double _VPDair;
                        private double _conductance;
                        private ParametersIO _parametersIO;

                        public PotentialET_PenmanAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public PotentialET_PenmanAuxiliary(PotentialET_PenmanAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        netRadiation = toCopy.netRadiation;
                                        solarRadiation = toCopy.solarRadiation;
                                        hslope = toCopy.hslope;
                                        VPDair = toCopy.VPDair;
                                        conductance = toCopy.conductance;
                                    }
                                }

                                public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
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
                                public double VPDair
    {
        get { return this._VPDair; }
        set { this._VPDair= value; } 
    }
                                public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }

                                public string Description
                                {
                                    get { return "PotentialET_PenmanAuxiliary of the component";}
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
                                     _netRadiation = default(double);
                                     _solarRadiation = default(double);
                                     _hslope = default(double);
                                     _VPDair = default(double);
                                     _conductance = default(double);
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