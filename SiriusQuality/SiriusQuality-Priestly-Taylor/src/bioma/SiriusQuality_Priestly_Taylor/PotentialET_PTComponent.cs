
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

using PotentialET_PT.DomainClass;
namespace PotentialET_PT.Strategies
{
    public class PotentialET_PTComponent : IStrategyPotentialET_PT
    {
        public PotentialET_PTComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'lambdaV'}, "lambdaV");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}, "psychrometricConstant");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'Alpha'}, "Alpha");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'ih'}, "ih");
            _parameters0_0.Add(v4);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(PotentialET_PT.DomainClass.PotentialET_PTAuxiliary);
            pd1.PropertyName = "solarRadiation";
            pd1.PropertyType = (PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.solarRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.solarRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(PotentialET_PT.DomainClass.PotentialET_PTAuxiliary);
            pd2.PropertyName = "hslope";
            pd2.PropertyType = (PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.hslope).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.hslope);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(PotentialET_PT.DomainClass.PotentialET_PTAuxiliary);
            pd3.PropertyName = "netRadiation";
            pd3.PropertyType = (PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.netRadiation);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(PotentialET_PT.DomainClass.PotentialET_PTRate);
            pd4.PropertyName = "evapoTranspirationPriestlyTaylor";
            pd4.PropertyType = (PotentialET_PT.DomainClass.PotentialET_PTRateVarInfo.evapoTranspirationPriestlyTaylor).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(PotentialET_PT.DomainClass.PotentialET_PTRateVarInfo.evapoTranspirationPriestlyTaylor);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(PotentialET_PT.Strategies.PriestlyTaylor).FullName);
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
            _pd.Add("Creator", "SQ");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRAE "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(PotentialET_PT.DomainClass.PotentialET_PTState), typeof(PotentialET_PT.DomainClass.PotentialET_PTState), typeof(PotentialET_PT.DomainClass.PotentialET_PTRate), typeof(PotentialET_PT.DomainClass.PotentialET_PTAuxiliary), typeof(PotentialET_PT.DomainClass.PotentialET_PTExogenous)};
        }

        public double lambdaV
        {
            get
            {
                 return _PriestlyTaylor.lambdaV; 
            }
            set
            {
                _PriestlyTaylor.lambdaV = value;
            }
        }
        public double psychrometricConstant
        {
            get
            {
                 return _PriestlyTaylor.psychrometricConstant; 
            }
            set
            {
                _PriestlyTaylor.psychrometricConstant = value;
            }
        }
        public double Alpha
        {
            get
            {
                 return _PriestlyTaylor.Alpha; 
            }
            set
            {
                _PriestlyTaylor.Alpha = value;
            }
        }
        public int ih
        {
            get
            {
                 return _PriestlyTaylor.ih; 
            }
            set
            {
                _PriestlyTaylor.ih = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _PriestlyTaylor.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            lambdaVVarInfo.Name = "lambdaV";
            lambdaVVarInfo.Description = "latent heat of vaporization of water";
            lambdaVVarInfo.MaxValue = 10.0;
            lambdaVVarInfo.MinValue = 0.0;
            lambdaVVarInfo.DefaultValue = 2.454;
            lambdaVVarInfo.Units = "MJ kg-1";
            lambdaVVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            psychrometricConstantVarInfo.Name = "psychrometricConstant";
            psychrometricConstantVarInfo.Description = "psychrometric constant";
            psychrometricConstantVarInfo.MaxValue = 1.0;
            psychrometricConstantVarInfo.MinValue = 0.0;
            psychrometricConstantVarInfo.DefaultValue = 0.66;
            psychrometricConstantVarInfo.Units = "";
            psychrometricConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            AlphaVarInfo.Name = "Alpha";
            AlphaVarInfo.Description = "Priestley-Taylor evapotranspiration proportionality constant";
            AlphaVarInfo.MaxValue = 100.0;
            AlphaVarInfo.MinValue = 0.0;
            AlphaVarInfo.DefaultValue = 1.5;
            AlphaVarInfo.Units = "";
            AlphaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            ihVarInfo.Name = "ih";
            ihVarInfo.Description = "hour of the day if the component is hourly, -999 if the component is daily";
            ihVarInfo.MaxValue = 24;
            ihVarInfo.MinValue = -999;
            ihVarInfo.DefaultValue = -999;
            ihVarInfo.Units = "";
            ihVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        public static VarInfo lambdaVVarInfo
        {
            get { return PotentialET_PT.Strategies.{'modu': 'PriestlyTaylor', 'var': 'lambdaV'}.lambdaVVarInfo;} 
        }

        public static VarInfo psychrometricConstantVarInfo
        {
            get { return PotentialET_PT.Strategies.{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}.psychrometricConstantVarInfo;} 
        }

        public static VarInfo AlphaVarInfo
        {
            get { return PotentialET_PT.Strategies.{'modu': 'PriestlyTaylor', 'var': 'Alpha'}.AlphaVarInfo;} 
        }

        public static VarInfo ihVarInfo
        {
            get { return PotentialET_PT.Strategies.{'modu': 'PriestlyTaylor', 'var': 'ih'}.ihVarInfo;} 
        }

        public string TestPostConditions(PotentialET_PT.DomainClass.PotentialET_PTState s,PotentialET_PT.DomainClass.PotentialET_PTState s1,PotentialET_PT.DomainClass.PotentialET_PTRate r,PotentialET_PT.DomainClass.PotentialET_PTAuxiliary a,PotentialET_PT.DomainClass.PotentialET_PTExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                PotentialET_PT.DomainClass.PotentialET_PTRateVarInfo.evapoTranspirationPriestlyTaylor.CurrentValue=r.evapoTranspirationPriestlyTaylor;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r8 = new RangeBasedCondition(PotentialET_PT.DomainClass.PotentialET_PTRateVarInfo.evapoTranspirationPriestlyTaylor);
                if(r8.ApplicableVarInfoValueTypes.Contains( PotentialET_PT.DomainClass.PotentialET_PTRateVarInfo.evapoTranspirationPriestlyTaylor.ValueType)){prc.AddCondition(r8);}

                string ret = "";
                ret += _PriestlyTaylor.TestPostConditions(s, s1, r, a, ex, " strategy PotentialET_PT.Strategies.PotentialET_PT");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .PotentialET_PT, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(PotentialET_PT.DomainClass.PotentialET_PTState s,PotentialET_PT.DomainClass.PotentialET_PTState s1,PotentialET_PT.DomainClass.PotentialET_PTRate r,PotentialET_PT.DomainClass.PotentialET_PTAuxiliary a,PotentialET_PT.DomainClass.PotentialET_PTExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.solarRadiation.CurrentValue=a.solarRadiation;
                PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.hslope.CurrentValue=a.hslope;
                PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.netRadiation.CurrentValue=a.netRadiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.solarRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.solarRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.hslope);
                if(r2.ApplicableVarInfoValueTypes.Contains( PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.hslope.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.netRadiation);
                if(r3.ApplicableVarInfoValueTypes.Contains( PotentialET_PT.DomainClass.PotentialET_PTAuxiliaryVarInfo.netRadiation.ValueType)){prc.AddCondition(r3);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambdaV")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("psychrometricConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ih")));
                string ret = "";
                ret += _PriestlyTaylor.TestPreConditions(s, s1, r, a, ex, " strategy PotentialET_PT.Strategies.PotentialET_PT");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .PotentialET_PT, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(PotentialET_PT.DomainClass.PotentialET_PTState s,PotentialET_PT.DomainClass.PotentialET_PTState s1,PotentialET_PT.DomainClass.PotentialET_PTRate r,PotentialET_PT.DomainClass.PotentialET_PTAuxiliary a,PotentialET_PT.DomainClass.PotentialET_PTExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component PotentialET_PT, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(PotentialET_PT.DomainClass.PotentialET_PTState s,PotentialET_PT.DomainClass.PotentialET_PTState s1,PotentialET_PT.DomainClass.PotentialET_PTRate r,PotentialET_PT.DomainClass.PotentialET_PTAuxiliary a,PotentialET_PT.DomainClass.PotentialET_PTExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();

        private void EstimateOfAssociatedClasses(PotentialET_PT.DomainClass.PotentialET_PTState s,PotentialET_PT.DomainClass.PotentialET_PTState s1,PotentialET_PT.DomainClass.PotentialET_PTRate r,PotentialET_PT.DomainClass.PotentialET_PTAuxiliary a,PotentialET_PT.DomainClass.PotentialET_PTExogenous ex)
        {
            _priestlytaylor.Estimate(s,s1, r, a, ex);
        }

        public void Init(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex)
        {
        }

        public PotentialET_PTComponent(PotentialET_PTComponent toCopy): this() // copy constructor 
        {
                lambdaV = toCopy.lambdaV;
                psychrometricConstant = toCopy.psychrometricConstant;
                Alpha = toCopy.Alpha;
                ih = toCopy.ih;
            }
        }
    }