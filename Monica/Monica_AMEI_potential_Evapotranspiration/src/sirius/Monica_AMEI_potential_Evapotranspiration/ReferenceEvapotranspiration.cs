
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
    public class ReferenceEvapotranspiration : IStrategySiriusQualityAMEIPotET
    {
        public ReferenceEvapotranspiration()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0;
            v1.Description = "height above sea level";
            v1.Id = 0;
            v1.MaxValue = 9999;
            v1.MinValue = -9999;
            v1.Name = "height_nn";
            v1.Size = 1;
            v1.Units = "m";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd1.PropertyName = "mean_air_temperature";
            pd1.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd2.PropertyName = "wind_speed";
            pd2.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous);
            pd3.PropertyName = "wind_speed_height";
            pd3.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd4.PropertyName = "net_radiation";
            pd4.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd5.PropertyName = "stomata_resistance";
            pd5.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd6.PropertyName = "saturation_vapor_pressure_deficit";
            pd6.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary);
            pd7.PropertyName = "reference_evapotranspiration";
            pd7.PropertyType = (SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd7);
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
            get { return "            A method following Penman-Monteith as described by the FAO in Allen            RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.            Guidelines for computing crop water requirements. FAO Irrigation and            Drainage Paper 56, FAO, Roma        " ;}
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

        public double height_nn
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("height_nn");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'height_nn' not found (or found null) in strategy 'ReferenceEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("height_nn");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'height_nn' not found in strategy 'ReferenceEvapotranspiration'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
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

        private static VarInfo _height_nnVarInfo = new VarInfo();
        public static VarInfo height_nnVarInfo
        {
            get { return _height_nnVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s,SiriusQualityAMEIPotET.DomainClass.AMEIPotETState s1,SiriusQualityAMEIPotET.DomainClass.AMEIPotETRate r,SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliary a,SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r8);}
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
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityAMEIPotET.DomainClass.AMEIPotETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r6);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
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

        private double _height_nn;
        public double height_nn
    {
        get { return this._height_nn; }
        set { this._height_nn= value; } 
    }
    /// <summary>
    /// Constructor of the ReferenceEvapotranspiration component")
    /// </summary>  
    public ReferenceEvapotranspiration() { }
    
        public void  CalculateModel(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
        {
            //- Name: ReferenceEvapotranspiration -Version: 1, -Time step: 1
            //- Description:
    //            * Title: MONICA reference evapotranspiration
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //            Allen RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration. Guidelines for computing crop water requirements. FAO Irrigation and
    //            Drainage Paper 56, FAO, Roma
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //            A method following Penman-Monteith as described by the FAO in Allen
    //            RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.
    //            Guidelines for computing crop water requirements. FAO Irrigation and
    //            Drainage Paper 56, FAO, Roma
    //        
    //            * ShortDescription: Calculates the MONICA reference evapotranspiration
            //- inputs:
    //            * name: height_nn
    //                          ** description : height above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : -9999
    //                          ** default : 0
    //                          ** unit : m
    //            * name: mean_air_temperature
    //                          ** description : daily average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : -100
    //                          ** default : 0
    //                          ** unit : °C
    //            * name: wind_speed
    //                          ** description : wind speed measured at wind speed height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : m/s
    //            * name: wind_speed_height
    //                          ** description : height at which the wind speed has been measured
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 9999
    //                          ** min : -9999
    //                          ** default : 2
    //                          ** unit : m
    //            * name: net_radiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: stomata_resistance
    //                          ** description : stomata resistance (FAO default value is 100)
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 100
    //                          ** unit : s/m
    //            * name: saturation_vapor_pressure_deficit
    //                          ** description : saturation_vapor_pressure_deficit
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : kPa
            //- outputs:
    //            * name: reference_evapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
            double mean_air_temperature = ex.mean_air_temperature;
            double wind_speed = ex.wind_speed;
            double wind_speed_height = ex.wind_speed_height;
            double net_radiation = a.net_radiation;
            double stomata_resistance = a.stomata_resistance;
            double saturation_vapor_pressure_deficit = a.saturation_vapor_pressure_deficit;
            double reference_evapotranspiration;
            double atmospheric_pressure;
            atmospheric_pressure = 101.3 * Math.Pow((293.0 - (0.0065 * height_nn)) / 293.0, 5.26);
            double psycrometer_constant;
            psycrometer_constant = 0.000665 * atmospheric_pressure;
            double saturated_vapour_pressure_slope;
            saturated_vapour_pressure_slope = 4098.0 * (0.6108 * Math.Exp(17.27 * mean_air_temperature / (mean_air_temperature + 237.3))) / ((mean_air_temperature + 237.3) * (mean_air_temperature + 237.3));
            double wind_speed_2m;
            wind_speed_2m = Math.Max(0.5, wind_speed * (4.87 / Math.Log((67.8 * wind_speed_height - 5.42))));
            double aerodynamic_resistance;
            aerodynamic_resistance = 208.0 / wind_speed_2m;
            double surface_resistance;
            surface_resistance = stomata_resistance / 1.44;
            reference_evapotranspiration = (0.408 * saturated_vapour_pressure_slope * net_radiation + (psycrometer_constant * (900.0 / (mean_air_temperature + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))));
            if (reference_evapotranspiration < 0.0)
            {
                reference_evapotranspiration = 0.0;
            }
            a.reference_evapotranspiration= reference_evapotranspiration;
        }
    }
}