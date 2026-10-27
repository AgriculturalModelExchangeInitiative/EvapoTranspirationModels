import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Evapotranspiration
{
    public void Init(ETState s, ETState s1, ETRate r, ETAuxiliary a,  ETExogenous ex)
    {
        double kc_factor = ex.getkc_factor();
        Boolean has_snow_cover = ex.gethas_snow_cover();
        Integer developmental_stage = ex.getdevelopmental_stage();
        Double [] crop_transpiration = ex.getcrop_transpiration();
        double crop_evaporated_from_intercepted = ex.getcrop_evaporated_from_intercepted();
        double percentage_soil_coverage = ex.getpercentage_soil_coverage();
        double surface_water_storage = 0.0;
        double evaporated_from_surface = 0.0;
        double actual_evaporation = 0.0;
        double actual_transpiration = 0.0;
        Double[] soil_moisture =  new Double [no_of_soil_moisture_layers];
        Double[] evaporation =  new Double [no_of_soil_moisture_layers];
        Double[] transpiration =  new Double [no_of_soil_moisture_layers];
        Double[] evapotranspiration =  new Double [no_of_soil_moisture_layers];
        double actual_evapotranspiration = 0.0;
        soil_moisture= new Double[no_of_soil_moisture_layers];
        Arrays.fill(soil_moisture, 0.0d);
        evaporation= new Double[no_of_soil_moisture_layers];
        Arrays.fill(evaporation, 0.0d);
        transpiration= new Double[no_of_soil_moisture_layers];
        Arrays.fill(transpiration, 0.0d);
        evapotranspiration= new Double[no_of_soil_moisture_layers];
        Arrays.fill(evapotranspiration, 0.0d);
        s.setsurface_water_storage(surface_water_storage);
        s.setevaporated_from_surface(evaporated_from_surface);
        s.setactual_evaporation(actual_evaporation);
        s.setactual_transpiration(actual_transpiration);
        s.setsoil_moisture(soil_moisture);
        s.setevaporation(evaporation);
        s.settranspiration(transpiration);
        s.setevapotranspiration(evapotranspiration);
        s.setactual_evapotranspiration(actual_evapotranspiration);
    }
    private double evaporation_zeta;
    public double getevaporation_zeta()
    { return evaporation_zeta; }

    public void setevaporation_zeta(double _evaporation_zeta)
    { this.evaporation_zeta= _evaporation_zeta; } 
    
    private double maximum_evaporation_impact_depth;
    public double getmaximum_evaporation_impact_depth()
    { return maximum_evaporation_impact_depth; }

    public void setmaximum_evaporation_impact_depth(double _maximum_evaporation_impact_depth)
    { this.maximum_evaporation_impact_depth= _maximum_evaporation_impact_depth; } 
    
    private Integer evaporation_reduction_method;
    public Integer getevaporation_reduction_method()
    { return evaporation_reduction_method; }

    public void setevaporation_reduction_method(Integer _evaporation_reduction_method)
    { this.evaporation_reduction_method= _evaporation_reduction_method; } 
    
    private double xsa_critical_soil_moisture;
    public double getxsa_critical_soil_moisture()
    { return xsa_critical_soil_moisture; }

    public void setxsa_critical_soil_moisture(double _xsa_critical_soil_moisture)
    { this.xsa_critical_soil_moisture= _xsa_critical_soil_moisture; } 
    
    private Integer no_of_soil_layers;
    public Integer getno_of_soil_layers()
    { return no_of_soil_layers; }

    public void setno_of_soil_layers(Integer _no_of_soil_layers)
    { this.no_of_soil_layers= _no_of_soil_layers; } 
    
    private Integer no_of_soil_moisture_layers;
    public Integer getno_of_soil_moisture_layers()
    { return no_of_soil_moisture_layers; }

    public void setno_of_soil_moisture_layers(Integer _no_of_soil_moisture_layers)
    { this.no_of_soil_moisture_layers= _no_of_soil_moisture_layers; } 
    
    private Double [] layer_thickness;
    public Double [] getlayer_thickness()
    { return layer_thickness; }

    public void setlayer_thickness(Double [] _layer_thickness)
    { this.layer_thickness= _layer_thickness; } 
    
    private Double [] permanent_wilting_point;
    public Double [] getpermanent_wilting_point()
    { return permanent_wilting_point; }

    public void setpermanent_wilting_point(Double [] _permanent_wilting_point)
    { this.permanent_wilting_point= _permanent_wilting_point; } 
    
    private Double [] field_capacity;
    public Double [] getfield_capacity()
    { return field_capacity; }

    public void setfield_capacity(Double [] _field_capacity)
    { this.field_capacity= _field_capacity; } 
    
    public Evapotranspiration() { }
    public void  Calculate_Model(ETState s, ETState s1, ETRate r, ETAuxiliary a,  ETExogenous ex)
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
        double kc_factor = ex.getkc_factor();
        Boolean has_snow_cover = ex.gethas_snow_cover();
        Integer developmental_stage = ex.getdevelopmental_stage();
        Double [] crop_transpiration = ex.getcrop_transpiration();
        double crop_evaporated_from_intercepted = ex.getcrop_evaporated_from_intercepted();
        double percentage_soil_coverage = ex.getpercentage_soil_coverage();
        double potential_evapotranspiration = a.getpotential_evapotranspiration();
        double surface_water_storage = s.getsurface_water_storage();
        double evaporated_from_surface = s.getevaporated_from_surface();
        double actual_evaporation = s.getactual_evaporation();
        double actual_transpiration = s.getactual_transpiration();
        Double [] soil_moisture = s.getsoil_moisture();
        Double [] evaporation = s.getevaporation();
        Double [] transpiration = s.gettranspiration();
        Double [] evapotranspiration = s.getevapotranspiration();
        double actual_evapotranspiration = s.getactual_evapotranspiration();
        double evaporated_from_intercept;
        if (developmental_stage > 0)
        {
            evaporated_from_intercept = crop_evaporated_from_intercepted;
        }
        else
        {
            evaporated_from_intercept = 0.0d;
        }
        evaporated_from_surface = 0.0d;
        actual_evaporation = 0.0d;
        actual_transpiration = 0.0d;
        Boolean evaporation_from_surface = false;
        double eRed1;
        double eRed2;
        double eRed3;
        double eReducer;
        Integer i;
        if (potential_evapotranspiration > 0.0d)
        {
            evaporation_from_surface = false;
            if (surface_water_storage > 0.0d)
            {
                evaporation_from_surface = true;
                potential_evapotranspiration = potential_evapotranspiration * (1.1d / kc_factor);
                if (has_snow_cover)
                {
                    evaporated_from_surface = 0.0d;
                }
                else if ( surface_water_storage < potential_evapotranspiration)
                {
                    potential_evapotranspiration = potential_evapotranspiration - surface_water_storage;
                    evaporated_from_surface = surface_water_storage;
                    surface_water_storage = 0.0d;
                }
                else
                {
                    surface_water_storage = surface_water_storage - potential_evapotranspiration;
                    evaporated_from_surface = potential_evapotranspiration;
                    potential_evapotranspiration = 0.0d;
                }
                potential_evapotranspiration = potential_evapotranspiration * (kc_factor / 1.1d);
            }
            if (potential_evapotranspiration > 0.0d)
            {
                for (i=0 ; i!=no_of_soil_layers ; i+=1)
                {
                    eRed1 = e_reducer_1(permanent_wilting_point[i], field_capacity[i], soil_moisture[i], percentage_soil_coverage, potential_evapotranspiration, evaporation_reduction_method, xsa_critical_soil_moisture);
                    eRed2 = 0.0d;
                    if ((double)(i) >= maximum_evaporation_impact_depth)
                    {
                        eRed2 = 0.0d;
                    }
                    else
                    {
                        eRed2 = get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i]);
                    }
                    eRed3 = 0.0d;
                    if (i > 0 && soil_moisture[i] < soil_moisture[i - 1])
                    {
                        eRed3 = 0.1d;
                    }
                    else
                    {
                        eRed3 = 1.0d;
                    }
                    eReducer = eRed1 * eRed2 * eRed3;
                    if (developmental_stage > 0)
                    {
                        if (percentage_soil_coverage >= 0.0d && percentage_soil_coverage < 1.0d)
                        {
                            evaporation[i] = (1.0d - percentage_soil_coverage) * eReducer * potential_evapotranspiration;
                        }
                        else if ( percentage_soil_coverage >= 1.0d)
                        {
                            evaporation[i] = 0.0d;
                        }
                        if (has_snow_cover)
                        {
                            evaporation[i] = 0.0d;
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
                            evaporation[i] = 0.0d;
                        }
                        else
                        {
                            evaporation[i] = potential_evapotranspiration * eReducer;
                        }
                        transpiration[i] = 0.0d;
                    }
                    evapotranspiration[i] = evaporation[i] + transpiration[i];
                    soil_moisture[i] = soil_moisture[i] - (evapotranspiration[i] / 1000.0d / layer_thickness[i]);
                    if (soil_moisture[i] < 0.01d)
                    {
                        soil_moisture[i] = 0.01d;
                    }
                    actual_transpiration = actual_transpiration + transpiration[i];
                    actual_evaporation = actual_evaporation + evaporation[i];
                }
            }
        }
        actual_evapotranspiration = actual_transpiration + actual_evaporation + evaporated_from_intercept + evaporated_from_surface;
        s.setsurface_water_storage(surface_water_storage);
        s.setevaporated_from_surface(evaporated_from_surface);
        s.setactual_evaporation(actual_evaporation);
        s.setactual_transpiration(actual_transpiration);
        s.setsoil_moisture(soil_moisture);
        s.setactual_evapotranspiration(actual_evapotranspiration);
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
    public static double get_deprivation_factor(Integer layer_no, double deprivation_depth, double zeta, double layer_thickness)
    {
        double ltf;
        ltf = deprivation_depth / (layer_thickness * 10.0d);
        double deprivation_factor;
        double c2;
        double c3;
        if (Math.abs(zeta) < 0.0003d)
        {
            deprivation_factor = 2.0d / ltf - (1.0d / (ltf * ltf) * (2 * layer_no - 1));
        }
        else
        {
            c2 = Math.log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))));
            c3 = zeta / (ltf * (zeta + 1.0d));
            deprivation_factor = (c2 - c3) / (Math.log(zeta + 1.0d) - (zeta / (zeta + 1.0d)));
        }
        return deprivation_factor;
    }
    public static double e_reducer_1(double pwp, double fc, double sm, double percentage_soil_coverage, double reference_evapotranspiration, Integer evaporation_reduction_method, double xsa_critical_soil_moisture)
    {
        sm = Math.max(0.33d * pwp, sm);
        double relative_evaporable_water;
        relative_evaporable_water = Math.min(1.0d, (sm - (0.33d * pwp)) / (fc - (0.33d * pwp)));
        double e_reduction_factor = 0.0;
        double critical_soil_moisture;
        double reducer;
        double xsa;
        if (evaporation_reduction_method == 0)
        {
            critical_soil_moisture = 0.65d * fc;
            if (percentage_soil_coverage > 0.0d)
            {
                reducer = 1.0d;
                if (reference_evapotranspiration > 2.5d)
                {
                    xsa = (0.65d * fc - pwp) * (fc - pwp);
                    reducer = xsa + ((1 - xsa) / 17.5d * (reference_evapotranspiration - 2.5d));
                }
                else
                {
                    reducer = xsa_critical_soil_moisture / 2.5d * reference_evapotranspiration;
                }
                critical_soil_moisture = fc * reducer;
            }
            if (sm > critical_soil_moisture)
            {
                e_reduction_factor = 1.0d;
            }
            else if ( sm > (0.33d * pwp))
            {
                e_reduction_factor = relative_evaporable_water;
            }
            else
            {
                e_reduction_factor = 0.0d;
            }
        }
        else
        {
            if (relative_evaporable_water > 0.33d)
            {
                e_reduction_factor = 1.0d - (0.1d * (1.0d - relative_evaporable_water) / (1.0d - 0.33d));
            }
            else if ( relative_evaporable_water > 0.22d)
            {
                e_reduction_factor = 0.9d - (0.625d * (0.33d - relative_evaporable_water) / (0.33d - 0.22d));
            }
            else if ( relative_evaporable_water > 0.2d)
            {
                e_reduction_factor = 0.275d - (0.225d * (0.22d - relative_evaporable_water) / (0.22d - 0.2d));
            }
            else
            {
                e_reduction_factor = 0.05d - (0.05d * (0.2d - relative_evaporable_water) / 0.2d);
            }
        }
        return e_reduction_factor;
    }
}