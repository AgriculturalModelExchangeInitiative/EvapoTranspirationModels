
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
    public class NetRadiation : IStrategyEnergyBalanceComposite
    {
        public NetRadiation()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.23;
            v1.Description = "albedo Coefficient";
            v1.Id = 0;
            v1.MaxValue = 1;
            v1.MinValue = 0;
            v1.Name = "albedoCoefficient";
            v1.Size = 1;
            v1.Units = "";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.9983;
            v2.Description = "plant cover factor";
            v2.Id = 0;
            v2.MaxValue = 100;
            v2.MinValue = 0;
            v2.Name = "tau";
            v2.Size = 1;
            v2.Units = "";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 0;
            v3.Description = "elevation";
            v3.Id = 0;
            v3.MaxValue = 10000;
            v3.MinValue = 500;
            v3.Name = "elevation";
            v3.Size = 1;
            v3.Units = "m";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = 4.903E-09;
            v4.Description = "stefan Boltzman constant";
            v4.Id = 0;
            v4.MaxValue = 1;
            v4.MinValue = 0;
            v4.Name = "stefanBoltzman";
            v4.Size = 1;
            v4.Units = "";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = 0.23;
            v5.Description = "albedo Coefficient";
            v5.Id = 0;
            v5.MaxValue = 1;
            v5.MinValue = 0;
            v5.Name = "albedoCoefficientCan";
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
            pd1.PropertyName = "maxTair";
            pd1.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.maxTair).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.maxTair);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd2.PropertyName = "minTair";
            pd2.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.minTair).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.minTair);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd3.PropertyName = "vaporPressure";
            pd3.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.vaporPressure).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.vaporPressure);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState);
            pd4.PropertyName = "ih";
            pd4.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.ih).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.ih);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd5.PropertyName = "extraSolarRadiation";
            pd5.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.extraSolarRadiation).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.extraSolarRadiation);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd6.PropertyName = "solarRadiation";
            pd6.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd7.PropertyName = "netRadiation";
            pd7.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd8.PropertyName = "netOutGoingLongWaveRadiation";
            pd8.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation);
            _outputs0_0.Add(pd8);
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
            get { return "It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both shortand long wavelength radiation" ;}
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

        public double albedoCoefficient
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("albedoCoefficient");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'albedoCoefficient' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("albedoCoefficient");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'albedoCoefficient' not found in strategy 'NetRadiation'");
            }
        }
        public double tau
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("tau");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'tau' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("tau");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'tau' not found in strategy 'NetRadiation'");
            }
        }
        public double elevation
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("elevation");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'elevation' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("elevation");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'elevation' not found in strategy 'NetRadiation'");
            }
        }
        public double stefanBoltzman
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("stefanBoltzman");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'stefanBoltzman' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("stefanBoltzman");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'stefanBoltzman' not found in strategy 'NetRadiation'");
            }
        }
        public double albedoCoefficientCan
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("albedoCoefficientCan");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'albedoCoefficientCan' not found (or found null) in strategy 'NetRadiation'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("albedoCoefficientCan");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'albedoCoefficientCan' not found in strategy 'NetRadiation'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            albedoCoefficientVarInfo.Name = "albedoCoefficient";
            albedoCoefficientVarInfo.Description = "albedo Coefficient";
            albedoCoefficientVarInfo.MaxValue = 1;
            albedoCoefficientVarInfo.MinValue = 0;
            albedoCoefficientVarInfo.DefaultValue = 0.23;
            albedoCoefficientVarInfo.Units = "";
            albedoCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            tauVarInfo.Name = "tau";
            tauVarInfo.Description = "plant cover factor";
            tauVarInfo.MaxValue = 100;
            tauVarInfo.MinValue = 0;
            tauVarInfo.DefaultValue = 0.9983;
            tauVarInfo.Units = "";
            tauVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            elevationVarInfo.Name = "elevation";
            elevationVarInfo.Description = "elevation";
            elevationVarInfo.MaxValue = 10000;
            elevationVarInfo.MinValue = 500;
            elevationVarInfo.DefaultValue = 0;
            elevationVarInfo.Units = "m";
            elevationVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stefanBoltzmanVarInfo.Name = "stefanBoltzman";
            stefanBoltzmanVarInfo.Description = "stefan Boltzman constant";
            stefanBoltzmanVarInfo.MaxValue = 1;
            stefanBoltzmanVarInfo.MinValue = 0;
            stefanBoltzmanVarInfo.DefaultValue = 4.903E-09;
            stefanBoltzmanVarInfo.Units = "";
            stefanBoltzmanVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            albedoCoefficientCanVarInfo.Name = "albedoCoefficientCan";
            albedoCoefficientCanVarInfo.Description = "albedo Coefficient";
            albedoCoefficientCanVarInfo.MaxValue = 1;
            albedoCoefficientCanVarInfo.MinValue = 0;
            albedoCoefficientCanVarInfo.DefaultValue = 0.23;
            albedoCoefficientCanVarInfo.Units = "";
            albedoCoefficientCanVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _albedoCoefficientVarInfo = new VarInfo();
        public static VarInfo albedoCoefficientVarInfo
        {
            get { return _albedoCoefficientVarInfo;} 
        }

        private static VarInfo _tauVarInfo = new VarInfo();
        public static VarInfo tauVarInfo
        {
            get { return _tauVarInfo;} 
        }

        private static VarInfo _elevationVarInfo = new VarInfo();
        public static VarInfo elevationVarInfo
        {
            get { return _elevationVarInfo;} 
        }

        private static VarInfo _stefanBoltzmanVarInfo = new VarInfo();
        public static VarInfo stefanBoltzmanVarInfo
        {
            get { return _stefanBoltzmanVarInfo;} 
        }

        private static VarInfo _albedoCoefficientCanVarInfo = new VarInfo();
        public static VarInfo albedoCoefficientCanVarInfo
        {
            get { return _albedoCoefficientCanVarInfo;} 
        }

        public string TestPostConditions(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation.CurrentValue=a.netRadiation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation.CurrentValue=a.netOutGoingLongWaveRadiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r12 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation);
                if(r12.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation);
                if(r13.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation.ValueType)){prc.AddCondition(r13);}
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
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.maxTair.CurrentValue=a.maxTair;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.minTair.CurrentValue=a.minTair;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.vaporPressure.CurrentValue=a.vaporPressure;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.ih.CurrentValue=s.ih;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.extraSolarRadiation.CurrentValue=a.extraSolarRadiation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation.CurrentValue=a.solarRadiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.maxTair);
                if(r1.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.maxTair.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.minTair);
                if(r2.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.minTair.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.vaporPressure);
                if(r3.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.vaporPressure.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.ih);
                if(r4.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.ih.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.extraSolarRadiation);
                if(r5.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.extraSolarRadiation.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation);
                if(r6.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.solarRadiation.ValueType)){prc.AddCondition(r6);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("albedoCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("tau")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("elevation")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stefanBoltzman")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("albedoCoefficientCan")));
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
            double maxTair = a.maxTair;
            double minTair = a.minTair;
            double vaporPressure = a.vaporPressure;
            int ih = s.ih;
            double extraSolarRadiation = a.extraSolarRadiation;
            double solarRadiation = a.solarRadiation;
            double netRadiation;
            double netOutGoingLongWaveRadiation;
            double Nsr;
            double clearSkySolarRadiation;
            double averageT;
            double surfaceEmissivity;
            double cloudCoverFactor;
            double Nolr;
            double cov;
            if (ih == -999)
            {
                Nsr = solarRadiation * (1 - (albedoCoefficientCan * tau + (albedoCoefficient * (1.00 - tau))));
            }
            else
            {
                cov = (double)(1);
                if (solarRadiation > 0.01)
                {
                    if (ih <= 7)
                    {
                        cov = 0.30;
                    }
                    else if ( ih > 7 && ih < 11)
                    {
                        cov = 0.30 - (0.09 / 3.00 * (ih - 7.00));
                    }
                    else if ( ih == 11)
                    {
                        cov = 0.21;
                    }
                    else if ( ih > 11 && ih < 15)
                    {
                        cov = 0.21 + (0.09 / 3.00 * (ih - 11.00));
                    }
                    else
                    {
                        cov = 0.30;
                    }
                }
                Nsr = (1 - cov) * solarRadiation;
            }
            clearSkySolarRadiation = (0.750 + (2 * Math.Pow(10.00, -5) * elevation)) * extraSolarRadiation;
            averageT = (Math.Pow(maxTair + 273.160, 4) + Math.Pow(minTair + 273.160, 4)) / 2.00;
            surfaceEmissivity = 0.340 - (0.140 * Math.Sqrt(vaporPressure / 10.00));
            cloudCoverFactor = 1.350 * (solarRadiation / clearSkySolarRadiation) - 0.350;
            Nolr = stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;
            if (ih != -999)
            {
                Nolr = Nolr / 24.00;
            }
            netRadiation = Nsr - Nolr;
            netOutGoingLongWaveRadiation = Nolr;
            a.netRadiation= netRadiation;
            a.netOutGoingLongWaveRadiation= netOutGoingLongWaveRadiation;
        }
    }
}