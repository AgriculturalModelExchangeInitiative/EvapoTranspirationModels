using APSIM.Shared.Utilities;
using Models.Climate;
using Models.Core;
using Models.Interfaces;
using Models.PMF;
using Models.Soils;
using Models.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Models.Crop2ML;

/// <summary>
///  This class encapsulates the ReferenceETPriestleyTaylor_Component
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class ReferenceETPriestleyTaylor_Wrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private ReferenceETPriestleyTaylor_State s;
    private ReferenceETPriestleyTaylor_State s1;
    private ReferenceETPriestleyTaylor_Rate r;
    private ReferenceETPriestleyTaylor_Auxiliary a;
    private ReferenceETPriestleyTaylor_Exogenous ex;
    private ReferenceETPriestleyTaylor_Component referenceetpriestleytaylor_Component;

    /// <summary>
    ///  The constructor of the Wrapper of the ReferenceETPriestleyTaylor_Component
    /// </summary>
    public ReferenceETPriestleyTaylor_Wrapper()
    {
        s = new ReferenceETPriestleyTaylor_State();
        s1 = new ReferenceETPriestleyTaylor_State();
        r = new ReferenceETPriestleyTaylor_Rate();
        a = new ReferenceETPriestleyTaylor_Auxiliary();
        ex = new ReferenceETPriestleyTaylor_Exogenous();
        referenceetpriestleytaylor_Component = new ReferenceETPriestleyTaylor_Component();
    }

    /// <summary>
    ///  The get method of the reference evapotranspiration (ET0) output variable
    /// </summary>
    [Description("reference evapotranspiration (ET0)")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day")]
    public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the ReferenceETPriestleyTaylor_Component
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETPriestleyTaylor_Wrapper(ReferenceETPriestleyTaylor_Wrapper toCopy, bool copyAll) 
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

    /// <summary>
    ///  The Initialization method of the wrapper of the ReferenceETPriestleyTaylor_Component
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        referenceetpriestleytaylor_Component.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the ReferenceETPriestleyTaylor_Component
    /// </summary>
    private void loadParameters()
    {
        referenceetpriestleytaylor_Component.cAlphaPT = 1.26; 
        referenceetpriestleytaylor_Component.cAltitude = 0.0; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the ReferenceETPriestleyTaylor_Component
    /// </summary>
    private void setExogenous()
    {
        ex.iTMin = null; // To be modified
        ex.iNetRadiation = null; // To be modified
        ex.iTMax = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        referenceetpriestleytaylor_Component.CalculateModel(s,s1, r, a, ex);
    }

}