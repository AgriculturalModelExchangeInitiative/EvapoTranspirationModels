
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
using SiriusQualityReferenceETPriestleyTaylor_.DomainClass;
namespace SiriusQualityReferenceETPriestleyTaylor_.Strategies
{
    public class ReferenceETPriestleyTaylor : IStrategySiriusQualityReferenceETPriestleyTaylor_
    {
        public ReferenceETPriestleyTaylor()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.0;
            v1.Description = "altitude";
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
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 1.26;
            v2.Description = "Priestley-Taylor coefficient";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = 0.0;
            v2.Name = "cAlphaPT";
            v2.Size = 1;
            v2.Units = "http://www.wurvoc.org/vocabularies/om-1.8/one";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd1.PropertyName = "iTMax";
            pd1.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd2.PropertyName = "iTMin";
            pd2.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd3.PropertyName = "iNetRadiation";
            pd3.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary);
            pd4.PropertyName = "ReferenceCropEvapotranspiration";
            pd4.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
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
            return new List<Type>() {  typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State),  typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double cAltitude
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("cAltitude");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'cAltitude' not found (or found null) in strategy 'ReferenceETPriestleyTaylor'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("cAltitude");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'cAltitude' not found in strategy 'ReferenceETPriestleyTaylor'");
            }
        }
        public double cAlphaPT
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("cAlphaPT");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'cAlphaPT' not found (or found null) in strategy 'ReferenceETPriestleyTaylor'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("cAlphaPT");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'cAlphaPT' not found in strategy 'ReferenceETPriestleyTaylor'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            cAltitudeVarInfo.Name = "cAltitude";
            cAltitudeVarInfo.Description = "altitude";
            cAltitudeVarInfo.MaxValue = -1D;
            cAltitudeVarInfo.MinValue = -1D;
            cAltitudeVarInfo.DefaultValue = 0.0;
            cAltitudeVarInfo.Units = "http://www.wurvoc.org/vocabularies/om-1.8/metre";
            cAltitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            cAlphaPTVarInfo.Name = "cAlphaPT";
            cAlphaPTVarInfo.Description = "Priestley-Taylor coefficient";
            cAlphaPTVarInfo.MaxValue = -1D;
            cAlphaPTVarInfo.MinValue = 0.0;
            cAlphaPTVarInfo.DefaultValue = 1.26;
            cAlphaPTVarInfo.Units = "http://www.wurvoc.org/vocabularies/om-1.8/one";
            cAlphaPTVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _cAltitudeVarInfo = new VarInfo();
        public static VarInfo cAltitudeVarInfo
        {
            get { return _cAltitudeVarInfo;} 
        }

        private static VarInfo _cAlphaPTVarInfo = new VarInfo();
        public static VarInfo cAlphaPTVarInfo
        {
            get { return _cAlphaPTVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.CurrentValue=a.ReferenceCropEvapotranspiration;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.ValueType)){prc.AddCondition(r6);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ReferenceETPriestleyTaylor_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax.CurrentValue=ex.iTMax;
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin.CurrentValue=ex.iTMin;
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation.CurrentValue=ex.iNetRadiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAltitude")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAlphaPT")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ReferenceETPriestleyTaylor_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityReferenceETPriestleyTaylor_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private double _cAltitude;
        public double cAltitude
    {
        get { return this._cAltitude; }
        set { this._cAltitude= value; } 
    }
        private double _cAlphaPT;
        public double cAlphaPT
    {
        get { return this._cAlphaPT; }
        set { this._cAlphaPT= value; } 
    }
    /// <summary>
    /// Constructor of the ReferenceETPriestleyTaylor component")
    /// </summary>  
    public ReferenceETPriestleyTaylor() { }
    
        public void  CalculateModel(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex)
        {
            //- Name: ReferenceETPriestleyTaylor -Version: 001, -Time step: 1
            //- Description:
    //            * Title: ReferenceETPriestleyTaylor model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
            //- inputs:
    //            * name: cAltitude
    //                          ** description : altitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: cAlphaPT
    //                          ** description : Priestley-Taylor coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 1.26
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
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
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
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
            double iNetRadiation = ex.iNetRadiation;
            double ReferenceCropEvapotranspiration;
            double lambdav;
            double T;
            double Delta;
            double AtmPres;
            double Gamma;
            double G;
            lambdav = 2.45;
            T = (iTMax + iTMin) / 2.0;
            Delta = SlopeOfSaturationVapPressureCurve(T);
            AtmPres = AtmosphericPressure(cAltitude);
            Gamma = PsychrometricConstant(AtmPres);
            G = 0.0;
            ReferenceCropEvapotranspiration = Math.Max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav);
            a.ReferenceCropEvapotranspiration= ReferenceCropEvapotranspiration;
        }
        public static double SlopeOfSaturationVapPressureCurve(double T)
        {
            double tempT;
            tempT = T + 237.3;
            return 4098 * (0.6108 * Math.Exp(17.27 * T / tempT)) / Math.Pow(tempT, 2);
        }
        public static double AtmosphericPressure(double z)
        {
            return 101.3 * Math.Pow((293 - (0.0065 * z)) / 293, 5.26);
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
    }
}