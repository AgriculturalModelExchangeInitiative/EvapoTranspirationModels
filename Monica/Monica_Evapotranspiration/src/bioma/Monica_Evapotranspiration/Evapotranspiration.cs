
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       
using ET.DomainClass;
namespace ET.Strategies
{
    public class Evapotranspiration : IStrategyET
    {
        public Evapotranspiration()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 40;
            v1.Description = "shape factor";
            v1.Id = 0;
            v1.MaxValue = 40;
            v1.MinValue = 0;
            v1.Name = "evaporation_zeta";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 5;
            v2.Description = "maximumEvaporationImpactDepth";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = 0;
            v2.Name = "maximum_evaporation_impact_depth";
            v2.Size = 1;
            v2.Units = "dm";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 1;
            v3.Description = "THESEUS (0) or HERMES (1) evaporation reduction method";
            v3.Id = 0;
            v3.MaxValue = 1;
            v3.MinValue = 0;
            v3.Name = "evaporation_reduction_method";
            v3.Size = 1;
            v3.Units = "dimensionless";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = 0.1;
            v4.Description = "XSACriticalSoilMoisture";
            v4.Id = 0;
            v4.MaxValue = 1.5;
            v4.MinValue = 0;
            v4.Name = "xsa_critical_soil_moisture";
            v4.Size = 1;
            v4.Units = "m3/m3";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = 20;
            v5.Description = "number of soil layers";
            v5.Id = 0;
            v5.MaxValue = -1D;
            v5.MinValue = 0;
            v5.Name = "no_of_soil_layers";
            v5.Size = 1;
            v5.Units = "dimensionless";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v5);
            VarInfo v6 = new VarInfo();
            v6.DefaultValue = 21;
            v6.Description = "number of soil layers + 1";
            v6.Id = 0;
            v6.MaxValue = -1D;
            v6.MinValue = 0;
            v6.Name = "no_of_soil_moisture_layers";
            v6.Size = 1;
            v6.Units = "dimensionless";
            v6.URL = "";
            v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v6.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v6);
            VarInfo v7 = new VarInfo();
            v7.DefaultValue = -1D;
            v7.Description = "layer thickness array";
            v7.Id = 0;
            v7.MaxValue = -1D;
            v7.MinValue = -1D;
            v7.Name = "layer_thickness";
            v7.Size = 1;
            v7.Units = "m";
            v7.URL = "";
            v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v7.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v7);
            VarInfo v8 = new VarInfo();
            v8.DefaultValue = -1D;
            v8.Description = "permanent wilting point array";
            v8.Id = 0;
            v8.MaxValue = -1D;
            v8.MinValue = -1D;
            v8.Name = "permanent_wilting_point";
            v8.Size = 1;
            v8.Units = "m3/m3";
            v8.URL = "";
            v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v8.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v8);
            VarInfo v9 = new VarInfo();
            v9.DefaultValue = -1D;
            v9.Description = "field capacity array";
            v9.Id = 0;
            v9.MaxValue = -1D;
            v9.MinValue = -1D;
            v9.Name = "field_capacity";
            v9.Size = 1;
            v9.Units = "m3/m3";
            v9.URL = "";
            v9.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v9.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v9);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd1.PropertyName = "kc_factor";
            pd1.PropertyType = (ET.DomainClass.ETExogenousVarInfo.kc_factor).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.kc_factor);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd2.PropertyName = "has_snow_cover";
            pd2.PropertyType = (ET.DomainClass.ETExogenousVarInfo.has_snow_cover).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.has_snow_cover);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd3.PropertyName = "developmental_stage";
            pd3.PropertyType = (ET.DomainClass.ETExogenousVarInfo.developmental_stage).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.developmental_stage);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd4.PropertyName = "crop_transpiration";
            pd4.PropertyType = (ET.DomainClass.ETExogenousVarInfo.crop_transpiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.crop_transpiration);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd5.PropertyName = "crop_evaporated_from_intercepted";
            pd5.PropertyType = (ET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd6.PropertyName = "percentage_soil_coverage";
            pd6.PropertyType = (ET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd7.PropertyName = "potential_evapotranspiration";
            pd7.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(ET.DomainClass.ETState);
            pd8.PropertyName = "surface_water_storage";
            pd8.PropertyType = (ET.DomainClass.ETStateVarInfo.surface_water_storage).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.surface_water_storage);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(ET.DomainClass.ETState);
            pd9.PropertyName = "evaporated_from_surface";
            pd9.PropertyType = (ET.DomainClass.ETStateVarInfo.evaporated_from_surface).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.evaporated_from_surface);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(ET.DomainClass.ETState);
            pd10.PropertyName = "actual_evaporation";
            pd10.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_evaporation).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_evaporation);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(ET.DomainClass.ETState);
            pd11.PropertyName = "actual_transpiration";
            pd11.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_transpiration).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_transpiration);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(ET.DomainClass.ETState);
            pd12.PropertyName = "soil_moisture";
            pd12.PropertyType = (ET.DomainClass.ETStateVarInfo.soil_moisture).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.soil_moisture);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(ET.DomainClass.ETState);
            pd13.PropertyName = "evaporation";
            pd13.PropertyType = (ET.DomainClass.ETStateVarInfo.evaporation).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.evaporation);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(ET.DomainClass.ETState);
            pd14.PropertyName = "transpiration";
            pd14.PropertyType = (ET.DomainClass.ETStateVarInfo.transpiration).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.transpiration);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(ET.DomainClass.ETState);
            pd15.PropertyName = "evapotranspiration";
            pd15.PropertyType = (ET.DomainClass.ETStateVarInfo.evapotranspiration).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.evapotranspiration);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(ET.DomainClass.ETState);
            pd16.PropertyName = "actual_evapotranspiration";
            pd16.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_evapotranspiration).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
            _inputs0_0.Add(pd16);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(ET.DomainClass.ETState);
            pd17.PropertyName = "evaporated_from_surface";
            pd17.PropertyType = (ET.DomainClass.ETStateVarInfo.evaporated_from_surface).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.evaporated_from_surface);
            _outputs0_0.Add(pd17);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(ET.DomainClass.ETState);
            pd18.PropertyName = "actual_evapotranspiration";
            pd18.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_evapotranspiration).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
            _outputs0_0.Add(pd18);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(ET.DomainClass.ETState);
            pd19.PropertyName = "actual_evaporation";
            pd19.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_evaporation).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_evaporation);
            _outputs0_0.Add(pd19);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(ET.DomainClass.ETState);
            pd20.PropertyName = "actual_transpiration";
            pd20.PropertyType = (ET.DomainClass.ETStateVarInfo.actual_transpiration).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.actual_transpiration);
            _outputs0_0.Add(pd20);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(ET.DomainClass.ETState);
            pd21.PropertyName = "surface_water_storage";
            pd21.PropertyType = (ET.DomainClass.ETStateVarInfo.surface_water_storage).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.surface_water_storage);
            _outputs0_0.Add(pd21);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(ET.DomainClass.ETState);
            pd22.PropertyName = "soil_moisture";
            pd22.PropertyType = (ET.DomainClass.ETStateVarInfo.soil_moisture).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(ET.DomainClass.ETStateVarInfo.soil_moisture);
            _outputs0_0.Add(pd22);
            mo0_0.Outputs=_outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        public string Description
        {
            get { return "" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "ZALF e.V. "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(ET.DomainClass.ETState),  typeof(ET.DomainClass.ETState), typeof(ET.DomainClass.ETRate), typeof(ET.DomainClass.ETAuxiliary), typeof(ET.DomainClass.ETExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double evaporation_zeta
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("evaporation_zeta");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'evaporation_zeta' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("evaporation_zeta");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'evaporation_zeta' not found in strategy 'Evapotranspiration'");
            }
        }
        public double maximum_evaporation_impact_depth
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("maximum_evaporation_impact_depth");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'maximum_evaporation_impact_depth' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("maximum_evaporation_impact_depth");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'maximum_evaporation_impact_depth' not found in strategy 'Evapotranspiration'");
            }
        }
        public int evaporation_reduction_method
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("evaporation_reduction_method");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'evaporation_reduction_method' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("evaporation_reduction_method");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'evaporation_reduction_method' not found in strategy 'Evapotranspiration'");
            }
        }
        public double xsa_critical_soil_moisture
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("xsa_critical_soil_moisture");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'xsa_critical_soil_moisture' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("xsa_critical_soil_moisture");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'xsa_critical_soil_moisture' not found in strategy 'Evapotranspiration'");
            }
        }
        public int no_of_soil_layers
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("no_of_soil_layers");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'no_of_soil_layers' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("no_of_soil_layers");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'no_of_soil_layers' not found in strategy 'Evapotranspiration'");
            }
        }
        public int no_of_soil_moisture_layers
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("no_of_soil_moisture_layers");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'no_of_soil_moisture_layers' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("no_of_soil_moisture_layers");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'no_of_soil_moisture_layers' not found in strategy 'Evapotranspiration'");
            }
        }
        public double[] layer_thickness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("layer_thickness");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'layer_thickness' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("layer_thickness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'layer_thickness' not found in strategy 'Evapotranspiration'");
            }
        }
        public double[] permanent_wilting_point
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("permanent_wilting_point");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'permanent_wilting_point' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("permanent_wilting_point");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'permanent_wilting_point' not found in strategy 'Evapotranspiration'");
            }
        }
        public double[] field_capacity
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("field_capacity");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'field_capacity' not found (or found null) in strategy 'Evapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("field_capacity");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'field_capacity' not found in strategy 'Evapotranspiration'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            evaporation_zetaVarInfo.Name = "evaporation_zeta";
            evaporation_zetaVarInfo.Description = "shape factor";
            evaporation_zetaVarInfo.MaxValue = 40;
            evaporation_zetaVarInfo.MinValue = 0;
            evaporation_zetaVarInfo.DefaultValue = 40;
            evaporation_zetaVarInfo.Units = "dimensionless";
            evaporation_zetaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            maximum_evaporation_impact_depthVarInfo.Name = "maximum_evaporation_impact_depth";
            maximum_evaporation_impact_depthVarInfo.Description = "maximumEvaporationImpactDepth";
            maximum_evaporation_impact_depthVarInfo.MaxValue = -1D;
            maximum_evaporation_impact_depthVarInfo.MinValue = 0;
            maximum_evaporation_impact_depthVarInfo.DefaultValue = 5;
            maximum_evaporation_impact_depthVarInfo.Units = "dm";
            maximum_evaporation_impact_depthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            evaporation_reduction_methodVarInfo.Name = "evaporation_reduction_method";
            evaporation_reduction_methodVarInfo.Description = "THESEUS (0) or HERMES (1) evaporation reduction method";
            evaporation_reduction_methodVarInfo.MaxValue = 1;
            evaporation_reduction_methodVarInfo.MinValue = 0;
            evaporation_reduction_methodVarInfo.DefaultValue = 1;
            evaporation_reduction_methodVarInfo.Units = "dimensionless";
            evaporation_reduction_methodVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            xsa_critical_soil_moistureVarInfo.Name = "xsa_critical_soil_moisture";
            xsa_critical_soil_moistureVarInfo.Description = "XSACriticalSoilMoisture";
            xsa_critical_soil_moistureVarInfo.MaxValue = 1.5;
            xsa_critical_soil_moistureVarInfo.MinValue = 0;
            xsa_critical_soil_moistureVarInfo.DefaultValue = 0.1;
            xsa_critical_soil_moistureVarInfo.Units = "m3/m3";
            xsa_critical_soil_moistureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            no_of_soil_layersVarInfo.Name = "no_of_soil_layers";
            no_of_soil_layersVarInfo.Description = "number of soil layers";
            no_of_soil_layersVarInfo.MaxValue = -1D;
            no_of_soil_layersVarInfo.MinValue = 0;
            no_of_soil_layersVarInfo.DefaultValue = 20;
            no_of_soil_layersVarInfo.Units = "dimensionless";
            no_of_soil_layersVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            no_of_soil_moisture_layersVarInfo.Name = "no_of_soil_moisture_layers";
            no_of_soil_moisture_layersVarInfo.Description = "number of soil layers + 1";
            no_of_soil_moisture_layersVarInfo.MaxValue = -1D;
            no_of_soil_moisture_layersVarInfo.MinValue = 0;
            no_of_soil_moisture_layersVarInfo.DefaultValue = 21;
            no_of_soil_moisture_layersVarInfo.Units = "dimensionless";
            no_of_soil_moisture_layersVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            layer_thicknessVarInfo.Name = "layer_thickness";
            layer_thicknessVarInfo.Description = "layer thickness array";
            layer_thicknessVarInfo.MaxValue = -1D;
            layer_thicknessVarInfo.MinValue = -1D;
            layer_thicknessVarInfo.DefaultValue = -1D;
            layer_thicknessVarInfo.Units = "m";
            layer_thicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            permanent_wilting_pointVarInfo.Name = "permanent_wilting_point";
            permanent_wilting_pointVarInfo.Description = "permanent wilting point array";
            permanent_wilting_pointVarInfo.MaxValue = -1D;
            permanent_wilting_pointVarInfo.MinValue = -1D;
            permanent_wilting_pointVarInfo.DefaultValue = -1D;
            permanent_wilting_pointVarInfo.Units = "m3/m3";
            permanent_wilting_pointVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            field_capacityVarInfo.Name = "field_capacity";
            field_capacityVarInfo.Description = "field capacity array";
            field_capacityVarInfo.MaxValue = -1D;
            field_capacityVarInfo.MinValue = -1D;
            field_capacityVarInfo.DefaultValue = -1D;
            field_capacityVarInfo.Units = "m3/m3";
            field_capacityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        private static VarInfo _evaporation_zetaVarInfo = new VarInfo();
        public static VarInfo evaporation_zetaVarInfo
        {
            get { return _evaporation_zetaVarInfo;} 
        }

        private static VarInfo _maximum_evaporation_impact_depthVarInfo = new VarInfo();
        public static VarInfo maximum_evaporation_impact_depthVarInfo
        {
            get { return _maximum_evaporation_impact_depthVarInfo;} 
        }

        private static VarInfo _evaporation_reduction_methodVarInfo = new VarInfo();
        public static VarInfo evaporation_reduction_methodVarInfo
        {
            get { return _evaporation_reduction_methodVarInfo;} 
        }

        private static VarInfo _xsa_critical_soil_moistureVarInfo = new VarInfo();
        public static VarInfo xsa_critical_soil_moistureVarInfo
        {
            get { return _xsa_critical_soil_moistureVarInfo;} 
        }

        private static VarInfo _no_of_soil_layersVarInfo = new VarInfo();
        public static VarInfo no_of_soil_layersVarInfo
        {
            get { return _no_of_soil_layersVarInfo;} 
        }

        private static VarInfo _no_of_soil_moisture_layersVarInfo = new VarInfo();
        public static VarInfo no_of_soil_moisture_layersVarInfo
        {
            get { return _no_of_soil_moisture_layersVarInfo;} 
        }

        private static VarInfo _layer_thicknessVarInfo = new VarInfo();
        public static VarInfo layer_thicknessVarInfo
        {
            get { return _layer_thicknessVarInfo;} 
        }

        private static VarInfo _permanent_wilting_pointVarInfo = new VarInfo();
        public static VarInfo permanent_wilting_pointVarInfo
        {
            get { return _permanent_wilting_pointVarInfo;} 
        }

        private static VarInfo _field_capacityVarInfo = new VarInfo();
        public static VarInfo field_capacityVarInfo
        {
            get { return _field_capacityVarInfo;} 
        }

        public string TestPostConditions(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ET.DomainClass.ETStateVarInfo.evaporated_from_surface.CurrentValue=s.evaporated_from_surface;
                ET.DomainClass.ETStateVarInfo.actual_evapotranspiration.CurrentValue=s.actual_evapotranspiration;
                ET.DomainClass.ETStateVarInfo.actual_evaporation.CurrentValue=s.actual_evaporation;
                ET.DomainClass.ETStateVarInfo.actual_transpiration.CurrentValue=s.actual_transpiration;
                ET.DomainClass.ETStateVarInfo.surface_water_storage.CurrentValue=s.surface_water_storage;
                ET.DomainClass.ETStateVarInfo.soil_moisture.CurrentValue=s.soil_moisture;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r26 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.evaporated_from_surface);
                if(r26.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.evaporated_from_surface.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
                if(r27.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_evapotranspiration.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_evaporation);
                if(r28.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_evaporation.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_transpiration);
                if(r29.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_transpiration.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.surface_water_storage);
                if(r30.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.surface_water_storage.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.soil_moisture);
                if(r31.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.soil_moisture.ValueType)){prc.AddCondition(r31);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".ET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                ET.DomainClass.ETExogenousVarInfo.kc_factor.CurrentValue=ex.kc_factor;
                ET.DomainClass.ETExogenousVarInfo.has_snow_cover.CurrentValue=ex.has_snow_cover;
                ET.DomainClass.ETExogenousVarInfo.developmental_stage.CurrentValue=ex.developmental_stage;
                ET.DomainClass.ETExogenousVarInfo.crop_transpiration.CurrentValue=ex.crop_transpiration;
                ET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted.CurrentValue=ex.crop_evaporated_from_intercepted;
                ET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage.CurrentValue=ex.percentage_soil_coverage;
                ET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration.CurrentValue=a.potential_evapotranspiration;
                ET.DomainClass.ETStateVarInfo.surface_water_storage.CurrentValue=s.surface_water_storage;
                ET.DomainClass.ETStateVarInfo.evaporated_from_surface.CurrentValue=s.evaporated_from_surface;
                ET.DomainClass.ETStateVarInfo.actual_evaporation.CurrentValue=s.actual_evaporation;
                ET.DomainClass.ETStateVarInfo.actual_transpiration.CurrentValue=s.actual_transpiration;
                ET.DomainClass.ETStateVarInfo.soil_moisture.CurrentValue=s.soil_moisture;
                ET.DomainClass.ETStateVarInfo.evaporation.CurrentValue=s.evaporation;
                ET.DomainClass.ETStateVarInfo.transpiration.CurrentValue=s.transpiration;
                ET.DomainClass.ETStateVarInfo.evapotranspiration.CurrentValue=s.evapotranspiration;
                ET.DomainClass.ETStateVarInfo.actual_evapotranspiration.CurrentValue=s.actual_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.kc_factor);
                if(r1.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.kc_factor.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.has_snow_cover);
                if(r2.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.has_snow_cover.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.developmental_stage);
                if(r3.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.developmental_stage.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.crop_transpiration);
                if(r4.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.crop_transpiration.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted);
                if(r5.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage);
                if(r6.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration);
                if(r7.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.surface_water_storage);
                if(r8.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.surface_water_storage.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.evaporated_from_surface);
                if(r9.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.evaporated_from_surface.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_evaporation);
                if(r10.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_evaporation.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_transpiration);
                if(r11.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_transpiration.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.soil_moisture);
                if(r12.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.soil_moisture.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.evaporation);
                if(r13.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.evaporation.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.transpiration);
                if(r14.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.transpiration.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.evapotranspiration);
                if(r15.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.evapotranspiration.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(ET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
                if(r16.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETStateVarInfo.actual_evapotranspiration.ValueType)){prc.AddCondition(r16);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("evaporation_zeta")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("maximum_evaporation_impact_depth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("evaporation_reduction_method")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("xsa_critical_soil_moisture")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("no_of_soil_layers")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("no_of_soil_moisture_layers")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layer_thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("permanent_wilting_point")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("field_capacity")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".ET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component ET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(ET.DomainClass.ETState s, ET.DomainClass.ETState s1, ET.DomainClass.ETRate r, ET.DomainClass.ETAuxiliary a, ET.DomainClass.ETExogenous ex)
        {
            double kc_factor = ex.kc_factor;
            bool has_snow_cover = ex.has_snow_cover;
            int developmental_stage = ex.developmental_stage;
            double[] crop_transpiration = ex.crop_transpiration;
            double crop_evaporated_from_intercepted = ex.crop_evaporated_from_intercepted;
            double percentage_soil_coverage = ex.percentage_soil_coverage;
            double surface_water_storage = 0.0;
            double evaporated_from_surface = 0.0;
            double actual_evaporation = 0.0;
            double actual_transpiration = 0.0;
            double[] soil_moisture =  new double [no_of_soil_moisture_layers];
            double[] evaporation =  new double [no_of_soil_moisture_layers];
            double[] transpiration =  new double [no_of_soil_moisture_layers];
            double[] evapotranspiration =  new double [no_of_soil_moisture_layers];
            double actual_evapotranspiration = 0.0;
            soil_moisture = new double[no_of_soil_moisture_layers];
            evaporation = new double[no_of_soil_moisture_layers];
            transpiration = new double[no_of_soil_moisture_layers];
            evapotranspiration = new double[no_of_soil_moisture_layers];
            s.surface_water_storage= surface_water_storage;
            s.evaporated_from_surface= evaporated_from_surface;
            s.actual_evaporation= actual_evaporation;
            s.actual_transpiration= actual_transpiration;
            s.soil_moisture= soil_moisture;
            s.evaporation= evaporation;
            s.transpiration= transpiration;
            s.evapotranspiration= evapotranspiration;
            s.actual_evapotranspiration= actual_evapotranspiration;
        }
        private void CalculateModel(ET.DomainClass.ETState s, ET.DomainClass.ETState s1, ET.DomainClass.ETRate r, ET.DomainClass.ETAuxiliary a, ET.DomainClass.ETExogenous ex)
        {
            double kc_factor = ex.kc_factor;
            bool has_snow_cover = ex.has_snow_cover;
            int developmental_stage = ex.developmental_stage;
            double[] crop_transpiration = ex.crop_transpiration;
            double crop_evaporated_from_intercepted = ex.crop_evaporated_from_intercepted;
            double percentage_soil_coverage = ex.percentage_soil_coverage;
            double potential_evapotranspiration = a.potential_evapotranspiration;
            double surface_water_storage = s.surface_water_storage;
            double evaporated_from_surface = s.evaporated_from_surface;
            double actual_evaporation = s.actual_evaporation;
            double actual_transpiration = s.actual_transpiration;
            double[] soil_moisture = s.soil_moisture;
            double[] evaporation = s.evaporation;
            double[] transpiration = s.transpiration;
            double[] evapotranspiration = s.evapotranspiration;
            double actual_evapotranspiration = s.actual_evapotranspiration;
            double evaporated_from_intercept;
            if (developmental_stage > 0)
            {
                evaporated_from_intercept = crop_evaporated_from_intercepted;
            }
            else
            {
                evaporated_from_intercept = 0.0;
            }
            evaporated_from_surface = 0.0;
            actual_evaporation = 0.0;
            actual_transpiration = 0.0;
            bool evaporation_from_surface = false;
            double eRed1;
            double eRed2;
            double eRed3;
            double eReducer;
            int i;
            if (potential_evapotranspiration > 0.0)
            {
                evaporation_from_surface = false;
                if (surface_water_storage > 0.0)
                {
                    evaporation_from_surface = true;
                    potential_evapotranspiration = potential_evapotranspiration * (1.1 / kc_factor);
                    if (has_snow_cover)
                    {
                        evaporated_from_surface = 0.0;
                    }
                    else if ( surface_water_storage < potential_evapotranspiration)
                    {
                        potential_evapotranspiration = potential_evapotranspiration - surface_water_storage;
                        evaporated_from_surface = surface_water_storage;
                        surface_water_storage = 0.0;
                    }
                    else
                    {
                        surface_water_storage = surface_water_storage - potential_evapotranspiration;
                        evaporated_from_surface = potential_evapotranspiration;
                        potential_evapotranspiration = 0.0;
                    }
                    potential_evapotranspiration = potential_evapotranspiration * (kc_factor / 1.1);
                }
                if (potential_evapotranspiration > 0.0)
                {
                    for (i=0 ; i!=no_of_soil_layers ; i+=1)
                    {
                        eRed1 = e_reducer_1(permanent_wilting_point[i], field_capacity[i], soil_moisture[i], percentage_soil_coverage, potential_evapotranspiration, evaporation_reduction_method, xsa_critical_soil_moisture);
                        eRed2 = 0.0;
                        if ((double)(i) >= maximum_evaporation_impact_depth)
                        {
                            eRed2 = 0.0;
                        }
                        else
                        {
                            eRed2 = get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i]);
                        }
                        eRed3 = 0.0;
                        if (i > 0 && soil_moisture[i] < soil_moisture[i - 1])
                        {
                            eRed3 = 0.1;
                        }
                        else
                        {
                            eRed3 = 1.0;
                        }
                        eReducer = eRed1 * eRed2 * eRed3;
                        if (developmental_stage > 0)
                        {
                            if (percentage_soil_coverage >= 0.0 && percentage_soil_coverage < 1.0)
                            {
                                evaporation[i] = (1.0 - percentage_soil_coverage) * eReducer * potential_evapotranspiration;
                            }
                            else if ( percentage_soil_coverage >= 1.0)
                            {
                                evaporation[i] = 0.0;
                            }
                            if (has_snow_cover)
                            {
                                evaporation[i] = 0.0;
                            }
                            transpiration[i] = crop_transpiration[i];
                            if (evaporation_from_surface)
                            {
                                transpiration[i] = percentage_soil_coverage * eReducer * potential_evapotranspiration;
                            }
                        }
                        else
                        {
                            if (has_snow_cover)
                            {
                                evaporation[i] = 0.0;
                            }
                            else
                            {
                                evaporation[i] = potential_evapotranspiration * eReducer;
                            }
                            transpiration[i] = 0.0;
                        }
                        evapotranspiration[i] = evaporation[i] + transpiration[i];
                        soil_moisture[i] = soil_moisture[i] - (evapotranspiration[i] / 1000.0 / layer_thickness[i]);
                        if (soil_moisture[i] < 0.01)
                        {
                            soil_moisture[i] = 0.01;
                        }
                        actual_transpiration = actual_transpiration + transpiration[i];
                        actual_evaporation = actual_evaporation + evaporation[i];
                    }
                }
            }
            actual_evapotranspiration = actual_transpiration + actual_evaporation + evaporated_from_intercept + evaporated_from_surface;
            s.surface_water_storage= surface_water_storage;
            s.evaporated_from_surface= evaporated_from_surface;
            s.actual_evaporation= actual_evaporation;
            s.actual_transpiration= actual_transpiration;
            s.soil_moisture= soil_moisture;
            s.actual_evapotranspiration= actual_evapotranspiration;
        }
        public static double bound(double lower, double value, double upper)
        {
            if (value < lower)
            {
                return lower;
            }
            if (value > upper)
            {
                return upper;
            }
            return value;
        }
        public static double get_deprivation_factor(int layer_no, double deprivation_depth, double zeta, double layer_thickness)
        {
            double ltf;
            ltf = deprivation_depth / (layer_thickness * 10.0);
            double deprivation_factor;
            double c2;
            double c3;
            if (Math.Abs(zeta) < 0.0003)
            {
                deprivation_factor = 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no - 1));
            }
            else
            {
                c2 = Math.Log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))));
                c3 = zeta / (ltf * (zeta + 1.0));
                deprivation_factor = (c2 - c3) / (Math.Log(zeta + 1.0) - (zeta / (zeta + 1.0)));
            }
            return deprivation_factor;
        }
        public static double e_reducer_1(double pwp, double fc, double sm, double percentage_soil_coverage, double reference_evapotranspiration, int evaporation_reduction_method, double xsa_critical_soil_moisture)
        {
            sm = Math.Max(0.33 * pwp, sm);
            double relative_evaporable_water;
            relative_evaporable_water = Math.Min(1.0, (sm - (0.33 * pwp)) / (fc - (0.33 * pwp)));
            double e_reduction_factor = 0.0;
            double critical_soil_moisture;
            double reducer;
            double xsa;
            if (evaporation_reduction_method == 0)
            {
                critical_soil_moisture = 0.65 * fc;
                if (percentage_soil_coverage > 0.0)
                {
                    reducer = 1.0;
                    if (reference_evapotranspiration > 2.5)
                    {
                        xsa = (0.65 * fc - pwp) * (fc - pwp);
                        reducer = xsa + ((1 - xsa) / 17.5 * (reference_evapotranspiration - 2.5));
                    }
                    else
                    {
                        reducer = xsa_critical_soil_moisture / 2.5 * reference_evapotranspiration;
                    }
                    critical_soil_moisture = fc * reducer;
                }
                if (sm > critical_soil_moisture)
                {
                    e_reduction_factor = 1.0;
                }
                else if ( sm > (0.33 * pwp))
                {
                    e_reduction_factor = relative_evaporable_water;
                }
                else
                {
                    e_reduction_factor = 0.0;
                }
            }
            else
            {
                if (relative_evaporable_water > 0.33)
                {
                    e_reduction_factor = 1.0 - (0.1 * (1.0 - relative_evaporable_water) / (1.0 - 0.33));
                }
                else if ( relative_evaporable_water > 0.22)
                {
                    e_reduction_factor = 0.9 - (0.625 * (0.33 - relative_evaporable_water) / (0.33 - 0.22));
                }
                else if ( relative_evaporable_water > 0.2)
                {
                    e_reduction_factor = 0.275 - (0.225 * (0.22 - relative_evaporable_water) / (0.22 - 0.2));
                }
                else
                {
                    e_reduction_factor = 0.05 - (0.05 * (0.2 - relative_evaporable_water) / 0.2);
                }
            }
            return e_reduction_factor;
        }
    }
}