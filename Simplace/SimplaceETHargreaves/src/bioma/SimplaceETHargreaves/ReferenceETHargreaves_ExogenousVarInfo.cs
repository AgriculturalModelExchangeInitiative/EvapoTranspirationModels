
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETHargreaves_.DomainClass
                                {
                                    public class ReferenceETHargreaves_ExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _iTMax = new VarInfo();
                                        static VarInfo _iSolarRadiation = new VarInfo();
                                        static VarInfo _iTMin = new VarInfo();

                                        static ReferenceETHargreaves_ExogenousVarInfo()
                                        {
                                            ReferenceETHargreaves_ExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETHargreaves_Exogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETHargreaves_Exogenous";}
                                        }

                                        public static  VarInfo iTMax
                                        {
                                            get { return _iTMax;}
                                        }

                                        public static  VarInfo iSolarRadiation
                                        {
                                            get { return _iSolarRadiation;}
                                        }

                                        public static  VarInfo iTMin
                                        {
                                            get { return _iTMin;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _iTMax.Name = "iTMax";
                                            _iTMax.Description = "maximum daily temperature";
                                            _iTMax.MaxValue = -1D;
                                            _iTMax.MinValue = -1D;
                                            _iTMax.DefaultValue = 0.0;
                                            _iTMax.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iSolarRadiation.Name = "iSolarRadiation";
                                            _iSolarRadiation.Description = "solar radiation";
                                            _iSolarRadiation.MaxValue = -1D;
                                            _iSolarRadiation.MinValue = -1D;
                                            _iSolarRadiation.DefaultValue = 0.0;
                                            _iSolarRadiation.Units = "http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day";
                                            _iSolarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iTMin.Name = "iTMin";
                                            _iTMin.Description = "minimum daily temperature";
                                            _iTMin.MaxValue = -1D;
                                            _iTMin.MinValue = -1D;
                                            _iTMin.DefaultValue = 0.0;
                                            _iTMin.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }