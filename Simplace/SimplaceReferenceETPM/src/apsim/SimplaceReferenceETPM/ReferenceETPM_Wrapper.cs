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
///  This class encapsulates the ReferenceETPM_Component
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class ReferenceETPM_Wrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private ReferenceETPM_State s;
    private ReferenceETPM_State s1;
    private ReferenceETPM_Rate r;
    private ReferenceETPM_Auxiliary a;
    private ReferenceETPM_Exogenous ex;
    private ReferenceETPM_Component referenceetpm_Component;

    /// <summary>
    ///  The constructor of the Wrapper of the ReferenceETPM_Component
    /// </summary>
    public ReferenceETPM_Wrapper()
    {
        s = new ReferenceETPM_State();
        s1 = new ReferenceETPM_State();
        r = new ReferenceETPM_Rate();
        a = new ReferenceETPM_Auxiliary();
        ex = new ReferenceETPM_Exogenous();
        referenceetpm_Component = new ReferenceETPM_Component();
    }

    /// <summary>
    ///  The get method of the reference evapotranspiration (ET0) output variable
    /// </summary>
    [Description("reference evapotranspiration (ET0)")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day")]
    public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the ReferenceETPM_Component
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETPM_Wrapper(ReferenceETPM_Wrapper toCopy, bool copyAll) 
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

    /// <summary>
    ///  The Initialization method of the wrapper of the ReferenceETPM_Component
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        referenceetpm_Component.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the ReferenceETPM_Component
    /// </summary>
    private void loadParameters()
    {
        referenceetpm_Component.cAltitude = 0.0; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the ReferenceETPM_Component
    /// </summary>
    private void setExogenous()
    {
        ex.iNetRadiation = null; // To be modified
        ex.iActualVapourPressure = null; // To be modified
        ex.iTMax = null; // To be modified
        ex.iTMin = null; // To be modified
        ex.iWindspeed = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        referenceetpm_Component.CalculateModel(s,s1, r, a, ex);
    }

}