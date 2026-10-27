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
class Radiation: public DiscreteTimeDyn {
public:
    Radiation(const vd::DynamicsInit& atom, const vd::InitEventList& events) : DiscreteTimeDyn(atom, events)
    {
        // Ces parametres ont une valeur par defaut utilise si la condition n'est pas definie
        latitude = (events.exist("latitude")) ? vv::toDouble(events.get("latitude")) : 0;
        //  Variables gérées par ce composant
        declination.init(this,"declination", events);
        astronomic_daylength.init(this,"astronomic_daylength", events);
        effective_daylength.init(this,"effective_daylength", events);
        photoperiodic_daylength.init(this,"photoperiodic_daylength", events);
        sunshine_hours_global_radiation.init(this,"sunshine_hours_global_radiation", events);
        extraterrestrial_radiation.init(this,"extraterrestrial_radiation", events);
        clear_day_radiation.init(this,"clear_day_radiation", events);
        overcast_day_radiation.init(this,"overcast_day_radiation", events);
        phot_act_radiation_mean.init(this,"phot_act_radiation_mean", events);
        //  Variables gérées par un autre composant
        global_radiation.init(this,"global_radiation", events);
        julian_day.init(this,"julian_day", events);
        sunshine_hours.init(this,"sunshine_hours", events);
    }
    /**
    * @brief Destructeur de la classe du modèle.
    **/
    virtual ~Radiation() {};
    /**
    * @brief Methode de calcul effectuée à chaque pas de temps
    * @param time la date du pas de temps courant
    */
    virtual void compute(const vd::Time& /*time*/)
    {
        double decl_sin;
        double decl_cos;
        tie(declination(), decl_sin, decl_cos) = calc_declinations(latitude, julian_day());
        astronomic_daylength = calc_astronomic_daylength(latitude, julian_day());
        effective_daylength = calc_effective_daylength(latitude, julian_day());
        photoperiodic_daylength = calc_photoperiodic_daylength(latitude, julian_day());
        double arg_phot_act;
        arg_phot_act = std::min(1.0, decl_sin / decl_cos * (decl_sin / decl_cos));
        phot_act_radiation_mean = 3600.0 * (decl_sin * astronomic_daylength() + (24.0 / M_PI * decl_cos * std::sqrt((1.0 - arg_phot_act))));
        if (phot_act_radiation_mean() > 0.0 && astronomic_daylength() > 0.0)
        {
            clear_day_radiation = 0.5 * 1300.0 * phot_act_radiation_mean() * std::exp(-0.14 / (phot_act_radiation_mean() / (astronomic_daylength() * 3600.0)));
        }
        overcast_day_radiation = 0.2 * clear_day_radiation();
        double solar_constant;
        solar_constant = 0.082;
        double SC;
        SC = 24.0 * 60.0 / M_PI * solar_constant * (1.0 + (0.033 * std::cos(2.0 * M_PI * julian_day() / 365.0)));
        double solar_angle;
        solar_angle = -std::tan((latitude * M_PI / 180.0)) * std::tan(declination() * M_PI / 180.0);
        solar_angle = bound(-1.0, solar_angle, 1.0);
        double sunset_solar_angle;
        sunset_solar_angle = std::acos(solar_angle);
        extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * std::sin(sunset_solar_angle)));
        if (sunshine_hours() > 0.0)
        {
            if (global_radiation() <= 0.0 && astronomic_daylength() > 0.0)
            {
                sunshine_hours_global_radiation = extraterrestrial_radiation() * (0.19 + (0.55 * sunshine_hours() / astronomic_daylength()));
            }
            else
            {
                sunshine_hours_global_radiation = 0.0;
            }
        }
    }
private:
    //Variables d'etat
    /**
    * @brief declination ()
    */
    Var declination;/**
    * @brief astronomic_daylength (mm)
    */
    Var astronomic_daylength;/**
    * @brief effective_daylength (mm)
    */
    Var effective_daylength;/**
    * @brief photoperiodic_daylength (mm)
    */
    Var photoperiodic_daylength;/**
    * @brief global radiation calculated from sunshine hours (MJ/m2)
    */
    Var sunshine_hours_global_radiation;/**
    * @brief extraterrestrial_radiation (MJ/m2)
    */
    Var extraterrestrial_radiation;/**
    * @brief clear_day_radiation (MJ/m2)
    */
    Var clear_day_radiation;/**
    * @brief overcast_day_radiation (MJ/m2)
    */
    Var overcast_day_radiation;/**
    * @brief phot_act_radiation_mean (J/m2)
    */
    Var phot_act_radiation_mean;

    //Entrées
    /**
        * @brief global radiation (MJ/m2)
        */
    Var global_radiation;/**
        * @brief day of year (day)
        */
    Var julian_day;/**
        * @brief number of sunshine hours (h)
        */
    Var sunshine_hours;

    //Paramètres du modele
    /**
    * @brief latitude (degree)
    */
    double latitude;
    double Radiation:: bound(double lower, double value, double upper)
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
    std::tuple<double,double,double> Radiation:: calc_declinations(double latitude, int julian_day)
    {
        declination = -23.4 * std::cos(2.0 * M_PI * ((julian_day() + 10.0) / 365.0));
        double decl_sin;
        decl_sin = std::sin(declination() * M_PI / 180.0) * std::sin(latitude * M_PI / 180.0);
        double decl_cos;
        decl_cos = std::cos(declination() * M_PI / 180.0) * std::cos(latitude * M_PI / 180.0);
        return make_tuple(declination(), decl_sin, decl_cos);
    }
    double Radiation:: calc_astronomic_daylength(double latitude, int julian_day)
    {
        double decl_sin;
        double decl_cos;
        tie(declination(), decl_sin, decl_cos) = calc_declinations(latitude, julian_day());
        double astro_daylength;
        astro_daylength = decl_sin / decl_cos;
        astro_daylength = bound(-1.0, astro_daylength, 1.0);
        astronomic_daylength = 12.0 * (M_PI + (2.0 * std::asin(astro_daylength))) / M_PI;
        return astronomic_daylength();
    }
    double Radiation:: calc_effective_daylength(double latitude, int julian_day)
    {
        double decl_sin;
        double decl_cos;
        tie(declination(), decl_sin, decl_cos) = calc_declinations(latitude, julian_day());
        double eff_daylength;
        eff_daylength = (-std::sin((8.0 * M_PI / 180.0)) + decl_sin) / decl_cos;
        eff_daylength = bound(-1.0, eff_daylength, 1.0);
        effective_daylength = 12.0 * (M_PI + (2.0 * std::asin(eff_daylength))) / M_PI;
        return effective_daylength();
    }
    double Radiation:: calc_photoperiodic_daylength(double latitude, int julian_day)
    {
        double decl_sin;
        double decl_cos;
        tie(declination(), decl_sin, decl_cos) = calc_declinations(latitude, julian_day());
        double photo_daylength;
        photo_daylength = (-std::sin((-6.0 * M_PI / 180.0)) + decl_sin) / decl_cos;
        photo_daylength = bound(-1.0, photo_daylength, 1.0);
        photoperiodic_daylength = 12.0 * (M_PI + (2.0 * std::asin(photo_daylength))) / M_PI;
        return photoperiodic_daylength();
    }
};
}
}
DECLARE_DYNAMICS(record::Et::Radiation); // balise specifique VLE