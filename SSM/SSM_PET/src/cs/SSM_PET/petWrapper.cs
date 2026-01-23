using System;
using System.Collections.Generic;
using System.Linq;
class PetWrapper
{
    private PetState s;
    private PetState s1;
    private PetRate r;
    private PetAuxiliary a;
    private PetExogenous ex;
    private PetComponent petComponent;

    public PetWrapper()
    {
        s = new PetState();
        r = new PetRate();
        a = new PetAuxiliary();
        ex = new PetExogenous();
        petComponent = new PetComponent();
        loadParameters();
    }

        double ket;
    double calb;
    double salb;

    public double pet{ get { return s.pet;}} 
     

    public PetWrapper(PetWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new PetState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new PetRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new PetAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new PetExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            petComponent = (toCopy.petComponent != null) ? new PetComponent(toCopy.petComponent) : null;
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

    private void setExogenous()
    {
        ex.tmax = null; // To be modified
        ex.tmin = null; // To be modified
        ex.srad = null; // To be modified
        ex.etlai = null; // To be modified
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