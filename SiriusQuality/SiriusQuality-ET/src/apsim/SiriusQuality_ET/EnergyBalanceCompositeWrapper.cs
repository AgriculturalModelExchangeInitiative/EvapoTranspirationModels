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
///  This class encapsulates the EnergyBalanceCompositeComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class EnergyBalanceCompositeWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private EnergyBalanceCompositeState s;
    private EnergyBalanceCompositeState s1;
    private EnergyBalanceCompositeRate r;
    private EnergyBalanceCompositeAuxiliary a;
    private EnergyBalanceCompositeExogenous ex;
    private EnergyBalanceCompositeComponent energybalancecompositeComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the EnergyBalanceCompositeComponent
    /// </summary>
    public EnergyBalanceCompositeWrapper()
    {
        s = new EnergyBalanceCompositeState();
        s1 = new EnergyBalanceCompositeState();
        r = new EnergyBalanceCompositeRate();
        a = new EnergyBalanceCompositeAuxiliary();
        ex = new EnergyBalanceCompositeExogenous();
        energybalancecompositeComponent = new EnergyBalanceCompositeComponent();
    }

    /// <summary>
    ///  The get method of the the boundary layer conductance output variable
    /// </summary>
    [Description("the boundary layer conductance")]
    [Units("m/d")]
    public double conductance{ get { return s.conductance;}} 
     

    /// <summary>
    ///  The get method of the evapoTranspiration of Priestly Taylor output variable
    /// </summary>
    [Description("evapoTranspiration of Priestly Taylor")]
    [Units("g m-2 d-1")]
    public double evapoTranspirationPriestlyTaylor{ get { return r.evapoTranspirationPriestlyTaylor;}} 
     

    /// <summary>
    ///  The get method of the evapoTranspiration of Penman Monteith output variable
    /// </summary>
    [Description("evapoTranspiration of Penman Monteith")]
    [Units("g m-2 d-1")]
    public double evapoTranspirationPenman{ get { return r.evapoTranspirationPenman;}} 
     

    /// <summary>
    ///  The get method of the net OutGoing Long Wave Radiation output variable
    /// </summary>
    [Description("net OutGoing Long Wave Radiation")]
    [Units("g m-2 d-1")]
    public double netOutGoingLongWaveRadiation{ get { return a.netOutGoingLongWaveRadiation;}} 
     

    /// <summary>
    ///  The get method of the net radiation output variable
    /// </summary>
    [Description("net radiation")]
    [Units("MJ m-2 d-1")]
    public double netRadiation{ get { return a.netRadiation;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the EnergyBalanceCompositeComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public EnergyBalanceCompositeWrapper(EnergyBalanceCompositeWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new EnergyBalanceCompositeState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new EnergyBalanceCompositeRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new EnergyBalanceCompositeAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new EnergyBalanceCompositeExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            energybalancecompositeComponent = (toCopy.energybalancecompositeComponent != null) ? new EnergyBalanceCompositeComponent(toCopy.energybalancecompositeComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the EnergyBalanceCompositeComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        energybalancecompositeComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the EnergyBalanceCompositeComponent
    /// </summary>
    private void loadParameters()
    {
        energybalancecompositeComponent.albedoCoefficient = 0.23; 
        energybalancecompositeComponent.tau = null; // To be modified
        energybalancecompositeComponent.elevation = 0; 
        energybalancecompositeComponent.stefanBoltzman = 4.903E-09; 
        energybalancecompositeComponent.albedoCoefficientCan = 0.23; 
        energybalancecompositeComponent.d = 0.67; 
        energybalancecompositeComponent.heightWeatherMeasurements = null; // To be modified
        energybalancecompositeComponent.zh = 0.013; 
        energybalancecompositeComponent.zm = 0.13; 
        energybalancecompositeComponent.vonKarman = 0.42; 
        energybalancecompositeComponent.lambdaV = 2.454; 
        energybalancecompositeComponent.psychrometricConstant = 0.66; 
        energybalancecompositeComponent.Alpha = 1.5; 
        energybalancecompositeComponent.specificHeatCapacityAir = 0.00101; 
        energybalancecompositeComponent.rhoDensityAir = 1.225; 
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the EnergyBalanceCompositeComponent
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
        energybalancecompositeComponent.CalculateModel(s,s1, r, a, ex);
    }

}