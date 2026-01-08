
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPriestleyTaylor_.DomainClass
                                {
                                    public class ReferenceETPriestleyTaylor_StateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETPriestleyTaylor_StateVarInfo()
                                        {
                                            ReferenceETPriestleyTaylor_StateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPriestleyTaylor_State Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPriestleyTaylor_State";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }