using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  ET component
/// </summary>
public class ETComponent 
{

    /// <summary>
    ///  constructor of ET component
    /// </summary>
    public ETComponent() {}

    //Declaration of the associated strategies
    Radiation _Radiation = new Radiation();
    NetRadiation _NetRadiation = new NetRadiation();
    StomataResistance _StomataResistance = new StomataResistance();
    CalcStomataResistance _CalcStomataResistance = new CalcStomataResistance();
    SaturatedVaporPressure _SaturatedVaporPressure = new SaturatedVaporPressure();
    SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();
    Evapotranspiration _Evapotranspiration = new Evapotranspiration();
    UseExtET0 _UseExtET0 = new UseExtET0();
    UseExtVaporPressure _UseExtVaporPressure = new UseExtVaporPressure();

    /// <summary>
    /// Gets and sets the latitude
    /// </summary>
    [Description("latitude")] 
    [Units("degree")] 
    public double latitude
    {
        get
        {
             return _Radiation.latitude; 
        }
        set
        {
            _Radiation.latitude = value;
        }
    }

    /// <summary>
    /// Gets and sets the reference albedo
    /// </summary>
    [Description("reference albedo")] 
    [Units("dimensionless")] 
    public double reference_albedo
    {
        get
        {
             return _NetRadiation.reference_albedo; 
        }
        set
        {
            _NetRadiation.reference_albedo = value;
        }
    }

    /// <summary>
    /// Gets and sets the height above sea level
    /// </summary>
    [Description("height above sea level")] 
    [Units("m")] 
    public double height_nn
    {
        get
        {
             return _NetRadiation.height_nn; 
        }
        set
        {
            _NetRadiation.height_nn = value;
            _ReferenceEvapotranspiration.height_nn = value;
        }
    }

    /// <summary>
    /// Gets and sets the Original: Yu et al. 2001; beta = 3.5
    /// </summary>
    [Description("Original: Yu et al. 2001; beta = 3.5")] 
    [Units("")] 
    public double saturation_beta
    {
        get
        {
             return _StomataResistance.saturation_beta; 
        }
        set
        {
            _StomataResistance.saturation_beta = value;
        }
    }

    /// <summary>
    /// Gets and sets the Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
    /// </summary>
    [Description("Original: Yu et al. 2001; alpha = 0.06 mol/m2/s")] 
    [Units("mmol/m2/s")] 
    public double stomata_conductance_alpha
    {
        get
        {
             return _StomataResistance.stomata_conductance_alpha; 
        }
        set
        {
            _StomataResistance.stomata_conductance_alpha = value;
        }
    }

    /// <summary>
    /// Gets and sets the Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
    /// </summary>
    [Description("Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)")] 
    [Units("dimensionless")] 
    public int carboxylation_pathway
    {
        get
        {
             return _StomataResistance.carboxylation_pathway; 
        }
        set
        {
            _StomataResistance.carboxylation_pathway = value;
        }
    }

    /// <summary>
    /// Gets and sets the shape factor
    /// </summary>
    [Description("shape factor")] 
    [Units("dimensionless")] 
    public double evaporation_zeta
    {
        get
        {
             return _Evapotranspiration.evaporation_zeta; 
        }
        set
        {
            _Evapotranspiration.evaporation_zeta = value;
        }
    }

    /// <summary>
    /// Gets and sets the maximumEvaporationImpactDepth
    /// </summary>
    [Description("maximumEvaporationImpactDepth")] 
    [Units("dm")] 
    public double maximum_evaporation_impact_depth
    {
        get
        {
             return _Evapotranspiration.maximum_evaporation_impact_depth; 
        }
        set
        {
            _Evapotranspiration.maximum_evaporation_impact_depth = value;
        }
    }

    /// <summary>
    /// Gets and sets the THESEUS (0) or HERMES (1) evaporation reduction method
    /// </summary>
    [Description("THESEUS (0) or HERMES (1) evaporation reduction method")] 
    [Units("dimensionless")] 
    public int evaporation_reduction_method
    {
        get
        {
             return _Evapotranspiration.evaporation_reduction_method; 
        }
        set
        {
            _Evapotranspiration.evaporation_reduction_method = value;
        }
    }

    /// <summary>
    /// Gets and sets the XSACriticalSoilMoisture
    /// </summary>
    [Description("XSACriticalSoilMoisture")] 
    [Units("m3/m3")] 
    public double xsa_critical_soil_moisture
    {
        get
        {
             return _Evapotranspiration.xsa_critical_soil_moisture; 
        }
        set
        {
            _Evapotranspiration.xsa_critical_soil_moisture = value;
        }
    }

    /// <summary>
    /// Gets and sets the number of soil layers
    /// </summary>
    [Description("number of soil layers")] 
    [Units("dimensionless")] 
    public int no_of_soil_layers
    {
        get
        {
             return _Evapotranspiration.no_of_soil_layers; 
        }
        set
        {
            _Evapotranspiration.no_of_soil_layers = value;
        }
    }

    /// <summary>
    /// Gets and sets the number of soil layers + 1
    /// </summary>
    [Description("number of soil layers + 1")] 
    [Units("dimensionless")] 
    public int no_of_soil_moisture_layers
    {
        get
        {
             return _Evapotranspiration.no_of_soil_moisture_layers; 
        }
        set
        {
            _Evapotranspiration.no_of_soil_moisture_layers = value;
        }
    }

    /// <summary>
    /// Gets and sets the layer thickness array
    /// </summary>
    [Description("layer thickness array")] 
    [Units("m")] 
    public double[] layer_thickness
    {
        get
        {
             return _Evapotranspiration.layer_thickness; 
        }
        set
        {
            _Evapotranspiration.layer_thickness = value;
        }
    }

    /// <summary>
    /// Gets and sets the permanent wilting point array
    /// </summary>
    [Description("permanent wilting point array")] 
    [Units("m3/m3")] 
    public double[] permanent_wilting_point
    {
        get
        {
             return _Evapotranspiration.permanent_wilting_point; 
        }
        set
        {
            _Evapotranspiration.permanent_wilting_point = value;
        }
    }

    /// <summary>
    /// Gets and sets the field capacity array
    /// </summary>
    [Description("field capacity array")] 
    [Units("m3/m3")] 
    public double[] field_capacity
    {
        get
        {
             return _Evapotranspiration.field_capacity; 
        }
        set
        {
            _Evapotranspiration.field_capacity = value;
        }
    }

    /// <summary>
    /// Algorithm of ET component
    /// </summary>
    public void CalculateModel(ETState s,ETState s1,ETRate r,ETAuxiliary a,ETExogenous ex)
    {
        _Radiation.CalculateModel(s,s1, r, a, ex);
        _SaturatedVaporPressure.CalculateModel(s,s1, r, a, ex);
        a.internal_vapor_pressure = a.vapor_pressure;
        _UseExtVaporPressure.CalculateModel(s,s1, r, a, ex);
        _NetRadiation.CalculateModel(s,s1, r, a, ex);
        _SaturationVaporPressureDeficit.CalculateModel(s,s1, r, a, ex);
        _StomataResistance.CalculateModel(s,s1, r, a, ex);
        a.calculated_stomata_resistance = a.stomata_resistance;
        _CalcStomataResistance.CalculateModel(s,s1, r, a, ex);
        _ReferenceEvapotranspiration.CalculateModel(s,s1, r, a, ex);
        a.internal_et0 = a.reference_evapotranspiration;
        _UseExtET0.CalculateModel(s,s1, r, a, ex);
        a.reference_evapotranspiration = a.et0;
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
        _Evapotranspiration.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// initialization of the ET component
    /// </summary>
    public void Init(ETState s,ETState s1,ETRate r,ETAuxiliary a,ETExogenous ex)
    {
        _Evapotranspiration.Init(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of ET component
    /// </summary>
    public void Init(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        _Evapotranspiration.Init(s, s1, r, a, ex);
    }

    /// <summary>
    /// constructor copy of ET component
    /// </summary>
    /// <param name="toCopy"></param>
    public ETComponent(ETComponent toCopy): this() // copy constructor 
    {
        latitude = toCopy.latitude;
        reference_albedo = toCopy.reference_albedo;
        height_nn = toCopy.height_nn;
        saturation_beta = toCopy.saturation_beta;
        stomata_conductance_alpha = toCopy.stomata_conductance_alpha;
        carboxylation_pathway = toCopy.carboxylation_pathway;
        evaporation_zeta = toCopy.evaporation_zeta;
        maximum_evaporation_impact_depth = toCopy.maximum_evaporation_impact_depth;
        evaporation_reduction_method = toCopy.evaporation_reduction_method;
        xsa_critical_soil_moisture = toCopy.xsa_critical_soil_moisture;
        no_of_soil_layers = toCopy.no_of_soil_layers;
        no_of_soil_moisture_layers = toCopy.no_of_soil_moisture_layers;
        
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { layer_thickness[i] = toCopy.layer_thickness[i]; }
    
        
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { permanent_wilting_point[i] = toCopy.permanent_wilting_point[i]; }
    
        
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { field_capacity[i] = toCopy.field_capacity[i]; }
    
}
}