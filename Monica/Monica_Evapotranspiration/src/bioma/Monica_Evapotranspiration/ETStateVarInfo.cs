
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
                                {
                                    public class ETStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _surface_water_storage = new VarInfo();
                                        static VarInfo _evaporated_from_surface = new VarInfo();
                                        static VarInfo _actual_evaporation = new VarInfo();
                                        static VarInfo _actual_transpiration = new VarInfo();
                                        static VarInfo _soil_moisture = new VarInfo();
                                        static VarInfo _evaporation = new VarInfo();
                                        static VarInfo _transpiration = new VarInfo();
                                        static VarInfo _evapotranspiration = new VarInfo();
                                        static VarInfo _actual_evapotranspiration = new VarInfo();

                                        static ETStateVarInfo()
                                        {
                                            ETStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "ETState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "ETState";}
                                        }

                                        public static  VarInfo surface_water_storage
                                        {
                                            get { return _surface_water_storage;}
                                        }

                                        public static  VarInfo evaporated_from_surface
                                        {
                                            get { return _evaporated_from_surface;}
                                        }

                                        public static  VarInfo actual_evaporation
                                        {
                                            get { return _actual_evaporation;}
                                        }

                                        public static  VarInfo actual_transpiration
                                        {
                                            get { return _actual_transpiration;}
                                        }

                                        public static  VarInfo soil_moisture
                                        {
                                            get { return _soil_moisture;}
                                        }

                                        public static  VarInfo evaporation
                                        {
                                            get { return _evaporation;}
                                        }

                                        public static  VarInfo transpiration
                                        {
                                            get { return _transpiration;}
                                        }

                                        public static  VarInfo evapotranspiration
                                        {
                                            get { return _evapotranspiration;}
                                        }

                                        public static  VarInfo actual_evapotranspiration
                                        {
                                            get { return _actual_evapotranspiration;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _surface_water_storage.Name = "surface_water_storage";
                                            _surface_water_storage.Description = "Simulates a virtual layer that contains the surface water";
                                            _surface_water_storage.MaxValue = -1D;
                                            _surface_water_storage.MinValue = 0;
                                            _surface_water_storage.DefaultValue = 0;
                                            _surface_water_storage.Units = "mm";
                                            _surface_water_storage.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _evaporated_from_surface.Name = "evaporated_from_surface";
                                            _evaporated_from_surface.Description = "evaporated_from_surface";
                                            _evaporated_from_surface.MaxValue = -1D;
                                            _evaporated_from_surface.MinValue = 0;
                                            _evaporated_from_surface.DefaultValue = 0;
                                            _evaporated_from_surface.Units = "mm";
                                            _evaporated_from_surface.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _actual_evaporation.Name = "actual_evaporation";
                                            _actual_evaporation.Description = "actual evaporation";
                                            _actual_evaporation.MaxValue = -1D;
                                            _actual_evaporation.MinValue = 0;
                                            _actual_evaporation.DefaultValue = 0;
                                            _actual_evaporation.Units = "mm";
                                            _actual_evaporation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _actual_transpiration.Name = "actual_transpiration";
                                            _actual_transpiration.Description = "actual transpiration";
                                            _actual_transpiration.MaxValue = -1D;
                                            _actual_transpiration.MinValue = 0;
                                            _actual_transpiration.DefaultValue = 0;
                                            _actual_transpiration.Units = "mm";
                                            _actual_transpiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _soil_moisture.Name = "soil_moisture";
                                            _soil_moisture.Description = "soil moisture array";
                                            _soil_moisture.MaxValue = -1D;
                                            _soil_moisture.MinValue = -1D;
                                            _soil_moisture.DefaultValue = -1D;
                                            _soil_moisture.Units = "m3/m3";
                                            _soil_moisture.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _evaporation.Name = "evaporation";
                                            _evaporation.Description = "evaporation array";
                                            _evaporation.MaxValue = -1D;
                                            _evaporation.MinValue = -1D;
                                            _evaporation.DefaultValue = -1D;
                                            _evaporation.Units = "mm";
                                            _evaporation.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _transpiration.Name = "transpiration";
                                            _transpiration.Description = "transpiration array";
                                            _transpiration.MaxValue = -1D;
                                            _transpiration.MinValue = -1D;
                                            _transpiration.DefaultValue = -1D;
                                            _transpiration.Units = "mm";
                                            _transpiration.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _evapotranspiration.Name = "evapotranspiration";
                                            _evapotranspiration.Description = "evapotranspiration array";
                                            _evapotranspiration.MaxValue = -1D;
                                            _evapotranspiration.MinValue = -1D;
                                            _evapotranspiration.DefaultValue = -1D;
                                            _evapotranspiration.Units = "mm";
                                            _evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _actual_evapotranspiration.Name = "actual_evapotranspiration";
                                            _actual_evapotranspiration.Description = "actual evapotranspiration";
                                            _actual_evapotranspiration.MaxValue = -1D;
                                            _actual_evapotranspiration.MinValue = 0;
                                            _actual_evapotranspiration.DefaultValue = 0;
                                            _actual_evapotranspiration.Units = "mm";
                                            _actual_evapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }