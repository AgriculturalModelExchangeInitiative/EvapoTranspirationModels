
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
    public class SaturationVaporPressureDeficit : IStrategySiriusQualityET
    {
        public SaturationVaporPressureDeficit()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd1.PropertyName = "saturated_vapor_pressure";
            pd1.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd2.PropertyName = "vapor_pressure";
            pd2.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd3.PropertyName = "saturation_vapor_pressure_deficit";
            pd3.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _outputs0_0.Add(pd3);
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
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r3);}
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
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure.CurrentValue=a.saturated_vapor_pressure;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.CurrentValue=a.vapor_pressure;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturated_vapor_pressure.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.vapor_pressure.ValueType)){prc.AddCondition(r2);}
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
    /// Constructor of the SaturationVaporPressureDeficit component")
    /// </summary>  
    public SaturationVaporPressureDeficit() { }
    
        public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
        {
            //- Name: SaturationVaporPressureDeficit -Version: 1, -Time step: 1
            //- Description:
    //            * Title: MONICA saturation vapor pressure deficit
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: Calculates saturation vapor pressure deficit as in the MONICA model
            //- inputs:
    //            * name: saturated_vapor_pressure
    //                          ** description : saturated vapor pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : kPa
    //            * name: vapor_pressure
    //                          ** description : vapor pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : kPa
            //- outputs:
    //            * name: saturation_vapor_pressure_deficit
    //                          ** description : saturation vapor pressure deficit
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : kPa
            double saturated_vapor_pressure = a.saturated_vapor_pressure;
            double vapor_pressure = a.vapor_pressure;
            double saturation_vapor_pressure_deficit;
            saturation_vapor_pressure_deficit = saturated_vapor_pressure - vapor_pressure;
            a.saturation_vapor_pressure_deficit= saturation_vapor_pressure_deficit;
        }
    }
}