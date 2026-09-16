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
///  This class encapsulates the PotentialET_PTComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class PotentialET_PTWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private PotentialET_PTState s;
    private PotentialET_PTState s1;
    private PotentialET_PTRate r;
    private PotentialET_PTAuxiliary a;
    private PotentialET_PTExogenous ex;
    private PotentialET_PTComponent potentialet_ptComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the PotentialET_PTComponent
    /// </summary>
    public PotentialET_PTWrapper()
    {
        s = new PotentialET_PTState();
        s1 = new PotentialET_PTState();
        r = new PotentialET_PTRate();
        a = new PotentialET_PTAuxiliary();
        ex = new PotentialET_PTExogenous();
        potentialet_ptComponent = new PotentialET_PTComponent();
    }

    /// <summary>
    ///  The get method of the evapoTranspiration of Priestly Taylor output variable
    /// </summary>
    [Description("evapoTranspiration of Priestly Taylor")]
    [Units("g m-2 d-1")]
    public double evapoTranspirationPriestlyTaylor{ get { return r.evapoTranspirationPriestlyTaylor;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the PotentialET_PTComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PotentialET_PTWrapper(PotentialET_PTWrapper toCopy, bool copyAll) 
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

    /// <summary>
    ///  The Initialization method of the wrapper of the PotentialET_PTComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        potentialet_ptComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the PotentialET_PTComponent
    /// </summary>
    private void loadParameters()
    {
        potentialet_ptComponent.lambdaV = 2.454; 
        potentialet_ptComponent.psychrometricConstant = 0.66; 
        potentialet_ptComponent.Alpha = 1.5; 
        potentialet_ptComponent.ih = -999; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the PotentialET_PTComponent
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
        potentialet_ptComponent.CalculateModel(s,s1, r, a, ex);
    }

}