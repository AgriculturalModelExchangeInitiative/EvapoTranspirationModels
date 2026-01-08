
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPM_.DomainClass
                                {
                                    public class ReferenceETPM_StateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETPM_StateVarInfo()
                                        {
                                            ReferenceETPM_StateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPM_State Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPM_State";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }