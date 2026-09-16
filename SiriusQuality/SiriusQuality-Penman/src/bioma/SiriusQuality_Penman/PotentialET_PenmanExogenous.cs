
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                        {
                            public class PotentialET_PenmanExogenous : ICloneable, IDomainClass
                            {
                                private ParametersIO _parametersIO;

                                public PotentialET_PenmanExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public PotentialET_PenmanExogenous(PotentialET_PenmanExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                            }
                                        }

                                        public string Description
                                        {
                                            get { return "PotentialET_PenmanExogenous of the component";}
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