using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_PotentialET_PT.DomainClass;
using Crop2ML_PotentialET_PT.Strategies;

namespace Model.Model.PotentialET_PT
{
    class PotentialET_PTWrapper :  UniverseLink
    {
        private PotentialET_PTState s;
        private PotentialET_PTState s1;
        private PotentialET_PTRate r;
        private PotentialET_PTAuxiliary a;
        private PotentialET_PTExogenous ex;
        private PotentialET_PTComponent potentialet_ptComponent;

        public PotentialET_PTWrapper(Universe universe) : base(universe)
        {
            s = new PotentialET_PTState();
            r = new PotentialET_PTRate();
            a = new PotentialET_PTAuxiliary();
            ex = new PotentialET_PTExogenous();
            potentialet_ptComponent = new PotentialET_PT();
            loadParameters();
        }

        public double evapoTranspirationPriestlyTaylor{ get { return r.evapoTranspirationPriestlyTaylor;}} 
     

        public PotentialET_PTWrapper(Universe universe, PotentialET_PTWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new PotentialET_PTState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new PotentialET_PTRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new PotentialET_PTAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new PotentialET_PTExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                potentialet_ptComponent = (toCopy.potentialet_ptComponent != null) ? new PotentialET_PT(toCopy.potentialet_ptComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            potentialet_ptComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            potentialet_ptComponent.lambdaV = 2.454; 
            potentialet_ptComponent.psychrometricConstant = 0.66; 
            potentialet_ptComponent.Alpha = 1.5; 
            potentialet_ptComponent.ih = -999; 
        }

        public void EstimatePotentialET_PT(double solarRadiation, double hslope, double netRadiation)
        {
            a.solarRadiation = solarRadiation;
            a.hslope = hslope;
            a.netRadiation = netRadiation;
            potentialet_ptComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}