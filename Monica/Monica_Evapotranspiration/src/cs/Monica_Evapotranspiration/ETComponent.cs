public class ETComponent
{
    
    /// <summary>
    /// Constructor of the ETComponent component")
    /// </summary>  
    public ETComponent() { }
    

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

    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
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
        
        for (int i = 0; i < 100; i++)
            { layer_thickness[i] = toCopy.layer_thickness[i]; }
    
        
        for (int i = 0; i < 100; i++)
            { permanent_wilting_point[i] = toCopy.permanent_wilting_point[i]; }
    
        
        for (int i = 0; i < 100; i++)
            { field_capacity[i] = toCopy.field_capacity[i]; }
    
    }
    

    

    /// <summary>
    /// Initialization of ET component
    /// </summary>

    public void Init(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        _Evapotranspiration.Init(s,s1, r, a, ex);
    }
    
}