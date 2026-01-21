
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
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'PotentialEvapotranspiration', 'var': 'ket'}, "ket");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'PotentialEvapotranspiration', 'var': 'calb'}, "calb");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'PotentialEvapotranspiration', 'var': 'salb'}, "salb");
            _parameters0_0.Add(v3);
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
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(pet.DomainClass.petExogenous);
            pd4.PropertyName = "etlai";
            pd4.PropertyType = (pet.DomainClass.petExogenousVarInfo.etlai).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(pet.DomainClass.petExogenousVarInfo.etlai);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(pet.DomainClass.petState);
            pd5.PropertyName = "pet";
            pd5.PropertyType = (pet.DomainClass.petStateVarInfo.pet).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(pet.DomainClass.petStateVarInfo.pet);
            _outputs0_0.Add(pd5);
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
            return new List<Type>() {  typeof(pet.DomainClass.petState), typeof(pet.DomainClass.petState), typeof(pet.DomainClass.petRate), typeof(pet.DomainClass.petAuxiliary), typeof(pet.DomainClass.petExogenous)};
        }

        public double ket
        {
            get
            {
                 return _PotentialEvapotranspiration.ket; 
            }
            set
            {
                _PotentialEvapotranspiration.ket = value;
            }
        }
        public double calb
        {
            get
            {
                 return _PotentialEvapotranspiration.calb; 
            }
            set
            {
                _PotentialEvapotranspiration.calb = value;
            }
        }
        public double salb
        {
            get
            {
                 return _PotentialEvapotranspiration.salb; 
            }
            set
            {
                _PotentialEvapotranspiration.salb = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _PotentialEvapotranspiration.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            ketVarInfo.Name = "ket";
            ketVarInfo.Description = "Extinction coefficient for canopy";
            ketVarInfo.MaxValue = 2.;
            ketVarInfo.MinValue = 0.1;
            ketVarInfo.DefaultValue = 0.5;
            ketVarInfo.Units = "-";
            ketVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            calbVarInfo.Name = "calb";
            calbVarInfo.Description = "Crop albedo";
            calbVarInfo.MaxValue = 1.;
            calbVarInfo.MinValue = 0.;
            calbVarInfo.DefaultValue = 0.23;
            calbVarInfo.Units = "-";
            calbVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            salbVarInfo.Name = "salb";
            salbVarInfo.Description = "Soil albedo";
            salbVarInfo.MaxValue = 1.;
            salbVarInfo.MinValue = 0.;
            salbVarInfo.DefaultValue = 0.13;
            salbVarInfo.Units = "-";
            salbVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo ketVarInfo
        {
            get { return pet.Strategies.{'modu': 'PotentialEvapotranspiration', 'var': 'ket'}.ketVarInfo;} 
        }

        public static VarInfo calbVarInfo
        {
            get { return pet.Strategies.{'modu': 'PotentialEvapotranspiration', 'var': 'calb'}.calbVarInfo;} 
        }

        public static VarInfo salbVarInfo
        {
            get { return pet.Strategies.{'modu': 'PotentialEvapotranspiration', 'var': 'salb'}.salbVarInfo;} 
        }

        public string TestPostConditions(pet.DomainClass.petState s,pet.DomainClass.petState s1,pet.DomainClass.petRate r,pet.DomainClass.petAuxiliary a,pet.DomainClass.petExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                pet.DomainClass.petStateVarInfo.pet.CurrentValue=s.pet;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r8 = new RangeBasedCondition(pet.DomainClass.petStateVarInfo.pet);
                if(r8.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petStateVarInfo.pet.ValueType)){prc.AddCondition(r8);}

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
                pet.DomainClass.petExogenousVarInfo.etlai.CurrentValue=ex.etlai;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.tmax);
                if(r1.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.tmax.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.tmin);
                if(r2.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.tmin.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.srad);
                if(r3.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.srad.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(pet.DomainClass.petExogenousVarInfo.etlai);
                if(r4.ApplicableVarInfoValueTypes.Contains( pet.DomainClass.petExogenousVarInfo.etlai.ValueType)){prc.AddCondition(r4);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ket")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("calb")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("salb")));
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
                ket = toCopy.ket;
                calb = toCopy.calb;
                salb = toCopy.salb;
            }
        }
    }