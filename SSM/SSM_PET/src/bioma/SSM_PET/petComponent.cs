
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
    public class petComponent : IStrategypet
    {
        public petComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'PotentialEvapotranspiration', 'var': 'albedo'}, "albedo");
            _parameters0_0.Add(v1);
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
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(pet.DomainClass.petState);
            pd4.PropertyName = "pet";
            pd4.PropertyType = (pet.DomainClass.petStateVarInfo.pet).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(pet.DomainClass.petStateVarInfo.pet);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(pet.Strategies.PotentialEvapotranspiration).FullName);
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
            _pd.Add("Creator", "Thomas Sinclair, ");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "CIRAD "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(pet.DomainClass.petState), typeof(pet.DomainClass.petState), typeof(pet.DomainClass.petRate), typeof(pet.DomainClass.petAuxiliary), typeof(pet.DomainClass.petExogenous)};
        }

        public double albedo
        {
            get
            {
                 return _PotentialEvapotranspiration.albedo; 
            }
            set
            {
                _PotentialEvapotranspiration.albedo = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _PotentialEvapotranspiration.SetParametersDefaultValue();
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

        public static VarInfo albedoVarInfo
        {
            get { return pet.Strategies.{'modu': 'PotentialEvapotranspiration', 'var': 'albedo'}.albedoVarInfo;} 
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

                string ret = "";
                ret += _PotentialEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy pet.Strategies.pet");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .pet, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
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
                string ret = "";
                ret += _PotentialEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy pet.Strategies.pet");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .pet, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

        private void EstimateOfAssociatedClasses(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex)
        {
            _potentialevapotranspiration.Estimate(s,s1, r, a, ex);
        }

        public void Init(PetState s, PetState s1, PetRate r, PetAuxiliary a, PetExogenous ex)
        {
        }

        public petComponent(petComponent toCopy): this() // copy constructor 
        {
                albedo = toCopy.albedo;
            }
        }
    }