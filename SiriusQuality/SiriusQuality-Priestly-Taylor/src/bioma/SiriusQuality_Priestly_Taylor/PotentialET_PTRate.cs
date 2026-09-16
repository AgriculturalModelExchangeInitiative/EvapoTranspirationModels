
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
        {
            public class PotentialET_PTRate : ICloneable, IDomainClass
            {
                private double _evapoTranspirationPriestlyTaylor;
                private ParametersIO _parametersIO;

                public PotentialET_PTRate()
                {
                    _parametersIO = new ParametersIO(this);
                }

                public PotentialET_PTRate(PotentialET_PTRate toCopy, bool copyAll) // copy constructor 
                {
                    if (copyAll)
                    {
                                evapoTranspirationPriestlyTaylor = toCopy.evapoTranspirationPriestlyTaylor;
                            }
                        }

                        public double evapoTranspirationPriestlyTaylor
    {
        get { return this._evapoTranspirationPriestlyTaylor; }
        set { this._evapoTranspirationPriestlyTaylor= value; } 
    }

                        public string Description
                        {
                            get { return "PotentialET_PTRate of the component";}
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