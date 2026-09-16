
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
                                {
                                    public class petRateVarInfo : IVarInfoClass
                                    {

                                        static petRateVarInfo()
                                        {
                                            petRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "petRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "petRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }