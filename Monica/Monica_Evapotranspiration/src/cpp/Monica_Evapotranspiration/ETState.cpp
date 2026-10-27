#include "ETState.h"
using namespace Monica_Evapotranspiration;

ETState::ETState() {}

double ETState::getsurface_water_storage() { return this->surface_water_storage; }
double ETState::getevaporated_from_surface() { return this->evaporated_from_surface; }
double ETState::getactual_evaporation() { return this->actual_evaporation; }
double ETState::getactual_transpiration() { return this->actual_transpiration; }
std::vector<double> & ETState::getsoil_moisture() { return this->soil_moisture; }
std::vector<double> & ETState::getevaporation() { return this->evaporation; }
std::vector<double> & ETState::gettranspiration() { return this->transpiration; }
std::vector<double> & ETState::getevapotranspiration() { return this->evapotranspiration; }
double ETState::getactual_evapotranspiration() { return this->actual_evapotranspiration; }

void ETState::setsurface_water_storage(double _surface_water_storage) { this->surface_water_storage = _surface_water_storage; }
void ETState::setevaporated_from_surface(double _evaporated_from_surface) { this->evaporated_from_surface = _evaporated_from_surface; }
void ETState::setactual_evaporation(double _actual_evaporation) { this->actual_evaporation = _actual_evaporation; }
void ETState::setactual_transpiration(double _actual_transpiration) { this->actual_transpiration = _actual_transpiration; }
void ETState::setsoil_moisture(std::vector<double> const &_soil_moisture){
    this->soil_moisture = _soil_moisture;
}
void ETState::setevaporation(std::vector<double> const &_evaporation){
    this->evaporation = _evaporation;
}
void ETState::settranspiration(std::vector<double> const &_transpiration){
    this->transpiration = _transpiration;
}
void ETState::setevapotranspiration(std::vector<double> const &_evapotranspiration){
    this->evapotranspiration = _evapotranspiration;
}
void ETState::setactual_evapotranspiration(double _actual_evapotranspiration) { this->actual_evapotranspiration = _actual_evapotranspiration; }