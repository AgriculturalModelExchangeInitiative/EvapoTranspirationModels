#include "AMEIRefETExogenous.h"
using namespace Monica_Reference_Evapotranspiration;

AMEIRefETExogenous::AMEIRefETExogenous() {}

double AMEIRefETExogenous::getmean_air_temperature() { return this->mean_air_temperature; }
double AMEIRefETExogenous::getwind_speed() { return this->wind_speed; }
double AMEIRefETExogenous::getwind_speed_height() { return this->wind_speed_height; }

void AMEIRefETExogenous::setmean_air_temperature(double _mean_air_temperature) { this->mean_air_temperature = _mean_air_temperature; }
void AMEIRefETExogenous::setwind_speed(double _wind_speed) { this->wind_speed = _wind_speed; }
void AMEIRefETExogenous::setwind_speed_height(double _wind_speed_height) { this->wind_speed_height = _wind_speed_height; }