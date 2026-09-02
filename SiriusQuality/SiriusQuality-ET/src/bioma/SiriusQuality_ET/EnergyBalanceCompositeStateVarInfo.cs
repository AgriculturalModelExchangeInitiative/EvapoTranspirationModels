
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
                                {
                                    public class EnergyBalanceCompositeStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _ih = new VarInfo();
                                        static VarInfo _conductance = new VarInfo();

                                        static EnergyBalanceCompositeStateVarInfo()
                                        {
                                            EnergyBalanceCompositeStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "EnergyBalanceCompositeState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "EnergyBalanceCompositeState";}
                                        }

                                        public static  VarInfo ih
                                        {
                                            get { return _ih;}
                                        }

                                        public static  VarInfo conductance
                                        {
                                            get { return _conductance;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _ih.Name = "ih";
                                            _ih.Description = "hour of the day if the component is hourly, -999 if the component is daily";
                                            _ih.MaxValue = 24;
                                            _ih.MinValue = 999;
                                            _ih.DefaultValue = 999;
                                            _ih.Units = "";
                                            _ih.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _conductance.Name = "conductance";
                                            _conductance.Description = "the boundary layer conductance";
                                            _conductance.MaxValue = 10000;
                                            _conductance.MinValue = 0;
                                            _conductance.DefaultValue = -1D;
                                            _conductance.Units = "m/d";
                                            _conductance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }