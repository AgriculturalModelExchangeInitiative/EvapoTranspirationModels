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
class Calcstomataresistance: public DiscreteTimeDyn {
public:
    Calcstomataresistance(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        //  Variables gérées par ce composant
        stomata_resistance.init(this,"stomata_resistance", events);
        //  Variables gérées par un autre composant
        calc_stomata_resistance.init(this,"calc_stomata_resistance", events);
        calculated_stomata_resistance.init(this,"calculated_stomata_resistance", events);
        fixed_stomata_resistance.init(this,"fixed_stomata_resistance", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Calcstomataresistance() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        if (calc_stomata_resistance())
        {
            stomata_resistance = calculated_stomata_resistance();
        }
        else
        {
            stomata_resistance = fixed_stomata_resistance();
        }
    }
private:
    //Variables d'etat
    /**
    * @brief the output value (s/m)
    */
    Var stomata_resistance;

    //Entrées
    /**
        * @brief boolean condition to be met ()
        */
    Var calc_stomata_resistance;/**
        * @brief value to be returned if condition is true (s/m)
        */
    Var calculated_stomata_resistance;/**
        * @brief value to be returned if condition is false (s/m)
        */
    Var fixed_stomata_resistance;

    //Paramètres du modele
};
}
}
DECLARE_DYNAMICS(record::Et::Calcstomataresistance); // balise specifique VLE