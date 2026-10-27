
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
using AMEIPotET.DomainClass;
namespace AMEIPotET.Strategies
{
    public class PotentialEvapotranspiration : IStrategyAMEIPotET
    {
        public PotentialEvapotranspiration()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 6.5;
            v1.Description = "cap ET0 to this value";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = 0;
            v1.Name = "potential_evapotranspiration_cap";
            v1.Size = 1;
            v1.Units = "mm";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(AMEIPotET.DomainClass.AMEIPotETExogenous);
            pd1.PropertyName = "kc_factor";
            pd1.PropertyType = (AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(AMEIPotET.DomainClass.AMEIPotETExogenous);
            pd2.PropertyName = "developmental_stage";
            pd2.PropertyType = (AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(AMEIPotET.DomainClass.AMEIPotETExogenous);
            pd3.PropertyName = "crop_remaining_evapotranspiration";
            pd3.PropertyType = (AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(AMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd4.PropertyName = "reference_evapotranspiration";
            pd4.PropertyType = (AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(AMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd5.PropertyName = "potential_evapotranspiration";
            pd5.PropertyType = (AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
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
            return new List<Type>() {  typeof(AMEIPotET.DomainClass.AMEIPotETState),  typeof(AMEIPotET.DomainClass.AMEIPotETState), typeof(AMEIPotET.DomainClass.AMEIPotETRate), typeof(AMEIPotET.DomainClass.AMEIPotETAuxiliary), typeof(AMEIPotET.DomainClass.AMEIPotETExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double potential_evapotranspiration_cap
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("potential_evapotranspiration_cap");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'potential_evapotranspiration_cap' not found (or found null) in strategy 'PotentialEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("potential_evapotranspiration_cap");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'potential_evapotranspiration_cap' not found in strategy 'PotentialEvapotranspiration'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            potential_evapotranspiration_capVarInfo.Name = "potential_evapotranspiration_cap";
            potential_evapotranspiration_capVarInfo.Description = "cap ET0 to this value";
            potential_evapotranspiration_capVarInfo.MaxValue = -1D;
            potential_evapotranspiration_capVarInfo.MinValue = 0;
            potential_evapotranspiration_capVarInfo.DefaultValue = 6.5;
            potential_evapotranspiration_capVarInfo.Units = "mm";
            potential_evapotranspiration_capVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _potential_evapotranspiration_capVarInfo = new VarInfo();
        public static VarInfo potential_evapotranspiration_capVarInfo
        {
            get { return _potential_evapotranspiration_capVarInfo;} 
        }

        public string TestPostConditions(AMEIPotET.DomainClass.AMEIPotETState s,AMEIPotET.DomainClass.AMEIPotETState s1,AMEIPotET.DomainClass.AMEIPotETRate r,AMEIPotET.DomainClass.AMEIPotETAuxiliary a,AMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.CurrentValue=a.potential_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
                if(r6.ApplicableVarInfoValueTypes.Contains( AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.ValueType)){prc.AddCondition(r6);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".AMEIPotET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(AMEIPotET.DomainClass.AMEIPotETState s,AMEIPotET.DomainClass.AMEIPotETState s1,AMEIPotET.DomainClass.AMEIPotETRate r,AMEIPotET.DomainClass.AMEIPotETAuxiliary a,AMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.CurrentValue=ex.kc_factor;
                AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.CurrentValue=ex.developmental_stage;
                AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.CurrentValue=ex.crop_remaining_evapotranspiration;
                AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
                if(r1.ApplicableVarInfoValueTypes.Contains( AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
                if(r2.ApplicableVarInfoValueTypes.Contains( AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
                if(r3.ApplicableVarInfoValueTypes.Contains( AMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r4.ApplicableVarInfoValueTypes.Contains( AMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r4);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("potential_evapotranspiration_cap")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".AMEIPotET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(AMEIPotET.DomainClass.AMEIPotETState s,AMEIPotET.DomainClass.AMEIPotETState s1,AMEIPotET.DomainClass.AMEIPotETRate r,AMEIPotET.DomainClass.AMEIPotETAuxiliary a,AMEIPotET.DomainClass.AMEIPotETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component AMEIPotET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(AMEIPotET.DomainClass.AMEIPotETState s, AMEIPotET.DomainClass.AMEIPotETState s1, AMEIPotET.DomainClass.AMEIPotETRate r, AMEIPotET.DomainClass.AMEIPotETAuxiliary a, AMEIPotET.DomainClass.AMEIPotETExogenous ex)
        {
            double kc_factor = ex.kc_factor;
            int developmental_stage = ex.developmental_stage;
            double crop_remaining_evapotranspiration = ex.crop_remaining_evapotranspiration;
            double reference_evapotranspiration = a.reference_evapotranspiration;
            double potential_evapotranspiration;
            if (developmental_stage > 0)
            {
                potential_evapotranspiration = crop_remaining_evapotranspiration;
            }
            else
            {
                potential_evapotranspiration = reference_evapotranspiration * kc_factor;
            }
            if (potential_evapotranspiration > potential_evapotranspiration_cap)
            {
                potential_evapotranspiration = potential_evapotranspiration_cap;
            }
            a.potential_evapotranspiration= potential_evapotranspiration;
        }
    }
}