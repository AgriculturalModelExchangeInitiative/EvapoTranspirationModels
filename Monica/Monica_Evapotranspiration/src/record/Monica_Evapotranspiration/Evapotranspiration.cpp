// @@tagdynamic@@
// @@tagdepends: vle.discrete-time @@endtagdepends

#include <vle/DiscreteTime.hpp>
namespace vd = vle::devs;
namespace vv = vle::value;
// Definition du namespace de la classe du modele
namespace record {
using namespace std;
namespace Et {
using namespace vle::discrete_time;
class Evapotranspiration: public DiscreteTimeDyn {
public:
    Evapotranspiration(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        evaporation_zeta = (events.exist("evaporation_zeta")) ? vv::toDouble(events.get("evaporation_zeta")) : 40;
        maximum_evaporation_impact_depth = (events.exist("maximum_evaporation_impact_depth")) ? vv::toDouble(events.get("maximum_evaporation_impact_depth")) : 5;
        evaporation_reduction_method = (events.exist("evaporation_reduction_method")) ? vv::toInteger(events.get("evaporation_reduction_method")) : 1;
        xsa_critical_soil_moisture = (events.exist("xsa_critical_soil_moisture")) ? vv::toDouble(events.get("xsa_critical_soil_moisture")) : 0.1;
        no_of_soil_layers = (events.exist("no_of_soil_layers")) ? vv::toInteger(events.get("no_of_soil_layers")) : 20;
        no_of_soil_moisture_layers = (events.exist("no_of_soil_moisture_layers")) ? vv::toInteger(events.get("no_of_soil_moisture_layers")) : 21;
        layer_thickness = (events.exist("layer_thickness")) ? vv::toMatrix(events.get("layer_thickness")) : ;
        permanent_wilting_point = (events.exist("permanent_wilting_point")) ? vv::toMatrix(events.get("permanent_wilting_point")) : ;
        field_capacity = (events.exist("field_capacity")) ? vv::toMatrix(events.get("field_capacity")) : ;
        //  Variables gérées par ce composant
        surface_water_storage.init(this,"surface_water_storage", events);
        evaporated_from_surface.init(this,"evaporated_from_surface", events);
        actual_evaporation.init(this,"actual_evaporation", events);
        actual_transpiration.init(this,"actual_transpiration", events);
        soil_moisture.init(this,"soil_moisture", events);
        actual_evapotranspiration.init(this,"actual_evapotranspiration", events);
        //  Variables gérées par un autre composant
        evaporation.init(this,"evaporation", events);
        transpiration.init(this,"transpiration", events);
        evapotranspiration.init(this,"evapotranspiration", events);
        potential_evapotranspiration.init(this,"potential_evapotranspiration", events);
        kc_factor.init(this,"kc_factor", events);
        has_snow_cover.init(this,"has_snow_cover", events);
        developmental_stage.init(this,"developmental_stage", events);
        crop_transpiration.init(this,"crop_transpiration", events);
        crop_evaporated_from_intercepted.init(this,"crop_evaporated_from_intercepted", events);
        percentage_soil_coverage.init(this,"percentage_soil_coverage", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Evapotranspiration() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        soil_moisture = new double[0.0];
        evaporation = new double[0.0];
        transpiration = new double[0.0];
        evapotranspiration = new double[0.0];
    }
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        double evaporated_from_intercept;
        if (developmental_stage() > 0)
        {
            evaporated_from_intercept = crop_evaporated_from_intercepted();
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
        if (potential_evapotranspiration() > 0.0)
        {
            evaporation_from_surface = false;
            if (surface_water_storage() > 0.0)
            {
                evaporation_from_surface = true;
                potential_evapotranspiration = potential_evapotranspiration() * (1.1 / kc_factor());
                if (has_snow_cover())
                {
                    evaporated_from_surface = 0.0;
                }
                else if ( surface_water_storage() < potential_evapotranspiration())
                {
                    potential_evapotranspiration = potential_evapotranspiration() - surface_water_storage();
                    evaporated_from_surface = surface_water_storage();
                    surface_water_storage = 0.0;
                }
                else
                {
                    surface_water_storage = surface_water_storage() - potential_evapotranspiration();
                    evaporated_from_surface = potential_evapotranspiration();
                    potential_evapotranspiration = 0.0;
                }
                potential_evapotranspiration = potential_evapotranspiration() * (kc_factor() / 1.1);
            }
            if (potential_evapotranspiration() > 0.0)
            {
                for (i=0 ; i!=no_of_soil_layers ; i+=1)
                {
                    eRed1 = e_reducer_1(permanent_wilting_point[i], field_capacity[i], soil_moisture()[i], percentage_soil_coverage(), potential_evapotranspiration(), evaporation_reduction_method, xsa_critical_soil_moisture);
                    eRed2 = 0.0;
                    if (float(i) >= maximum_evaporation_impact_depth)
                    {
                        eRed2 = 0.0;
                    }
                    else
                    {
                        eRed2 = get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i]);
                    }
                    eRed3 = 0.0;
                    if (i > 0 && soil_moisture()[i] < soil_moisture()[i - 1])
                    {
                        eRed3 = 0.1;
                    }
                    else
                    {
                        eRed3 = 1.0;
                    }
                    eReducer = eRed1 * eRed2 * eRed3;
                    if (developmental_stage() > 0)
                    {
                        if (percentage_soil_coverage() >= 0.0 && percentage_soil_coverage() < 1.0)
                        {
                            evaporation()[i] = (1.0 - percentage_soil_coverage()) * eReducer * potential_evapotranspiration();
                        }
                        else if ( percentage_soil_coverage() >= 1.0)
                        {
                            evaporation()[i] = 0.0;
                        }
                        if (has_snow_cover())
                        {
                            evaporation()[i] = 0.0;
                        }
                        transpiration()[i] = crop_transpiration()[i];
                        if (evaporation_from_surface)
                        {
                            transpiration()[i] = percentage_soil_coverage() * eReducer * potential_evapotranspiration();
                        }
                    }
                    else
                    {
                        if (has_snow_cover())
                        {
                            evaporation()[i] = 0.0;
                        }
                        else
                        {
                            evaporation()[i] = potential_evapotranspiration() * eReducer;
                        }
                        transpiration()[i] = 0.0;
                    }
                    evapotranspiration()[i] = evaporation()[i] + transpiration()[i];
                    soil_moisture()[i] = soil_moisture()[i] - (evapotranspiration()[i] / 1000.0 / layer_thickness[i]);
                    if (soil_moisture()[i] < 0.01)
                    {
                        soil_moisture()[i] = 0.01;
                    }
                    actual_transpiration = actual_transpiration() + transpiration()[i];
                    actual_evaporation = actual_evaporation() + evaporation()[i];
                }
            }
        }
        actual_evapotranspiration = actual_transpiration() + actual_evaporation() + evaporated_from_intercept + evaporated_from_surface();
    }
private:
    //Variables d'etat
    /**
    * @brief Simulates a virtual layer that contains the surface water (mm)
    */
    Var surface_water_storage;/**
    * @brief evaporated_from_surface (mm)
    */
    Var evaporated_from_surface;/**
    * @brief actual evaporation (mm)
    */
    Var actual_evaporation;/**
    * @brief actual transpiration (mm)
    */
    Var actual_transpiration;/**
    * @brief soil moisture array (m3/m3)
    */
    Var soil_moisture;/**
    * @brief actual evapotranspiration (mm)
    */
    Var actual_evapotranspiration;

    //Entrées
    /**
        * @brief evaporation array (mm)
        */
    Var evaporation;/**
        * @brief transpiration array (mm)
        */
    Var transpiration;/**
        * @brief evapotranspiration array (mm)
        */
    Var evapotranspiration;/**
        * @brief the potential evapotranspiration (mm)
        */
    Var potential_evapotranspiration;/**
        * @brief crop coefficient ETc/ET0 (dimensionless)
        */
    Var kc_factor;/**
        * @brief is the soil covered by snow (dimensionless)
        */
    Var has_snow_cover;/**
        * @brief MONICA crop developmental stage (dimensionless)
        */
    Var developmental_stage;/**
        * @brief crop transpiration array (mm)
        */
    Var crop_transpiration;/**
        * @brief crop evaporated water from intercepted water (mm)
        */
    Var crop_evaporated_from_intercepted;/**
        * @brief fraction of soil covered by crop (m2/m2)
        */
    Var percentage_soil_coverage;

    //Paramètres du modele
    /**
    * @brief shape factor (dimensionless)
    */
    double evaporation_zeta;
    /**
    * @brief maximumEvaporationImpactDepth (dm)
    */
    double maximum_evaporation_impact_depth;
    /**
    * @brief THESEUS (0) or HERMES (1) evaporation reduction method (dimensionless)
    */
    int evaporation_reduction_method;
    /**
    * @brief XSACriticalSoilMoisture (m3/m3)
    */
    double xsa_critical_soil_moisture;
    /**
    * @brief number of soil layers (dimensionless)
    */
    int no_of_soil_layers;
    /**
    * @brief number of soil layers + 1 (dimensionless)
    */
    int no_of_soil_moisture_layers;
    /**
    * @brief layer thickness array (m)
    */
    std::vector<double>  layer_thickness;
    /**
    * @brief permanent wilting point array (m3/m3)
    */
    std::vector<double>  permanent_wilting_point;
    /**
    * @brief field capacity array (m3/m3)
    */
    std::vector<double>  field_capacity;
    double Evapotranspiration:: bound(double lower, double value, double upper)
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
    double Evapotranspiration:: get_deprivation_factor(int layer_no, double deprivation_depth, double zeta, double layer_thickness)
    {
        double ltf;
        ltf = deprivation_depth / (layer_thickness * 10.0);
        double deprivation_factor;
        double c2;
        double c3;
        if (std::abs(zeta) < 0.0003)
        {
            deprivation_factor = 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no - 1));
        }
        else
        {
            c2 = std::log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))));
            c3 = zeta / (ltf * (zeta + 1.0));
            deprivation_factor = (c2 - c3) / (std::log(zeta + 1.0) - (zeta / (zeta + 1.0)));
        }
        return deprivation_factor;
    }
    double Evapotranspiration:: e_reducer_1(double pwp, double fc, double sm, double percentage_soil_coverage, double reference_evapotranspiration, int evaporation_reduction_method, double xsa_critical_soil_moisture)
    {
        sm = std::max(0.33 * pwp, sm);
        double relative_evaporable_water;
        relative_evaporable_water = std::min(1.0, (sm - (0.33 * pwp)) / (fc - (0.33 * pwp)));
        double e_reduction_factor = 0.0;
        double critical_soil_moisture;
        double reducer;
        double xsa;
        if (evaporation_reduction_method == 0)
        {
            critical_soil_moisture = 0.65 * fc;
            if (percentage_soil_coverage() > 0.0)
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
};
}
}
DECLARE_DYNAMICS(record::Et::Evapotranspiration); // balise specifique VLE