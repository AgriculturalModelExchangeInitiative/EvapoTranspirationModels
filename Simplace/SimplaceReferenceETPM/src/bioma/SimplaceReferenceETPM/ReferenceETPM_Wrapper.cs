using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_ReferenceETPM_.DomainClass;
using Crop2ML_ReferenceETPM_.Strategies;

namespace Model.Model.ReferenceETPM_
{
    class ReferenceETPM_Wrapper :  UniverseLink
    {
        private ReferenceETPM_State s;
        private ReferenceETPM_State s1;
        private ReferenceETPM_Rate r;
        private ReferenceETPM_Auxiliary a;
        private ReferenceETPM_Exogenous ex;
        private ReferenceETPM_Component referenceetpm_Component;

        public ReferenceETPM_Wrapper(Universe universe) : base(universe)
        {
            s = new ReferenceETPM_State();
            r = new ReferenceETPM_Rate();
            a = new ReferenceETPM_Auxiliary();
            ex = new ReferenceETPM_Exogenous();
            referenceetpm_Component = new ReferenceETPM_();
            loadParameters();
        }

        public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

        public ReferenceETPM_Wrapper(Universe universe, ReferenceETPM_Wrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new ReferenceETPM_State(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new ReferenceETPM_Rate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new ReferenceETPM_Auxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new ReferenceETPM_Exogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                referenceetpm_Component = (toCopy.referenceetpm_Component != null) ? new ReferenceETPM_(toCopy.referenceetpm_Component) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            referenceetpm_Component.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            referenceetpm_Component.cAltitude = 0.0; 
        }

        public void EstimateReferenceETPM_(double iNetRadiation, double iActualVapourPressure, double iTMax, double iTMin, double iWindspeed)
        {
            ex.iNetRadiation = iNetRadiation;
            ex.iActualVapourPressure = iActualVapourPressure;
            ex.iTMax = iTMax;
            ex.iTMin = iTMin;
            ex.iWindspeed = iWindspeed;
            referenceetpm_Component.CalculateModel(s,s1, r, a, ex);
        }

    }

}