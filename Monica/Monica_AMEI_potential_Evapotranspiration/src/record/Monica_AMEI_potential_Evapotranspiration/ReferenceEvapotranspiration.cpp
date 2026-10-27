// @@tagdynamic@@
// @@tagdepends: vle.discrete-time @@endtagdepends

#include <vle/DiscreteTime.hpp>
namespace vd = vle::devs;
namespace vv = vle::value;
// Definition du namespace de la classe du modele
namespace record {
using namespace std;
namespace Ameipotet {
using namespace vle::discrete_time;
class Referenceevapotranspiration: public DiscreteTimeDyn {
public:
    Referenceevapotranspiration(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        height_nn = (events.exist("height_nn")) ? vv::toDouble(events.get("height_nn")) : 0;
        //  Variables gérées par ce composant
        reference_evapotranspiration.init(this,"reference_evapotranspiration", events);
        //  Variables gérées par un autre composant
        net_radiation.init(this,"net_radiation", events);
        stomata_resistance.init(this,"stomata_resistance", events);
        saturation_vapor_pressure_deficit.init(this,"saturation_vapor_pressure_deficit", events);
        mean_air_temperature.init(this,"mean_air_temperature", events);
        wind_speed.init(this,"wind_speed", events);
        wind_speed_height.init(this,"wind_speed_height", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Referenceevapotranspiration() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        double atmospheric_pressure;
        atmospheric_pressure = 101.3 * std::pow((293.0 - (0.0065 * height_nn)) / 293.0, 5.26);
        double psycrometer_constant;
        psycrometer_constant = 0.000665 * atmospheric_pressure;
        double saturated_vapour_pressure_slope;
        saturated_vapour_pressure_slope = 4098.0 * (0.6108 * std::exp(17.27 * mean_air_temperature() / (mean_air_temperature() + 237.3))) / ((mean_air_temperature() + 237.3) * (mean_air_temperature() + 237.3));
        double wind_speed_2m;
        wind_speed_2m = std::max(0.5, wind_speed() * (4.87 / std::log((67.8 * wind_speed_height() - 5.42))));
        double aerodynamic_resistance;
        aerodynamic_resistance = 208.0 / wind_speed_2m;
        double surface_resistance;
        surface_resistance = stomata_resistance() / 1.44;
        reference_evapotranspiration = (0.408 * saturated_vapour_pressure_slope * net_radiation() + (psycrometer_constant * (900.0 / (mean_air_temperature() + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit())) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))));
        if (reference_evapotranspiration() < 0.0)
        {
            reference_evapotranspiration = 0.0;
        }
    }
private:
    //Variables d'etat
    /**
    * @brief reference evapotranspiration (ET0) (mm)
    */
    Var reference_evapotranspiration;

    //Entrées
    /**
        * @brief net radiation (MJ/m2)
        */
    Var net_radiation;/**
        * @brief stomata resistance (FAO default value is 100) (s/m)
        */
    Var stomata_resistance;/**
        * @brief saturation_vapor_pressure_deficit (kPa)
        */
    Var saturation_vapor_pressure_deficit;/**
        * @brief daily average air temperature (°C)
        */
    Var mean_air_temperature;/**
        * @brief wind speed measured at wind speed height (m/s)
        */
    Var wind_speed;/**
        * @brief height at which the wind speed has been measured (m)
        */
    Var wind_speed_height;

    //Paramètres du modele
    /**
    * @brief height above sea level (m)
    */
    double height_nn;
};
}
}
DECLARE_DYNAMICS(record::Ameipotet::Referenceevapotranspiration); // balise specifique VLE