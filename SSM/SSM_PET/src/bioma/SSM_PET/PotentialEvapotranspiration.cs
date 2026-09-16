
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
using pet.DomainClass;
namespace pet.Strategies
{
    public class PotentialEvapotranspiration : IStrategypet
    {
        public PotentialEvapotranspiration()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 1.0;
            v1.Description = "Surface albedo.";
            v1.Id = 0;
            v1.MaxValue = 10.0;
            v1.MinValue = 0.0;
            v1.Name = "albedo";
            v1.Size = 1;
            v1.Units = "-";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(pet.DomainClass.petExogenous);
            pd1.PropertyName = "tmax";
            pd1.PropertyType = (pet.DomainClass.petExogenousVarInfo.tmax).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(pet.DomainClass.petExogenousVarInfo.tmax);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(pet.DomainClass.petExogenous);
            pd2.PropertyName = "tmin";
            pd2.PropertyType = (pet.DomainClass.petExogenousVarInfo.tmin).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(pet.DomainClass.petExogenousVarInfo.tmin);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(pet.DomainClass.petExogenous);
            pd3.PropertyName = "srad";
            pd3.PropertyType = (pet.DomainClass.petExogenousVarInfo.srad).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(pet.DomainClass.petExogenousVarInfo.srad);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(pet.DomainClass.petState);
            pd4.PropertyName = "pet";
            pd4.PropertyType = (pet.DomainClass.petStateVarInfo.pet).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(pet.DomainClass.petStateVarInfo.pet);
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
            get { return "Python implementation of a simplified Penman-style PET model (from Sultani and Sinclair 2012) computing equilibrium evaporation EEQ = SRAD*(0.004876-0.004374*ALBEDO)*(TD+29) with TD = 0.6*TMAX+0.4*TMIN, PET adjusted by Tmax-dependent multipliers (including low-temperature and high-advection corrections) and intended to be combined with an exponential Beer–Bouguer–Lambert factor for fraction of uncovered soil." ;}
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
            _pd.Add("Creator", "-");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "- "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(pet.DomainClass.petState),  typeof(pet.DomainClass.petState), typeof(pet.DomainClass.petRate), typeof(pet.DomainClass.petAuxiliary), typeof(pet.DomainClass.petExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double albedo
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("albedo");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'albedo' not found (or found null) in strategy 'PotentialEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("albedo");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'albedo' not found in strategy 'PotentialEvapotranspiration'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            albedoVarInfo.Name = "albedo";
            albedoVarInfo.Description = "Surface albedo.";
            albedoVarInfo.MaxValue = 10.0;
            albedoVarInfo.MinValue = 0.0;
            albedoVarInfo.DefaultValue = 1.0;
            albedoVarInfo.Units = "-";
            albedoVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _albedoVarInfo = new VarInfo();
        public static VarInfo albedoVarInfo
        {
            get { return _albedoVarInfo;} 
        }

        public string TestPostConditions(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                pet.DomainClass.petStateVarInfo.pet.CurrentValue=s.pet;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r5 = new RangeBasedCondition(pet.DomainClass.petStateVarInfo.pet);
                if(r5.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petStateVarInfo.pet.ValueType)){prc.AddCondition(r5);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".pet, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                pet.DomainClass.petExogenousVarInfo.tmax.CurrentValue=ex.tmax;
                pet.DomainClass.petExogenousVarInfo.tmin.CurrentValue=ex.tmin;
                pet.DomainClass.petExogenousVarInfo.srad.CurrentValue=ex.srad;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.tmax);
                if(r1.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.tmax.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.tmin);
                if(r2.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.tmin.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.srad);
                if(r3.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.srad.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("albedo")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".pet, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component pet, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(pet.DomainClass.petState s, pet.DomainClass.petState s1, pet.DomainClass.petRate r, pet.DomainClass.petAuxiliary a, pet.DomainClass.petExogenous ex)
        {
            double tmax = ex.tmax;
            double tmin = ex.tmin;
            double srad = ex.srad;
            double pet;
            double td;
            double eeq;
            td = 0.6 * tmax + (0.4 * tmin);
            eeq = srad * (0.004876 - (0.004374 * albedo)) * (td + 29.0);
            if (tmax > 5.0 && tmax < 34.0)
            {
                pet = eeq * 1.1;
            }
            else if ( tmax >= 34.0)
            {
                pet = eeq * ((tmax - 34.0) * 0.05 + 1.1);
            }
            else
            {
                pet = eeq * 0.01 * Math.Exp(0.18 * (tmax + 20.0));
            }
            s.pet= pet;
        }
    }
}