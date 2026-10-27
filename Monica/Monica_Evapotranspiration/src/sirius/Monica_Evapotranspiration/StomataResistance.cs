
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
using SiriusQualityET.DomainClass;
namespace SiriusQualityET.Strategies
{
    public class StomataResistance : IStrategySiriusQualityET
    {
        public StomataResistance()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 2.5;
            v1.Description = "Original: Yu et al. 2001; beta = 3.5";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "saturation_beta";
            v1.Size = 1;
            v1.Units = "";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 40;
            v2.Description = "Original: Yu et al. 2001; alpha = 0.06 mol/m2/s";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "stomata_conductance_alpha";
            v2.Size = 1;
            v2.Units = "mmol/m2/s";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 0;
            v3.Description = "Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)";
            v3.Id = 0;
            v3.MaxValue = 2;
            v3.MinValue = 0;
            v3.Name = "carboxylation_pathway";
            v3.Size = 1;
            v3.Units = "dimensionless";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v3);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd1.PropertyName = "atmospheric_co2_concentration";
            pd1.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd2.PropertyName = "saturation_vapor_pressure_deficit";
            pd2.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd3.PropertyName = "gross_photosynthesis_reference_mol";
            pd3.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd4.PropertyName = "stomata_resistance";
            pd4.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
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
            get { return "        " ;}
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
            _pd.Add("Creator", "Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "ZALF e.V. "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualityET.DomainClass.ETState),  typeof(SiriusQualityET.DomainClass.ETState), typeof(SiriusQualityET.DomainClass.ETRate), typeof(SiriusQualityET.DomainClass.ETAuxiliary), typeof(SiriusQualityET.DomainClass.ETExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double saturation_beta
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("saturation_beta");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'saturation_beta' not found (or found null) in strategy 'StomataResistance'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("saturation_beta");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'saturation_beta' not found in strategy 'StomataResistance'");
            }
        }
        public double stomata_conductance_alpha
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("stomata_conductance_alpha");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'stomata_conductance_alpha' not found (or found null) in strategy 'StomataResistance'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("stomata_conductance_alpha");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'stomata_conductance_alpha' not found in strategy 'StomataResistance'");
            }
        }
        public int carboxylation_pathway
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("carboxylation_pathway");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'carboxylation_pathway' not found (or found null) in strategy 'StomataResistance'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("carboxylation_pathway");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'carboxylation_pathway' not found in strategy 'StomataResistance'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            saturation_betaVarInfo.Name = "saturation_beta";
            saturation_betaVarInfo.Description = "Original: Yu et al. 2001; beta = 3.5";
            saturation_betaVarInfo.MaxValue = -1D;
            saturation_betaVarInfo.MinValue = -1D;
            saturation_betaVarInfo.DefaultValue = 2.5;
            saturation_betaVarInfo.Units = "";
            saturation_betaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stomata_conductance_alphaVarInfo.Name = "stomata_conductance_alpha";
            stomata_conductance_alphaVarInfo.Description = "Original: Yu et al. 2001; alpha = 0.06 mol/m2/s";
            stomata_conductance_alphaVarInfo.MaxValue = -1D;
            stomata_conductance_alphaVarInfo.MinValue = -1D;
            stomata_conductance_alphaVarInfo.DefaultValue = 40;
            stomata_conductance_alphaVarInfo.Units = "mmol/m2/s";
            stomata_conductance_alphaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            carboxylation_pathwayVarInfo.Name = "carboxylation_pathway";
            carboxylation_pathwayVarInfo.Description = "Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)";
            carboxylation_pathwayVarInfo.MaxValue = 2;
            carboxylation_pathwayVarInfo.MinValue = 0;
            carboxylation_pathwayVarInfo.DefaultValue = 0;
            carboxylation_pathwayVarInfo.Units = "dimensionless";
            carboxylation_pathwayVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        private static VarInfo _saturation_betaVarInfo = new VarInfo();
        public static VarInfo saturation_betaVarInfo
        {
            get { return _saturation_betaVarInfo;} 
        }

        private static VarInfo _stomata_conductance_alphaVarInfo = new VarInfo();
        public static VarInfo stomata_conductance_alphaVarInfo
        {
            get { return _stomata_conductance_alphaVarInfo;} 
        }

        private static VarInfo _carboxylation_pathwayVarInfo = new VarInfo();
        public static VarInfo carboxylation_pathwayVarInfo
        {
            get { return _carboxylation_pathwayVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r7);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration.CurrentValue=ex.atmospheric_co2_concentration;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.CurrentValue=a.saturation_vapor_pressure_deficit;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol.CurrentValue=a.gross_photosynthesis_reference_mol;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.saturation_vapor_pressure_deficit.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("saturation_beta")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stomata_conductance_alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("carboxylation_pathway")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private double _saturation_beta;
        public double saturation_beta
    {
        get { return this._saturation_beta; }
        set { this._saturation_beta= value; } 
    }
        private double _stomata_conductance_alpha;
        public double stomata_conductance_alpha
    {
        get { return this._stomata_conductance_alpha; }
        set { this._stomata_conductance_alpha= value; } 
    }
        private int _carboxylation_pathway;
        public int carboxylation_pathway
    {
        get { return this._carboxylation_pathway; }
        set { this._carboxylation_pathway= value; } 
    }
    /// <summary>
    /// Constructor of the StomataResistance component")
    /// </summary>  
    public StomataResistance() { }
    
        public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
        {
            //- Name: StomataResistance -Version: 1, -Time step: 1
            //- Description:
    //            * Title: MONICA stomata resistance
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: 
    //        
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: 
    //        
    //            * ShortDescription: Calculates the MONICA reference evapotranspiration
            //- inputs:
    //            * name: saturation_beta
    //                          ** description : Original: Yu et al. 2001; beta = 3.5
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2.5
    //                          ** unit : 
    //            * name: stomata_conductance_alpha
    //                          ** description : Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 40
    //                          ** unit : mmol/m2/s
    //            * name: carboxylation_pathway
    //                          ** description : Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 2
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : dimensionless
    //            * name: atmospheric_co2_concentration
    //                          ** description : CO2 concentration in the atmosphere. Optional if no crop.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 430
    //                          ** unit : ppm
    //            * name: saturation_vapor_pressure_deficit
    //                          ** description : saturation_vapor_pressure_deficit
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : kPa
    //            * name: gross_photosynthesis_reference_mol
    //                          ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : -1
    //                          ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
            //- outputs:
    //            * name: stomata_resistance
    //                          ** description : stomata resistance (FAO default value is 100)
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : s/m
            double atmospheric_co2_concentration = ex.atmospheric_co2_concentration;
            double saturation_vapor_pressure_deficit = a.saturation_vapor_pressure_deficit;
            double gross_photosynthesis_reference_mol = a.gross_photosynthesis_reference_mol;
            double stomata_resistance;
            if (carboxylation_pathway > 0)
            {
                if (gross_photosynthesis_reference_mol <= 0.0)
                {
                    stomata_resistance = 999999.9;
                }
                else if ( carboxylation_pathway == 1)
                {
                    stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol);
                }
                else
                {
                    stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol);
                }
            }
            a.stomata_resistance= stomata_resistance;
        }
    }
}