
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPM_.DomainClass
{
    public class ReferenceETPM_State : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public ReferenceETPM_State()
        {
            _parametersIO = new ParametersIO(this);
        }

        public ReferenceETPM_State(ReferenceETPM_State toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                    }
                }

                public string Description
                {
                    get { return "ReferenceETPM_State of the component";}
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