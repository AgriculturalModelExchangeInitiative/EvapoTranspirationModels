
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
    public class CalcStomataResistance : IStrategyET
    {
        public CalcStomataResistance()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd1.PropertyName = "calc_stomata_resistance";
            pd1.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd2.PropertyName = "calculated_stomata_resistance";
            pd2.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.calculated_stomata_resistance).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.calculated_stomata_resistance);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd3.PropertyName = "fixed_stomata_resistance";
            pd3.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "stomata_resistance";
            pd4.PropertyType = (ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
            _outputs0_0.Add(pd4);
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
            _pd.Add("Creator", "Michael Berg-Mohnicke");
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
                ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r4 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
                if(r4.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r4);}
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
                ET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance.CurrentValue=a.calc_stomata_resistance;
                ET.DomainClass.ETAuxiliaryVarInfo.calculated_stomata_resistance.CurrentValue=a.calculated_stomata_resistance;
                ET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance.CurrentValue=a.fixed_stomata_resistance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance);
                if(r1.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.calculated_stomata_resistance);
                if(r2.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.calculated_stomata_resistance.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance);
                if(r3.ApplicableVarInfoValueTypes.Contains( ET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance.ValueType)){prc.AddCondition(r3);}
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
            bool calc_stomata_resistance = a.calc_stomata_resistance;
            double calculated_stomata_resistance = a.calculated_stomata_resistance;
            double fixed_stomata_resistance = a.fixed_stomata_resistance;
            double stomata_resistance;
            if (calc_stomata_resistance)
            {
                stomata_resistance = calculated_stomata_resistance;
            }
            else
            {
                stomata_resistance = fixed_stomata_resistance;
            }
            a.stomata_resistance= stomata_resistance;
        }
    }
}