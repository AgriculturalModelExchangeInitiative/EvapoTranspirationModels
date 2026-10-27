
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
    public class SaturationVaporPressureDeficit : IStrategySiriusQualityAMEIPotET
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
            pd1.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd1.PropertyName = "saturated_vapor_pressure";
            pd1.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd2.PropertyName = "vapor_pressure";
            pd2.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd3.PropertyName = "saturation_vapor_pressure_deficit";
            pd3.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
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
            return new List<Type>() {  typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState),  typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r3);}
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
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure.CurrentValue=a.saturated_vapor_pressure;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure.CurrentValue=a.vapor_pressure;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure.ValueType)){prc.AddCondition(r2);}
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

        
    /// <summary>
    /// Constructor of the SaturationVaporPressureDeficit component")
    /// </summary>  
    public SaturationVaporPressureDeficit() { }
    
        public void  CalculateModel(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
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