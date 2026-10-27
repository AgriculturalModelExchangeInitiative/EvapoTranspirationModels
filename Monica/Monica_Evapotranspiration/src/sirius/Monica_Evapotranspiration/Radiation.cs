
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
    public class Radiation : IStrategySiriusQualityET
    {
        public Radiation()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0;
            v1.Description = "latitude";
            v1.Id = 0;
            v1.MaxValue = 90;
            v1.MinValue = -90;
            v1.Name = "latitude";
            v1.Size = 1;
            v1.Units = "degree";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd1.PropertyName = "global_radiation";
            pd1.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd2.PropertyName = "julian_day";
            pd2.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd3.PropertyName = "sunshine_hours";
            pd3.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "declination";
            pd4.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd5.PropertyName = "astronomic_daylength";
            pd5.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength);
            _outputs0_0.Add(pd5);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd6.PropertyName = "effective_daylength";
            pd6.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength);
            _outputs0_0.Add(pd6);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd7.PropertyName = "photoperiodic_daylength";
            pd7.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd8.PropertyName = "sunshine_hours_global_radiation";
            pd8.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation);
            _outputs0_0.Add(pd8);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd9.PropertyName = "extraterrestrial_radiation";
            pd9.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
            _outputs0_0.Add(pd9);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd10.PropertyName = "clear_day_radiation";
            pd10.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation);
            _outputs0_0.Add(pd10);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd11.PropertyName = "overcast_day_radiation";
            pd11.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation);
            _outputs0_0.Add(pd11);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd12.PropertyName = "phot_act_radiation_mean";
            pd12.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean);
            _outputs0_0.Add(pd12);
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

        public double latitude
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("latitude");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'latitude' not found (or found null) in strategy 'Radiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("latitude");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'latitude' not found in strategy 'Radiation'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            latitudeVarInfo.Name = "latitude";
            latitudeVarInfo.Description = "latitude";
            latitudeVarInfo.MaxValue = 90;
            latitudeVarInfo.MinValue = -90;
            latitudeVarInfo.DefaultValue = 0;
            latitudeVarInfo.Units = "degree";
            latitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _latitudeVarInfo = new VarInfo();
        public static VarInfo latitudeVarInfo
        {
            get { return _latitudeVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination.CurrentValue=a.declination;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength.CurrentValue=a.astronomic_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength.CurrentValue=a.effective_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength.CurrentValue=a.photoperiodic_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation.CurrentValue=a.sunshine_hours_global_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.CurrentValue=a.extraterrestrial_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation.CurrentValue=a.clear_day_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation.CurrentValue=a.overcast_day_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean.CurrentValue=a.phot_act_radiation_mean;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean.ValueType)){prc.AddCondition(r13);}
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
                SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation.CurrentValue=ex.global_radiation;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day.CurrentValue=ex.julian_day;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours.CurrentValue=ex.sunshine_hours;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latitude")));
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

        private double _latitude;
        public double latitude
    {
        get { return this._latitude; }
        set { this._latitude= value; } 
    }
    /// <summary>
    /// Constructor of the Radiation component")
    /// </summary>  
    public Radiation() { }
    
        public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
        {
            //- Name: Radiation -Version: 1, -Time step: 1
            //- Description:
    //            * Title: MONICA radiation calculations
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //            Taken from the original HERMES model, Kersebaum, K.C. and Richter J.
    //            (1991): Modelling nitrogen dynamics in a plant-soil system with a
    //            simple model for advisory purposes. Fert. Res. 27 (2-3), 273 - 281.
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: Calculates the MONICA reference evapotranspiration
            //- inputs:
    //            * name: latitude
    //                          ** description : latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 90
    //                          ** min : -90
    //                          ** default : 0
    //                          ** unit : degree
    //            * name: global_radiation
    //                          ** description : global radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : MJ/m2
    //            * name: julian_day
    //                          ** description : day of year
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 366
    //                          ** min : 1
    //                          ** default : 1
    //                          ** unit : day
    //            * name: sunshine_hours
    //                          ** description : number of sunshine hours
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : h
            //- outputs:
    //            * name: declination
    //                          ** description : declination
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : 
    //            * name: astronomic_daylength
    //                          ** description : astronomic_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: effective_daylength
    //                          ** description : effective_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: photoperiodic_daylength
    //                          ** description : photoperiodic_daylength
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: sunshine_hours_global_radiation
    //                          ** description : global radiation calculated from sunshine hours
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: extraterrestrial_radiation
    //                          ** description : extraterrestrial_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: clear_day_radiation
    //                          ** description : clear_day_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: overcast_day_radiation
    //                          ** description : overcast_day_radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : MJ/m2
    //            * name: phot_act_radiation_mean
    //                          ** description : phot_act_radiation_mean
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : J/m2
            double global_radiation = ex.global_radiation;
            int julian_day = ex.julian_day;
            double sunshine_hours = ex.sunshine_hours;
            double declination;
            double astronomic_daylength;
            double effective_daylength;
            double photoperiodic_daylength;
            double sunshine_hours_global_radiation;
            double extraterrestrial_radiation;
            double clear_day_radiation;
            double overcast_day_radiation;
            double phot_act_radiation_mean;
            double decl_sin;
            double decl_cos;
            calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
            astronomic_daylength = calc_astronomic_daylength(latitude, julian_day);
            effective_daylength = calc_effective_daylength(latitude, julian_day);
            photoperiodic_daylength = calc_photoperiodic_daylength(latitude, julian_day);
            double arg_phot_act;
            arg_phot_act = Math.Min(1.0, decl_sin / decl_cos * (decl_sin / decl_cos));
            phot_act_radiation_mean = 3600.0 * (decl_sin * astronomic_daylength + (24.0 / Math.PI * decl_cos * Math.Sqrt((1.0 - arg_phot_act))));
            if (phot_act_radiation_mean > 0.0 && astronomic_daylength > 0.0)
            {
                clear_day_radiation = 0.5 * 1300.0 * phot_act_radiation_mean * Math.Exp(-0.14 / (phot_act_radiation_mean / (astronomic_daylength * 3600.0)));
            }
            overcast_day_radiation = 0.2 * clear_day_radiation;
            double solar_constant;
            solar_constant = 0.082;
            double SC;
            SC = 24.0 * 60.0 / Math.PI * solar_constant * (1.0 + (0.033 * Math.Cos(2.0 * Math.PI * julian_day / 365.0)));
            double solar_angle;
            solar_angle = -Math.Tan((latitude * Math.PI / 180.0)) * Math.Tan(declination * Math.PI / 180.0);
            solar_angle = bound(-1.0, solar_angle, 1.0);
            double sunset_solar_angle;
            sunset_solar_angle = Math.Acos(solar_angle);
            extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * Math.Sin(sunset_solar_angle)));
            if (sunshine_hours > 0.0)
            {
                if (global_radiation <= 0.0 && astronomic_daylength > 0.0)
                {
                    sunshine_hours_global_radiation = extraterrestrial_radiation * (0.19 + (0.55 * sunshine_hours / astronomic_daylength));
                }
                else
                {
                    sunshine_hours_global_radiation = 0.0;
                }
            }
            a.declination= declination;
            a.astronomic_daylength= astronomic_daylength;
            a.effective_daylength= effective_daylength;
            a.photoperiodic_daylength= photoperiodic_daylength;
            a.sunshine_hours_global_radiation= sunshine_hours_global_radiation;
            a.extraterrestrial_radiation= extraterrestrial_radiation;
            a.clear_day_radiation= clear_day_radiation;
            a.overcast_day_radiation= overcast_day_radiation;
            a.phot_act_radiation_mean= phot_act_radiation_mean;
        }
        public static double bound(double lower, double value, double upper)
        {
            if (value < lower)
            {
                return lower;
            }
            if (value > upper)
            {
                return upper;
            }
            return value;
        }
        public static void  calc_declinations(double latitude, int julian_day)
        {
            declination = -23.4 * Math.Cos(2.0 * Math.PI * ((julian_day + 10.0) / 365.0));
            decl_sin = Math.Sin(declination * Math.PI / 180.0) * Math.Sin(latitude * Math.PI / 180.0);
            decl_cos = Math.Cos(declination * Math.PI / 180.0) * Math.Cos(latitude * Math.PI / 180.0);
        }
        public static double calc_astronomic_daylength(double latitude, int julian_day)
        {
            double declination;
            double decl_sin;
            double decl_cos;
            calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
            double astro_daylength;
            astro_daylength = decl_sin / decl_cos;
            astro_daylength = bound(-1.0, astro_daylength, 1.0);
            double astronomic_daylength;
            astronomic_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(astro_daylength))) / Math.PI;
            return astronomic_daylength;
        }
        public static double calc_effective_daylength(double latitude, int julian_day)
        {
            double declination;
            double decl_sin;
            double decl_cos;
            calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
            double eff_daylength;
            eff_daylength = (-Math.Sin((8.0 * Math.PI / 180.0)) + decl_sin) / decl_cos;
            eff_daylength = bound(-1.0, eff_daylength, 1.0);
            double effective_daylength;
            effective_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(eff_daylength))) / Math.PI;
            return effective_daylength;
        }
        public static double calc_photoperiodic_daylength(double latitude, int julian_day)
        {
            double declination;
            double decl_sin;
            double decl_cos;
            calc_declinations(latitude, julian_day, out declination, out decl_sin, out decl_cos);
            double photo_daylength;
            photo_daylength = (-Math.Sin((-6.0 * Math.PI / 180.0)) + decl_sin) / decl_cos;
            photo_daylength = bound(-1.0, photo_daylength, 1.0);
            double photoperiodic_daylength;
            photoperiodic_daylength = 12.0 * (Math.PI + (2.0 * Math.Asin(photo_daylength))) / Math.PI;
            return photoperiodic_daylength;
        }
    }
}