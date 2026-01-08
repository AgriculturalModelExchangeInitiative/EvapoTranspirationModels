using System;
using System.Collections.Generic;
using System.Linq;
class ReferenceETPM_Wrapper
{
    private ReferenceETPM_State s;
    private ReferenceETPM_State s1;
    private ReferenceETPM_Rate r;
    private ReferenceETPM_Auxiliary a;
    private ReferenceETPM_Exogenous ex;
    private ReferenceETPM_Component referenceetpm_Component;

    public ReferenceETPM_Wrapper()
    {
        s = new ReferenceETPM_State();
        r = new ReferenceETPM_Rate();
        a = new ReferenceETPM_Auxiliary();
        ex = new ReferenceETPM_Exogenous();
        referenceetpm_Component = new ReferenceETPM_Component();
        loadParameters();
    }

        double cAltitude;

    public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

    public ReferenceETPM_Wrapper(ReferenceETPM_Wrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new ReferenceETPM_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new ReferenceETPM_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new ReferenceETPM_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new ReferenceETPM_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            referenceetpm_Component = (toCopy.referenceetpm_Component != null) ? new ReferenceETPM_Component(toCopy.referenceetpm_Component) : null;
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

    private void setExogenous()
    {
        ex.iNetRadiation = null; // To be modified
        ex.iActualVapourPressure = null; // To be modified
        ex.iTMax = null; // To be modified
        ex.iTMin = null; // To be modified
        ex.iWindspeed = null; // To be modified
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