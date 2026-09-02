
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
{
    public class EnergyBalanceCompositeState : ICloneable, IDomainClass
    {
        private int _ih;
        private double _conductance;
        private ParametersIO _parametersIO;

        public EnergyBalanceCompositeState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public EnergyBalanceCompositeState(EnergyBalanceCompositeState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                        ih = toCopy.ih;
                        conductance = toCopy.conductance;
                    }
                }

                public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
                public double conductance
    {
        get { return this._conductance; }
        set { this._conductance= value; } 
    }

                public string Description
                {
                    get { return "EnergyBalanceCompositeState of the component";}
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
                     _ih = default(int);
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