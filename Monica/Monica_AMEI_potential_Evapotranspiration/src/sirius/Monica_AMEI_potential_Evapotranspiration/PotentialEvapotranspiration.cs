
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
using SiriusQualityAMEIPotET.DomainClass;
namespace SiriusQualityAMEIPotET.Strategies
{
    public class PotentialEvapotranspiration : IStrategySiriusQualityAMEIPotET
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
            pd1.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd1.PropertyName = "kc_factor";
            pd1.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd2.PropertyName = "developmental_stage";
            pd2.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd3.PropertyName = "crop_remaining_evapotranspiration";
            pd3.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd4.PropertyName = "reference_evapotranspiration";
            pd4.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd5.PropertyName = "potential_evapotranspiration";
            pd5.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
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
            return new List<Type>() {  typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState),  typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous)};
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

        public string TestPostConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.CurrentValue=a.potential_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.ValueType)){prc.AddCondition(r6);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.AMEIPotET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.CurrentValue=ex.kc_factor;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.CurrentValue=ex.developmental_stage;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.CurrentValue=ex.crop_remaining_evapotranspiration;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r4);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("potential_evapotranspiration_cap")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.AMEIPotET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityAMEIPotET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private double _potential_evapotranspiration_cap;
        public double potential_evapotranspiration_cap
    {
        get { return this._potential_evapotranspiration_cap; }
        set { this._potential_evapotranspiration_cap= value; } 
    }
    /// <summary>
    /// Constructor of the PotentialEvapotranspiration component")
    /// </summary>  
    public PotentialEvapotranspiration() { }
    
        public void  CalculateModel(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
        {
            //- Name: PotentialEvapotranspiration -Version: 1, -Time step: 1
            //- Description:
    //            * Title: MONICA potential evapotranspiration calculation
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: Calculates the MONICA potential evapotranspiration
            //- inputs:
    //            * name: potential_evapotranspiration_cap
    //                          ** description : cap ET0 to this value
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 6.5
    //                          ** unit : mm
    //            * name: kc_factor
    //                          ** description : crop coefficient ETc/ET0
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0.75
    //                          ** unit : dimensionless
    //            * name: developmental_stage
    //                          ** description : MONICA crop developmental stage
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 6
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : dimensionless
    //            * name: crop_remaining_evapotranspiration
    //                          ** description : crop remaining evapotranspiration
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: reference_evapotranspiration
    //                          ** description : ET0 either from external ET0 or crop specific ET0
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
            //- outputs:
    //            * name: potential_evapotranspiration
    //                          ** description : the potential evapotranspiration
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
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