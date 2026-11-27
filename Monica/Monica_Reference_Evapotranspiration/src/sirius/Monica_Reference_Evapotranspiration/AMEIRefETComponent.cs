
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

using SiriusQualityAMEIRefET.DomainClass;
namespace SiriusQualityAMEIRefET.Strategies
{
    public class AMEIRefETComponent : IStrategySiriusQualityAMEIRefET
    {
        public AMEIRefETComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_ReferenceEvapotranspiration, "height_nn");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_ReferenceEvapotranspiration, "latent_heat_of_vaporization");
            _parameters0_0.Add(v2);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous);
            pd1.PropertyName = "mean_air_temperature";
            pd1.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous);
            pd2.PropertyName = "wind_speed";
            pd2.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous);
            pd3.PropertyName = "wind_speed_height";
            pd3.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd4.PropertyName = "stomata_resistance";
            pd4.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd5.PropertyName = "net_radiation";
            pd5.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd6.PropertyName = "saturation_vapor_pressure_deficit";
            pd6.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary);
            pd7.PropertyName = "reference_evapotranspiration";
            pd7.PropertyType = (SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualityAMEIRefET.Strategies.ReferenceEvapotranspiration).FullName);
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
            return new List<Type>() {  typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState), typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState), typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate), typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary), typeof(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous)};
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
        public double latent_heat_of_vaporization
        {
            get
            {
                 return _ReferenceEvapotranspiration.latent_heat_of_vaporization; 
            }
            set
            {
                _ReferenceEvapotranspiration.latent_heat_of_vaporization = value;
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

            latent_heat_of_vaporizationVarInfo.Name = "latent_heat_of_vaporization";
            latent_heat_of_vaporizationVarInfo.Description = "latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure)";
            latent_heat_of_vaporizationVarInfo.MaxValue = 10;
            latent_heat_of_vaporizationVarInfo.MinValue = 0;
            latent_heat_of_vaporizationVarInfo.DefaultValue = 0;
            latent_heat_of_vaporizationVarInfo.Units = "MJ/kg";
            latent_heat_of_vaporizationVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo height_nnVarInfo
        {
            get { return SiriusQualityAMEIRefET.Strategies.ReferenceEvapotranspiration.height_nnVarInfo;} 
        }

        public static VarInfo latent_heat_of_vaporizationVarInfo
        {
            get { return SiriusQualityAMEIRefET.Strategies.ReferenceEvapotranspiration.latent_heat_of_vaporizationVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s,SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s1,SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate r,SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary a,SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r9);}

                string ret = "";
                ret += _ReferenceEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIRefET.Strategies.AMEIRefET");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.AMEIRefET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s,SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s1,SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate r,SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary a,SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r6);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latent_heat_of_vaporization")));
                string ret = "";
                ret += _ReferenceEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityAMEIRefET.Strategies.AMEIRefET");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.AMEIRefET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s,SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s1,SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate r,SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary a,SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityAMEIRefET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s,SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s1,SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate r,SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary a,SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

        private void EstimateOfAssociatedClasses(SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s,SiriusQualityAMEIRefET.DomainClass.AMEIRefETState s1,SiriusQualityAMEIRefET.DomainClass.AMEIRefETRate r,SiriusQualityAMEIRefET.DomainClass.AMEIRefETAuxiliary a,SiriusQualityAMEIRefET.DomainClass.AMEIRefETExogenous ex)
        {
            _ReferenceEvapotranspiration.Estimate(s,s1, r, a, ex);
        }

        public AMEIRefETComponent(AMEIRefETComponent toCopy): this() // copy constructor 
        {
                height_nn = toCopy.height_nn;
                latent_heat_of_vaporization = toCopy.latent_heat_of_vaporization;
            }
        }
    }