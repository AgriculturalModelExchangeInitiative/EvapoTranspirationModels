
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

using PotentialET_Penman.DomainClass;
namespace PotentialET_Penman.Strategies
{
    public class PotentialET_PenmanComponent : IStrategyPotentialET_Penman
    {
        public PotentialET_PenmanComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'lambdaV'}, "lambdaV");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'lambdaV'}, "lambdaV");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}, "psychrometricConstant");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'psychrometricConstant'}, "psychrometricConstant");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'Alpha'}, "Alpha");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'Alpha'}, "Alpha");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'ih'}, "ih");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'specificHeatCapacityAir'}, "specificHeatCapacityAir");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'rhoDensityAir'}, "rhoDensityAir");
            _parameters0_0.Add(v9);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary);
            pd1.PropertyName = "netRadiation";
            pd1.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.netRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary);
            pd2.PropertyName = "solarRadiation";
            pd2.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.solarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.solarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary);
            pd3.PropertyName = "hslope";
            pd3.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.hslope).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.hslope);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary);
            pd4.PropertyName = "VPDair";
            pd4.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.VPDair).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.VPDair);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary);
            pd5.PropertyName = "conductance";
            pd5.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.conductance).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.conductance);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanRate);
            pd6.PropertyName = "evapoTranspirationPenman";
            pd6.PropertyType = (PotentialET_Penman.DomainClass.PotentialET_PenmanRateVarInfo.evapoTranspirationPenman).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(PotentialET_Penman.DomainClass.PotentialET_PenmanRateVarInfo.evapoTranspirationPenman);
            _outputs0_0.Add(pd6);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(PotentialET_Penman.Strategies.PriestlyTaylor).FullName);
            lAssStrat0_0.Add(typeof(PotentialET_Penman.Strategies.Penman).FullName);
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
            return new List<Type>() {  typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanState), typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanState), typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanRate), typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary), typeof(PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous)};
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
                _Penman.lambdaV = value;
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
                _Penman.psychrometricConstant = value;
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
                _Penman.Alpha = value;
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
        public double specificHeatCapacityAir
        {
            get
            {
                 return _Penman.specificHeatCapacityAir; 
            }
            set
            {
                _Penman.specificHeatCapacityAir = value;
            }
        }
        public double rhoDensityAir
        {
            get
            {
                 return _Penman.rhoDensityAir; 
            }
            set
            {
                _Penman.rhoDensityAir = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _PriestlyTaylor.SetParametersDefaultValue();
            _Penman.SetParametersDefaultValue();
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

            specificHeatCapacityAirVarInfo.Name = "specificHeatCapacityAir";
            specificHeatCapacityAirVarInfo.Description = "Specific heat capacity of dry air";
            specificHeatCapacityAirVarInfo.MaxValue = 1.0;
            specificHeatCapacityAirVarInfo.MinValue = 0.0;
            specificHeatCapacityAirVarInfo.DefaultValue = 0.00101;
            specificHeatCapacityAirVarInfo.Units = "";
            specificHeatCapacityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            rhoDensityAirVarInfo.Name = "rhoDensityAir";
            rhoDensityAirVarInfo.Description = "Density of air";
            rhoDensityAirVarInfo.MaxValue = -1D;
            rhoDensityAirVarInfo.MinValue = -1D;
            rhoDensityAirVarInfo.DefaultValue = 1.225;
            rhoDensityAirVarInfo.Units = "";
            rhoDensityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo lambdaVVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'PriestlyTaylor', 'var': 'lambdaV'}.lambdaVVarInfo;} 
        }

        public static VarInfo psychrometricConstantVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}.psychrometricConstantVarInfo;} 
        }

        public static VarInfo AlphaVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'PriestlyTaylor', 'var': 'Alpha'}.AlphaVarInfo;} 
        }

        public static VarInfo ihVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'PriestlyTaylor', 'var': 'ih'}.ihVarInfo;} 
        }

        public static VarInfo specificHeatCapacityAirVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'Penman', 'var': 'specificHeatCapacityAir'}.specificHeatCapacityAirVarInfo;} 
        }

        public static VarInfo rhoDensityAirVarInfo
        {
            get { return PotentialET_Penman.Strategies.{'modu': 'Penman', 'var': 'rhoDensityAir'}.rhoDensityAirVarInfo;} 
        }

        public string TestPostConditions(PotentialET_Penman.DomainClass.PotentialET_PenmanState s,PotentialET_Penman.DomainClass.PotentialET_PenmanState s1,PotentialET_Penman.DomainClass.PotentialET_PenmanRate r,PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary a,PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                PotentialET_Penman.DomainClass.PotentialET_PenmanRateVarInfo.evapoTranspirationPenman.CurrentValue=r.evapoTranspirationPenman;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r12 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanRateVarInfo.evapoTranspirationPenman);
                if(r12.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanRateVarInfo.evapoTranspirationPenman.ValueType)){prc.AddCondition(r12);}

                string ret = "";
                ret += _PriestlyTaylor.TestPostConditions(s, s1, r, a, ex, " strategy PotentialET_Penman.Strategies.PotentialET_Penman");
                ret += _Penman.TestPostConditions(s, s1, r, a, ex, " strategy PotentialET_Penman.Strategies.PotentialET_Penman");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .PotentialET_Penman, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(PotentialET_Penman.DomainClass.PotentialET_PenmanState s,PotentialET_Penman.DomainClass.PotentialET_PenmanState s1,PotentialET_Penman.DomainClass.PotentialET_PenmanRate r,PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary a,PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.netRadiation.CurrentValue=a.netRadiation;
                PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.solarRadiation.CurrentValue=a.solarRadiation;
                PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.hslope.CurrentValue=a.hslope;
                PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.VPDair.CurrentValue=a.VPDair;
                PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.conductance.CurrentValue=a.conductance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.netRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.netRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.solarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.solarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.hslope);
                if(r3.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.hslope.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.VPDair);
                if(r4.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.VPDair.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.conductance);
                if(r5.ApplicableVarInfoValueTypes.Contains( PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliaryVarInfo.conductance.ValueType)){prc.AddCondition(r5);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambdaV")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("psychrometricConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ih")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("specificHeatCapacityAir")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoDensityAir")));
                string ret = "";
                ret += _PriestlyTaylor.TestPreConditions(s, s1, r, a, ex, " strategy PotentialET_Penman.Strategies.PotentialET_Penman");
                ret += _Penman.TestPreConditions(s, s1, r, a, ex, " strategy PotentialET_Penman.Strategies.PotentialET_Penman");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .PotentialET_Penman, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(PotentialET_Penman.DomainClass.PotentialET_PenmanState s,PotentialET_Penman.DomainClass.PotentialET_PenmanState s1,PotentialET_Penman.DomainClass.PotentialET_PenmanRate r,PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary a,PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component PotentialET_Penman, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(PotentialET_Penman.DomainClass.PotentialET_PenmanState s,PotentialET_Penman.DomainClass.PotentialET_PenmanState s1,PotentialET_Penman.DomainClass.PotentialET_PenmanRate r,PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary a,PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
        Penman _Penman = new Penman();

        private void EstimateOfAssociatedClasses(PotentialET_Penman.DomainClass.PotentialET_PenmanState s,PotentialET_Penman.DomainClass.PotentialET_PenmanState s1,PotentialET_Penman.DomainClass.PotentialET_PenmanRate r,PotentialET_Penman.DomainClass.PotentialET_PenmanAuxiliary a,PotentialET_Penman.DomainClass.PotentialET_PenmanExogenous ex)
        {
            _priestlytaylor.Estimate(s,s1, r, a, ex);
            _penman.Estimate(s,s1, r, a, ex);
        }

        public void Init(PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex)
        {
        }

        public PotentialET_PenmanComponent(PotentialET_PenmanComponent toCopy): this() // copy constructor 
        {
                lambdaV = toCopy.lambdaV;
                psychrometricConstant = toCopy.psychrometricConstant;
                Alpha = toCopy.Alpha;
                ih = toCopy.ih;
                specificHeatCapacityAir = toCopy.specificHeatCapacityAir;
                rhoDensityAir = toCopy.rhoDensityAir;
            }
        }
    }