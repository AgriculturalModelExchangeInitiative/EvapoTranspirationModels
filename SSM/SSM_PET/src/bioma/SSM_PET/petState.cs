
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
{
    public class petState : ICloneable, IDomainClass
    {
        private double _pet;
        private ParametersIO _parametersIO;

        public petState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public petState(petState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                        pet = toCopy.pet;
                    }
                }

                public double pet
    {
        get { return this._pet; }
        set { this._pet= value; } 
    }

                public string Description
                {
                    get { return "petState of the component";}
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
                     _pet = default(double);
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