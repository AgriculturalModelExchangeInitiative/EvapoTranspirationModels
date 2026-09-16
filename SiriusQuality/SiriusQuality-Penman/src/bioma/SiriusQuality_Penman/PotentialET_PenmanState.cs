
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
{
    public class PotentialET_PenmanState : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public PotentialET_PenmanState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public PotentialET_PenmanState(PotentialET_PenmanState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                    }
                }

                public string Description
                {
                    get { return "PotentialET_PenmanState of the component";}
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