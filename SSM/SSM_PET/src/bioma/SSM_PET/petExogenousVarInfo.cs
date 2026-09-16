
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
                                {
                                    public class petExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _tmax = new VarInfo();
                                        static VarInfo _tmin = new VarInfo();
                                        static VarInfo _srad = new VarInfo();

                                        static petExogenousVarInfo()
                                        {
                                            petExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "petExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "petExogenous";}
                                        }

                                        public static  VarInfo tmax
                                        {
                                            get { return _tmax;}
                                        }

                                        public static  VarInfo tmin
                                        {
                                            get { return _tmin;}
                                        }

                                        public static  VarInfo srad
                                        {
                                            get { return _srad;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _tmax.Name = "tmax";
                                            _tmax.Description = "Daily maximum temperature.";
                                            _tmax.MaxValue = 60.0;
                                            _tmax.MinValue = -60.0;
                                            _tmax.DefaultValue = -1D;
                                            _tmax.Units = "°C";
                                            _tmax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _tmin.Name = "tmin";
                                            _tmin.Description = "Daily minimum temperature.";
                                            _tmin.MaxValue = 60.0;
                                            _tmin.MinValue = -60.0;
                                            _tmin.DefaultValue = -1D;
                                            _tmin.Units = "°C";
                                            _tmin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _srad.Name = "srad";
                                            _srad.Description = "Daily solar radiation.";
                                            _srad.MaxValue = 120.0;
                                            _srad.MinValue = 0.0;
                                            _srad.DefaultValue = -1D;
                                            _srad.Units = "MJ m-2 day-1";
                                            _srad.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }