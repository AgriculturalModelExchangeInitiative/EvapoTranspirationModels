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
class Useextet0: public DiscreteTimeDyn {
public:
    Useextet0(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        //  Variables gérées par ce composant
        et0.init(this,"et0", events);
        //  Variables gérées par un autre composant
        use_external_et0.init(this,"use_external_et0", events);
        external_et0.init(this,"external_et0", events);
        internal_et0.init(this,"internal_et0", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Useextet0() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        if (use_external_et0())
        {
            et0 = external_et0();
        }
        else
        {
            et0 = internal_et0();
        }
    }
private:
    //Variables d'etat
    /**
    * @brief the output value (mm)
    */
    Var et0;

    //Entrées
    /**
        * @brief boolean condition to be met ()
        */
    Var use_external_et0;/**
        * @brief value to be returned if condition is true (mm)
        */
    Var external_et0;/**
        * @brief value to be returned if condition is false (mm)
        */
    Var internal_et0;

    //Paramètres du modele
};
}
}
DECLARE_DYNAMICS(record::Et::Useextet0); // balise specifique VLE