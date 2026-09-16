
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                                {
                                    public class PotentialET_PenmanRateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _evapoTranspirationPenman = new VarInfo();
                                        static VarInfo _evapoTranspirationPriestlyTaylor = new VarInfo();

                                        static PotentialET_PenmanRateVarInfo()
                                        {
                                            PotentialET_PenmanRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PenmanRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PenmanRate";}
                                        }

                                        public static  VarInfo evapoTranspirationPenman
                                        {
                                            get { return _evapoTranspirationPenman;}
                                        }

                                        public static  VarInfo evapoTranspirationPriestlyTaylor
                                        {
                                            get { return _evapoTranspirationPriestlyTaylor;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _evapoTranspirationPenman.Name = "evapoTranspirationPenman";
                                            _evapoTranspirationPenman.Description = "evapoTranspiration of Penman Monteith";
                                            _evapoTranspirationPenman.MaxValue = 5000.0;
                                            _evapoTranspirationPenman.MinValue = 0.0;
                                            _evapoTranspirationPenman.DefaultValue = -1D;
                                            _evapoTranspirationPenman.Units = "g m-2 d-1";
                                            _evapoTranspirationPenman.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _evapoTranspirationPriestlyTaylor.Name = "evapoTranspirationPriestlyTaylor";
                                            _evapoTranspirationPriestlyTaylor.Description = "evapoTranspiration of Priestly Taylor";
                                            _evapoTranspirationPriestlyTaylor.MaxValue = 10000.0;
                                            _evapoTranspirationPriestlyTaylor.MinValue = 0.0;
                                            _evapoTranspirationPriestlyTaylor.DefaultValue = -1D;
                                            _evapoTranspirationPriestlyTaylor.Units = "g m-2 d-1";
                                            _evapoTranspirationPriestlyTaylor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }