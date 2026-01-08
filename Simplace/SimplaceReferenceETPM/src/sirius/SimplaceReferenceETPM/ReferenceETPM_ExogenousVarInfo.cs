
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityReferenceETPM_.DomainClass
                                {
                                    public class ReferenceETPM_ExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _iNetRadiation = new VarInfo();
                                        static VarInfo _iActualVapourPressure = new VarInfo();
                                        static VarInfo _iTMax = new VarInfo();
                                        static VarInfo _iTMin = new VarInfo();
                                        static VarInfo _iWindspeed = new VarInfo();

                                        static ReferenceETPM_ExogenousVarInfo()
                                        {
                                            ReferenceETPM_ExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPM_Exogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPM_Exogenous";}
                                        }

                                        public static  VarInfo iNetRadiation
                                        {
                                            get { return _iNetRadiation;}
                                        }

                                        public static  VarInfo iActualVapourPressure
                                        {
                                            get { return _iActualVapourPressure;}
                                        }

                                        public static  VarInfo iTMax
                                        {
                                            get { return _iTMax;}
                                        }

                                        public static  VarInfo iTMin
                                        {
                                            get { return _iTMin;}
                                        }

                                        public static  VarInfo iWindspeed
                                        {
                                            get { return _iWindspeed;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _iNetRadiation.Name = "iNetRadiation";
                                            _iNetRadiation.Description = "net radiation";
                                            _iNetRadiation.MaxValue = -1D;
                                            _iNetRadiation.MinValue = -1D;
                                            _iNetRadiation.DefaultValue = 0.0;
                                            _iNetRadiation.Units = "http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day";
                                            _iNetRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iActualVapourPressure.Name = "iActualVapourPressure";
                                            _iActualVapourPressure.Description = "actual vapour pressure";
                                            _iActualVapourPressure.MaxValue = -1D;
                                            _iActualVapourPressure.MinValue = -1D;
                                            _iActualVapourPressure.DefaultValue = 0.0;
                                            _iActualVapourPressure.Units = "http://www.wurvoc.org/vocabularies/om-1.8/kilopascal";
                                            _iActualVapourPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iTMax.Name = "iTMax";
                                            _iTMax.Description = "maximum daily temperature";
                                            _iTMax.MaxValue = -1D;
                                            _iTMax.MinValue = -1D;
                                            _iTMax.DefaultValue = 0.0;
                                            _iTMax.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iTMin.Name = "iTMin";
                                            _iTMin.Description = "minimum daily temperature";
                                            _iTMin.MaxValue = -1D;
                                            _iTMin.MinValue = -1D;
                                            _iTMin.DefaultValue = 0.0;
                                            _iTMin.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iTMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iWindspeed.Name = "iWindspeed";
                                            _iWindspeed.Description = "wind speed at 2m height";
                                            _iWindspeed.MaxValue = -1D;
                                            _iWindspeed.MinValue = -1D;
                                            _iWindspeed.DefaultValue = 0.0;
                                            _iWindspeed.Units = "http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time";
                                            _iWindspeed.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }