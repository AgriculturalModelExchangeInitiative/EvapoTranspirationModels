
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
        {
            public class EnergyBalanceCompositeRate : ICloneable, IDomainClass
            {
                private double _evapoTranspirationPriestlyTaylor;
                private double _evapoTranspirationPenman;
                private ParametersIO _parametersIO;

                public EnergyBalanceCompositeRate()
                {
                    _parametersIO = new ParametersIO(this);
                }

                public EnergyBalanceCompositeRate(EnergyBalanceCompositeRate toCopy, bool copyAll) // copy constructor 
                {
                    if (copyAll)
                    {
                                evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
                                evapoTranspirationPenman = toCopy.evapoTranspirationPenman;
                            }
                        }

                        public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }
                        public double evapoTranspirationPenman
    {
        get { return this._evapoTranspirationPenman; }
        set { this._evapoTranspirationPenman= value; } 
    }

                        public string Description
                        {
                            get { return "EnergyBalanceCompositeRate of the component";}
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
                             _evapoTranspirationPriestlyTaylor = default(double);
                             _evapoTranspirationPenman = default(double);
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