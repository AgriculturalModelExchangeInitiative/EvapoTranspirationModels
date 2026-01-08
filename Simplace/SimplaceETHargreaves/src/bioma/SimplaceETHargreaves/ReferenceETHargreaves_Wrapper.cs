using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_ReferenceETHargreaves_.DomainClass;
using Crop2ML_ReferenceETHargreaves_.Strategies;

namespace Model.Model.ReferenceETHargreaves_
{
    class ReferenceETHargreaves_Wrapper :  UniverseLink
    {
        private ReferenceETHargreaves_State s;
        private ReferenceETHargreaves_State s1;
        private ReferenceETHargreaves_Rate r;
        private ReferenceETHargreaves_Auxiliary a;
        private ReferenceETHargreaves_Exogenous ex;
        private ReferenceETHargreaves_Component referenceethargreaves_Component;

        public ReferenceETHargreaves_Wrapper(Universe universe) : base(universe)
        {
            s = new ReferenceETHargreaves_State();
            r = new ReferenceETHargreaves_Rate();
            a = new ReferenceETHargreaves_Auxiliary();
            ex = new ReferenceETHargreaves_Exogenous();
            referenceethargreaves_Component = new ReferenceETHargreaves_();
            loadParameters();
        }

        public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

        public ReferenceETHargreaves_Wrapper(Universe universe, ReferenceETHargreaves_Wrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new ReferenceETHargreaves_State(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new ReferenceETHargreaves_Rate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new ReferenceETHargreaves_Auxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new ReferenceETHargreaves_Exogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                referenceethargreaves_Component = (toCopy.referenceethargreaves_Component != null) ? new ReferenceETHargreaves_(toCopy.referenceethargreaves_Component) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            referenceethargreaves_Component.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            referenceethargreaves_Component.cConvertLeByTemp = false; 
        }

        public void EstimateReferenceETHargreaves_(double iTMax, double iSolarRadiation, double iTMin)
        {
            ex.iTMax = iTMax;
            ex.iSolarRadiation = iSolarRadiation;
            ex.iTMin = iTMin;
            referenceethargreaves_Component.CalculateModel(s,s1, r, a, ex);
        }

    }

}