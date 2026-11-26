#include "AMEIRefETAuxiliary.h"
using namespace Monica_Reference_Evapotranspiration;


AMEIRefETAuxiliary::AMEIRefETAuxiliary() {}

double AMEIRefETAuxiliary::getstomata_resistance() { return this->stomata_resistance; }
double AMEIRefETAuxiliary::getnet_radiation() { return this->net_radiation; }
double AMEIRefETAuxiliary::getsaturation_vapor_pressure_deficit() { return this->saturation_vapor_pressure_deficit; }
double AMEIRefETAuxiliary::getreference_evapotranspiration() { return this->reference_evapotranspiration; }

void AMEIRefETAuxiliary::setstomata_resistance(double _stomata_resistance) { this->stomata_resistance = _stomata_resistance; }
void AMEIRefETAuxiliary::setnet_radiation(double _net_radiation) { this->net_radiation = _net_radiation; }
void AMEIRefETAuxiliary::setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit) { this->saturation_vapor_pressure_deficit = _saturation_vapor_pressure_deficit; }
void AMEIRefETAuxiliary::setreference_evapotranspiration(double _reference_evapotranspiration) { this->reference_evapotranspiration = _reference_evapotranspiration; }