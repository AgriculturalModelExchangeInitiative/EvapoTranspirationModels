#include "AMEIPotETAuxiliary.h"
using namespace Monica_AMEI_potential_Evapotranspiration;


AMEIPotETAuxiliary::AMEIPotETAuxiliary() {}

double AMEIPotETAuxiliary::getvapor_pressure() { return this->vapor_pressure; }
double AMEIPotETAuxiliary::getsaturated_vapor_pressure() { return this->saturated_vapor_pressure; }
double AMEIPotETAuxiliary::getstomata_resistance() { return this->stomata_resistance; }
double AMEIPotETAuxiliary::getnet_radiation() { return this->net_radiation; }
double AMEIPotETAuxiliary::getreference_evapotranspiration() { return this->reference_evapotranspiration; }
double AMEIPotETAuxiliary::getpotential_evapotranspiration() { return this->potential_evapotranspiration; }
double AMEIPotETAuxiliary::getsaturation_vapor_pressure_deficit() { return this->saturation_vapor_pressure_deficit; }

void AMEIPotETAuxiliary::setvapor_pressure(double _vapor_pressure) { this->vapor_pressure = _vapor_pressure; }
void AMEIPotETAuxiliary::setsaturated_vapor_pressure(double _saturated_vapor_pressure) { this->saturated_vapor_pressure = _saturated_vapor_pressure; }
void AMEIPotETAuxiliary::setstomata_resistance(double _stomata_resistance) { this->stomata_resistance = _stomata_resistance; }
void AMEIPotETAuxiliary::setnet_radiation(double _net_radiation) { this->net_radiation = _net_radiation; }
void AMEIPotETAuxiliary::setreference_evapotranspiration(double _reference_evapotranspiration) { this->reference_evapotranspiration = _reference_evapotranspiration; }
void AMEIPotETAuxiliary::setpotential_evapotranspiration(double _potential_evapotranspiration) { this->potential_evapotranspiration = _potential_evapotranspiration; }
void AMEIPotETAuxiliary::setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit) { this->saturation_vapor_pressure_deficit = _saturation_vapor_pressure_deficit; }