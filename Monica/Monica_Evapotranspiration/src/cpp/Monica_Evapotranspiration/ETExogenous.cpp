#include "ETExogenous.h"
using namespace Monica_Evapotranspiration;

ETExogenous::ETExogenous() {}

double ETExogenous::getglobal_radiation() { return this->global_radiation; }
int ETExogenous::getjulian_day() { return this->julian_day; }
double ETExogenous::getsunshine_hours() { return this->sunshine_hours; }
double ETExogenous::getmax_air_temperature() { return this->max_air_temperature; }
double ETExogenous::getmin_air_temperature() { return this->min_air_temperature; }
double ETExogenous::getrelative_humidity() { return this->relative_humidity; }
double ETExogenous::getatmospheric_co2_concentration() { return this->atmospheric_co2_concentration; }
double ETExogenous::getmean_air_temperature() { return this->mean_air_temperature; }
double ETExogenous::getwind_speed() { return this->wind_speed; }
double ETExogenous::getwind_speed_height() { return this->wind_speed_height; }
double ETExogenous::getkc_factor() { return this->kc_factor; }
int ETExogenous::getdevelopmental_stage() { return this->developmental_stage; }
double ETExogenous::getcrop_remaining_evapotranspiration() { return this->crop_remaining_evapotranspiration; }
bool ETExogenous::gethas_snow_cover() { return this->has_snow_cover; }
std::vector<double> & ETExogenous::getcrop_transpiration() { return this->crop_transpiration; }
double ETExogenous::getcrop_evaporated_from_intercepted() { return this->crop_evaporated_from_intercepted; }
double ETExogenous::getpercentage_soil_coverage() { return this->percentage_soil_coverage; }

void ETExogenous::setglobal_radiation(double _global_radiation) { this->global_radiation = _global_radiation; }
void ETExogenous::setjulian_day(int _julian_day) { this->julian_day = _julian_day; }
void ETExogenous::setsunshine_hours(double _sunshine_hours) { this->sunshine_hours = _sunshine_hours; }
void ETExogenous::setmax_air_temperature(double _max_air_temperature) { this->max_air_temperature = _max_air_temperature; }
void ETExogenous::setmin_air_temperature(double _min_air_temperature) { this->min_air_temperature = _min_air_temperature; }
void ETExogenous::setrelative_humidity(double _relative_humidity) { this->relative_humidity = _relative_humidity; }
void ETExogenous::setatmospheric_co2_concentration(double _atmospheric_co2_concentration) { this->atmospheric_co2_concentration = _atmospheric_co2_concentration; }
void ETExogenous::setmean_air_temperature(double _mean_air_temperature) { this->mean_air_temperature = _mean_air_temperature; }
void ETExogenous::setwind_speed(double _wind_speed) { this->wind_speed = _wind_speed; }
void ETExogenous::setwind_speed_height(double _wind_speed_height) { this->wind_speed_height = _wind_speed_height; }
void ETExogenous::setkc_factor(double _kc_factor) { this->kc_factor = _kc_factor; }
void ETExogenous::setdevelopmental_stage(int _developmental_stage) { this->developmental_stage = _developmental_stage; }
void ETExogenous::setcrop_remaining_evapotranspiration(double _crop_remaining_evapotranspiration) { this->crop_remaining_evapotranspiration = _crop_remaining_evapotranspiration; }
void ETExogenous::sethas_snow_cover(bool _has_snow_cover) { this->has_snow_cover = _has_snow_cover; }
void ETExogenous::setcrop_transpiration(std::vector<double> const &_crop_transpiration){
    this->crop_transpiration = _crop_transpiration;
}
void ETExogenous::setcrop_evaporated_from_intercepted(double _crop_evaporated_from_intercepted) { this->crop_evaporated_from_intercepted = _crop_evaporated_from_intercepted; }
void ETExogenous::setpercentage_soil_coverage(double _percentage_soil_coverage) { this->percentage_soil_coverage = _percentage_soil_coverage; }