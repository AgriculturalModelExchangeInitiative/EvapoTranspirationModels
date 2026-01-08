
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
    public class ReferenceETPriestleyTaylor_Component : IStrategySiriusQualityReferenceETPriestleyTaylor_
    {
        public ReferenceETPriestleyTaylor_Component()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'ReferenceETPriestleyTaylor', 'var': 'cAlphaPT'}, "cAlphaPT");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'ReferenceETPriestleyTaylor', 'var': 'cAltitude'}, "cAltitude");
            _parameters0_0.Add(v2);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd1.PropertyName = "iTMin";
            pd1.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd2.PropertyName = "iNetRadiation";
            pd2.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous);
            pd3.PropertyName = "iTMax";
            pd3.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary);
            pd4.PropertyName = "ReferenceCropEvapotranspiration";
            pd4.PropertyType = (SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualityReferenceETPriestleyTaylor_.Strategies.ReferenceETPriestleyTaylor).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
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
            return new List<Type>() {  typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary), typeof(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous)};
        }

        public double cAlphaPT
        {
            get
            {
                 return _ReferenceETPriestleyTaylor.cAlphaPT; 
            }
            set
            {
                _ReferenceETPriestleyTaylor.cAlphaPT = value;
            }
        }
        public double cAltitude
        {
            get
            {
                 return _ReferenceETPriestleyTaylor.cAltitude; 
            }
            set
            {
                _ReferenceETPriestleyTaylor.cAltitude = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _ReferenceETPriestleyTaylor.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            cAlphaPTVarInfo.Name = "cAlphaPT";
            cAlphaPTVarInfo.Description = "Priestley-Taylor coefficient";
            cAlphaPTVarInfo.MaxValue = -1D;
            cAlphaPTVarInfo.MinValue = 0.0;
            cAlphaPTVarInfo.DefaultValue = 1.26;
            cAlphaPTVarInfo.Units = "http://www.wurvoc.org/vocabularies/om-1.8/one";
            cAlphaPTVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            cAltitudeVarInfo.Name = "cAltitude";
            cAltitudeVarInfo.Description = "altitude";
            cAltitudeVarInfo.MaxValue = -1D;
            cAltitudeVarInfo.MinValue = -1D;
            cAltitudeVarInfo.DefaultValue = 0.0;
            cAltitudeVarInfo.Units = "http://www.wurvoc.org/vocabularies/om-1.8/metre";
            cAltitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo cAlphaPTVarInfo
        {
            get { return SiriusQualityReferenceETPriestleyTaylor_.Strategies.{'modu': 'ReferenceETPriestleyTaylor', 'var': 'cAlphaPT'}.cAlphaPTVarInfo;} 
        }

        public static VarInfo cAltitudeVarInfo
        {
            get { return SiriusQualityReferenceETPriestleyTaylor_.Strategies.{'modu': 'ReferenceETPriestleyTaylor', 'var': 'cAltitude'}.cAltitudeVarInfo;} 
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

                string ret = "";
                ret += _ReferenceETPriestleyTaylor.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityReferenceETPriestleyTaylor_.Strategies.ReferenceETPriestleyTaylor_");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.ReferenceETPriestleyTaylor_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin.CurrentValue=ex.iTMin;
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation.CurrentValue=ex.iNetRadiation;
                SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax.CurrentValue=ex.iTMax;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMin.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iNetRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_ExogenousVarInfo.iTMax.ValueType)){prc.AddCondition(r3);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAlphaPT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAltitude")));
                string ret = "";
                ret += _ReferenceETPriestleyTaylor.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityReferenceETPriestleyTaylor_.Strategies.ReferenceETPriestleyTaylor_");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.ReferenceETPriestleyTaylor_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        ReferenceETPriestleyTaylor _ReferenceETPriestleyTaylor = new ReferenceETPriestleyTaylor();

        private void EstimateOfAssociatedClasses(SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_State s1,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Rate r,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Auxiliary a,SiriusQualityReferenceETPriestleyTaylor_.DomainClass.ReferenceETPriestleyTaylor_Exogenous ex)
        {
            _ReferenceETPriestleyTaylor.Estimate(s,s1, r, a, ex);
        }

        public ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component toCopy): this() // copy constructor 
        {
                cAlphaPT = toCopy.cAlphaPT;
                cAltitude = toCopy.cAltitude;
            }
        }
    }