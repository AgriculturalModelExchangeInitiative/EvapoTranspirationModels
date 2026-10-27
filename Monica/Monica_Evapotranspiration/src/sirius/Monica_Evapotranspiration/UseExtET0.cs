
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
using SiriusQualityET.DomainClass;
namespace SiriusQualityET.Strategies
{
    public class UseExtET0 : IStrategySiriusQualityET
    {
        public UseExtET0()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd1.PropertyName = "use_external_et0";
            pd1.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd2.PropertyName = "external_et0";
            pd2.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd3.PropertyName = "internal_et0";
            pd3.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.internal_et0).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.internal_et0);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "et0";
            pd4.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.et0).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.et0);
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
            return new List<Type>() {  typeof(SiriusQualityET.DomainClass.ETState),  typeof(SiriusQualityET.DomainClass.ETState), typeof(SiriusQualityET.DomainClass.ETRate), typeof(SiriusQualityET.DomainClass.ETAuxiliary), typeof(SiriusQualityET.DomainClass.ETExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.et0.CurrentValue=a.et0;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.et0);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.et0.ValueType)){prc.AddCondition(r4);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0.CurrentValue=a.use_external_et0;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0.CurrentValue=a.external_et0;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.internal_et0.CurrentValue=a.internal_et0;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.internal_et0);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.internal_et0.ValueType)){prc.AddCondition(r3);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        
    /// <summary>
    /// Constructor of the UseExtET0 component")
    /// </summary>  
    public UseExtET0() { }
    
        public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
        {
            //- Name: UseExtET0 -Version: 1, -Time step: 1
            //- Description:
    //            * Title: If Else unit 
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: switches between two input values 
            //- inputs:
    //            * name: use_external_et0
    //                          ** description : boolean condition to be met
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : BOOLEAN
    //                          ** default : false
    //                          ** unit : 
    //            * name: external_et0
    //                          ** description : value to be returned if condition is true
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: internal_et0
    //                          ** description : value to be returned if condition is false
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
            //- outputs:
    //            * name: et0
    //                          ** description : the output value
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
            bool use_external_et0 = a.use_external_et0;
            double external_et0 = a.external_et0;
            double internal_et0 = a.internal_et0;
            double et0;
            if (use_external_et0)
            {
                et0 = external_et0;
            }
            else
            {
                et0 = internal_et0;
            }
            a.et0= et0;
        }
    }
}