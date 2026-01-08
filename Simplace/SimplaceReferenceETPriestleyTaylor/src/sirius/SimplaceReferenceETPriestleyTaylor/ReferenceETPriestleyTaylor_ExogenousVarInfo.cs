
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPriestleyTaylor_.DomainClass
                                {
                                    public class ReferenceETPriestleyTaylor_ExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _iTMin = new VarInfo();
                                        static VarInfo _iNetRadiation = new VarInfo();
                                        static VarInfo _iTMax = new VarInfo();

                                        static ReferenceETPriestleyTaylor_ExogenousVarInfo()
                                        {
                                            ReferenceETPriestleyTaylor_ExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Exogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Exogenous";}
                                        }

                                        public static  VarInfo iTMin
                                        {
                                            get { return _iTMin;}
                                        }

                                        public static  VarInfo iNetRadiation
                                        {
                                            get { return _iNetRadiation;}
                                        }

                                        public static  VarInfo iTMax
                                        {
                                            get { return _iTMax;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _iTMin.Name = "iTMin";
                                            _iTMin.Description = "minimum daily temperature";
                                            _iTMin.MaxValue = -1D;
                                            _iTMin.MinValue = -1D;
                                            _iTMin.DefaultValue = 0.0;
                                            _iTMin.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iNetRadiation.Name = "iNetRadiation";
                                            _iNetRadiation.Description = "net radiation";
                                            _iNetRadiation.MaxValue = -1D;
                                            _iNetRadiation.MinValue = -1D;
                                            _iNetRadiation.DefaultValue = 0.0;
                                            _iNetRadiation.Units = "http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day";
                                            _iNetRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iTMax.Name = "iTMax";
                                            _iTMax.Description = "maximum daily temperature";
                                            _iTMax.MaxValue = -1D;
                                            _iTMax.MinValue = -1D;
                                            _iTMax.DefaultValue = 0.0;
                                            _iTMax.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }