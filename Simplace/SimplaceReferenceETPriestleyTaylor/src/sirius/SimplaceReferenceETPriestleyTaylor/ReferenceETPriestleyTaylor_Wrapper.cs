using System;
using System.Collections.Generic;
using System.Linq;
using SQCrop2ML_ReferenceETPriestleyTaylor_.DomainClass;
using SQCrop2ML_ReferenceETPriestleyTaylor_.Strategies;

namespace SiriusModel.Model.ReferenceETPriestleyTaylor_
{
    class ReferenceETPriestleyTaylor_Wrapper :  UniverseLink
    {
        private ReferenceETPriestleyTaylor_State s;
        private ReferenceETPriestleyTaylor_State s1;
        private ReferenceETPriestleyTaylor_Rate r;
        private ReferenceETPriestleyTaylor_Auxiliary a;
        private ReferenceETPriestleyTaylor_Exogenous ex;
        private ReferenceETPriestleyTaylor_Component referenceetpriestleytaylor_Component;

        public ReferenceETPriestleyTaylor_Wrapper(Universe universe) : base(universe)
        {
            s = new ReferenceETPriestleyTaylor_State();
            r = new ReferenceETPriestleyTaylor_Rate();
            a = new ReferenceETPriestleyTaylor_Auxiliary();
            ex = new ReferenceETPriestleyTaylor_Exogenous();
            referenceetpriestleytaylor_Component = new ReferenceETPriestleyTaylor_();
            loadParameters();
        }

        public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

        public ReferenceETPriestleyTaylor_Wrapper(Universe universe, ReferenceETPriestleyTaylor_Wrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new ReferenceETPriestleyTaylor_State(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new ReferenceETPriestleyTaylor_Rate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new ReferenceETPriestleyTaylor_Auxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new ReferenceETPriestleyTaylor_Exogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                referenceetpriestleytaylor_Component = (toCopy.referenceetpriestleytaylor_Component != null) ? new ReferenceETPriestleyTaylor_(toCopy.referenceetpriestleytaylor_Component) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            referenceetpriestleytaylor_Component.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            referenceetpriestleytaylor_Component.cAlphaPT = 1.26; 
            referenceetpriestleytaylor_Component.cAltitude = 0.0; 
        }

        public void EstimateReferenceETPriestleyTaylor_(double iTMin, double iNetRadiation, double iTMax)
        {
            ex.iTMin = iTMin;
            ex.iNetRadiation = iNetRadiation;
            ex.iTMax = iTMax;
            referenceetpriestleytaylor_Component.CalculateModel(s,s1, r, a, ex);
        }

    }

}