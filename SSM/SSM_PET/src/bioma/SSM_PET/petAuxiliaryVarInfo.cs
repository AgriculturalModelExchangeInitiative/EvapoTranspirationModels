
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
                                {
                                    public class petAuxiliaryVarInfo : IVarInfoClass
                                    {

                                        static petAuxiliaryVarInfo()
                                        {
                                            petAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "petAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "petAuxiliary";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }