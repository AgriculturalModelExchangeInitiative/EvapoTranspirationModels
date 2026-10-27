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
class Potentialevapotranspiration: public DiscreteTimeDyn {
public:
    Potentialevapotranspiration(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        potential_evapotranspiration_cap = (events.exist("potential_evapotranspiration_cap")) ? vv::toDouble(events.get("potential_evapotranspiration_cap")) : 6.5;
        //  Variables gérées par ce composant
        potential_evapotranspiration.init(this,"potential_evapotranspiration", events);
        //  Variables gérées par un autre composant
        reference_evapotranspiration.init(this,"reference_evapotranspiration", events);
        kc_factor.init(this,"kc_factor", events);
        developmental_stage.init(this,"developmental_stage", events);
        crop_remaining_evapotranspiration.init(this,"crop_remaining_evapotranspiration", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Potentialevapotranspiration() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        if (developmental_stage() > 0)
        {
            potential_evapotranspiration = crop_remaining_evapotranspiration();
        }
        else
        {
            potential_evapotranspiration = reference_evapotranspiration() * kc_factor();
        }
        if (potential_evapotranspiration() > potential_evapotranspiration_cap)
        {
            potential_evapotranspiration = potential_evapotranspiration_cap;
        }
    }
private:
    //Variables d'etat
    /**
    * @brief the potential evapotranspiration (mm)
    */
    Var potential_evapotranspiration;

    //Entrées
    /**
        * @brief ET0 either from external ET0 or crop specific ET0 (mm)
        */
    Var reference_evapotranspiration;/**
        * @brief crop coefficient ETc/ET0 (dimensionless)
        */
    Var kc_factor;/**
        * @brief MONICA crop developmental stage (dimensionless)
        */
    Var developmental_stage;/**
        * @brief crop remaining evapotranspiration (mm)
        */
    Var crop_remaining_evapotranspiration;

    //Paramètres du modele
    /**
    * @brief cap ET0 to this value (mm)
    */
    double potential_evapotranspiration_cap;
};
}
}
DECLARE_DYNAMICS(record::Et::Potentialevapotranspiration); // balise specifique VLE