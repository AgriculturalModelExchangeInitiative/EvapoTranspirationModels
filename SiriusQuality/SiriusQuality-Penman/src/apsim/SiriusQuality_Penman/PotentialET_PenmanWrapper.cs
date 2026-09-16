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
///  This class encapsulates the PotentialET_PenmanComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class PotentialET_PenmanWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private PotentialET_PenmanState s;
    private PotentialET_PenmanState s1;
    private PotentialET_PenmanRate r;
    private PotentialET_PenmanAuxiliary a;
    private PotentialET_PenmanExogenous ex;
    private PotentialET_PenmanComponent potentialet_penmanComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the PotentialET_PenmanComponent
    /// </summary>
    public PotentialET_PenmanWrapper()
    {
        s = new PotentialET_PenmanState();
        s1 = new PotentialET_PenmanState();
        r = new PotentialET_PenmanRate();
        a = new PotentialET_PenmanAuxiliary();
        ex = new PotentialET_PenmanExogenous();
        potentialet_penmanComponent = new PotentialET_PenmanComponent();
    }

    /// <summary>
    ///  The get method of the evapoTranspiration of Penman Monteith output variable
    /// </summary>
    [Description("evapoTranspiration of Penman Monteith")]
    [Units("g m-2 d-1")]
    public double evapoTranspirationPenman{ get { return r.evapoTranspirationPenman;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the PotentialET_PenmanComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PenmanWrapper(PotentialET_PenmanWrapper toCopy, bool copyAll) 
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

    /// <summary>
    ///  The Initialization method of the wrapper of the PotentialET_PenmanComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        potentialet_penmanComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the PotentialET_PenmanComponent
    /// </summary>
    private void loadParameters()
    {
        potentialet_penmanComponent.lambdaV = 2.454; 
        potentialet_penmanComponent.psychrometricConstant = 0.66; 
        potentialet_penmanComponent.Alpha = 1.5; 
        potentialet_penmanComponent.ih = -999; 
        potentialet_penmanComponent.specificHeatCapacityAir = 0.00101; 
        potentialet_penmanComponent.rhoDensityAir = 1.225; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the PotentialET_PenmanComponent
    /// </summary>
    private void setExogenous()
    {
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        potentialet_penmanComponent.CalculateModel(s,s1, r, a, ex);
    }

}