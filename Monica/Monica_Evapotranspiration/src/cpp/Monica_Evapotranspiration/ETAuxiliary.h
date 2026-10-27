#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_Evapotranspiration {
class ETAuxiliary
{
    private:
        bool use_external_vapor_pressure ;
        double external_vapor_pressure ;
        bool calc_stomata_resistance ;
        double fixed_stomata_resistance ;
        double gross_photosynthesis_reference_mol ;
        double stomata_resistance ;
        double net_radiation ;
        bool use_external_et0 ;
        double external_et0 ;
        double declination ;
        double astronomic_daylength ;
        double effective_daylength ;
        double photoperiodic_daylength ;
        double sunshine_hours_global_radiation ;
        double extraterrestrial_radiation ;
        double clear_day_radiation ;
        double overcast_day_radiation ;
        double phot_act_radiation_mean ;
        double reference_evapotranspiration ;
        double potential_evapotranspiration ;
        double vapor_pressure ;
        double internal_vapor_pressure ;
        double internal_et0 ;
        double saturated_vapor_pressure ;
        double saturation_vapor_pressure_deficit ;
        double calculated_stomata_resistance ;
        double et0 ;
    public:
        ETAuxiliary();
        bool getuse_external_vapor_pressure();
        void setuse_external_vapor_pressure(bool _use_external_vapor_pressure);
        double getexternal_vapor_pressure();
        void setexternal_vapor_pressure(double _external_vapor_pressure);
        bool getcalc_stomata_resistance();
        void setcalc_stomata_resistance(bool _calc_stomata_resistance);
        double getfixed_stomata_resistance();
        void setfixed_stomata_resistance(double _fixed_stomata_resistance);
        double getgross_photosynthesis_reference_mol();
        void setgross_photosynthesis_reference_mol(double _gross_photosynthesis_reference_mol);
        double getstomata_resistance();
        void setstomata_resistance(double _stomata_resistance);
        double getnet_radiation();
        void setnet_radiation(double _net_radiation);
        bool getuse_external_et0();
        void setuse_external_et0(bool _use_external_et0);
        double getexternal_et0();
        void setexternal_et0(double _external_et0);
        double getdeclination();
        void setdeclination(double _declination);
        double getastronomic_daylength();
        void setastronomic_daylength(double _astronomic_daylength);
        double geteffective_daylength();
        void seteffective_daylength(double _effective_daylength);
        double getphotoperiodic_daylength();
        void setphotoperiodic_daylength(double _photoperiodic_daylength);
        double getsunshine_hours_global_radiation();
        void setsunshine_hours_global_radiation(double _sunshine_hours_global_radiation);
        double getextraterrestrial_radiation();
        void setextraterrestrial_radiation(double _extraterrestrial_radiation);
        double getclear_day_radiation();
        void setclear_day_radiation(double _clear_day_radiation);
        double getovercast_day_radiation();
        void setovercast_day_radiation(double _overcast_day_radiation);
        double getphot_act_radiation_mean();
        void setphot_act_radiation_mean(double _phot_act_radiation_mean);
        double getreference_evapotranspiration();
        void setreference_evapotranspiration(double _reference_evapotranspiration);
        double getpotential_evapotranspiration();
        void setpotential_evapotranspiration(double _potential_evapotranspiration);
        double getvapor_pressure();
        void setvapor_pressure(double _vapor_pressure);
        double getinternal_vapor_pressure();
        void setinternal_vapor_pressure(double _internal_vapor_pressure);
        double getinternal_et0();
        void setinternal_et0(double _internal_et0);
        double getsaturated_vapor_pressure();
        void setsaturated_vapor_pressure(double _saturated_vapor_pressure);
        double getsaturation_vapor_pressure_deficit();
        void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit);
        double getcalculated_stomata_resistance();
        void setcalculated_stomata_resistance(double _calculated_stomata_resistance);
        double getet0();
        void setet0(double _et0);

};
}
