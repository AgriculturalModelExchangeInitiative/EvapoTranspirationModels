
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETHargreaves_.DomainClass
                                {
                                    public class ReferenceETHargreaves_StateVarInfo : IVarInfoClass
                                    {

                                        static ReferenceETHargreaves_StateVarInfo()
                                        {
                                            ReferenceETHargreaves_StateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETHargreaves_State Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETHargreaves_State";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }