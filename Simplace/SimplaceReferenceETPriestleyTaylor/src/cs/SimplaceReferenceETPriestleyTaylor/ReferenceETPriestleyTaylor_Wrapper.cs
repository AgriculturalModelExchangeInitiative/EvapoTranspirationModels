using System;
using System.Collections.Generic;
using System.Linq;
class ReferenceETPriestleyTaylor_Wrapper
{
    private ReferenceETPriestleyTaylor_State s;
    private ReferenceETPriestleyTaylor_State s1;
    private ReferenceETPriestleyTaylor_Rate r;
    private ReferenceETPriestleyTaylor_Auxiliary a;
    private ReferenceETPriestleyTaylor_Exogenous ex;
    private ReferenceETPriestleyTaylor_Component referenceetpriestleytaylor_Component;

    public ReferenceETPriestleyTaylor_Wrapper()
    {
        s = new ReferenceETPriestleyTaylor_State();
        r = new ReferenceETPriestleyTaylor_Rate();
        a = new ReferenceETPriestleyTaylor_Auxiliary();
        ex = new ReferenceETPriestleyTaylor_Exogenous();
        referenceetpriestleytaylor_Component = new ReferenceETPriestleyTaylor_Component();
        loadParameters();
    }

        double cAlphaPT;
    double cAltitude;

    public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

    public ReferenceETPriestleyTaylor_Wrapper(ReferenceETPriestleyTaylor_Wrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new ReferenceETPriestleyTaylor_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new ReferenceETPriestleyTaylor_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new ReferenceETPriestleyTaylor_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new ReferenceETPriestleyTaylor_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            referenceetpriestleytaylor_Component = (toCopy.referenceetpriestleytaylor_Component != null) ? new ReferenceETPriestleyTaylor_Component(toCopy.referenceetpriestleytaylor_Component) : null;
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

    private void setExogenous()
    {
        ex.iTMin = null; // To be modified
        ex.iNetRadiation = null; // To be modified
        ex.iTMax = null; // To be modified
    }

    public void EstimateReferenceETPriestleyTaylor_(double iTMin, double iNetRadiation, double iTMax)
    {
        ex.iTMin = iTMin;
        ex.iNetRadiation = iNetRadiation;
        ex.iTMax = iTMax;
        referenceetpriestleytaylor_Component.CalculateModel(s,s1, r, a, ex);
    }

}