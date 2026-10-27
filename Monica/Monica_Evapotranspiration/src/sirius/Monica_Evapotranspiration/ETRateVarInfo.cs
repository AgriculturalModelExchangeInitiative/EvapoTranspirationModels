
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityET.DomainClass
                                {
                                    public class ETRateVarInfo : IVarInfoClass
                                    {

                                        static ETRateVarInfo()
                                        {
                                            ETRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ETRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ETRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }