
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
    public class Penman : IStrategyEnergyBalanceComposite
    {
        public Penman()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.00101;
            v1.Description = "Specific heat capacity of dry air";
            v1.Id = 0;
            v1.MaxValue = 1;
            v1.MinValue = 0;
            v1.Name = "specificHeatCapacityAir";
            v1.Size = 1;
            v1.Units = "";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.66;
            v2.Description = "psychrometric constant";
            v2.Id = 0;
            v2.MaxValue = 1;
            v2.MinValue = 0;
            v2.Name = "psychrometricConstant";
            v2.Size = 1;
            v2.Units = "";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 1.225;
            v3.Description = "Density of air";
            v3.Id = 0;
            v3.MaxValue = None;
            v3.MinValue = None;
            v3.Name = "rhoDensityAir";
            v3.Size = 1;
            v3.Units = "";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = 1.5;
            v4.Description = "Priestley-Taylor evapotranspiration proportionality constant";
            v4.Id = 0;
            v4.MaxValue = 100;
            v4.MinValue = 0;
            v4.Name = "Alpha";
            v4.Size = 1;
            v4.Units = "";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = 2.454;
            v5.Description = "latent heat of vaporization of water";
            v5.Id = 0;
            v5.MaxValue = 10;
            v5.MinValue = 0;
            v5.Name = "lambdaV";
            v5.Size = 1;
            v5.Units = "";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v5);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd1.PropertyName = "VPDair";
            pd1.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate);
            pd2.PropertyName = "evapoTranspirationPriestlyTaylor";
            pd2.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd3.PropertyName = "hslope";
            pd3.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState);
            pd4.PropertyName = "conductance";
            pd4.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate);
            pd5.PropertyName = "evapoTranspirationPenman";
            pd5.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman);
            _outputs0_0.Add(pd5);
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
            get { return "It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data" ;}
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

        public double specificHeatCapacityAir
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("specificHeatCapacityAir");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'specificHeatCapacityAir' not found (or found null) in strategy 'Penman'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("specificHeatCapacityAir");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'specificHeatCapacityAir' not found in strategy 'Penman'");
            }
        }
        public double psychrometricConstant
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("psychrometricConstant");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'psychrometricConstant' not found (or found null) in strategy 'Penman'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("psychrometricConstant");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'psychrometricConstant' not found in strategy 'Penman'");
            }
        }
        public double rhoDensityAir
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("rhoDensityAir");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'rhoDensityAir' not found (or found null) in strategy 'Penman'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("rhoDensityAir");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'rhoDensityAir' not found in strategy 'Penman'");
            }
        }
        public double Alpha
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Alpha");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'Alpha' not found (or found null) in strategy 'Penman'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Alpha");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Alpha' not found in strategy 'Penman'");
            }
        }
        public double lambdaV
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("lambdaV");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'lambdaV' not found (or found null) in strategy 'Penman'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("lambdaV");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'lambdaV' not found in strategy 'Penman'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            specificHeatCapacityAirVarInfo.Name = "specificHeatCapacityAir";
            specificHeatCapacityAirVarInfo.Description = "Specific heat capacity of dry air";
            specificHeatCapacityAirVarInfo.MaxValue = 1;
            specificHeatCapacityAirVarInfo.MinValue = 0;
            specificHeatCapacityAirVarInfo.DefaultValue = 0.00101;
            specificHeatCapacityAirVarInfo.Units = "";
            specificHeatCapacityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            psychrometricConstantVarInfo.Name = "psychrometricConstant";
            psychrometricConstantVarInfo.Description = "psychrometric constant";
            psychrometricConstantVarInfo.MaxValue = 1;
            psychrometricConstantVarInfo.MinValue = 0;
            psychrometricConstantVarInfo.DefaultValue = 0.66;
            psychrometricConstantVarInfo.Units = "";
            psychrometricConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            rhoDensityAirVarInfo.Name = "rhoDensityAir";
            rhoDensityAirVarInfo.Description = "Density of air";
            rhoDensityAirVarInfo.MaxValue = None;
            rhoDensityAirVarInfo.MinValue = None;
            rhoDensityAirVarInfo.DefaultValue = 1.225;
            rhoDensityAirVarInfo.Units = "";
            rhoDensityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            AlphaVarInfo.Name = "Alpha";
            AlphaVarInfo.Description = "Priestley-Taylor evapotranspiration proportionality constant";
            AlphaVarInfo.MaxValue = 100;
            AlphaVarInfo.MinValue = 0;
            AlphaVarInfo.DefaultValue = 1.5;
            AlphaVarInfo.Units = "";
            AlphaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            lambdaVVarInfo.Name = "lambdaV";
            lambdaVVarInfo.Description = "latent heat of vaporization of water";
            lambdaVVarInfo.MaxValue = 10;
            lambdaVVarInfo.MinValue = 0;
            lambdaVVarInfo.DefaultValue = 2.454;
            lambdaVVarInfo.Units = "";
            lambdaVVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _specificHeatCapacityAirVarInfo = new VarInfo();
        public static VarInfo specificHeatCapacityAirVarInfo
        {
            get { return _specificHeatCapacityAirVarInfo;} 
        }

        private static VarInfo _psychrometricConstantVarInfo = new VarInfo();
        public static VarInfo psychrometricConstantVarInfo
        {
            get { return _psychrometricConstantVarInfo;} 
        }

        private static VarInfo _rhoDensityAirVarInfo = new VarInfo();
        public static VarInfo rhoDensityAirVarInfo
        {
            get { return _rhoDensityAirVarInfo;} 
        }

        private static VarInfo _AlphaVarInfo = new VarInfo();
        public static VarInfo AlphaVarInfo
        {
            get { return _AlphaVarInfo;} 
        }

        private static VarInfo _lambdaVVarInfo = new VarInfo();
        public static VarInfo lambdaVVarInfo
        {
            get { return _lambdaVVarInfo;} 
        }

        public string TestPostConditions(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman.CurrentValue=r.evapoTranspirationPenman;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r10 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman);
                if(r10.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman.ValueType)){prc.AddCondition(r10);}
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
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair.CurrentValue=a.VPDair;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.CurrentValue=r.evapoTranspirationPriestlyTaylor;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.CurrentValue=a.hslope;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance.CurrentValue=s.conductance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair);
                if(r1.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
                if(r2.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
                if(r3.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance);
                if(r4.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance.ValueType)){prc.AddCondition(r4);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("specificHeatCapacityAir")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("psychrometricConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoDensityAir")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambdaV")));
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
            double VPDair = a.VPDair;
            double evapoTranspirationPriestlyTaylor = r.evapoTranspirationPriestlyTaylor;
            double hslope = a.hslope;
            double conductance = s.conductance;
            double evapoTranspirationPenman;
            evapoTranspirationPenman = evapoTranspirationPriestlyTaylor / Alpha + (1000.00 * (rhoDensityAir * specificHeatCapacityAir * VPDair * conductance / (lambdaV * (hslope + psychrometricConstant))));
            r.evapoTranspirationPenman = evapoTranspirationPenman;
        }
    }
}