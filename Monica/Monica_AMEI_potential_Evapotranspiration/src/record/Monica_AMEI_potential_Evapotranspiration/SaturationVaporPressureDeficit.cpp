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
class Saturationvaporpressuredeficit: public DiscreteTimeDyn {
public:
    Saturationvaporpressuredeficit(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        //  Variables gérées par ce composant
        saturation_vapor_pressure_deficit.init(this,"saturation_vapor_pressure_deficit", events);
        //  Variables gérées par un autre composant
        saturated_vapor_pressure.init(this,"saturated_vapor_pressure", events);
        vapor_pressure.init(this,"vapor_pressure", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Saturationvaporpressuredeficit() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        saturation_vapor_pressure_deficit = saturated_vapor_pressure() - vapor_pressure();
    }
private:
    //Variables d'etat
    /**
    * @brief saturation vapor pressure deficit (kPa)
    */
    Var saturation_vapor_pressure_deficit;

    //Entrées
    /**
        * @brief saturated vapor pressure (kPa)
        */
    Var saturated_vapor_pressure;/**
        * @brief vapor pressure (kPa)
        */
    Var vapor_pressure;

    //Paramètres du modele
};
}
}
DECLARE_DYNAMICS(record::Ameipotet::Saturationvaporpressuredeficit); // balise specifique VLE