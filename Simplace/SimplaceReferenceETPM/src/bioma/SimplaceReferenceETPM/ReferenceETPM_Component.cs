
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

using ReferenceETPM_.DomainClass;
namespace ReferenceETPM_.Strategies
{
    public class ReferenceETPM_Component : IStrategyReferenceETPM_
    {
        public ReferenceETPM_Component()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'ReferenceETPM', 'var': 'cAltitude'}, "cAltitude");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd1.PropertyName = "iNetRadiation";
            pd1.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd2.PropertyName = "iActualVapourPressure";
            pd2.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd3.PropertyName = "iTMax";
            pd3.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd4.PropertyName = "iTMin";
            pd4.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous);
            pd5.PropertyName = "iWindspeed";
            pd5.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary);
            pd6.PropertyName = "ReferenceCropEvapotranspiration";
            pd6.PropertyType = (ReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(ReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
            _outputs0_0.Add(pd6);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(ReferenceETPM_.Strategies.ReferenceETPM).FullName);
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
            return new List<Type>() {  typeof(ReferenceETPM_.DomainClass.ReferenceETPM_State), typeof(ReferenceETPM_.DomainClass.ReferenceETPM_State), typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Rate), typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary), typeof(ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous)};
        }

        public double cAltitude
        {
            get
            {
                 return _ReferenceETPM.cAltitude; 
            }
            set
            {
                _ReferenceETPM.cAltitude = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _ReferenceETPM.SetParametersDefaultValue();
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

        public static VarInfo cAltitudeVarInfo
        {
            get { return ReferenceETPM_.Strategies.{'modu': 'ReferenceETPM', 'var': 'cAltitude'}.cAltitudeVarInfo;} 
        }

        public string TestPostConditions(ReferenceETPM_.DomainClass.ReferenceETPM_State s,ReferenceETPM_.DomainClass.ReferenceETPM_State s1,ReferenceETPM_.DomainClass.ReferenceETPM_Rate r,ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.CurrentValue=a.ReferenceCropEvapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r7 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
                if(r7.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.ValueType)){prc.AddCondition(r7);}

                string ret = "";
                ret += _ReferenceETPM.TestPostConditions(s, s1, r, a, ex, " strategy ReferenceETPM_.Strategies.ReferenceETPM_");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .ReferenceETPM_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(ReferenceETPM_.DomainClass.ReferenceETPM_State s,ReferenceETPM_.DomainClass.ReferenceETPM_State s1,ReferenceETPM_.DomainClass.ReferenceETPM_Rate r,ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation.CurrentValue=ex.iNetRadiation;
                ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure.CurrentValue=ex.iActualVapourPressure;
                ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax.CurrentValue=ex.iTMax;
                ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin.CurrentValue=ex.iTMin;
                ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed.CurrentValue=ex.iWindspeed;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iNetRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure);
                if(r2.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iActualVapourPressure.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax);
                if(r3.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMax.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin);
                if(r4.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iTMin.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed);
                if(r5.ApplicableVarInfoValueTypes.Contains( ReferenceETPM_.DomainClass.ReferenceETPM_ExogenousVarInfo.iWindspeed.ValueType)){prc.AddCondition(r5);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cAltitude")));
                string ret = "";
                ret += _ReferenceETPM.TestPreConditions(s, s1, r, a, ex, " strategy ReferenceETPM_.Strategies.ReferenceETPM_");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .ReferenceETPM_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(ReferenceETPM_.DomainClass.ReferenceETPM_State s,ReferenceETPM_.DomainClass.ReferenceETPM_State s1,ReferenceETPM_.DomainClass.ReferenceETPM_Rate r,ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component ReferenceETPM_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(ReferenceETPM_.DomainClass.ReferenceETPM_State s,ReferenceETPM_.DomainClass.ReferenceETPM_State s1,ReferenceETPM_.DomainClass.ReferenceETPM_Rate r,ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        ReferenceETPM _ReferenceETPM = new ReferenceETPM();

        private void EstimateOfAssociatedClasses(ReferenceETPM_.DomainClass.ReferenceETPM_State s,ReferenceETPM_.DomainClass.ReferenceETPM_State s1,ReferenceETPM_.DomainClass.ReferenceETPM_Rate r,ReferenceETPM_.DomainClass.ReferenceETPM_Auxiliary a,ReferenceETPM_.DomainClass.ReferenceETPM_Exogenous ex)
        {
            _referenceetpm.Estimate(s,s1, r, a, ex);
        }

        public void Init(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
        {
        }

        public ReferenceETPM_Component(ReferenceETPM_Component toCopy): this() // copy constructor 
        {
                cAltitude = toCopy.cAltitude;
            }
        }
    }