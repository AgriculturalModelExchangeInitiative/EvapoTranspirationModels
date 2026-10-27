#include "ETAuxiliary.h"
using namespace Monica_Evapotranspiration;


ETAuxiliary::ETAuxiliary() {}

bool ETAuxiliary::getuse_external_vapor_pressure() { return this->use_external_vapor_pressure; }
double ETAuxiliary::getexternal_vapor_pressure() { return this->external_vapor_pressure; }
bool ETAuxiliary::getcalc_stomata_resistance() { return this->calc_stomata_resistance; }
double ETAuxiliary::getfixed_stomata_resistance() { return this->fixed_stomata_resistance; }
double ETAuxiliary::getgross_photosynthesis_reference_mol() { return this->gross_photosynthesis_reference_mol; }
double ETAuxiliary::getstomata_resistance() { return this->stomata_resistance; }
double ETAuxiliary::getnet_radiation() { return this->net_radiation; }
bool ETAuxiliary::getuse_external_et0() { return this->use_external_et0; }
double ETAuxiliary::getexternal_et0() { return this->external_et0; }
double ETAuxiliary::getdeclination() { return this->declination; }
double ETAuxiliary::getastronomic_daylength() { return this->astronomic_daylength; }
double ETAuxiliary::geteffective_daylength() { return this->effective_daylength; }
double ETAuxiliary::getphotoperiodic_daylength() { return this->photoperiodic_daylength; }
double ETAuxiliary::getsunshine_hours_global_radiation() { return this->sunshine_hours_global_radiation; }
double ETAuxiliary::getextraterrestrial_radiation() { return this->extraterrestrial_radiation; }
double ETAuxiliary::getclear_day_radiation() { return this->clear_day_radiation; }
double ETAuxiliary::getovercast_day_radiation() { return this->overcast_day_radiation; }
double ETAuxiliary::getphot_act_radiation_mean() { return this->phot_act_radiation_mean; }
double ETAuxiliary::getreference_evapotranspiration() { return this->reference_evapotranspiration; }
double ETAuxiliary::getpotential_evapotranspiration() { return this->potential_evapotranspiration; }
double ETAuxiliary::getvapor_pressure() { return this->vapor_pressure; }
double ETAuxiliary::getinternal_vapor_pressure() { return this->internal_vapor_pressure; }
double ETAuxiliary::getinternal_et0() { return this->internal_et0; }
double ETAuxiliary::getsaturated_vapor_pressure() { return this->saturated_vapor_pressure; }
double ETAuxiliary::getsaturation_vapor_pressure_deficit() { return this->saturation_vapor_pressure_deficit; }
double ETAuxiliary::getcalculated_stomata_resistance() { return this->calculated_stomata_resistance; }
double ETAuxiliary::getet0() { return this->et0; }

void ETAuxiliary::setuse_external_vapor_pressure(bool _use_external_vapor_pressure) { this->use_external_vapor_pressure = _use_external_vapor_pressure; }
void ETAuxiliary::setexternal_vapor_pressure(double _external_vapor_pressure) { this->external_vapor_pressure = _external_vapor_pressure; }
void ETAuxiliary::setcalc_stomata_resistance(bool _calc_stomata_resistance) { this->calc_stomata_resistance = _calc_stomata_resistance; }
void ETAuxiliary::setfixed_stomata_resistance(double _fixed_stomata_resistance) { this->fixed_stomata_resistance = _fixed_stomata_resistance; }
void ETAuxiliary::setgross_photosynthesis_reference_mol(double _gross_photosynthesis_reference_mol) { this->gross_photosynthesis_reference_mol = _gross_photosynthesis_reference_mol; }
void ETAuxiliary::setstomata_resistance(double _stomata_resistance) { this->stomata_resistance = _stomata_resistance; }
void ETAuxiliary::setnet_radiation(double _net_radiation) { this->net_radiation = _net_radiation; }
void ETAuxiliary::setuse_external_et0(bool _use_external_et0) { this->use_external_et0 = _use_external_et0; }
void ETAuxiliary::setexternal_et0(double _external_et0) { this->external_et0 = _external_et0; }
void ETAuxiliary::setdeclination(double _declination) { this->declination = _declination; }
void ETAuxiliary::setastronomic_daylength(double _astronomic_daylength) { this->astronomic_daylength = _astronomic_daylength; }
void ETAuxiliary::seteffective_daylength(double _effective_daylength) { this->effective_daylength = _effective_daylength; }
void ETAuxiliary::setphotoperiodic_daylength(double _photoperiodic_daylength) { this->photoperiodic_daylength = _photoperiodic_daylength; }
void ETAuxiliary::setsunshine_hours_global_radiation(double _sunshine_hours_global_radiation) { this->sunshine_hours_global_radiation = _sunshine_hours_global_radiation; }
void ETAuxiliary::setextraterrestrial_radiation(double _extraterrestrial_radiation) { this->extraterrestrial_radiation = _extraterrestrial_radiation; }
void ETAuxiliary::setclear_day_radiation(double _clear_day_radiation) { this->clear_day_radiation = _clear_day_radiation; }
void ETAuxiliary::setovercast_day_radiation(double _overcast_day_radiation) { this->overcast_day_radiation = _overcast_day_radiation; }
void ETAuxiliary::setphot_act_radiation_mean(double _phot_act_radiation_mean) { this->phot_act_radiation_mean = _phot_act_radiation_mean; }
void ETAuxiliary::setreference_evapotranspiration(double _reference_evapotranspiration) { this->reference_evapotranspiration = _reference_evapotranspiration; }
void ETAuxiliary::setpotential_evapotranspiration(double _potential_evapotranspiration) { this->potential_evapotranspiration = _potential_evapotranspiration; }
void ETAuxiliary::setvapor_pressure(double _vapor_pressure) { this->vapor_pressure = _vapor_pressure; }
void ETAuxiliary::setinternal_vapor_pressure(double _internal_vapor_pressure) { this->internal_vapor_pressure = _internal_vapor_pressure; }
void ETAuxiliary::setinternal_et0(double _internal_et0) { this->internal_et0 = _internal_et0; }
void ETAuxiliary::setsaturated_vapor_pressure(double _saturated_vapor_pressure) { this->saturated_vapor_pressure = _saturated_vapor_pressure; }
void ETAuxiliary::setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit) { this->saturation_vapor_pressure_deficit = _saturation_vapor_pressure_deficit; }
void ETAuxiliary::setcalculated_stomata_resistance(double _calculated_stomata_resistance) { this->calculated_stomata_resistance = _calculated_stomata_resistance; }
void ETAuxiliary::setet0(double _et0) { this->et0 = _et0; }