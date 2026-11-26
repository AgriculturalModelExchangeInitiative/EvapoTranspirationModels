
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIRefET.DomainClass
                                {
                                    public class AMEIRefETRateVarInfo : IVarInfoClass
                                    {

                                        static AMEIRefETRateVarInfo()
                                        {
                                            AMEIRefETRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIRefETRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIRefETRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }