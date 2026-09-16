
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace PotentialET_Penman.DomainClass
                                {
                                    public class PotentialET_PenmanAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _netRadiation = new VarInfo();
                                        static VarInfo _solarRadiation = new VarInfo();
                                        static VarInfo _hslope = new VarInfo();
                                        static VarInfo _VPDair = new VarInfo();
                                        static VarInfo _conductance = new VarInfo();

                                        static PotentialET_PenmanAuxiliaryVarInfo()
                                        {
                                            PotentialET_PenmanAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "PotentialET_PenmanAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "PotentialET_PenmanAuxiliary";}
                                        }

                                        public static  VarInfo netRadiation
                                        {
                                            get { return _netRadiation;}
                                        }

                                        public static  VarInfo solarRadiation
                                        {
                                            get { return _solarRadiation;}
                                        }

                                        public static  VarInfo hslope
                                        {
                                            get { return _hslope;}
                                        }

                                        public static  VarInfo VPDair
                                        {
                                            get { return _VPDair;}
                                        }

                                        public static  VarInfo conductance
                                        {
                                            get { return _conductance;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _netRadiation.Name = "netRadiation";
                                            _netRadiation.Description = "net radiation";
                                            _netRadiation.MaxValue = 5000.0;
                                            _netRadiation.MinValue = 0.0;
                                            _netRadiation.DefaultValue = 1.566;
                                            _netRadiation.Units = "MJ m-2 d-1";
                                            _netRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

                                            _VPDair.Name = "VPDair";
                                            _VPDair.Description = "vapour pressure density";
                                            _VPDair.MaxValue = 1000.0;
                                            _VPDair.MinValue = 0.0;
                                            _VPDair.DefaultValue = 2.19;
                                            _VPDair.Units = "hPa";
                                            _VPDair.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _conductance.Name = "conductance";
                                            _conductance.Description = "conductance";
                                            _conductance.MaxValue = 10000.0;
                                            _conductance.MinValue = 0.0;
                                            _conductance.DefaultValue = 598.685;
                                            _conductance.Units = "m d-1";
                                            _conductance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }