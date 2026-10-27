public class ETComponent
{
    
    public ETComponent() { }

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

    public double getlatitude()
    { return _Radiation.getlatitude(); }
    public void setlatitude(double _latitude){
    _Radiation.setlatitude(_latitude);
    }

    public double getreference_albedo()
    { return _NetRadiation.getreference_albedo(); }
    public void setreference_albedo(double _reference_albedo){
    _NetRadiation.setreference_albedo(_reference_albedo);
    }

    public double getheight_nn()
    { return _NetRadiation.getheight_nn(); }
    public void setheight_nn(double _height_nn){
    _NetRadiation.setheight_nn(_height_nn);
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
    }

    public double getsaturation_beta()
    { return _StomataResistance.getsaturation_beta(); }
    public void setsaturation_beta(double _saturation_beta){
    _StomataResistance.setsaturation_beta(_saturation_beta);
    }

    public double getstomata_conductance_alpha()
    { return _StomataResistance.getstomata_conductance_alpha(); }
    public void setstomata_conductance_alpha(double _stomata_conductance_alpha){
    _StomataResistance.setstomata_conductance_alpha(_stomata_conductance_alpha);
    }

    public Integer getcarboxylation_pathway()
    { return _StomataResistance.getcarboxylation_pathway(); }
    public void setcarboxylation_pathway(Integer _carboxylation_pathway){
    _StomataResistance.setcarboxylation_pathway(_carboxylation_pathway);
    }

    public double getevaporation_zeta()
    { return _Evapotranspiration.getevaporation_zeta(); }
    public void setevaporation_zeta(double _evaporation_zeta){
    _Evapotranspiration.setevaporation_zeta(_evaporation_zeta);
    }

    public double getmaximum_evaporation_impact_depth()
    { return _Evapotranspiration.getmaximum_evaporation_impact_depth(); }
    public void setmaximum_evaporation_impact_depth(double _maximum_evaporation_impact_depth){
    _Evapotranspiration.setmaximum_evaporation_impact_depth(_maximum_evaporation_impact_depth);
    }

    public Integer getevaporation_reduction_method()
    { return _Evapotranspiration.getevaporation_reduction_method(); }
    public void setevaporation_reduction_method(Integer _evaporation_reduction_method){
    _Evapotranspiration.setevaporation_reduction_method(_evaporation_reduction_method);
    }

    public double getxsa_critical_soil_moisture()
    { return _Evapotranspiration.getxsa_critical_soil_moisture(); }
    public void setxsa_critical_soil_moisture(double _xsa_critical_soil_moisture){
    _Evapotranspiration.setxsa_critical_soil_moisture(_xsa_critical_soil_moisture);
    }

    public Integer getno_of_soil_layers()
    { return _Evapotranspiration.getno_of_soil_layers(); }
    public void setno_of_soil_layers(Integer _no_of_soil_layers){
    _Evapotranspiration.setno_of_soil_layers(_no_of_soil_layers);
    }

    public Integer getno_of_soil_moisture_layers()
    { return _Evapotranspiration.getno_of_soil_moisture_layers(); }
    public void setno_of_soil_moisture_layers(Integer _no_of_soil_moisture_layers){
    _Evapotranspiration.setno_of_soil_moisture_layers(_no_of_soil_moisture_layers);
    }

    public Double [] getlayer_thickness()
    { return _Evapotranspiration.getlayer_thickness(); }
    public void setlayer_thickness(Double [] _layer_thickness){
    _Evapotranspiration.setlayer_thickness(_layer_thickness);
    }

    public Double [] getpermanent_wilting_point()
    { return _Evapotranspiration.getpermanent_wilting_point(); }
    public void setpermanent_wilting_point(Double [] _permanent_wilting_point){
    _Evapotranspiration.setpermanent_wilting_point(_permanent_wilting_point);
    }

    public Double [] getfield_capacity()
    { return _Evapotranspiration.getfield_capacity(); }
    public void setfield_capacity(Double [] _field_capacity){
    _Evapotranspiration.setfield_capacity(_field_capacity);
    }
    public void  Calculate_Model(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        _Radiation.Calculate_Model(s, s1, r, a, ex);
        _SaturatedVaporPressure.Calculate_Model(s, s1, r, a, ex);
        a.setinternal_vapor_pressure(a.getvapor_pressure());
        _UseExtVaporPressure.Calculate_Model(s, s1, r, a, ex);
        _NetRadiation.Calculate_Model(s, s1, r, a, ex);
        _SaturationVaporPressureDeficit.Calculate_Model(s, s1, r, a, ex);
        _StomataResistance.Calculate_Model(s, s1, r, a, ex);
        a.setcalculated_stomata_resistance(a.getstomata_resistance());
        _CalcStomataResistance.Calculate_Model(s, s1, r, a, ex);
        _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
        a.setinternal_et0(a.getreference_evapotranspiration());
        _UseExtET0.Calculate_Model(s, s1, r, a, ex);
        a.setreference_evapotranspiration(a.getet0());
        _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
        _Evapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double latitude;
    private double reference_albedo;
    private double height_nn;
    private double saturation_beta;
    private double stomata_conductance_alpha;
    private Integer carboxylation_pathway;
    private double evaporation_zeta;
    private double maximum_evaporation_impact_depth;
    private Integer evaporation_reduction_method;
    private double xsa_critical_soil_moisture;
    private Integer no_of_soil_layers;
    private Integer no_of_soil_moisture_layers;
    private Double [] layer_thickness;
    private Double [] permanent_wilting_point;
    private Double [] field_capacity;
    public ETComponent(ETComponent toCopy) // copy constructor 
    {
        this.latitude = toCopy.getlatitude();
        this.reference_albedo = toCopy.getreference_albedo();
        this.height_nn = toCopy.getheight_nn();
        this.saturation_beta = toCopy.getsaturation_beta();
        this.stomata_conductance_alpha = toCopy.getstomata_conductance_alpha();
        this.carboxylation_pathway = toCopy.getcarboxylation_pathway();
        this.evaporation_zeta = toCopy.getevaporation_zeta();
        this.maximum_evaporation_impact_depth = toCopy.getmaximum_evaporation_impact_depth();
        this.evaporation_reduction_method = toCopy.getevaporation_reduction_method();
        this.xsa_critical_soil_moisture = toCopy.getxsa_critical_soil_moisture();
        this.no_of_soil_layers = toCopy.getno_of_soil_layers();
        this.no_of_soil_moisture_layers = toCopy.getno_of_soil_moisture_layers();
        
        for (int i = 0; i < toCopy.getlayer_thickness().length; i++)
        {
            layer_thickness[i] = toCopy.getlayer_thickness()[i];
        }
        
        for (int i = 0; i < toCopy.getpermanent_wilting_point().length; i++)
        {
            permanent_wilting_point[i] = toCopy.getpermanent_wilting_point()[i];
        }
        
        for (int i = 0; i < toCopy.getfield_capacity().length; i++)
        {
            field_capacity[i] = toCopy.getfield_capacity()[i];
        }

    }
    

    

    public void Init(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        _Evapotranspiration.Init(s, s1, r, a, ex);
    }
    
}