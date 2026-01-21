
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
            v1.DefaultValue = 0.5;
            v1.Description = "Extinction coefficient for canopy";
            v1.Id = 0;
            v1.MaxValue = 2.;
            v1.MinValue = 0.1;
            v1.Name = "ket";
            v1.Size = 1;
            v1.Units = "-";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.23;
            v2.Description = "Crop albedo";
            v2.Id = 0;
            v2.MaxValue = 1.;
            v2.MinValue = 0.;
            v2.Name = "calb";
            v2.Size = 1;
            v2.Units = "-";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 0.13;
            v3.Description = "Soil albedo";
            v3.Id = 0;
            v3.MaxValue = 1.;
            v3.MinValue = 0.;
            v3.Name = "salb";
            v3.Size = 1;
            v3.Units = "-";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
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
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(pet.DomainClass.petExogenous);
            pd4.PropertyName = "etlai";
            pd4.PropertyType = (pet.DomainClass.petExogenousVarInfo.etlai).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(pet.DomainClass.petExogenousVarInfo.etlai);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(pet.DomainClass.petState);
            pd5.PropertyName = "pet";
            pd5.PropertyType = (pet.DomainClass.petStateVarInfo.pet).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(pet.DomainClass.petStateVarInfo.pet);
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
            get { return "Computes daily potential evapotranspiration (PET, mm d-1) following Soltani and Sinclair (2012) using an equilibrium evaporation (EEQ) term adjusted by temperature-dependent multipliers. Average daytime temperature is TD = 0.6·Tmax + 0.4·Tmin. The surface albedo blends crop and soil albedos weighted by the fraction of surface energy reaching soil, exp(-KET·ETLAI): ALBEDO = CALB·(1 - exp(-KET·ETLAI)) + SALB·exp(-KET·ETLAI). EEQ is then EEQ = SRAD·(0.004876 - 0.004374·ALBEDO)·(TD + 29). PET is derived from EEQ with three regimes: PET = 1.1·EEQ for 5 < Tmax < 34; PET = EEQ·((Tmax - 34)·0.05 + 1.1) for Tmax ≥ 34 (advection); PET = EEQ·0.01·exp(0.18·(Tmax + 20)) for Tmax ≤ 5 (cold/frozen conditions). The uncovered-soil fraction follows the Beer–Bouguer–Lambert law via ETLAI and KET. Methodology relates to Priestley–Taylor (1972) and the modifications summarized by Ritchie (1998) as presented in Soltani and Sinclair (2012)." ;}
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

        public double ket
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("ket");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'ket' not found (or found null) in strategy 'PotentialEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ket");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'ket' not found in strategy 'PotentialEvapotranspiration'");
            }
        }
        public double calb
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("calb");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'calb' not found (or found null) in strategy 'PotentialEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("calb");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'calb' not found in strategy 'PotentialEvapotranspiration'");
            }
        }
        public double salb
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("salb");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'salb' not found (or found null) in strategy 'PotentialEvapotranspiration'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("salb");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'salb' not found in strategy 'PotentialEvapotranspiration'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
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

        private static VarInfo _ketVarInfo = new VarInfo();
        public static VarInfo ketVarInfo
        {
            get { return _ketVarInfo;} 
        }

        private static VarInfo _calbVarInfo = new VarInfo();
        public static VarInfo calbVarInfo
        {
            get { return _calbVarInfo;} 
        }

        private static VarInfo _salbVarInfo = new VarInfo();
        public static VarInfo salbVarInfo
        {
            get { return _salbVarInfo;} 
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
            double etlai = ex.etlai;
            double pet;
            double td;
            double fraction_nrj_soil;
            double albedo;
            double eeq;
            td = 0.6 * tmax + (0.4 * tmin);
            fraction_nrj_soil = Math.Exp(-(ket * etlai));
            albedo = calb * (1.0 - fraction_nrj_soil) + (salb * fraction_nrj_soil);
            eeq = srad * (0.004876 - (0.004374 * albedo)) * (td + 29.0);
            if (tmax > 5.0 && tmax < 34.0)
            {
                pet = eeq * 1.1;
            }
            else
            {
                if (tmax >= 34.0)
                {
                    pet = eeq * ((tmax - 34.0) * 0.05 + 1.1);
                }
                else
                {
                    pet = eeq * 0.01 * Math.Exp(0.18 * (tmax + 20.0));
                }
            }
            s.pet= pet;
        }
    }
}