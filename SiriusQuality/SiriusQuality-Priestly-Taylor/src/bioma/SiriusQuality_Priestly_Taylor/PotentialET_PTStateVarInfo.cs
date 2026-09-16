
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                                {
                                    public class PotentialET_PTStateVarInfo : IVarInfoClass
                                    {

                                        static PotentialET_PTStateVarInfo()
                                        {
                                            PotentialET_PTStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PTState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PTState";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }