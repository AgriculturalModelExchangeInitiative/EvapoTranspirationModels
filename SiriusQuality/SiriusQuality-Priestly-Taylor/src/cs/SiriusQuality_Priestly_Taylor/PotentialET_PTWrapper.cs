using System;
using System.Collections.Generic;
using System.Linq;
class PotentialET_PTWrapper
{
    private PotentialET_PTState s;
    private PotentialET_PTState s1;
    private PotentialET_PTRate r;
    private PotentialET_PTAuxiliary a;
    private PotentialET_PTExogenous ex;
    private PotentialET_PTComponent potentialet_ptComponent;

    public PotentialET_PTWrapper()
    {
        s = new PotentialET_PTState();
        r = new PotentialET_PTRate();
        a = new PotentialET_PTAuxiliary();
        ex = new PotentialET_PTExogenous();
        potentialet_ptComponent = new PotentialET_PTComponent();
        loadParameters();
    }

        double lambdaV;
    double psychrometricConstant;
    double Alpha;
    int ih;

    public double evapoTranspirationPriestlyTaylor{ get { return r.evapoTranspirationPriestlyTaylor;}} 
     

    public PotentialET_PTWrapper(PotentialET_PTWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new PotentialET_PTState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new PotentialET_PTRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new PotentialET_PTAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new PotentialET_PTExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            potentialet_ptComponent = (toCopy.potentialet_ptComponent != null) ? new PotentialET_PTComponent(toCopy.potentialet_ptComponent) : null;
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

    private void setExogenous()
    {
    }

    public void EstimatePotentialET_PT(double solarRadiation, double hslope, double netRadiation)
    {
        a.solarRadiation = solarRadiation;
        a.hslope = hslope;
        a.netRadiation = netRadiation;
        potentialet_ptComponent.CalculateModel(s,s1, r, a, ex);
    }

}