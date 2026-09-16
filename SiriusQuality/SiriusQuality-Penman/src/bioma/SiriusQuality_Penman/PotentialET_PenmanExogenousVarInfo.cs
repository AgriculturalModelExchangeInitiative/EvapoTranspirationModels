
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                                {
                                    public class PotentialET_PenmanExogenousVarInfo : IVarInfoClass
                                    {

                                        static PotentialET_PenmanExogenousVarInfo()
                                        {
                                            PotentialET_PenmanExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PenmanExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PenmanExogenous";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }