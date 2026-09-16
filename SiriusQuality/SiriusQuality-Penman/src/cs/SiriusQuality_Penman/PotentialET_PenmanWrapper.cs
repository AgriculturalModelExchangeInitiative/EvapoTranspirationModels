using System;
using System.Collections.Generic;
using System.Linq;
class PotentialET_PenmanWrapper
{
    private PotentialET_PenmanState s;
    private PotentialET_PenmanState s1;
    private PotentialET_PenmanRate r;
    private PotentialET_PenmanAuxiliary a;
    private PotentialET_PenmanExogenous ex;
    private PotentialET_PenmanComponent potentialet_penmanComponent;

    public PotentialET_PenmanWrapper()
    {
        s = new PotentialET_PenmanState();
        r = new PotentialET_PenmanRate();
        a = new PotentialET_PenmanAuxiliary();
        ex = new PotentialET_PenmanExogenous();
        potentialet_penmanComponent = new PotentialET_PenmanComponent();
        loadParameters();
    }

        double lambdaV;
    double psychrometricConstant;
    double Alpha;
    int ih;
    double specificHeatCapacityAir;
    double rhoDensityAir;

    public double evapoTranspirationPenman{ get { return r.evapoTranspirationPenman;}} 
     

    public PotentialET_PenmanWrapper(PotentialET_PenmanWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new PotentialET_PenmanState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new PotentialET_PenmanRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new PotentialET_PenmanAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new PotentialET_PenmanExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            potentialet_penmanComponent = (toCopy.potentialet_penmanComponent != null) ? new PotentialET_PenmanComponent(toCopy.potentialet_penmanComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        potentialet_penmanComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        potentialet_penmanComponent.lambdaV = 2.454; 
        potentialet_penmanComponent.psychrometricConstant = 0.66; 
        potentialet_penmanComponent.Alpha = 1.5; 
        potentialet_penmanComponent.ih = -999; 
        potentialet_penmanComponent.specificHeatCapacityAir = 0.00101; 
        potentialet_penmanComponent.rhoDensityAir = 1.225; 
    }

    private void setExogenous()
    {
    }

    public void EstimatePotentialET_Penman(double netRadiation, double solarRadiation, double hslope, double VPDair, double conductance)
    {
        a.netRadiation = netRadiation;
        a.solarRadiation = solarRadiation;
        a.hslope = hslope;
        a.VPDair = VPDair;
        a.conductance = conductance;
        potentialet_penmanComponent.CalculateModel(s,s1, r, a, ex);
    }

}