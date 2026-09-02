
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
                                {
                                    public class EnergyBalanceCompositeRateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _evapoTranspirationPriestlyTaylor = new VarInfo();
                                        static VarInfo _evapoTranspirationPenman = new VarInfo();

                                        static EnergyBalanceCompositeRateVarInfo()
                                        {
                                            EnergyBalanceCompositeRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "EnergyBalanceCompositeRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "EnergyBalanceCompositeRate";}
                                        }

                                        public static  VarInfo evapoTranspirationPriestlyTaylor
                                        {
                                            get { return _evapoTranspirationPriestlyTaylor;}
                                        }

                                        public static  VarInfo evapoTranspirationPenman
                                        {
                                            get { return _evapoTranspirationPenman;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _evapoTranspirationPriestlyTaylor.Name = "evapoTranspirationPriestlyTaylor";
                                            _evapoTranspirationPriestlyTaylor.Description = "evapoTranspiration of Priestly Taylor";
                                            _evapoTranspirationPriestlyTaylor.MaxValue = 10000;
                                            _evapoTranspirationPriestlyTaylor.MinValue = 0;
                                            _evapoTranspirationPriestlyTaylor.DefaultValue = -1D;
                                            _evapoTranspirationPriestlyTaylor.Units = "g m-2 d-1";
                                            _evapoTranspirationPriestlyTaylor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _evapoTranspirationPenman.Name = "evapoTranspirationPenman";
                                            _evapoTranspirationPenman.Description = "evapoTranspiration of Penman Monteith";
                                            _evapoTranspirationPenman.MaxValue = 5000;
                                            _evapoTranspirationPenman.MinValue = 0;
                                            _evapoTranspirationPenman.DefaultValue = -1D;
                                            _evapoTranspirationPenman.Units = "g m-2 d-1";
                                            _evapoTranspirationPenman.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }