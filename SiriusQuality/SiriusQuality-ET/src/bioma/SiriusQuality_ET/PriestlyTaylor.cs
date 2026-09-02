
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
using EnergyBalanceComposite.DomainClass;
namespace EnergyBalanceComposite.Strategies
{
    public class PriestlyTaylor : IStrategyEnergyBalanceComposite
    {
        public PriestlyTaylor()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.66;
            v1.Description = "psychrometric constant";
            v1.Id = 0;
            v1.MaxValue = 1;
            v1.MinValue = 0;
            v1.Name = "psychrometricConstant";
            v1.Size = 1;
            v1.Units = "";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 1.5;
            v2.Description = "Priestley-Taylor evapotranspiration proportionality constant";
            v2.Id = 0;
            v2.MaxValue = 100;
            v2.MinValue = 0;
            v2.Name = "Alpha";
            v2.Size = 1;
            v2.Units = "";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 999;
            v3.Description = "hour of the day if the component is hourly, -999 if the component is daily";
            v3.Id = 0;
            v3.MaxValue = 24;
            v3.MinValue = 999;
            v3.Name = "ih";
            v3.Size = 1;
            v3.Units = "";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v3);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd1.PropertyName = "netRadiationEquivalentEvaporation";
            pd1.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiationEquivalentEvaporation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiationEquivalentEvaporation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd2.PropertyName = "solarRadiation";
            pd2.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd3.PropertyName = "hslope";
            pd3.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate);
            pd4.PropertyName = "evapoTranspirationPriestlyTaylor";
            pd4.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
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
            get { return "Calculate Energy Balance" ;}
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
            _pd.Add("Creator", "Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "New Zealand Institute for Crop and Food Research Ltd., New Zealand Institute for Crop and Food Research Ltd., New Zealand Institute for Crop and Food Research Ltd., New Zealand Institute for Crop and Food Research Ltd. "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState),  typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double psychrometricConstant
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("psychrometricConstant");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'psychrometricConstant' not found (or found null) in strategy 'PriestlyTaylor'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("psychrometricConstant");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'psychrometricConstant' not found in strategy 'PriestlyTaylor'");
            }
        }
        public double Alpha
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Alpha");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'Alpha' not found (or found null) in strategy 'PriestlyTaylor'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Alpha");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Alpha' not found in strategy 'PriestlyTaylor'");
            }
        }
        public int ih
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("ih");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'ih' not found (or found null) in strategy 'PriestlyTaylor'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ih");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'ih' not found in strategy 'PriestlyTaylor'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            psychrometricConstantVarInfo.Name = "psychrometricConstant";
            psychrometricConstantVarInfo.Description = "psychrometric constant";
            psychrometricConstantVarInfo.MaxValue = 1;
            psychrometricConstantVarInfo.MinValue = 0;
            psychrometricConstantVarInfo.DefaultValue = 0.66;
            psychrometricConstantVarInfo.Units = "";
            psychrometricConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            AlphaVarInfo.Name = "Alpha";
            AlphaVarInfo.Description = "Priestley-Taylor evapotranspiration proportionality constant";
            AlphaVarInfo.MaxValue = 100;
            AlphaVarInfo.MinValue = 0;
            AlphaVarInfo.DefaultValue = 1.5;
            AlphaVarInfo.Units = "";
            AlphaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            ihVarInfo.Name = "ih";
            ihVarInfo.Description = "hour of the day if the component is hourly, -999 if the component is daily";
            ihVarInfo.MaxValue = 24;
            ihVarInfo.MinValue = 999;
            ihVarInfo.DefaultValue = 999;
            ihVarInfo.Units = "";
            ihVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        private static VarInfo _psychrometricConstantVarInfo = new VarInfo();
        public static VarInfo psychrometricConstantVarInfo
        {
            get { return _psychrometricConstantVarInfo;} 
        }

        private static VarInfo _AlphaVarInfo = new VarInfo();
        public static VarInfo AlphaVarInfo
        {
            get { return _AlphaVarInfo;} 
        }

        private static VarInfo _ihVarInfo = new VarInfo();
        public static VarInfo ihVarInfo
        {
            get { return _ihVarInfo;} 
        }

        public string TestPostConditions(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.CurrentValue=r.evapoTranspirationPriestlyTaylor;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r7 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
                if(r7.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.ValueType)){prc.AddCondition(r7);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".EnergyBalanceComposite, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiationEquivalentEvaporation.CurrentValue=a.netRadiationEquivalentEvaporation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation.CurrentValue=a.solarRadiation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.CurrentValue=a.hslope;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiationEquivalentEvaporation);
                if(r1.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiationEquivalentEvaporation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
                if(r3.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("psychrometricConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ih")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".EnergyBalanceComposite, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component EnergyBalanceComposite, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s, EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1, EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r, EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a, EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex)
        {
            double netRadiationEquivalentEvaporation = a.netRadiationEquivalentEvaporation;
            double solarRadiation = a.solarRadiation;
            double hslope = a.hslope;
            double evapoTranspirationPriestlyTaylor;
            double a_G_Rn;
            a_G_Rn = 1.00;
            if (ih != -999)
            {
                if (solarRadiation < 0.001)
                {
                    a_G_Rn = 0.50;
                }
                else
                {
                    a_G_Rn = 0.90;
                }
            }
            evapoTranspirationPriestlyTaylor = Math.Max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00);
            r.evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor;
        }
    }
}