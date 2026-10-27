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
class Useextvaporpressure: public DiscreteTimeDyn {
public:
    Useextvaporpressure(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        //  Variables gérées par ce composant
        vapor_pressure.init(this,"vapor_pressure", events);
        //  Variables gérées par un autre composant
        use_external_vapor_pressure.init(this,"use_external_vapor_pressure", events);
        external_vapor_pressure.init(this,"external_vapor_pressure", events);
        internal_vapor_pressure.init(this,"internal_vapor_pressure", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Useextvaporpressure() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        if (use_external_vapor_pressure())
        {
            vapor_pressure = external_vapor_pressure();
        }
        else
        {
            vapor_pressure = internal_vapor_pressure();
        }
    }
private:
    //Variables d'etat
    /**
    * @brief the output value (mm)
    */
    Var vapor_pressure;

    //Entrées
    /**
        * @brief boolean condition to be met (mm)
        */
    Var use_external_vapor_pressure;/**
        * @brief value to be returned if condition is true (kPa)
        */
    Var external_vapor_pressure;/**
        * @brief value to be returned if condition is false (kPa)
        */
    Var internal_vapor_pressure;

    //Paramètres du modele
};
}
}
DECLARE_DYNAMICS(record::Et::Useextvaporpressure); // balise specifique VLE