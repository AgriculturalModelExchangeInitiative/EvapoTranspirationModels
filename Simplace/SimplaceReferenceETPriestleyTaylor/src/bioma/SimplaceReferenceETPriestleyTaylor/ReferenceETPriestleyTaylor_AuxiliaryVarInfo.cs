
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPriestleyTaylor_.DomainClass
                                {
                                    public class ReferenceETPriestleyTaylor_AuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _ReferenceCropEvapotranspiration = new VarInfo();

                                        static ReferenceETPriestleyTaylor_AuxiliaryVarInfo()
                                        {
                                            ReferenceETPriestleyTaylor_AuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Auxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPriestleyTaylor_Auxiliary";}
                                        }

                                        public static  VarInfo ReferenceCropEvapotranspiration
                                        {
                                            get { return _ReferenceCropEvapotranspiration;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _ReferenceCropEvapotranspiration.Name = "ReferenceCropEvapotranspiration";
                                            _ReferenceCropEvapotranspiration.Description = "reference evapotranspiration (ET0)";
                                            _ReferenceCropEvapotranspiration.MaxValue = -1D;
                                            _ReferenceCropEvapotranspiration.MinValue = -1D;
                                            _ReferenceCropEvapotranspiration.DefaultValue = -1D;
                                            _ReferenceCropEvapotranspiration.Units = "http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day";
                                            _ReferenceCropEvapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }