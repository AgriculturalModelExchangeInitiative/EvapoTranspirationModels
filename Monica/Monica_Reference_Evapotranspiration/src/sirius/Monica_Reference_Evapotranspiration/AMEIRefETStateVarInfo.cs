
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityAMEIRefET.DomainClass
                                {
                                    public class AMEIRefETStateVarInfo : IVarInfoClass
                                    {

                                        static AMEIRefETStateVarInfo()
                                        {
                                            AMEIRefETStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIRefETState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIRefETState";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }