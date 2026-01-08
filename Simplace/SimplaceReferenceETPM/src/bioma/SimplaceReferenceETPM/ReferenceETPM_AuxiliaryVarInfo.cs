
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ReferenceETPM_.DomainClass
                                {
                                    public class ReferenceETPM_AuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _ReferenceCropEvapotranspiration = new VarInfo();

                                        static ReferenceETPM_AuxiliaryVarInfo()
                                        {
                                            ReferenceETPM_AuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ReferenceETPM_Auxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ReferenceETPM_Auxiliary";}
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