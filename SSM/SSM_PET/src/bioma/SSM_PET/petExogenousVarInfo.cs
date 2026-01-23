
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
                                        static VarInfo _etlai = new VarInfo();

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

                                        public static  VarInfo etlai
                                        {
                                            get { return _etlai;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _tmax.Name = "tmax";
                                            _tmax.Description = "Daily maximum temperature";
                                            _tmax.MaxValue = -1D;
                                            _tmax.MinValue = -1D;
                                            _tmax.DefaultValue = -1D;
                                            _tmax.Units = "degC";
                                            _tmax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _tmin.Name = "tmin";
                                            _tmin.Description = "Daily minimum temperature";
                                            _tmin.MaxValue = -1D;
                                            _tmin.MinValue = -1D;
                                            _tmin.DefaultValue = -1D;
                                            _tmin.Units = "degC";
                                            _tmin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _srad.Name = "srad";
                                            _srad.Description = "Daily solar radiation";
                                            _srad.MaxValue = -1D;
                                            _srad.MinValue = 0;
                                            _srad.DefaultValue = -1D;
                                            _srad.Units = "MJ m-2 day-1";
                                            _srad.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _etlai.Name = "etlai";
                                            _etlai.Description = "Leaf area index effective in evapotranspiration";
                                            _etlai.MaxValue = -1D;
                                            _etlai.MinValue = 0;
                                            _etlai.DefaultValue = -1D;
                                            _etlai.Units = "m2 m-2";
                                            _etlai.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }