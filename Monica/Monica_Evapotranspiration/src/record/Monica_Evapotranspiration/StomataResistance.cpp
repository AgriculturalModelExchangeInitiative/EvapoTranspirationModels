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
class Stomataresistance: public DiscreteTimeDyn {
public:
    Stomataresistance(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        saturation_beta = (events.exist("saturation_beta")) ? vv::toDouble(events.get("saturation_beta")) : 2.5;
        stomata_conductance_alpha = (events.exist("stomata_conductance_alpha")) ? vv::toDouble(events.get("stomata_conductance_alpha")) : 40;
        carboxylation_pathway = (events.exist("carboxylation_pathway")) ? vv::toInteger(events.get("carboxylation_pathway")) : 0;
        //  Variables gérées par ce composant
        stomata_resistance.init(this,"stomata_resistance", events);
        //  Variables gérées par un autre composant
        saturation_vapor_pressure_deficit.init(this,"saturation_vapor_pressure_deficit", events);
        gross_photosynthesis_reference_mol.init(this,"gross_photosynthesis_reference_mol", events);
        atmospheric_co2_concentration.init(this,"atmospheric_co2_concentration", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Stomataresistance() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        if (carboxylation_pathway > 0)
        {
            if (gross_photosynthesis_reference_mol() <= 0.0)
            {
                stomata_resistance = 999999.9;
            }
            else if ( carboxylation_pathway == 1)
            {
                stomata_resistance = atmospheric_co2_concentration() * (1.0 + (saturation_vapor_pressure_deficit() / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol());
            }
            else
            {
                stomata_resistance = atmospheric_co2_concentration() * (1.0 + (saturation_vapor_pressure_deficit() / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol());
            }
        }
    }
private:
    //Variables d'etat
    /**
    * @brief stomata resistance (FAO default value is 100) (s/m)
    */
    Var stomata_resistance;

    //Entrées
    /**
        * @brief saturation_vapor_pressure_deficit (kPa)
        */
    Var saturation_vapor_pressure_deficit;/**
        * @brief gross_photosynthesis_reference_mol (-1 = not supplied = no crop) ([mol m-2 s-1] or [cm3 cm-2 s-1])
        */
    Var gross_photosynthesis_reference_mol;/**
        * @brief CO2 concentration in the atmosphere. Optional if no crop. (ppm)
        */
    Var atmospheric_co2_concentration;

    //Paramètres du modele
    /**
    * @brief Original: Yu et al. 2001; beta = 3.5 ()
    */
    double saturation_beta;
    /**
    * @brief Original: Yu et al. 2001; alpha = 0.06 mol/m2/s (mmol/m2/s)
    */
    double stomata_conductance_alpha;
    /**
    * @brief Is it a C3 (=1) or C4 (=2) crop. (0 = no crop) (dimensionless)
    */
    int carboxylation_pathway;
};
}
}
DECLARE_DYNAMICS(record::Et::Stomataresistance); // balise specifique VLE