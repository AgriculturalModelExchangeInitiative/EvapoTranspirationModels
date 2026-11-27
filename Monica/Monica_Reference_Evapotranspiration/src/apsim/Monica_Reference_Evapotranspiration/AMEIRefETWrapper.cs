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
///  This class encapsulates the AMEIRefETComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class AMEIRefETWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private AMEIRefETState s;
    private AMEIRefETState s1;
    private AMEIRefETRate r;
    private AMEIRefETAuxiliary a;
    private AMEIRefETExogenous ex;
    private AMEIRefETComponent ameirefetComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the AMEIRefETComponent
    /// </summary>
    public AMEIRefETWrapper()
    {
        s = new AMEIRefETState();
        s1 = new AMEIRefETState();
        r = new AMEIRefETRate();
        a = new AMEIRefETAuxiliary();
        ex = new AMEIRefETExogenous();
        ameirefetComponent = new AMEIRefETComponent();
    }

    /// <summary>
    ///  The get method of the reference evapotranspiration (ET0) output variable
    /// </summary>
    [Description("reference evapotranspiration (ET0)")]
    [Units("mm")]
    public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the AMEIRefETComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIRefETWrapper(AMEIRefETWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new AMEIRefETState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new AMEIRefETRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new AMEIRefETAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new AMEIRefETExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            ameirefetComponent = (toCopy.ameirefetComponent != null) ? new AMEIRefETComponent(toCopy.ameirefetComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the AMEIRefETComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        ameirefetComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the AMEIRefETComponent
    /// </summary>
    private void loadParameters()
    {
        ameirefetComponent.height_nn = 0; 
        ameirefetComponent.latent_heat_of_vaporization = 0; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the AMEIRefETComponent
    /// </summary>
    private void setExogenous()
    {
        ex.mean_air_temperature = null; // To be modified
        ex.wind_speed = null; // To be modified
        ex.wind_speed_height = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        ameirefetComponent.CalculateModel(s,s1, r, a, ex);
    }

}