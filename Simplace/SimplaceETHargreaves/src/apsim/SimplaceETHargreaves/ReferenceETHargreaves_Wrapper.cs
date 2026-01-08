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
///  This class encapsulates the ReferenceETHargreaves_Component
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class ReferenceETHargreaves_Wrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private ReferenceETHargreaves_State s;
    private ReferenceETHargreaves_State s1;
    private ReferenceETHargreaves_Rate r;
    private ReferenceETHargreaves_Auxiliary a;
    private ReferenceETHargreaves_Exogenous ex;
    private ReferenceETHargreaves_Component referenceethargreaves_Component;

    /// <summary>
    ///  The constructor of the Wrapper of the ReferenceETHargreaves_Component
    /// </summary>
    public ReferenceETHargreaves_Wrapper()
    {
        s = new ReferenceETHargreaves_State();
        s1 = new ReferenceETHargreaves_State();
        r = new ReferenceETHargreaves_Rate();
        a = new ReferenceETHargreaves_Auxiliary();
        ex = new ReferenceETHargreaves_Exogenous();
        referenceethargreaves_Component = new ReferenceETHargreaves_Component();
    }

    /// <summary>
    ///  The get method of the reference evapotranspiration (ET0) output variable
    /// </summary>
    [Description("reference evapotranspiration (ET0)")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day")]
    public double ReferenceCropEvapotranspiration{ get { return a.ReferenceCropEvapotranspiration;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the ReferenceETHargreaves_Component
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ReferenceETHargreaves_Wrapper(ReferenceETHargreaves_Wrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new ReferenceETHargreaves_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new ReferenceETHargreaves_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new ReferenceETHargreaves_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new ReferenceETHargreaves_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            referenceethargreaves_Component = (toCopy.referenceethargreaves_Component != null) ? new ReferenceETHargreaves_Component(toCopy.referenceethargreaves_Component) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the ReferenceETHargreaves_Component
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        referenceethargreaves_Component.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the ReferenceETHargreaves_Component
    /// </summary>
    private void loadParameters()
    {
        referenceethargreaves_Component.cConvertLeByTemp = false; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the ReferenceETHargreaves_Component
    /// </summary>
    private void setExogenous()
    {
        ex.iTMax = null; // To be modified
        ex.iSolarRadiation = null; // To be modified
        ex.iTMin = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        referenceethargreaves_Component.CalculateModel(s,s1, r, a, ex);
    }

}