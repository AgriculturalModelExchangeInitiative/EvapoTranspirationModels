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
///  This class encapsulates the PetComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class PetWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private PetState s;
    private PetState s1;
    private PetRate r;
    private PetAuxiliary a;
    private PetExogenous ex;
    private PetComponent petComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the PetComponent
    /// </summary>
    public PetWrapper()
    {
        s = new PetState();
        s1 = new PetState();
        r = new PetRate();
        a = new PetAuxiliary();
        ex = new PetExogenous();
        petComponent = new PetComponent();
    }

    /// <summary>
    ///  The get method of the Potential evapotranspiration output variable
    /// </summary>
    [Description("Potential evapotranspiration")]
    [Units("mm day-1")]
    public double pet{ get { return s.pet;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the PetComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public PetWrapper(PetWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new PetState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new PetRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new PetAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new PetExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            petComponent = (toCopy.petComponent != null) ? new PetComponent(toCopy.petComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the PetComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        petComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the PetComponent
    /// </summary>
    private void loadParameters()
    {
        petComponent.ket = 0.5; 
        petComponent.calb = 0.23; 
        petComponent.salb = 0.13; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the PetComponent
    /// </summary>
    private void setExogenous()
    {
        ex.tmax = null; // To be modified
        ex.tmin = null; // To be modified
        ex.srad = null; // To be modified
        ex.etlai = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        petComponent.CalculateModel(s,s1, r, a, ex);
    }

}