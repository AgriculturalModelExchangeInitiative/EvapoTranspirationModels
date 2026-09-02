using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_EnergyBalanceComposite.DomainClass;
using Crop2ML_EnergyBalanceComposite.Strategies;

namespace Model.Model.EnergyBalanceComposite
{
    class EnergyBalanceCompositeWrapper :  UniverseLink
    {
        private EnergyBalanceCompositeState s;
        private EnergyBalanceCompositeState s1;
        private EnergyBalanceCompositeRate r;
        private EnergyBalanceCompositeAuxiliary a;
        private EnergyBalanceCompositeExogenous ex;
        private EnergyBalanceCompositeComponent energybalancecompositeComponent;

        public EnergyBalanceCompositeWrapper(Universe universe) : base(universe)
        {
            s = new EnergyBalanceCompositeState();
            r = new EnergyBalanceCompositeRate();
            a = new EnergyBalanceCompositeAuxiliary();
            ex = new EnergyBalanceCompositeExogenous();
            energybalancecompositeComponent = new EnergyBalanceComposite();
            loadParameters();
        }

        public double conductance{ get { return s.conductance;}} 
     
        public double evapoTranspirationPriestlyTaylor{ get { return r.evapoTranspirationPriestlyTaylor;}} 
     
        public double evapoTranspirationPenman{ get { return r.evapoTranspirationPenman;}} 
     
        public double netOutGoingLongWaveRadiation{ get { return a.netOutGoingLongWaveRadiation;}} 
     
        public double netRadiation{ get { return a.netRadiation;}} 
     

        public EnergyBalanceCompositeWrapper(Universe universe, EnergyBalanceCompositeWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new EnergyBalanceCompositeState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new EnergyBalanceCompositeRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new EnergyBalanceCompositeAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new EnergyBalanceCompositeExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                energybalancecompositeComponent = (toCopy.energybalancecompositeComponent != null) ? new EnergyBalanceComposite(toCopy.energybalancecompositeComponent) : null;
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
            energybalancecompositeComponent.lambdaV = 2.454; 
            energybalancecompositeComponent.psychrometricConstant = 0.66; 
            energybalancecompositeComponent.Alpha = 1.5; 
            energybalancecompositeComponent.specificHeatCapacityAir = 0.00101; 
            energybalancecompositeComponent.rhoDensityAir = 1.225; 
        }

        public void EstimateEnergyBalanceComposite(double maxTair, double minTair, double vaporPressure, double extraSolarRadiation, double solarRadiation, double plantHeight, double wind, double hslope, double VPDair)
        {
            a.maxTair = maxTair;
            a.minTair = minTair;
            a.vaporPressure = vaporPressure;
            a.extraSolarRadiation = extraSolarRadiation;
            a.solarRadiation = solarRadiation;
            a.plantHeight = plantHeight;
            a.wind = wind;
            a.hslope = hslope;
            a.VPDair = VPDair;
            energybalancecompositeComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}