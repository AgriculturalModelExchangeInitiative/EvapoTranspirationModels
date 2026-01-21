using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_pet.DomainClass;
using Crop2ML_pet.Strategies;

namespace Model.Model.pet
{
    class petWrapper :  UniverseLink
    {
        private PetState s;
        private PetState s1;
        private PetRate r;
        private PetAuxiliary a;
        private PetExogenous ex;
        private PetComponent petComponent;

        public petWrapper(Universe universe) : base(universe)
        {
            s = new petState();
            r = new petRate();
            a = new petAuxiliary();
            ex = new petExogenous();
            petComponent = new pet();
            loadParameters();
        }

        public double pet{ get { return s.pet;}} 
     

        public petWrapper(Universe universe, petWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new petState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new petRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new petAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new petExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                petComponent = (toCopy.petComponent != null) ? new pet(toCopy.petComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            petComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            petComponent.ket = 0.5; 
            petComponent.calb = 0.23; 
            petComponent.salb = 0.13; 
        }

        public void EstimatePet(double tmax, double tmin, double srad, double etlai)
        {
            ex.tmax = tmax;
            ex.tmin = tmin;
            ex.srad = srad;
            ex.etlai = etlai;
            petComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}