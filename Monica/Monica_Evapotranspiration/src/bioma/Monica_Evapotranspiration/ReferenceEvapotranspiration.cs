
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
    public class ReferenceEvapotranspiration : IStrategyET
    {
        public ReferenceEvapotranspiration()
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
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd1.PropertyName = "mean_air_temperature";
            pd1.PropertyType = (ET.DomainClass.ETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd2.PropertyName = "wind_speed";
            pd2.PropertyType = (ET.DomainClass.ETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd3.PropertyName = "wind_speed_height";
            pd3.PropertyType = (ET.DomainClass.ETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "net_radiation";
            pd4.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd5.PropertyName = "stomata_resistance";
            pd5.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd6.PropertyName = "saturation_vapor_pressure_deficit";
            pd6.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd7.PropertyName = "reference_evapotranspiration";
            pd7.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd7);
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
            get { return "            A method following Penman-Monteith as described by the FAO in Allen            RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.            Guidelines for computing crop water requirements. FAO Irrigation and            Drainage Paper 56, FAO, Roma        " ;}
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
                else throw new Exception("Parameter 'height_nn' not found (or found null) in strategy 'ReferenceEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("height_nn");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'height_nn' not found in strategy 'ReferenceEvapotranspiration'");
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
        }

        private static VarInfo _height_nnVarInfo = new VarInfo();
        public static VarInfo height_nnVarInfo
        {
            get { return _height_nnVarInfo;} 
        }

        public string TestPostConditions(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r8.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r8);}
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
                ET.DomainClass.ETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                ET.DomainClass.ETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                ET.DomainClass.ETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                ET.DomainClass.ETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                ET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.mean_air_temperature);
                if(r1.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.wind_speed);
                if(r2.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.wind_speed_height);
                if(r3.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
                if(r4.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
                if(r5.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r6.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r6);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
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
            double mean_air_temperature = ex.mean_air_temperature;
            double wind_speed = ex.wind_speed;
            double wind_speed_height = ex.wind_speed_height;
            double net_radiation = a.net_radiation;
            double stomata_resistance = a.stomata_resistance;
            double saturation_vapor_pressure_deficit = a.saturation_vapor_pressure_deficit;
            double reference_evapotranspiration;
            double atmospheric_pressure;
            atmospheric_pressure = 101.3 * Math.Pow((293.0 - (0.0065 * height_nn)) / 293.0, 5.26);
            double psycrometer_constant;
            psycrometer_constant = 0.000665 * atmospheric_pressure;
            double saturated_vapour_pressure_slope;
            saturated_vapour_pressure_slope = 4098.0 * (0.6108 * Math.Exp(17.27 * mean_air_temperature / (mean_air_temperature + 237.3))) / ((mean_air_temperature + 237.3) * (mean_air_temperature + 237.3));
            double wind_speed_2m;
            wind_speed_2m = Math.Max(0.5, wind_speed * (4.87 / Math.Log((67.8 * wind_speed_height - 5.42))));
            double aerodynamic_resistance;
            aerodynamic_resistance = 208.0 / wind_speed_2m;
            double surface_resistance;
            surface_resistance = stomata_resistance / 1.44;
            reference_evapotranspiration = (0.408 * saturated_vapour_pressure_slope * net_radiation + (psycrometer_constant * (900.0 / (mean_air_temperature + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))));
            if (reference_evapotranspiration < 0.0)
            {
                reference_evapotranspiration = 0.0;
            }
            a.reference_evapotranspiration= reference_evapotranspiration;
        }
    }
}