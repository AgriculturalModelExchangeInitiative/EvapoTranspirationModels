
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPriestleyTaylor_.DomainClass
                                {
                                    public class ReferenceETPriestleyTaylor_RateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETPriestleyTaylor_RateVarInfo()
                                        {
                                            ReferenceETPriestleyTaylor_RateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Rate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Rate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }