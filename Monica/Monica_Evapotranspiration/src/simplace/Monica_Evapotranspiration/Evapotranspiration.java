package net.simplace.sim.components.Monica_Evapotranspiration;
import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class Evapotranspiration extends FWSimComponent
{
    private FWSimVariable<Double> evaporation_zeta;
    private FWSimVariable<Double> maximum_evaporation_impact_depth;
    private FWSimVariable<Integer> evaporation_reduction_method;
    private FWSimVariable<Double> xsa_critical_soil_moisture;
    private FWSimVariable<Integer> no_of_soil_layers;
    private FWSimVariable<Integer> no_of_soil_moisture_layers;
    private FWSimVariable<Double[]> layer_thickness;
    private FWSimVariable<Double[]> permanent_wilting_point;
    private FWSimVariable<Double[]> field_capacity;
    private FWSimVariable<Double> kc_factor;
    private FWSimVariable<Boolean> has_snow_cover;
    private FWSimVariable<Integer> developmental_stage;
    private FWSimVariable<Double[]> crop_transpiration;
    private FWSimVariable<Double> crop_evaporated_from_intercepted;
    private FWSimVariable<Double> percentage_soil_coverage;
    private FWSimVariable<Double> potential_evapotranspiration;
    private FWSimVariable<Double> surface_water_storage;
    private FWSimVariable<Double> evaporated_from_surface;
    private FWSimVariable<Double> actual_evaporation;
    private FWSimVariable<Double> actual_transpiration;
    private FWSimVariable<Double[]> soil_moisture;
    private FWSimVariable<Double[]> evaporation;
    private FWSimVariable<Double[]> transpiration;
    private FWSimVariable<Double[]> evapotranspiration;
    private FWSimVariable<Double> actual_evapotranspiration;

    public Evapotranspiration(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Evapotranspiration(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("evaporation_zeta", "shape factor", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0.0, 40.0, 40.0, this));
        addVariable(FWSimVariable.createSimVariable("maximum_evaporation_impact_depth", "maximumEvaporationImpactDepth", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dm", 0.0, 0.0, 5.0, this));
        addVariable(FWSimVariable.createSimVariable("evaporation_reduction_method", "THESEUS (0) or HERMES (1) evaporation reduction method", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", 0, 1, 1, this));
        addVariable(FWSimVariable.createSimVariable("xsa_critical_soil_moisture", "XSACriticalSoilMoisture", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m3/m3", 0.0, 1.5, 0.1, this));
        addVariable(FWSimVariable.createSimVariable("no_of_soil_layers", "number of soil layers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", 0, 0, 20, this));
        addVariable(FWSimVariable.createSimVariable("no_of_soil_moisture_layers", "number of soil layers + 1", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", 0, 0, 21, this));
        addVariable(FWSimVariable.createSimVariable("layer_thickness", "layer thickness array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("permanent_wilting_point", "permanent wilting point array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m3/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("field_capacity", "field capacity array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m3/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("kc_factor", "crop coefficient ETc/ET0", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"dimensionless", 0.0, 0.0, 0.75, this));
        addVariable(FWSimVariable.createSimVariable("has_snow_cover", "is the soil covered by snow", DATA_TYPE.BOOLEAN, CONTENT_TYPE.input,"dimensionless", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("developmental_stage", "MONICA crop developmental stage", DATA_TYPE.INT, CONTENT_TYPE.input,"dimensionless", 0, 6, 0, this));
        addVariable(FWSimVariable.createSimVariable("crop_transpiration", "crop transpiration array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("crop_evaporated_from_intercepted", "crop evaporated water from intercepted water", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("percentage_soil_coverage", "fraction of soil covered by crop", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m2/m2", 0.0, 1.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("potential_evapotranspiration", "the potential evapotranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("surface_water_storage", "Simulates a virtual layer that contains the surface water", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("evaporated_from_surface", "evaporated_from_surface", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("actual_evaporation", "actual evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("actual_transpiration", "actual transpiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("soil_moisture", "soil moisture array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"m3/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("evaporation", "evaporation array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("transpiration", "transpiration array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("evapotranspiration", "evapotranspiration array", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("actual_evapotranspiration", "actual evapotranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        double t_evaporation_zeta = evaporation_zeta.getValue();
        double t_maximum_evaporation_impact_depth = maximum_evaporation_impact_depth.getValue();
        Integer t_evaporation_reduction_method = evaporation_reduction_method.getValue();
        double t_xsa_critical_soil_moisture = xsa_critical_soil_moisture.getValue();
        Integer t_no_of_soil_layers = no_of_soil_layers.getValue();
        Integer t_no_of_soil_moisture_layers = no_of_soil_moisture_layers.getValue();
        Double [] t_layer_thickness = layer_thickness.getValue();
        Double [] t_permanent_wilting_point = permanent_wilting_point.getValue();
        Double [] t_field_capacity = field_capacity.getValue();
        double t_kc_factor = kc_factor.getValue();
        Boolean t_has_snow_cover = has_snow_cover.getValue();
        Integer t_developmental_stage = developmental_stage.getValue();
        Double [] t_crop_transpiration = crop_transpiration.getValue();
        double t_crop_evaporated_from_intercepted = crop_evaporated_from_intercepted.getValue();
        double t_percentage_soil_coverage = percentage_soil_coverage.getValue();
        double t_surface_water_storage = surface_water_storage.getDefault();
        double t_evaporated_from_surface = evaporated_from_surface.getDefault();
        double t_actual_evaporation = actual_evaporation.getDefault();
        double t_actual_transpiration = actual_transpiration.getDefault();
        Double [] t_soil_moisture = soil_moisture.getDefault();
        Double [] t_evaporation = evaporation.getDefault();
        Double [] t_transpiration = transpiration.getDefault();
        Double [] t_evapotranspiration = evapotranspiration.getDefault();
        double t_actual_evapotranspiration = actual_evapotranspiration.getDefault();
        Arrays.fill(t_soil_moisture, 0.0d);
        Arrays.fill(t_evaporation, 0.0d);
        Arrays.fill(t_transpiration, 0.0d);
        Arrays.fill(t_evapotranspiration, 0.0d);
        surface_water_storage.setValue(t_surface_water_storage, this);
        evaporated_from_surface.setValue(t_evaporated_from_surface, this);
        actual_evaporation.setValue(t_actual_evaporation, this);
        actual_transpiration.setValue(t_actual_transpiration, this);
        soil_moisture.setValue(t_soil_moisture, this);
        evaporation.setValue(t_evaporation, this);
        transpiration.setValue(t_transpiration, this);
        evapotranspiration.setValue(t_evapotranspiration, this);
        actual_evapotranspiration.setValue(t_actual_evapotranspiration, this);
    }
    @Override
    protected void process()
    {
        double t_evaporation_zeta = evaporation_zeta.getValue();
        double t_maximum_evaporation_impact_depth = maximum_evaporation_impact_depth.getValue();
        Integer t_evaporation_reduction_method = evaporation_reduction_method.getValue();
        double t_xsa_critical_soil_moisture = xsa_critical_soil_moisture.getValue();
        Integer t_no_of_soil_layers = no_of_soil_layers.getValue();
        Integer t_no_of_soil_moisture_layers = no_of_soil_moisture_layers.getValue();
        Double [] t_layer_thickness = layer_thickness.getValue();
        Double [] t_permanent_wilting_point = permanent_wilting_point.getValue();
        Double [] t_field_capacity = field_capacity.getValue();
        double t_kc_factor = kc_factor.getValue();
        Boolean t_has_snow_cover = has_snow_cover.getValue();
        Integer t_developmental_stage = developmental_stage.getValue();
        Double [] t_crop_transpiration = crop_transpiration.getValue();
        double t_crop_evaporated_from_intercepted = crop_evaporated_from_intercepted.getValue();
        double t_percentage_soil_coverage = percentage_soil_coverage.getValue();
        double t_potential_evapotranspiration = potential_evapotranspiration.getValue();
        double t_surface_water_storage = surface_water_storage.getValue();
        double t_evaporated_from_surface = evaporated_from_surface.getValue();
        double t_actual_evaporation = actual_evaporation.getValue();
        double t_actual_transpiration = actual_transpiration.getValue();
        Double [] t_soil_moisture = soil_moisture.getValue();
        Double [] t_evaporation = evaporation.getValue();
        Double [] t_transpiration = transpiration.getValue();
        Double [] t_evapotranspiration = evapotranspiration.getValue();
        double t_actual_evapotranspiration = actual_evapotranspiration.getValue();
        double evaporated_from_intercept;
        if (t_developmental_stage > 0)
        {
            evaporated_from_intercept = t_crop_evaporated_from_intercepted;
        }
        else
        {
            evaporated_from_intercept = 0.0d;
        }
        t_evaporated_from_surface = 0.0d;
        t_actual_evaporation = 0.0d;
        t_actual_transpiration = 0.0d;
        Boolean evaporation_from_surface = false;
        double eRed1;
        double eRed2;
        double eRed3;
        double eReducer;
        Integer i;
        if (t_potential_evapotranspiration > 0.0d)
        {
            evaporation_from_surface = false;
            if (t_surface_water_storage > 0.0d)
            {
                evaporation_from_surface = true;
                t_potential_evapotranspiration = t_potential_evapotranspiration * (1.1d / t_kc_factor);
                if (t_has_snow_cover)
                {
                    t_evaporated_from_surface = 0.0d;
                }
                else if ( t_surface_water_storage < t_potential_evapotranspiration)
                {
                    t_potential_evapotranspiration = t_potential_evapotranspiration - t_surface_water_storage;
                    t_evaporated_from_surface = t_surface_water_storage;
                    t_surface_water_storage = 0.0d;
                }
                else
                {
                    t_surface_water_storage = t_surface_water_storage - t_potential_evapotranspiration;
                    t_evaporated_from_surface = t_potential_evapotranspiration;
                    t_potential_evapotranspiration = 0.0d;
                }
                t_potential_evapotranspiration = t_potential_evapotranspiration * (t_kc_factor / 1.1d);
            }
            if (t_potential_evapotranspiration > 0.0d)
            {
                for (i=0 ; i!=t_no_of_soil_layers ; i+=1)
                {
                    eRed1 = e_reducer_1(t_permanent_wilting_point[i], t_field_capacity[i], t_soil_moisture[i], t_percentage_soil_coverage, t_potential_evapotranspiration, t_evaporation_reduction_method, t_xsa_critical_soil_moisture);
                    eRed2 = 0.0d;
                    if ((double)(i) >= t_maximum_evaporation_impact_depth)
                    {
                        eRed2 = 0.0d;
                    }
                    else
                    {
                        eRed2 = get_deprivation_factor(i + 1, t_maximum_evaporation_impact_depth, t_evaporation_zeta, t_layer_thickness[i]);
                    }
                    eRed3 = 0.0d;
                    if (i > 0 && t_soil_moisture[i] < t_soil_moisture[i - 1])
                    {
                        eRed3 = 0.1d;
                    }
                    else
                    {
                        eRed3 = 1.0d;
                    }
                    eReducer = eRed1 * eRed2 * eRed3;
                    if (t_developmental_stage > 0)
                    {
                        if (t_percentage_soil_coverage >= 0.0d && t_percentage_soil_coverage < 1.0d)
                        {
                            t_evaporation[i] = (1.0d - t_percentage_soil_coverage) * eReducer * t_potential_evapotranspiration;
                        }
                        else if ( t_percentage_soil_coverage >= 1.0d)
                        {
                            t_evaporation[i] = 0.0d;
                        }
                        if (t_has_snow_cover)
                        {
                            t_evaporation[i] = 0.0d;
                        }
                        t_transpiration[i] = t_crop_transpiration[i];
                        if (evaporation_from_surface)
                        {
                            t_transpiration[i] = t_percentage_soil_coverage * eReducer * t_potential_evapotranspiration;
                        }
                    }
                    else
                    {
                        if (t_has_snow_cover)
                        {
                            t_evaporation[i] = 0.0d;
                        }
                        else
                        {
                            t_evaporation[i] = t_potential_evapotranspiration * eReducer;
                        }
                        t_transpiration[i] = 0.0d;
                    }
                    t_evapotranspiration[i] = t_evaporation[i] + t_transpiration[i];
                    t_soil_moisture[i] = t_soil_moisture[i] - (t_evapotranspiration[i] / 1000.0d / t_layer_thickness[i]);
                    if (t_soil_moisture[i] < 0.01d)
                    {
                        t_soil_moisture[i] = 0.01d;
                    }
                    t_actual_transpiration = t_actual_transpiration + t_transpiration[i];
                    t_actual_evaporation = t_actual_evaporation + t_evaporation[i];
                }
            }
        }
        t_actual_evapotranspiration = t_actual_transpiration + t_actual_evaporation + evaporated_from_intercept + t_evaporated_from_surface;
        surface_water_storage.setValue(t_surface_water_storage, this);
        evaporated_from_surface.setValue(t_evaporated_from_surface, this);
        actual_evaporation.setValue(t_actual_evaporation, this);
        actual_transpiration.setValue(t_actual_transpiration, this);
        soil_moisture.setValue(t_soil_moisture, this);
        actual_evapotranspiration.setValue(t_actual_evapotranspiration, this);
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

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new Evapotranspiration(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}