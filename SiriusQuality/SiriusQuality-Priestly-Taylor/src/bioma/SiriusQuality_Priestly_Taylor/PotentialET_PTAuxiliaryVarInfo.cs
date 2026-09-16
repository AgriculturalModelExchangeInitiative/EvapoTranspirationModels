
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_PT.DomainClass
                                {
                                    public class PotentialET_PTAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _solarRadiation = new VarInfo();
                                        static VarInfo _hslope = new VarInfo();
                                        static VarInfo _netRadiation = new VarInfo();

                                        static PotentialET_PTAuxiliaryVarInfo()
                                        {
                                            PotentialET_PTAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PTAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PTAuxiliary";}
                                        }

                                        public static  VarInfo solarRadiation
                                        {
                                            get { return _solarRadiation;}
                                        }

                                        public static  VarInfo hslope
                                        {
                                            get { return _hslope;}
                                        }

                                        public static  VarInfo netRadiation
                                        {
                                            get { return _netRadiation;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _solarRadiation.Name = "solarRadiation";
                                            _solarRadiation.Description = "solar Radiation";
                                            _solarRadiation.MaxValue = 1000.0;
                                            _solarRadiation.MinValue = 0.0;
                                            _solarRadiation.DefaultValue = 3.0;
                                            _solarRadiation.Units = "MJ m-2 d-1";
                                            _solarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _hslope.Name = "hslope";
                                            _hslope.Description = "the slope of saturated vapor pressure temperature curve at a given temperature";
                                            _hslope.MaxValue = 1000.0;
                                            _hslope.MinValue = 0.0;
                                            _hslope.DefaultValue = 0.584;
                                            _hslope.Units = "hPa degC-1";
                                            _hslope.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _netRadiation.Name = "netRadiation";
                                            _netRadiation.Description = "net radiation";
                                            _netRadiation.MaxValue = 5000.0;
                                            _netRadiation.MinValue = 0.0;
                                            _netRadiation.DefaultValue = 1.566;
                                            _netRadiation.Units = "MJ m-2 d-1";
                                            _netRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }