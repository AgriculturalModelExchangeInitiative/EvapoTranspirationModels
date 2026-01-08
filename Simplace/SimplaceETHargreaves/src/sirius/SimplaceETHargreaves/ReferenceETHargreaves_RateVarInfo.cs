
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETHargreaves_.DomainClass
                                {
                                    public class ReferenceETHargreaves_RateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETHargreaves_RateVarInfo()
                                        {
                                            ReferenceETHargreaves_RateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETHargreaves_Rate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETHargreaves_Rate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }