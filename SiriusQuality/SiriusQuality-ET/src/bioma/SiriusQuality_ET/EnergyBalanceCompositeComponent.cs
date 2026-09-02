
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
    public class EnergyBalanceCompositeComponent : IStrategyEnergyBalanceComposite
    {
        public EnergyBalanceCompositeComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiation', 'var': 'albedoCoefficient'}, "albedoCoefficient");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiation', 'var': 'tau'}, "tau");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiation', 'var': 'elevation'}, "elevation");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiation', 'var': 'stefanBoltzman'}, "stefanBoltzman");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiation', 'var': 'albedoCoefficientCan'}, "albedoCoefficientCan");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'Conductance', 'var': 'd'}, "d");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'Conductance', 'var': 'heightWeatherMeasurements'}, "heightWeatherMeasurements");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'Conductance', 'var': 'zh'}, "zh");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'Conductance', 'var': 'zm'}, "zm");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_{'modu': 'Conductance', 'var': 'vonKarman'}, "vonKarman");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_{'modu': 'NetRadiationEquivalentEvaporation', 'var': 'lambdaV'}, "lambdaV");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'lambdaV'}, "lambdaV");
            _parameters0_0.Add(v12);
            VarInfo v13 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}, "psychrometricConstant");
            _parameters0_0.Add(v13);
            VarInfo v14 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'psychrometricConstant'}, "psychrometricConstant");
            _parameters0_0.Add(v14);
            VarInfo v15 = new CompositeStrategyVarInfo(_{'modu': 'PriestlyTaylor', 'var': 'Alpha'}, "Alpha");
            _parameters0_0.Add(v15);
            VarInfo v16 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'Alpha'}, "Alpha");
            _parameters0_0.Add(v16);
            VarInfo v17 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'specificHeatCapacityAir'}, "specificHeatCapacityAir");
            _parameters0_0.Add(v17);
            VarInfo v18 = new CompositeStrategyVarInfo(_{'modu': 'Penman', 'var': 'rhoDensityAir'}, "rhoDensityAir");
            _parameters0_0.Add(v18);
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
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd7.PropertyName = "plantHeight";
            pd7.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.plantHeight).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.plantHeight);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd8.PropertyName = "wind";
            pd8.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.wind).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.wind);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd9.PropertyName = "hslope";
            pd9.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd10.PropertyName = "VPDair";
            pd10.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd11.PropertyName = "netOutGoingLongWaveRadiation";
            pd11.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState);
            pd12.PropertyName = "conductance";
            pd12.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary);
            pd13.PropertyName = "netRadiation";
            pd13.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation);
            _outputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate);
            pd14.PropertyName = "evapoTranspirationPriestlyTaylor";
            pd14.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
            _outputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate);
            pd15.PropertyName = "evapoTranspirationPenman";
            pd15.PropertyType = (EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman);
            _outputs0_0.Add(pd15);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(EnergyBalanceComposite.Strategies.NetRadiation).FullName);
            lAssStrat0_0.Add(typeof(EnergyBalanceComposite.Strategies.Conductance).FullName);
            lAssStrat0_0.Add(typeof(EnergyBalanceComposite.Strategies.NetRadiationEquivalentEvaporation).FullName);
            lAssStrat0_0.Add(typeof(EnergyBalanceComposite.Strategies.PriestlyTaylor).FullName);
            lAssStrat0_0.Add(typeof(EnergyBalanceComposite.Strategies.Penman).FullName);
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
            return new List<Type>() {  typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary), typeof(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous)};
        }

        public double albedoCoefficient
        {
            get
            {
                 return _NetRadiation.albedoCoefficient; 
            }
            set
            {
                _NetRadiation.albedoCoefficient = value;
            }
        }
        public double tau
        {
            get
            {
                 return _NetRadiation.tau; 
            }
            set
            {
                _NetRadiation.tau = value;
            }
        }
        public double elevation
        {
            get
            {
                 return _NetRadiation.elevation; 
            }
            set
            {
                _NetRadiation.elevation = value;
            }
        }
        public double stefanBoltzman
        {
            get
            {
                 return _NetRadiation.stefanBoltzman; 
            }
            set
            {
                _NetRadiation.stefanBoltzman = value;
            }
        }
        public double albedoCoefficientCan
        {
            get
            {
                 return _NetRadiation.albedoCoefficientCan; 
            }
            set
            {
                _NetRadiation.albedoCoefficientCan = value;
            }
        }
        public double d
        {
            get
            {
                 return _Conductance.d; 
            }
            set
            {
                _Conductance.d = value;
            }
        }
        public double heightWeatherMeasurements
        {
            get
            {
                 return _Conductance.heightWeatherMeasurements; 
            }
            set
            {
                _Conductance.heightWeatherMeasurements = value;
            }
        }
        public double zh
        {
            get
            {
                 return _Conductance.zh; 
            }
            set
            {
                _Conductance.zh = value;
            }
        }
        public double zm
        {
            get
            {
                 return _Conductance.zm; 
            }
            set
            {
                _Conductance.zm = value;
            }
        }
        public double vonKarman
        {
            get
            {
                 return _Conductance.vonKarman; 
            }
            set
            {
                _Conductance.vonKarman = value;
            }
        }
        public double lambdaV
        {
            get
            {
                 return _NetRadiationEquivalentEvaporation.lambdaV; 
            }
            set
            {
                _NetRadiationEquivalentEvaporation.lambdaV = value;
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
            _NetRadiation.SetParametersDefaultValue();
            _Conductance.SetParametersDefaultValue();
            _NetRadiationEquivalentEvaporation.SetParametersDefaultValue();
            _PriestlyTaylor.SetParametersDefaultValue();
            _Penman.SetParametersDefaultValue();
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

            dVarInfo.Name = "d";
            dVarInfo.Description = "corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO";
            dVarInfo.MaxValue = 1;
            dVarInfo.MinValue = 0;
            dVarInfo.DefaultValue = 0.67;
            dVarInfo.Units = "dimensionless";
            dVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            heightWeatherMeasurementsVarInfo.Name = "heightWeatherMeasurements";
            heightWeatherMeasurementsVarInfo.Description = "reference height of wind and humidity measurements";
            heightWeatherMeasurementsVarInfo.MaxValue = 10;
            heightWeatherMeasurementsVarInfo.MinValue = 0;
            heightWeatherMeasurementsVarInfo.DefaultValue = 2;
            heightWeatherMeasurementsVarInfo.Units = "m";
            heightWeatherMeasurementsVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            zhVarInfo.Name = "zh";
            zhVarInfo.Description = "roughness length governing transfer of heat and vapour, FAO";
            zhVarInfo.MaxValue = 1;
            zhVarInfo.MinValue = 0;
            zhVarInfo.DefaultValue = 0.013;
            zhVarInfo.Units = "m";
            zhVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            zmVarInfo.Name = "zm";
            zmVarInfo.Description = "roughness length governing momentum transfer, FAO";
            zmVarInfo.MaxValue = 1;
            zmVarInfo.MinValue = 0;
            zmVarInfo.DefaultValue = 0.13;
            zmVarInfo.Units = "m";
            zmVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            vonKarmanVarInfo.Name = "vonKarman";
            vonKarmanVarInfo.Description = "von Karman constant";
            vonKarmanVarInfo.MaxValue = 1;
            vonKarmanVarInfo.MinValue = 0;
            vonKarmanVarInfo.DefaultValue = 0.42;
            vonKarmanVarInfo.Units = "dimensionless";
            vonKarmanVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            lambdaVVarInfo.Name = "lambdaV";
            lambdaVVarInfo.Description = "latent heat of vaporization of water";
            lambdaVVarInfo.MaxValue = 10;
            lambdaVVarInfo.MinValue = 0;
            lambdaVVarInfo.DefaultValue = 2.454;
            lambdaVVarInfo.Units = "MJ kg-1";
            lambdaVVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

            specificHeatCapacityAirVarInfo.Name = "specificHeatCapacityAir";
            specificHeatCapacityAirVarInfo.Description = "Specific heat capacity of dry air";
            specificHeatCapacityAirVarInfo.MaxValue = 1;
            specificHeatCapacityAirVarInfo.MinValue = 0;
            specificHeatCapacityAirVarInfo.DefaultValue = 0.00101;
            specificHeatCapacityAirVarInfo.Units = "";
            specificHeatCapacityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            rhoDensityAirVarInfo.Name = "rhoDensityAir";
            rhoDensityAirVarInfo.Description = "Density of air";
            rhoDensityAirVarInfo.MaxValue = None;
            rhoDensityAirVarInfo.MinValue = None;
            rhoDensityAirVarInfo.DefaultValue = 1.225;
            rhoDensityAirVarInfo.Units = "";
            rhoDensityAirVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo albedoCoefficientVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiation', 'var': 'albedoCoefficient'}.albedoCoefficientVarInfo;} 
        }

        public static VarInfo tauVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiation', 'var': 'tau'}.tauVarInfo;} 
        }

        public static VarInfo elevationVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiation', 'var': 'elevation'}.elevationVarInfo;} 
        }

        public static VarInfo stefanBoltzmanVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiation', 'var': 'stefanBoltzman'}.stefanBoltzmanVarInfo;} 
        }

        public static VarInfo albedoCoefficientCanVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiation', 'var': 'albedoCoefficientCan'}.albedoCoefficientCanVarInfo;} 
        }

        public static VarInfo dVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Conductance', 'var': 'd'}.dVarInfo;} 
        }

        public static VarInfo heightWeatherMeasurementsVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Conductance', 'var': 'heightWeatherMeasurements'}.heightWeatherMeasurementsVarInfo;} 
        }

        public static VarInfo zhVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Conductance', 'var': 'zh'}.zhVarInfo;} 
        }

        public static VarInfo zmVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Conductance', 'var': 'zm'}.zmVarInfo;} 
        }

        public static VarInfo vonKarmanVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Conductance', 'var': 'vonKarman'}.vonKarmanVarInfo;} 
        }

        public static VarInfo lambdaVVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'NetRadiationEquivalentEvaporation', 'var': 'lambdaV'}.lambdaVVarInfo;} 
        }

        public static VarInfo psychrometricConstantVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'PriestlyTaylor', 'var': 'psychrometricConstant'}.psychrometricConstantVarInfo;} 
        }

        public static VarInfo AlphaVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'PriestlyTaylor', 'var': 'Alpha'}.AlphaVarInfo;} 
        }

        public static VarInfo specificHeatCapacityAirVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Penman', 'var': 'specificHeatCapacityAir'}.specificHeatCapacityAirVarInfo;} 
        }

        public static VarInfo rhoDensityAirVarInfo
        {
            get { return EnergyBalanceComposite.Strategies.{'modu': 'Penman', 'var': 'rhoDensityAir'}.rhoDensityAirVarInfo;} 
        }

        public string TestPostConditions(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation.CurrentValue=a.netOutGoingLongWaveRadiation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance.CurrentValue=s.conductance;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation.CurrentValue=a.netRadiation;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.CurrentValue=r.evapoTranspirationPriestlyTaylor;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman.CurrentValue=r.evapoTranspirationPenman;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r26 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation);
                if(r26.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netOutGoingLongWaveRadiation.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance);
                if(r27.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeStateVarInfo.conductance.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation);
                if(r28.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.netRadiation.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor);
                if(r29.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPriestlyTaylor.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman);
                if(r30.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRateVarInfo.evapoTranspirationPenman.ValueType)){prc.AddCondition(r30);}

                string ret = "";
                ret += _NetRadiation.TestPostConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _Conductance.TestPostConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _NetRadiationEquivalentEvaporation.TestPostConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _PriestlyTaylor.TestPostConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _Penman.TestPostConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .EnergyBalanceComposite, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
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
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.plantHeight.CurrentValue=a.plantHeight;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.wind.CurrentValue=a.wind;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.CurrentValue=a.hslope;
                EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair.CurrentValue=a.VPDair;
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
                RangeBasedCondition r7 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.plantHeight);
                if(r7.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.plantHeight.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.wind);
                if(r8.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.wind.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope);
                if(r9.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.hslope.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair);
                if(r10.ApplicableVarInfoValueTypes.Contains( EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliaryVarInfo.VPDair.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("albedoCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("tau")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("elevation")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stefanBoltzman")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("albedoCoefficientCan")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("d")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("heightWeatherMeasurements")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("zh")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("zm")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("vonKarman")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambdaV")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("psychrometricConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("specificHeatCapacityAir")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoDensityAir")));
                string ret = "";
                ret += _NetRadiation.TestPreConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _Conductance.TestPreConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _NetRadiationEquivalentEvaporation.TestPreConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _PriestlyTaylor.TestPreConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                ret += _Penman.TestPreConditions(s, s1, r, a, ex, " strategy EnergyBalanceComposite.Strategies.EnergyBalanceComposite");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .EnergyBalanceComposite, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        NetRadiation _NetRadiation = new NetRadiation();
        Conductance _Conductance = new Conductance();
        NetRadiationEquivalentEvaporation _NetRadiationEquivalentEvaporation = new NetRadiationEquivalentEvaporation();
        PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
        Penman _Penman = new Penman();

        private void EstimateOfAssociatedClasses(EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeState s1,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeRate r,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeAuxiliary a,EnergyBalanceComposite.DomainClass.EnergyBalanceCompositeExogenous ex)
        {
            _netradiation.Estimate(s,s1, r, a, ex);
            _conductance.Estimate(s,s1, r, a, ex);
            _netradiationequivalentevaporation.Estimate(s,s1, r, a, ex);
            _priestlytaylor.Estimate(s,s1, r, a, ex);
            _penman.Estimate(s,s1, r, a, ex);
        }

        public void Init(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
        {
        }

        public EnergyBalanceCompositeComponent(EnergyBalanceCompositeComponent toCopy): this() // copy constructor 
        {
                albedoCoefficient = toCopy.albedoCoefficient;
                tau = toCopy.tau;
                elevation = toCopy.elevation;
                stefanBoltzman = toCopy.stefanBoltzman;
                albedoCoefficientCan = toCopy.albedoCoefficientCan;
                d = toCopy.d;
                heightWeatherMeasurements = toCopy.heightWeatherMeasurements;
                zh = toCopy.zh;
                zm = toCopy.zm;
                vonKarman = toCopy.vonKarman;
                lambdaV = toCopy.lambdaV;
                psychrometricConstant = toCopy.psychrometricConstant;
                Alpha = toCopy.Alpha;
                specificHeatCapacityAir = toCopy.specificHeatCapacityAir;
                rhoDensityAir = toCopy.rhoDensityAir;
            }
        }
    }