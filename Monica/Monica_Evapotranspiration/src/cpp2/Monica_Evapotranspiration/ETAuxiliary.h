#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Monica_Evapotranspiration {
struct ETAuxiliary
{
    double use_external_vapor_pressure{0};
    double external_vapor_pressure{0};
    double gross_photosynthesis_reference_mol{-1};
    double stomata_resistance{100};
    double net_radiation{0.0};
    double use_external_et0{0};
    double external_et0{0};
    double declination{0.0};
    double astronomic_daylength{0.0};
    double effective_daylength{0.0};
    double photoperiodic_daylength{0.0};
    double sunshine_hours_global_radiation{0.0};
    double extraterrestrial_radiation{0.0};
    double clear_day_radiation{0.0};
    double overcast_day_radiation{0.0};
    double phot_act_radiation_mean{0.0};
    double reference_evapotranspiration{0.0};
    double potential_evapotranspiration{0.0};
    double vapor_pressure{0.0};
    double internal_vapor_pressure{0};
    double internal_et0{0};
    double saturated_vapor_pressure{0.0};
    double saturation_vapor_pressure_deficit{0.0};
    double et0{0.0};
};
}