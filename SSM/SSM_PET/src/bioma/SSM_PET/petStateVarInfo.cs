
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace pet.DomainClass
                                {
                                    public class petStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _pet = new VarInfo();

                                        static petStateVarInfo()
                                        {
                                            petStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "petState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "petState";}
                                        }

                                        public static  VarInfo pet
                                        {
                                            get { return _pet;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _pet.Name = "pet";
                                            _pet.Description = "Potential evapotranspiration";
                                            _pet.MaxValue = -1D;
                                            _pet.MinValue = -1D;
                                            _pet.DefaultValue = -1D;
                                            _pet.Units = "mm day-1";
                                            _pet.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }