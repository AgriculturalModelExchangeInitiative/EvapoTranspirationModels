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
///  This class encapsulates the AMEIPotETComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class AMEIPotETWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private AMEIPotETState s;
    private AMEIPotETState s1;
    private AMEIPotETRate r;
    private AMEIPotETAuxiliary a;
    private AMEIPotETExogenous ex;
    private AMEIPotETComponent ameipotetComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the AMEIPotETComponent
    /// </summary>
    public AMEIPotETWrapper()
    {
        s = new AMEIPotETState();
        s1 = new AMEIPotETState();
        r = new AMEIPotETRate();
        a = new AMEIPotETAuxiliary();
        ex = new AMEIPotETExogenous();
        ameipotetComponent = new AMEIPotETComponent();
    }

    /// <summary>
    ///  The get method of the reference evapotranspiration (ET0) output variable
    /// </summary>
    [Description("reference evapotranspiration (ET0)")]
    [Units("mm")]
    public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     

    /// <summary>
    ///  The get method of the the potential evapotranspiration output variable
    /// </summary>
    [Description("the potential evapotranspiration")]
    [Units("mm")]
    public double potential_evapotranspiration{ get { return a.potential_evapotranspiration;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the AMEIPotETComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public AMEIPotETWrapper(AMEIPotETWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new AMEIPotETState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new AMEIPotETRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new AMEIPotETAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new AMEIPotETExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            ameipotetComponent = (toCopy.ameipotetComponent != null) ? new AMEIPotETComponent(toCopy.ameipotetComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the AMEIPotETComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        ameipotetComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the AMEIPotETComponent
    /// </summary>
    private void loadParameters()
    {
        ameipotetComponent.height_nn = 0; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the AMEIPotETComponent
    /// </summary>
    private void setExogenous()
    {
        ex.mean_air_temperature = null; // To be modified
        ex.wind_speed = null; // To be modified
        ex.wind_speed_height = null; // To be modified
        ex.kc_factor = null; // To be modified
        ex.developmental_stage = null; // To be modified
        ex.crop_remaining_evapotranspiration = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        ameipotetComponent.CalculateModel(s,s1, r, a, ex);
    }

}