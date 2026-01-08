
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
using SiriusQualityReferenceETPM_.DomainClass;
namespace SiriusQualityReferenceETPM_.Strategies
{
    public class ReferenceETPM : IStrategySiriusQualityReferenceETPM_
    {
        public ReferenceETPM()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.0;
            v1.Description = "elevation above sea level";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "cAltitude";
            v1.Size = 1;
            v1.Units = "http://www.wurvoc.org/vocabularies/om-1.8/metre";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd1.PropertyName = "iTMax";
            pd1.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd2.PropertyName = "iTMin";
            pd2.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd3.PropertyName = "iActualVapourPressure";
            pd3.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd4.PropertyName = "iNetRadiation";
            pd4.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd5.PropertyName = "iWindspeed";
            pd5.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary);
            pd6.PropertyName = "ReferenceCropEvapotranspiration";
            pd6.PropertyType = (SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
            _outputs0_0.Add(pd6);
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
            get { return "as given in the documentation" ;}
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
            _pd.Add("Creator", "Gunther Krauss");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRES Pflanzenbau, Uni Bonn "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State),  typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State), typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Rate), typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary), typeof(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double cAltitude
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("cAltitude");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'cAltitude' not found (or found null) in strategy 'ReferenceETPM'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("cAltitude");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'cAltitude' not found in strategy 'ReferenceETPM'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            cAltitudeVarInfo.Name = "cAltitude";
            cAltitudeVarInfo.Description = "elevation above sea level";
            cAltitudeVarInfo.MaxValue = -1D;
            cAltitudeVarInfo.MinValue = -1D;
            cAltitudeVarInfo.DefaultValue = 0.0;
            cAltitudeVarInfo.Units = "http://www.wurvoc.org/vocabularies/om-1.8/metre";
            cAltitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _cAltitudeVarInfo = new VarInfo();
        public static VarInfo cAltitudeVarInfo
        {
            get { return _cAltitudeVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s1,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Rate r,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.CurrentValue=a.ReferenceCropEvapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.ValueType)){prc.AddCondition(r7);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ReferenceETPM_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s1,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Rate r,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax.CurrentValue=ex.iTMax;
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin.CurrentValue=ex.iTMin;
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure.CurrentValue=ex.iActualVapourPressure;
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation.CurrentValue=ex.iNetRadiation;
                SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed.CurrentValue=ex.iWindspeed;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed.ValueType)){prc.AddCondition(r5);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAltitude")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ReferenceETPM_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_State s1,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Rate r,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,SiriusQualityReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityReferenceETPM_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private double _cAltitude;
        public double cAltitude
    {
        get { return this._cAltitude; }
        set { this._cAltitude= value; } 
    }
    /// <summary>
    /// Constructor of the ReferenceETPM component")
    /// </summary>  
    public ReferenceETPM() { }
    
        public void  CalculateModel(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
        {
            //- Name: ReferenceETPM -Version: 001, -Time step: 1
            //- Description:
    //            * Title: ReferenceETPM model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
            //- inputs:
    //            * name: cAltitude
    //                          ** description : elevation above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: iTMax
    //                          ** description : maximum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iTMin
    //                          ** description : minimum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iActualVapourPressure
    //                          ** description : actual vapour pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    //            * name: iWindspeed
    //                          ** description : wind speed at 2m height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
            //- outputs:
    //            * name: ReferenceCropEvapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
            double iTMax = ex.iTMax;
            double iTMin = ex.iTMin;
            double iActualVapourPressure = ex.iActualVapourPressure;
            double iNetRadiation = ex.iNetRadiation;
            double iWindspeed = ex.iWindspeed;
            double ReferenceCropEvapotranspiration;
            double T;
            double e_s;
            T = (iTMax + iTMin) / 2;
            e_s = MeanSaturatedVapourPressure(iTMax, iTMin);
            if (iActualVapourPressure > e_s)
            {
                iActualVapourPressure = e_s;
            }
            ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude);
            a.ReferenceCropEvapotranspiration= ReferenceCropEvapotranspiration;
        }
        public static double SaturationVapourPressureAtTemperature(double T)
        {
            return 0.6108 * Math.Exp(17.27 * T / (T + 237.3));
        }
        public static double MeanSaturatedVapourPressure(double T_max, double T_min)
        {
            return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2;
        }
        public static double SlopeOfSaturationVapPressureCurve(double T)
        {
            double tempT;
            tempT = T + 237.3;
            return 4098 * (0.6108 * Math.Exp(17.27 * T / tempT)) / Math.Pow(tempT, 2);
        }
        public static double PsychrometricConstant(double P)
        {
            double lambdav;
            double c_p;
            double epsilon;
            double factor;
            lambdav = 2.45;
            c_p = 1.0130E-3;
            epsilon = 0.622;
            factor = Math.Round(c_p / (epsilon * lambdav) * 100E6) / 100E6;
            return factor * P;
        }
        public static double AtmosphericPressure(double z)
        {
            return 101.3 * Math.Pow((293 - (0.0065 * z)) / 293, 5.26);
        }
        public static double ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z)
        {
            double P;
            double gamma;
            double Delta;
            double G;
            double ET0;
            P = AtmosphericPressure(z);
            gamma = PsychrometricConstant(P);
            Delta = SlopeOfSaturationVapPressureCurve(T);
            G = (double)(0);
            ET0 = (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))));
            return ET0;
        }
    }
}