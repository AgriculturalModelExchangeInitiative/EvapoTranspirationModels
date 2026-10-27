using System;
using System.Collections.Generic;
using System.Linq;
public class Evapotranspiration
{
    public void Init(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        double kc_factor = ex.kc_factor;
        bool has_snow_cover = ex.has_snow_cover;
        int developmental_stage = ex.developmental_stage;
        double[] crop_transpiration = ex.crop_transpiration;
        double crop_evaporated_from_intercepted = ex.crop_evaporated_from_intercepted;
        double percentage_soil_coverage = ex.percentage_soil_coverage;
        double surface_water_storage = 0.0;
        double evaporated_from_surface = 0.0;
        double actual_evaporation = 0.0;
        double actual_transpiration = 0.0;
        double[] soil_moisture =  new double [no_of_soil_moisture_layers];
        double[] evaporation =  new double [no_of_soil_moisture_layers];
        double[] transpiration =  new double [no_of_soil_moisture_layers];
        double[] evapotranspiration =  new double [no_of_soil_moisture_layers];
        double actual_evapotranspiration = 0.0;
        soil_moisture = new double[no_of_soil_moisture_layers];
        evaporation = new double[no_of_soil_moisture_layers];
        transpiration = new double[no_of_soil_moisture_layers];
        evapotranspiration = new double[no_of_soil_moisture_layers];
        s.surface_water_storage= surface_water_storage;
        s.evaporated_from_surface= evaporated_from_surface;
        s.actual_evaporation= actual_evaporation;
        s.actual_transpiration= actual_transpiration;
        s.soil_moisture= soil_moisture;
        s.evaporation= evaporation;
        s.transpiration= transpiration;
        s.evapotranspiration= evapotranspiration;
        s.actual_evapotranspiration= actual_evapotranspiration;
    }
    private double _evaporation_zeta;
    public double evaporation_zeta
    {
        get { return this._evaporation_zeta; }
        set { this._evaporation_zeta= value; } 
    }
    private double _maximum_evaporation_impact_depth;
    public double maximum_evaporation_impact_depth
    {
        get { return this._maximum_evaporation_impact_depth; }
        set { this._maximum_evaporation_impact_depth= value; } 
    }
    private int _evaporation_reduction_method;
    public int evaporation_reduction_method
    {
        get { return this._evaporation_reduction_method; }
        set { this._evaporation_reduction_method= value; } 
    }
    private double _xsa_critical_soil_moisture;
    public double xsa_critical_soil_moisture
    {
        get { return this._xsa_critical_soil_moisture; }
        set { this._xsa_critical_soil_moisture= value; } 
    }
    private int _no_of_soil_layers;
    public int no_of_soil_layers
    {
        get { return this._no_of_soil_layers; }
        set { this._no_of_soil_layers= value; } 
    }
    private int _no_of_soil_moisture_layers;
    public int no_of_soil_moisture_layers
    {
        get { return this._no_of_soil_moisture_layers; }
        set { this._no_of_soil_moisture_layers= value; } 
    }
    private double[] _layer_thickness;
    public double[] layer_thickness
    {
        get { return this._layer_thickness; }
        set { this._layer_thickness= value; } 
    }
    private double[] _permanent_wilting_point;
    public double[] permanent_wilting_point
    {
        get { return this._permanent_wilting_point; }
        set { this._permanent_wilting_point= value; } 
    }
    private double[] _field_capacity;
    public double[] field_capacity
    {
        get { return this._field_capacity; }
        set { this._field_capacity= value; } 
    }
    /// <summary>
    /// Constructor of the Evapotranspiration component")
    /// </summary>  
    public Evapotranspiration() { }
    
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        //- Name: Evapotranspiration -Version: 1, -Time step: 1
        //- Description:
    //            * Title: MONICA evapotranspiration model
    //            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: Calculates the MONICA evapotranspiration
        //- inputs:
    //            * name: evaporation_zeta
    //                          ** description : shape factor
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 40
    //                          ** min : 0
    //                          ** default : 40
    //                          ** unit : dimensionless
    //            * name: maximum_evaporation_impact_depth
    //                          ** description : maximumEvaporationImpactDepth
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 5
    //                          ** unit : dm
    //            * name: evaporation_reduction_method
    //                          ** description : THESEUS (0) or HERMES (1) evaporation reduction method
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 1
    //                          ** unit : dimensionless
    //            * name: xsa_critical_soil_moisture
    //                          ** description : XSACriticalSoilMoisture
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1.5
    //                          ** min : 0
    //                          ** default : 0.1
    //                          ** unit : m3/m3
    //            * name: no_of_soil_layers
    //                          ** description : number of soil layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 20
    //                          ** unit : dimensionless
    //            * name: no_of_soil_moisture_layers
    //                          ** description : number of soil layers + 1
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 21
    //                          ** unit : dimensionless
    //            * name: layer_thickness
    //                          ** description : layer thickness array
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m
    //            * name: permanent_wilting_point
    //                          ** description : permanent wilting point array
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m3/m3
    //            * name: field_capacity
    //                          ** description : field capacity array
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m3/m3
    //            * name: kc_factor
    //                          ** description : crop coefficient ETc/ET0
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0.75
    //                          ** unit : dimensionless
    //            * name: has_snow_cover
    //                          ** description : is the soil covered by snow
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : BOOLEAN
    //                          ** default : false
    //                          ** unit : dimensionless
    //            * name: developmental_stage
    //                          ** description : MONICA crop developmental stage
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 6
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : dimensionless
    //            * name: crop_transpiration
    //                          ** description : crop transpiration array
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: crop_evaporated_from_intercepted
    //                          ** description : crop evaporated water from intercepted water
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: percentage_soil_coverage
    //                          ** description : fraction of soil covered by crop
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : m2/m2
    //            * name: potential_evapotranspiration
    //                          ** description : the potential evapotranspiration
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: surface_water_storage
    //                          ** description : Simulates a virtual layer that contains the surface water
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: evaporated_from_surface
    //                          ** description : evaporated_from_surface
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: actual_evaporation
    //                          ** description : actual evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: actual_transpiration
    //                          ** description : actual transpiration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: soil_moisture
    //                          ** description : soil moisture array
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m3/m3
    //            * name: evaporation
    //                          ** description : evaporation array
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: transpiration
    //                          ** description : transpiration array
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: evapotranspiration
    //                          ** description : evapotranspiration array
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: actual_evapotranspiration
    //                          ** description : actual evapotranspiration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
        //- outputs:
    //            * name: evaporated_from_surface
    //                          ** description : 
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: actual_evapotranspiration
    //                          ** description : actual evapotranspiration
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 200
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: actual_evaporation
    //                          ** description : actual evaporation
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: actual_transpiration
    //                          ** description : actual transpiration
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: surface_water_storage
    //                          ** description : Simulates a virtual layer that contains the surface water
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : mm
    //            * name: soil_moisture
    //                          ** description : soil moisture array
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : no_of_soil_moisture_layers
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : m3/m3
        double kc_factor = ex.kc_factor;
        bool has_snow_cover = ex.has_snow_cover;
        int developmental_stage = ex.developmental_stage;
        double[] crop_transpiration = ex.crop_transpiration;
        double crop_evaporated_from_intercepted = ex.crop_evaporated_from_intercepted;
        double percentage_soil_coverage = ex.percentage_soil_coverage;
        double potential_evapotranspiration = a.potential_evapotranspiration;
        double surface_water_storage = s.surface_water_storage;
        double evaporated_from_surface = s.evaporated_from_surface;
        double actual_evaporation = s.actual_evaporation;
        double actual_transpiration = s.actual_transpiration;
        double[] soil_moisture = s.soil_moisture;
        double[] evaporation = s.evaporation;
        double[] transpiration = s.transpiration;
        double[] evapotranspiration = s.evapotranspiration;
        double actual_evapotranspiration = s.actual_evapotranspiration;
        double evaporated_from_intercept;
        if (developmental_stage > 0)
        {
            evaporated_from_intercept = crop_evaporated_from_intercepted;
        }
        else
        {
            evaporated_from_intercept = 0.0;
        }
        evaporated_from_surface = 0.0;
        actual_evaporation = 0.0;
        actual_transpiration = 0.0;
        bool evaporation_from_surface = false;
        double eRed1;
        double eRed2;
        double eRed3;
        double eReducer;
        int i;
        if (potential_evapotranspiration > 0.0)
        {
            evaporation_from_surface = false;
            if (surface_water_storage > 0.0)
            {
                evaporation_from_surface = true;
                potential_evapotranspiration = potential_evapotranspiration * (1.1 / kc_factor);
                if (has_snow_cover)
                {
                    evaporated_from_surface = 0.0;
                }
                else if ( surface_water_storage < potential_evapotranspiration)
                {
                    potential_evapotranspiration = potential_evapotranspiration - surface_water_storage;
                    evaporated_from_surface = surface_water_storage;
                    surface_water_storage = 0.0;
                }
                else
                {
                    surface_water_storage = surface_water_storage - potential_evapotranspiration;
                    evaporated_from_surface = potential_evapotranspiration;
                    potential_evapotranspiration = 0.0;
                }
                potential_evapotranspiration = potential_evapotranspiration * (kc_factor / 1.1);
            }
            if (potential_evapotranspiration > 0.0)
            {
                for (i=0 ; i!=no_of_soil_layers ; i+=1)
                {
                    eRed1 = e_reducer_1(permanent_wilting_point[i], field_capacity[i], soil_moisture[i], percentage_soil_coverage, potential_evapotranspiration, evaporation_reduction_method, xsa_critical_soil_moisture);
                    eRed2 = 0.0;
                    if ((double)(i) >= maximum_evaporation_impact_depth)
                    {
                        eRed2 = 0.0;
                    }
                    else
                    {
                        eRed2 = get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i]);
                    }
                    eRed3 = 0.0;
                    if (i > 0 && soil_moisture[i] < soil_moisture[i - 1])
                    {
                        eRed3 = 0.1;
                    }
                    else
                    {
                        eRed3 = 1.0;
                    }
                    eReducer = eRed1 * eRed2 * eRed3;
                    if (developmental_stage > 0)
                    {
                        if (percentage_soil_coverage >= 0.0 && percentage_soil_coverage < 1.0)
                        {
                            evaporation[i] = (1.0 - percentage_soil_coverage) * eReducer * potential_evapotranspiration;
                        }
                        else if ( percentage_soil_coverage >= 1.0)
                        {
                            evaporation[i] = 0.0;
                        }
                        if (has_snow_cover)
                        {
                            evaporation[i] = 0.0;
                        }
                        transpiration[i] = crop_transpiration[i];
                        if (evaporation_from_surface)
                        {
                            transpiration[i] = percentage_soil_coverage * eReducer * potential_evapotranspiration;
                        }
                    }
                    else
                    {
                        if (has_snow_cover)
                        {
                            evaporation[i] = 0.0;
                        }
                        else
                        {
                            evaporation[i] = potential_evapotranspiration * eReducer;
                        }
                        transpiration[i] = 0.0;
                    }
                    evapotranspiration[i] = evaporation[i] + transpiration[i];
                    soil_moisture[i] = soil_moisture[i] - (evapotranspiration[i] / 1000.0 / layer_thickness[i]);
                    if (soil_moisture[i] < 0.01)
                    {
                        soil_moisture[i] = 0.01;
                    }
                    actual_transpiration = actual_transpiration + transpiration[i];
                    actual_evaporation = actual_evaporation + evaporation[i];
                }
            }
        }
        actual_evapotranspiration = actual_transpiration + actual_evaporation + evaporated_from_intercept + evaporated_from_surface;
        s.surface_water_storage= surface_water_storage;
        s.evaporated_from_surface= evaporated_from_surface;
        s.actual_evaporation= actual_evaporation;
        s.actual_transpiration= actual_transpiration;
        s.soil_moisture= soil_moisture;
        s.actual_evapotranspiration= actual_evapotranspiration;
    }
    public static double bound(double lower, double value, double upper)
    {
        if (value < lower)
        {
            return lower;
        }
        if (value > upper)
        {
            return upper;
        }
        return value;
    }
    public static double get_deprivation_factor(int layer_no, double deprivation_depth, double zeta, double layer_thickness)
    {
        double ltf;
        ltf = deprivation_depth / (layer_thickness * 10.0);
        double deprivation_factor;
        double c2;
        double c3;
        if (Math.Abs(zeta) < 0.0003)
        {
            deprivation_factor = 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no - 1));
        }
        else
        {
            c2 = Math.Log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))));
            c3 = zeta / (ltf * (zeta + 1.0));
            deprivation_factor = (c2 - c3) / (Math.Log(zeta + 1.0) - (zeta / (zeta + 1.0)));
        }
        return deprivation_factor;
    }
    public static double e_reducer_1(double pwp, double fc, double sm, double percentage_soil_coverage, double reference_evapotranspiration, int evaporation_reduction_method, double xsa_critical_soil_moisture)
    {
        sm = Math.Max(0.33 * pwp, sm);
        double relative_evaporable_water;
        relative_evaporable_water = Math.Min(1.0, (sm - (0.33 * pwp)) / (fc - (0.33 * pwp)));
        double e_reduction_factor = 0.0;
        double critical_soil_moisture;
        double reducer;
        double xsa;
        if (evaporation_reduction_method == 0)
        {
            critical_soil_moisture = 0.65 * fc;
            if (percentage_soil_coverage > 0.0)
            {
                reducer = 1.0;
                if (reference_evapotranspiration > 2.5)
                {
                    xsa = (0.65 * fc - pwp) * (fc - pwp);
                    reducer = xsa + ((1 - xsa) / 17.5 * (reference_evapotranspiration - 2.5));
                }
                else
                {
                    reducer = xsa_critical_soil_moisture / 2.5 * reference_evapotranspiration;
                }
                critical_soil_moisture = fc * reducer;
            }
            if (sm > critical_soil_moisture)
            {
                e_reduction_factor = 1.0;
            }
            else if ( sm > (0.33 * pwp))
            {
                e_reduction_factor = relative_evaporable_water;
            }
            else
            {
                e_reduction_factor = 0.0;
            }
        }
        else
        {
            if (relative_evaporable_water > 0.33)
            {
                e_reduction_factor = 1.0 - (0.1 * (1.0 - relative_evaporable_water) / (1.0 - 0.33));
            }
            else if ( relative_evaporable_water > 0.22)
            {
                e_reduction_factor = 0.9 - (0.625 * (0.33 - relative_evaporable_water) / (0.33 - 0.22));
            }
            else if ( relative_evaporable_water > 0.2)
            {
                e_reduction_factor = 0.275 - (0.225 * (0.22 - relative_evaporable_water) / (0.22 - 0.2));
            }
            else
            {
                e_reduction_factor = 0.05 - (0.05 * (0.2 - relative_evaporable_water) / 0.2);
            }
        }
        return e_reduction_factor;
    }
}