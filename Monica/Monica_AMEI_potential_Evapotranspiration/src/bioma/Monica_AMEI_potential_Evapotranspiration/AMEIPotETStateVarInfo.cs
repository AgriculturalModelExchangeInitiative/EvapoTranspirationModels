
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace AMEIPotET.DomainClass
                                {
                                    public class AMEIPotETStateVarInfo : IVarInfoClass
                                    {

                                        static AMEIPotETStateVarInfo()
                                        {
                                            AMEIPotETStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "AMEIPotETState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "AMEIPotETState";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }