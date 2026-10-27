
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
    public class NetRadiation : IStrategyET
    {
        public NetRadiation()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0;
            v1.Description = "height above sea level";
            v1.Id = 0;
            v1.MaxValue = 9999;
            v1.MinValue = -9999;
            v1.Name = "height_nn";
            v1.Size = 1;
            v1.Units = "m";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0;
            v2.Description = "reference albedo";
            v2.Id = 0;
            v2.MaxValue = 1;
            v2.MinValue = 0;
            v2.Name = "reference_albedo";
            v2.Size = 1;
            v2.Units = "dimensionless";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd1.PropertyName = "global_radiation";
            pd1.PropertyType = (ET.DomainClass.ETExogenousVarInfo.global_radiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.global_radiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd2.PropertyName = "max_air_temperature";
            pd2.PropertyType = (ET.DomainClass.ETExogenousVarInfo.max_air_temperature).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.max_air_temperature);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd3.PropertyName = "min_air_temperature";
            pd3.PropertyType = (ET.DomainClass.ETExogenousVarInfo.min_air_temperature).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.min_air_temperature);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "extraterrestrial_radiation";
            pd4.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd5.PropertyName = "vapor_pressure";
            pd5.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd6.PropertyName = "net_radiation";
            pd6.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
            _outputs0_0.Add(pd6);
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
            get { return "        " ;}
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

        public double height_nn
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("height_nn");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'height_nn' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("height_nn");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'height_nn' not found in strategy 'NetRadiation'");
            }
        }
        public double reference_albedo
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("reference_albedo");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'reference_albedo' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("reference_albedo");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'reference_albedo' not found in strategy 'NetRadiation'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            height_nnVarInfo.Name = "height_nn";
            height_nnVarInfo.Description = "height above sea level";
            height_nnVarInfo.MaxValue = 9999;
            height_nnVarInfo.MinValue = -9999;
            height_nnVarInfo.DefaultValue = 0;
            height_nnVarInfo.Units = "m";
            height_nnVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            reference_albedoVarInfo.Name = "reference_albedo";
            reference_albedoVarInfo.Description = "reference albedo";
            reference_albedoVarInfo.MaxValue = 1;
            reference_albedoVarInfo.MinValue = 0;
            reference_albedoVarInfo.DefaultValue = 0;
            reference_albedoVarInfo.Units = "dimensionless";
            reference_albedoVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _height_nnVarInfo = new VarInfo();
        public static VarInfo height_nnVarInfo
        {
            get { return _height_nnVarInfo;} 
        }

        private static VarInfo _reference_albedoVarInfo = new VarInfo();
        public static VarInfo reference_albedoVarInfo
        {
            get { return _reference_albedoVarInfo;} 
        }

        public string TestPostConditions(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ET.DomainClass.ETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
                if(r8.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r8);}
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
                ET.DomainClass.ETExogenousVarInfo.global_radiation.CurrentValue=ex.global_radiation;
                ET.DomainClass.ETExogenousVarInfo.max_air_temperature.CurrentValue=ex.max_air_temperature;
                ET.DomainClass.ETExogenousVarInfo.min_air_temperature.CurrentValue=ex.min_air_temperature;
                ET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.CurrentValue=a.extraterrestrial_radiation;
                ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.CurrentValue=a.vapor_pressure;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.global_radiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.global_radiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.max_air_temperature);
                if(r2.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.max_air_temperature.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.min_air_temperature);
                if(r3.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.min_air_temperature.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
                if(r4.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
                if(r5.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.ValueType)){prc.AddCondition(r5);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("reference_albedo")));
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

        private void CalculateModel(ET.DomainClass.ETState s, ET.DomainClass.ETState s1, ET.DomainClass.ETRate r, ET.DomainClass.ETAuxiliary a, ET.DomainClass.ETExogenous ex)
        {
            double global_radiation = ex.global_radiation;
            double max_air_temperature = ex.max_air_temperature;
            double min_air_temperature = ex.min_air_temperature;
            double extraterrestrial_radiation = a.extraterrestrial_radiation;
            double vapor_pressure = a.vapor_pressure;
            double net_radiation;
            double clear_sky_solar_radiation;
            clear_sky_solar_radiation = (0.75 + (0.00002 * height_nn)) * extraterrestrial_radiation;
            double relative_shortwave_radiation;
            relative_shortwave_radiation = clear_sky_solar_radiation > 0.0 ? Math.Min(global_radiation / clear_sky_solar_radiation, 1.0) : 1.0;
            double bolzmann_constant = 0.0000000049;
            double shortwave_radiation;
            shortwave_radiation = (1.0 - reference_albedo) * global_radiation;
            double longwave_radiation;
            longwave_radiation = bolzmann_constant * ((Math.Pow(min_air_temperature + 273.16, 4.0) + Math.Pow(max_air_temperature + 273.16, 4.0)) / 2.0) * (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 * Math.Sqrt(vapor_pressure)));
            net_radiation = shortwave_radiation - longwave_radiation;
            a.net_radiation= net_radiation;
        }
    }
}