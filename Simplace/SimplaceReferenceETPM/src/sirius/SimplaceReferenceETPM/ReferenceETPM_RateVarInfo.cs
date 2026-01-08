
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPM_.DomainClass
                                {
                                    public class ReferenceETPM_RateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETPM_RateVarInfo()
                                        {
                                            ReferenceETPM_RateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPM_Rate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPM_Rate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }