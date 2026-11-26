
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

using AMEIRefET.DomainClass;
namespace AMEIRefET.Strategies
{
    public class AMEIRefETComponent : IStrategyAMEIRefET
    {
        public AMEIRefETComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_ReferenceEvapotranspiration, "height_nn");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETExogenous);
            pd1.PropertyName = "mean_air_temperature";
            pd1.PropertyType = (AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETExogenous);
            pd2.PropertyName = "wind_speed";
            pd2.PropertyType = (AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETExogenous);
            pd3.PropertyName = "wind_speed_height";
            pd3.PropertyType = (AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd4.PropertyName = "stomata_resistance";
            pd4.PropertyType = (AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd5.PropertyName = "net_radiation";
            pd5.PropertyType = (AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd6.PropertyName = "saturation_vapor_pressure_deficit";
            pd6.PropertyType = (AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(AMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd7.PropertyName = "reference_evapotranspiration";
            pd7.PropertyType = (AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(AMEIRefET.Strategies.ReferenceEvapotranspiration).FullName);
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
            return new List<Type>() {  typeof(AMEIRefET.DomainClass.AMEIRefETState), typeof(AMEIRefET.DomainClass.AMEIRefETState), typeof(AMEIRefET.DomainClass.AMEIRefETRate), typeof(AMEIRefET.DomainClass.AMEIRefETAuxiliary), typeof(AMEIRefET.DomainClass.AMEIRefETExogenous)};
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
            _ReferenceEvapotranspiration.SetParametersDefaultValue();
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
            get { return AMEIRefET.Strategies.ReferenceEvapotranspiration.height_nnVarInfo;} 
        }

        public string TestPostConditions(AMEIRefET.DomainClass.AMEIRefETState s,AMEIRefET.DomainClass.AMEIRefETState s1,AMEIRefET.DomainClass.AMEIRefETRate r,AMEIRefET.DomainClass.AMEIRefETAuxiliary a,AMEIRefET.DomainClass.AMEIRefETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r8 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r8.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r8);}

                string ret = "";
                ret += _ReferenceEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy AMEIRefET.Strategies.AMEIRefET");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .AMEIRefET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(AMEIRefET.DomainClass.AMEIRefETState s,AMEIRefET.DomainClass.AMEIRefETState s1,AMEIRefET.DomainClass.AMEIRefETRate r,AMEIRefET.DomainClass.AMEIRefETAuxiliary a,AMEIRefET.DomainClass.AMEIRefETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature);
                if(r1.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed);
                if(r2.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height);
                if(r3.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance);
                if(r4.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation);
                if(r5.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r6.ApplicableVarInfoValueTypes.Contains( AMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r6);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
                string ret = "";
                ret += _ReferenceEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy AMEIRefET.Strategies.AMEIRefET");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .AMEIRefET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(AMEIRefET.DomainClass.AMEIRefETState s,AMEIRefET.DomainClass.AMEIRefETState s1,AMEIRefET.DomainClass.AMEIRefETRate r,AMEIRefET.DomainClass.AMEIRefETAuxiliary a,AMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component AMEIRefET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(AMEIRefET.DomainClass.AMEIRefETState s,AMEIRefET.DomainClass.AMEIRefETState s1,AMEIRefET.DomainClass.AMEIRefETRate r,AMEIRefET.DomainClass.AMEIRefETAuxiliary a,AMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

        private void EstimateOfAssociatedClasses(AMEIRefET.DomainClass.AMEIRefETState s,AMEIRefET.DomainClass.AMEIRefETState s1,AMEIRefET.DomainClass.AMEIRefETRate r,AMEIRefET.DomainClass.AMEIRefETAuxiliary a,AMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            _ReferenceEvapotranspiration.Estimate(s,s1, r, a, ex);
        }

        public AMEIRefETComponent(AMEIRefETComponent toCopy): this() // copy constructor 
        {
                height_nn = toCopy.height_nn;
            }
        }
    }