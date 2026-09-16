
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                                {
                                    public class PotentialET_PTRateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _evapoTranspirationPriestlyTaylor = new VarInfo();

                                        static PotentialET_PTRateVarInfo()
                                        {
                                            PotentialET_PTRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PTRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PTRate";}
                                        }

                                        public static  VarInfo evapoTranspirationPriestlyTaylor
                                        {
                                            get { return _evapoTranspirationPriestlyTaylor;}
                                        }

                                        static void DescribeVariables()
                                        {
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