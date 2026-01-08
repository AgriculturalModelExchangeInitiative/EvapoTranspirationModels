
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

using ReferenceETHargreaves_.DomainClass;
namespace ReferenceETHargreaves_.Strategies
{
    public class ReferenceETHargreaves_Component : IStrategyReferenceETHargreaves_
    {
        public ReferenceETHargreaves_Component()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'ReferenceETHargreaves', 'var': 'cConvertLeByTemp'}, "cConvertLeByTemp");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous);
            pd1.PropertyName = "iTMax";
            pd1.PropertyType = (ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMax).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMax);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous);
            pd2.PropertyName = "iSolarRadiation";
            pd2.PropertyType = (ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iSolarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iSolarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous);
            pd3.PropertyName = "iTMin";
            pd3.PropertyType = (ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMin).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMin);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary);
            pd4.PropertyName = "ReferenceCropEvapotranspiration";
            pd4.PropertyType = (ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_AuxiliaryVarInfo.ReferenceCropEvapotranspiration).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(ReferenceETHargreaves_.Strategies.ReferenceETHargreaves).FullName);
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
            return new List<Type>() {  typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State), typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State), typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate), typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary), typeof(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous)};
        }

        public bool cConvertLeByTemp
        {
            get
            {
                 return _ReferenceETHargreaves.cConvertLeByTemp; 
            }
            set
            {
                _ReferenceETHargreaves.cConvertLeByTemp = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _ReferenceETHargreaves.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            cConvertLeByTempVarInfo.Name = "cConvertLeByTemp";
            cConvertLeByTempVarInfo.Description = "Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.";
            cConvertLeByTempVarInfo.MaxValue = -1D;
            cConvertLeByTempVarInfo.MinValue = -1D;
            cConvertLeByTempVarInfo.DefaultValue = -1D;
            cConvertLeByTempVarInfo.Units = "";
            cConvertLeByTempVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");
        }

        public static VarInfo cConvertLeByTempVarInfo
        {
            get { return ReferenceETHargreaves_.Strategies.{'modu': 'ReferenceETHargreaves', 'var': 'cConvertLeByTemp'}.cConvertLeByTempVarInfo;} 
        }

        public string TestPostConditions(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s1,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate r,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.CurrentValue=a.ReferenceCropEvapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r5 = new RangeBasedCondition(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_AuxiliaryVarInfo.ReferenceCropEvapotranspiration);
                if(r5.ApplicableVarInfoValueTypes.Contains( ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_AuxiliaryVarInfo.ReferenceCropEvapotranspiration.ValueType)){prc.AddCondition(r5);}

                string ret = "";
                ret += _ReferenceETHargreaves.TestPostConditions(s, s1, r, a, ex, " strategy ReferenceETHargreaves_.Strategies.ReferenceETHargreaves_");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .ReferenceETHargreaves_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s1,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate r,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMax.CurrentValue=ex.iTMax;
                ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iSolarRadiation.CurrentValue=ex.iSolarRadiation;
                ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMin.CurrentValue=ex.iTMin;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMax);
                if(r1.ApplicableVarInfoValueTypes.Contains( ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMax.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iSolarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iSolarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMin);
                if(r3.ApplicableVarInfoValueTypes.Contains( ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_ExogenousVarInfo.iTMin.ValueType)){prc.AddCondition(r3);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("cConvertLeByTemp")));
                string ret = "";
                ret += _ReferenceETHargreaves.TestPreConditions(s, s1, r, a, ex, " strategy ReferenceETHargreaves_.Strategies.ReferenceETHargreaves_");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .ReferenceETHargreaves_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s1,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate r,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component ReferenceETHargreaves_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s1,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate r,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        ReferenceETHargreaves _ReferenceETHargreaves = new ReferenceETHargreaves();

        private void EstimateOfAssociatedClasses(ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_State s1,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Rate r,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_.DomainClass.ReferenceETHargreaves_Exogenous ex)
        {
            _referenceethargreaves.Estimate(s,s1, r, a, ex);
        }

        public void Init(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex)
        {
        }

        public ReferenceETHargreaves_Component(ReferenceETHargreaves_Component toCopy): this() // copy constructor 
        {
                cConvertLeByTemp = toCopy.cConvertLeByTemp;
            }
        }
    }