
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                                {
                                    public class PotentialET_PTExogenousVarInfo : IVarInfoClass
                                    {

                                        static PotentialET_PTExogenousVarInfo()
                                        {
                                            PotentialET_PTExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PTExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PTExogenous";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }