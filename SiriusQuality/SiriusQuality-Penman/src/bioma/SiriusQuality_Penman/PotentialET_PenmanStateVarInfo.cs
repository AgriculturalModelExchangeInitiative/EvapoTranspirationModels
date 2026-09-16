
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                                {
                                    public class PotentialET_PenmanStateVarInfo : IVarInfoClass
                                    {

                                        static PotentialET_PenmanStateVarInfo()
                                        {
                                            PotentialET_PenmanStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PenmanState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PenmanState";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }