
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
    public class SaturatedVaporPressure : IStrategyET
    {
        public SaturatedVaporPressure()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd1.PropertyName = "max_air_temperature";
            pd1.PropertyType = (ET.DomainClass.ETExogenousVarInfo.max_air_temperature).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.max_air_temperature);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd2.PropertyName = "min_air_temperature";
            pd2.PropertyType = (ET.DomainClass.ETExogenousVarInfo.min_air_temperature).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.min_air_temperature);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ET.DomainClass.ETExogenous);
            pd3.PropertyName = "relative_humidity";
            pd3.PropertyType = (ET.DomainClass.ETExogenousVarInfo.relative_humidity).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ET.DomainClass.ETExogenousVarInfo.relative_humidity);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "saturated_vapor_pressure";
            pd4.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd5.PropertyName = "vapor_pressure";
            pd5.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
            _outputs0_0.Add(pd5);
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


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(ET.DomainClass.ETState s,ET.DomainClass.ETState s1,ET.DomainClass.ETRate r,ET.DomainClass.ETAuxiliary a,ET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure.CurrentValue=a.saturated_vapor_pressure;
                ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.CurrentValue=a.vapor_pressure;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r4 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure);
                if(r4.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
                if(r5.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.ValueType)){prc.AddCondition(r5);}
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
                ET.DomainClass.ETExogenousVarInfo.max_air_temperature.CurrentValue=ex.max_air_temperature;
                ET.DomainClass.ETExogenousVarInfo.min_air_temperature.CurrentValue=ex.min_air_temperature;
                ET.DomainClass.ETExogenousVarInfo.relative_humidity.CurrentValue=ex.relative_humidity;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.max_air_temperature);
                if(r1.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.max_air_temperature.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.min_air_temperature);
                if(r2.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.min_air_temperature.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ET.DomainClass.ETExogenousVarInfo.relative_humidity);
                if(r3.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETExogenousVarInfo.relative_humidity.ValueType)){prc.AddCondition(r3);}
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
            double max_air_temperature = ex.max_air_temperature;
            double min_air_temperature = ex.min_air_temperature;
            double relative_humidity = ex.relative_humidity;
            double saturated_vapor_pressure;
            double vapor_pressure;
            double saturated_vapor_pressure_max;
            saturated_vapor_pressure_max = 0.6108 * Math.Exp(17.27 * max_air_temperature / (237.3 + max_air_temperature));
            double saturated_vapor_pressure_min;
            saturated_vapor_pressure_min = 0.6108 * Math.Exp(17.27 * min_air_temperature / (237.3 + min_air_temperature));
            saturated_vapor_pressure = (saturated_vapor_pressure_max + saturated_vapor_pressure_min) / 2.0;
            if (relative_humidity <= 0.0)
            {
                vapor_pressure = saturated_vapor_pressure_min;
            }
            else
            {
                vapor_pressure = relative_humidity * saturated_vapor_pressure;
            }
            a.saturated_vapor_pressure= saturated_vapor_pressure;
            a.vapor_pressure= vapor_pressure;
        }
    }
}