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
class Netradiation: public DiscreteTimeDyn {
public:
    Netradiation(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        height_nn = (events.exist("height_nn")) ? vv::toDouble(events.get("height_nn")) : 0;
        reference_albedo = (events.exist("reference_albedo")) ? vv::toDouble(events.get("reference_albedo")) : 0;
        //  Variables gérées par ce composant
        net_radiation.init(this,"net_radiation", events);
        //  Variables gérées par un autre composant
        extraterrestrial_radiation.init(this,"extraterrestrial_radiation", events);
        vapor_pressure.init(this,"vapor_pressure", events);
        global_radiation.init(this,"global_radiation", events);
        max_air_temperature.init(this,"max_air_temperature", events);
        min_air_temperature.init(this,"min_air_temperature", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Netradiation() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        double clear_sky_solar_radiation;
        clear_sky_solar_radiation = (0.75 + (0.00002 * height_nn)) * extraterrestrial_radiation();
        double relative_shortwave_radiation;
        relative_shortwave_radiation = clear_sky_solar_radiation > 0.0 ? std::min(global_radiation() / clear_sky_solar_radiation, 1.0) : 1.0;
        double bolzmann_constant = 0.0000000049;
        double shortwave_radiation;
        shortwave_radiation = (1.0 - reference_albedo) * global_radiation();
        double longwave_radiation;
        longwave_radiation = bolzmann_constant * ((std::pow(min_air_temperature() + 273.16, 4.0) + std::pow(max_air_temperature() + 273.16, 4.0)) / 2.0) * (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 * std::sqrt(vapor_pressure())));
        net_radiation = shortwave_radiation - longwave_radiation;
    }
private:
    //Variables d'etat
    /**
    * @brief net_radiation (MJ/m2)
    */
    Var net_radiation;

    //Entrées
    /**
        * @brief extraterrestrial_radiation (MJ/m2)
        */
    Var extraterrestrial_radiation;/**
        * @brief vapor pressure (kPa)
        */
    Var vapor_pressure;/**
        * @brief global radiation (MJ/m2)
        */
    Var global_radiation;/**
        * @brief daily maximum air temperature (°C)
        */
    Var max_air_temperature;/**
        * @brief daily minimum air temperature (°C)
        */
    Var min_air_temperature;

    //Paramètres du modele
    /**
    * @brief height above sea level (m)
    */
    double height_nn;
    /**
    * @brief reference albedo (dimensionless)
    */
    double reference_albedo;
};
}
}
DECLARE_DYNAMICS(record::Et::Netradiation); // balise specifique VLE