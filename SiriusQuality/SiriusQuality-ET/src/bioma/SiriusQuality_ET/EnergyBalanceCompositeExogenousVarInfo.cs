
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
                                {
                                    public class EnergyBalanceCompositeExogenousVarInfo : IVarInfoClass
                                    {

                                        static EnergyBalanceCompositeExogenousVarInfo()
                                        {
                                            EnergyBalanceCompositeExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "EnergyBalanceCompositeExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "EnergyBalanceCompositeExogenous";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }