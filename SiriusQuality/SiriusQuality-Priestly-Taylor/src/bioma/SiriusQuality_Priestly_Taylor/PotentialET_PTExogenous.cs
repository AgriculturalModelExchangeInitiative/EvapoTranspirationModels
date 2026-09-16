
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                        {
                            public class PotentialET_PTExogenous : ICloneable, IDomainClass
                            {
                                private ParametersIO _parametersIO;

                                public PotentialET_PTExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public PotentialET_PTExogenous(PotentialET_PTExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                            }
                                        }

                                        public string Description
                                        {
                                            get { return "PotentialET_PTExogenous of the component";}
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