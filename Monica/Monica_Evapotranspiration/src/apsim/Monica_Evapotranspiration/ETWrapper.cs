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
///  This class encapsulates the ETComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class ETWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private ETState s;
    private ETState s1;
    private ETRate r;
    private ETAuxiliary a;
    private ETExogenous ex;
    private ETComponent etComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the ETComponent
    /// </summary>
    public ETWrapper()
    {
        s = new ETState();
        s1 = new ETState();
        r = new ETRate();
        a = new ETAuxiliary();
        ex = new ETExogenous();
        etComponent = new ETComponent();
    }

    /// <summary>
    ///  The get method of the declination output variable
    /// </summary>
    [Description("declination")]
    [Units("")]
    public double declination{ get { return a.declination;}} 
     

    /// <summary>
    ///  The get method of the astronomic_daylength output variable
    /// </summary>
    [Description("astronomic_daylength")]
    [Units("mm")]
    public double astronomic_daylength{ get { return a.astronomic_daylength;}} 
     

    /// <summary>
    ///  The get method of the effective_daylength output variable
    /// </summary>
    [Description("effective_daylength")]
    [Units("mm")]
    public double effective_daylength{ get { return a.effective_daylength;}} 
     

    /// <summary>
    ///  The get method of the photoperiodic_daylength output variable
    /// </summary>
    [Description("photoperiodic_daylength")]
    [Units("mm")]
    public double photoperiodic_daylength{ get { return a.photoperiodic_daylength;}} 
     

    /// <summary>
    ///  The get method of the global radiation calculated from sunshine hours output variable
    /// </summary>
    [Description("global radiation calculated from sunshine hours")]
    [Units("MJ/m2")]
    public double sunshine_hours_global_radiation{ get { return a.sunshine_hours_global_radiation;}} 
     

    /// <summary>
    ///  The get method of the extraterrestrial_radiation output variable
    /// </summary>
    [Description("extraterrestrial_radiation")]
    [Units("MJ/m2")]
    public double extraterrestrial_radiation{ get { return a.extraterrestrial_radiation;}} 
     

    /// <summary>
    ///  The get method of the clear_day_radiation output variable
    /// </summary>
    [Description("clear_day_radiation")]
    [Units("MJ/m2")]
    public double clear_day_radiation{ get { return a.clear_day_radiation;}} 
     

    /// <summary>
    ///  The get method of the overcast_day_radiation output variable
    /// </summary>
    [Description("overcast_day_radiation")]
    [Units("MJ/m2")]
    public double overcast_day_radiation{ get { return a.overcast_day_radiation;}} 
     

    /// <summary>
    ///  The get method of the phot_act_radiation_mean output variable
    /// </summary>
    [Description("phot_act_radiation_mean")]
    [Units("J/m2")]
    public double phot_act_radiation_mean{ get { return a.phot_act_radiation_mean;}} 
     

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
    ///  The Constructor copy of the wrapper of the ETComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ETWrapper(ETWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new ETState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new ETRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new ETAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new ETExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            etComponent = (toCopy.etComponent != null) ? new ETComponent(toCopy.etComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the ETComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        etComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the ETComponent
    /// </summary>
    private void loadParameters()
    {
        etComponent.latitude = 0; 
        etComponent.reference_albedo = 0; 
        etComponent.height_nn = 0; 
        etComponent.saturation_beta = 2.5; 
        etComponent.stomata_conductance_alpha = 40; 
        etComponent.carboxylation_pathway = 0; 
        etComponent.evaporation_zeta = 40; 
        etComponent.maximum_evaporation_impact_depth = 5; 
        etComponent.evaporation_reduction_method = 1; 
        etComponent.xsa_critical_soil_moisture = 0.1; 
        etComponent.no_of_soil_layers = 20; 
        etComponent.no_of_soil_moisture_layers = 21; 
        etComponent.layer_thickness = null; // To be modified
        etComponent.permanent_wilting_point = null; // To be modified
        etComponent.field_capacity = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the ETComponent
    /// </summary>
    private void setExogenous()
    {
        ex.global_radiation = null; // To be modified
        ex.julian_day = null; // To be modified
        ex.sunshine_hours = null; // To be modified
        ex.max_air_temperature = null; // To be modified
        ex.min_air_temperature = null; // To be modified
        ex.relative_humidity = null; // To be modified
        ex.atmospheric_co2_concentration = null; // To be modified
        ex.mean_air_temperature = null; // To be modified
        ex.wind_speed = null; // To be modified
        ex.wind_speed_height = null; // To be modified
        ex.kc_factor = null; // To be modified
        ex.developmental_stage = null; // To be modified
        ex.crop_remaining_evapotranspiration = null; // To be modified
        ex.has_snow_cover = null; // To be modified
        ex.crop_transpiration = null; // To be modified
        ex.crop_evaporated_from_intercepted = null; // To be modified
        ex.percentage_soil_coverage = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        etComponent.CalculateModel(s,s1, r, a, ex);
    }

}