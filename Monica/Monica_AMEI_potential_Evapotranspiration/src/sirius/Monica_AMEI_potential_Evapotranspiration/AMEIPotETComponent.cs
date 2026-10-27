
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
    public class AMEIPotETComponent : IStrategySiriusQualityAMEIPotET
    {
        public AMEIPotETComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_ReferenceEvapotranspiration, "height_nn");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd1.PropertyName = "vapor_pressure";
            pd1.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd2.PropertyName = "saturated_vapor_pressure";
            pd2.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd3.PropertyName = "mean_air_temperature";
            pd3.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd4.PropertyName = "wind_speed";
            pd4.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd5.PropertyName = "wind_speed_height";
            pd5.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd6.PropertyName = "stomata_resistance";
            pd6.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd7.PropertyName = "net_radiation";
            pd7.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd8.PropertyName = "kc_factor";
            pd8.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd9.PropertyName = "developmental_stage";
            pd9.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd10.PropertyName = "crop_remaining_evapotranspiration";
            pd10.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd11.PropertyName = "reference_evapotranspiration";
            pd11.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd12.PropertyName = "potential_evapotranspiration";
            pd12.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
            _outputs0_0.Add(pd12);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualityAMEIPotET.Strategies.SaturationVaporPressureDeficit).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityAMEIPotET.Strategies.ReferenceEvapotranspiration).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityAMEIPotET.Strategies.PotentialEvapotranspiration).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
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
            return new List<Type>() {  typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary), typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous)};
        }

        public double height_nn
        {
            get
            {
                 return _ReferenceEvapotranspiration.height_nn; 
            }
            set
            {
                _ReferenceEvapotranspiration.height_nn = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SaturationVaporPressureDeficit.SetParametersDefaultValue();
            _ReferenceEvapotranspiration.SetParametersDefaultValue();
            _PotentialEvapotranspiration.SetParametersDefaultValue();
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

        public static VarInfo height_nnVarInfo
        {
            get { return SiriusQualityAMEIPotET.Strategies.ReferenceEvapotranspiration.height_nnVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.CurrentValue=a.potential_evapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.potential_evapotranspiration.ValueType)){prc.AddCondition(r13);}

                string ret = "";
                ret += _SaturationVaporPressureDeficit.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                ret += _ReferenceEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                ret += _PotentialEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.AMEIPotET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure.CurrentValue=a.vapor_pressure;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure.CurrentValue=a.saturated_vapor_pressure;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.CurrentValue=ex.kc_factor;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.CurrentValue=ex.developmental_stage;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.CurrentValue=ex.crop_remaining_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.vapor_pressure.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturated_vapor_pressure.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.kc_factor.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.developmental_stage.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.crop_remaining_evapotranspiration.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
                string ret = "";
                ret += _SaturationVaporPressureDeficit.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                ret += _ReferenceEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                ret += _PotentialEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIPotET.Strategies.AMEIPotET");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.AMEIPotET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
        ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
        PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

        private void EstimateOfAssociatedClasses(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex)
        {
            _SaturationVaporPressureDeficit.Estimate(s,s1, r, a, ex);
            _ReferenceEvapotranspiration.Estimate(s,s1, r, a, ex);
            _PotentialEvapotranspiration.Estimate(s,s1, r, a, ex);
        }

        public AMEIPotETComponent(AMEIPotETComponent toCopy): this() // copy constructor 
        {
                height_nn = toCopy.height_nn;
            }
        }
    }