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
class Saturatedvaporpressure: public DiscreteTimeDyn {
public:
    Saturatedvaporpressure(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        //  Variables gérées par ce composant
        saturated_vapor_pressure.init(this,"saturated_vapor_pressure", events);
        vapor_pressure.init(this,"vapor_pressure", events);
        //  Variables gérées par un autre composant
        max_air_temperature.init(this,"max_air_temperature", events);
        min_air_temperature.init(this,"min_air_temperature", events);
        relative_humidity.init(this,"relative_humidity", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Saturatedvaporpressure() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        double saturated_vapor_pressure_max;
        saturated_vapor_pressure_max = 0.6108 * std::exp(17.27 * max_air_temperature() / (237.3 + max_air_temperature()));
        double saturated_vapor_pressure_min;
        saturated_vapor_pressure_min = 0.6108 * std::exp(17.27 * min_air_temperature() / (237.3 + min_air_temperature()));
        saturated_vapor_pressure = (saturated_vapor_pressure_max + saturated_vapor_pressure_min) / 2.0;
        if (relative_humidity() <= 0.0)
        {
            vapor_pressure = saturated_vapor_pressure_min;
        }
        else
        {
            vapor_pressure = relative_humidity() * saturated_vapor_pressure();
        }
    }
private:
    //Variables d'etat
    /**
    * @brief saturated vapor pressure (kPa)
    */
    Var saturated_vapor_pressure;/**
    * @brief vapor pressure from relative humidity and saturated vapor pressure (kPa)
    */
    Var vapor_pressure;

    //Entrées
    /**
        * @brief daily maximum air temperature (°C)
        */
    Var max_air_temperature;/**
        * @brief daily minimum air temperature (°C)
        */
    Var min_air_temperature;/**
        * @brief relative humidity (fraction)
        */
    Var relative_humidity;

    //Paramètres du modele
};
}
}
DECLARE_DYNAMICS(record::Et::Saturatedvaporpressure); // balise specifique VLE