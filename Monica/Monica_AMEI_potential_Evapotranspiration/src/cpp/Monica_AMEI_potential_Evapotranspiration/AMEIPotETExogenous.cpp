#include "AMEIPotETExogenous.h"
using namespace Monica_AMEI_potential_Evapotranspiration;

AMEIPotETExogenous::AMEIPotETExogenous() {}

double AMEIPotETExogenous::getmean_air_temperature() { return this->mean_air_temperature; }
double AMEIPotETExogenous::getwind_speed() { return this->wind_speed; }
double AMEIPotETExogenous::getwind_speed_height() { return this->wind_speed_height; }
double AMEIPotETExogenous::getkc_factor() { return this->kc_factor; }
int AMEIPotETExogenous::getdevelopmental_stage() { return this->developmental_stage; }
double AMEIPotETExogenous::getcrop_remaining_evapotranspiration() { return this->crop_remaining_evapotranspiration; }

void AMEIPotETExogenous::setmean_air_temperature(double _mean_air_temperature) { this->mean_air_temperature = _mean_air_temperature; }
void AMEIPotETExogenous::setwind_speed(double _wind_speed) { this->wind_speed = _wind_speed; }
void AMEIPotETExogenous::setwind_speed_height(double _wind_speed_height) { this->wind_speed_height = _wind_speed_height; }
void AMEIPotETExogenous::setkc_factor(double _kc_factor) { this->kc_factor = _kc_factor; }
void AMEIPotETExogenous::setdevelopmental_stage(int _developmental_stage) { this->developmental_stage = _developmental_stage; }
void AMEIPotETExogenous::setcrop_remaining_evapotranspiration(double _crop_remaining_evapotranspiration) { this->crop_remaining_evapotranspiration = _crop_remaining_evapotranspiration; }