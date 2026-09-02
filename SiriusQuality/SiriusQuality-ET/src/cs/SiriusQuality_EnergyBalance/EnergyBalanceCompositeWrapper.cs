using System;
using System.Collections.Generic;
using System.Linq;
class EnergyBalanceCompositeWrapper
{
    private EnergyBalanceCompositeState s;
    private EnergyBalanceCompositeState s1;
    private EnergyBalanceCompositeRate r;
    private EnergyBalanceCompositeAuxiliary a;
    private EnergyBalanceCompositeExogenous ex;
    private EnergyBalanceCompositeComponent energybalancecompositeComponent;

    public EnergyBalanceCompositeWrapper()
    {
        s = new EnergyBalanceCompositeState();
        r = new EnergyBalanceCompositeRate();
        a = new EnergyBalanceCompositeAuxiliary();
        ex = new EnergyBalanceCompositeExogenous();
        energybalancecompositeComponent = new EnergyBalanceCompositeComponent();
        loadParameters();
    }

        double albedoCoefficient;
    double tau;
    double elevation;
    double stefanBoltzman;
    double albedoCoefficientCan;
    double d;
    double heightWeatherMeasurements;
    double zh;
    double zm;
    double vonKarman;
    double soilDiffusionConstant;
    double lambdaV;
    double psychrometricConstant;
    double Alpha;
    double tauAlpha;
    double specificHeatCapacityAir;
    double rhoDensityAir;
    int isWindVpDefined;

    public double maxCanopyTemperature{ get { return s.maxCanopyTemperature;}} 
     
    public double diffusionLimitedEvaporation{ get { return s.diffusionLimitedEvaporation;}} 
     
    public double minCanopyTemperature{ get { return s.minCanopyTemperature;}} 
     
    public double conductance{ get { return s.conductance;}} 
     
    public double netOutGoingLongWaveRadiation{ get { return a.netOutGoingLongWaveRadiation;}} 
     

    public EnergyBalanceCompositeWrapper(EnergyBalanceCompositeWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new EnergyBalanceCompositeState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new EnergyBalanceCompositeRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new EnergyBalanceCompositeAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new EnergyBalanceCompositeExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            energybalancecompositeComponent = (toCopy.energybalancecompositeComponent != null) ? new EnergyBalanceCompositeComponent(toCopy.energybalancecompositeComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        energybalancecompositeComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        energybalancecompositeComponent.albedoCoefficient = 0.23; 
        energybalancecompositeComponent.tau = null; // To be modified
        energybalancecompositeComponent.elevation = 0; 
        energybalancecompositeComponent.stefanBoltzman = 4.903E-09; 
        energybalancecompositeComponent.albedoCoefficientCan = 0.23; 
        energybalancecompositeComponent.d = 0.67; 
        energybalancecompositeComponent.heightWeatherMeasurements = null; // To be modified
        energybalancecompositeComponent.zh = 0.013; 
        energybalancecompositeComponent.zm = 0.13; 
        energybalancecompositeComponent.vonKarman = 0.42; 
        energybalancecompositeComponent.soilDiffusionConstant = null; // To be modified
        energybalancecompositeComponent.lambdaV = 2.454; 
        energybalancecompositeComponent.psychrometricConstant = 0.66; 
        energybalancecompositeComponent.Alpha = 1.5; 
        energybalancecompositeComponent.tauAlpha = null; // To be modified
        energybalancecompositeComponent.specificHeatCapacityAir = 0.00101; 
        energybalancecompositeComponent.rhoDensityAir = 1.225; 
        energybalancecompositeComponent.isWindVpDefined = 1; 
    }

    private void setExogenous()
    {
    }

    public void EstimateEnergyBalanceComposite(double maxTair, double minTair, double vaporPressure, double extraSolarRadiation, double solarRadiation, double plantHeight, double wind, double deficitOnTopLayers, double hslope, double VPDair)
    {
        a.maxTair = maxTair;
        a.minTair = minTair;
        a.vaporPressure = vaporPressure;
        a.extraSolarRadiation = extraSolarRadiation;
        a.solarRadiation = solarRadiation;
        a.plantHeight = plantHeight;
        a.wind = wind;
        a.deficitOnTopLayers = deficitOnTopLayers;
        a.hslope = hslope;
        a.VPDair = VPDair;
        energybalancecompositeComponent.CalculateModel(s,s1, r, a, ex);
    }

}