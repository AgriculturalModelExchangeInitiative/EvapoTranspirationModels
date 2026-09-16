
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
        {
            public class PotentialET_PenmanRate : ICloneable, IDomainClass
            {
                private double _evapoTranspirationPenman;
                private double _evapoTranspirationPriestlyTaylor;
                private ParametersIO _parametersIO;

                public PotentialET_PenmanRate()
                {
                    _parametersIO = new ParametersIO(this);
                }

                public PotentialET_PenmanRate(PotentialET_PenmanRate toCopy, bool copyAll) // copy constructor 
                {
                    if (copyAll)
                    {
                                evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
                                evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
                            }
                        }

                        public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }
                        public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }

                        public string Description
                        {
                            get { return "PotentialET_PenmanRate of the component";}
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
                             _evapoTranspirationPenman = default(double);
                             _evapoTranspirationPriestlyTaylor = default(double);
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