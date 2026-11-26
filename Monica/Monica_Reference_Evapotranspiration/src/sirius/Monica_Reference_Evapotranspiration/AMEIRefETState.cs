
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityAMEIRefET.DomainClass
{
    public class AMEIRefETState : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public AMEIRefETState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public AMEIRefETState(AMEIRefETState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                    }
                }

                public string Description
                {
                    get { return "AMEIRefETState of the component";}
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