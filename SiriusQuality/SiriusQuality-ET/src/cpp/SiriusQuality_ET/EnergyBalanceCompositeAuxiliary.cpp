#include "EnergyBalanceCompositeAuxiliary.h"
using namespace SiriusQuality_ET;

EnergyBalanceCompositeAuxiliary::EnergyBalanceCompositeAuxiliary() {}

double EnergyBalanceCompositeAuxiliary::getmaxTair() { return this->maxTair; }
double EnergyBalanceCompositeAuxiliary::getminTair() { return this->minTair; }
double EnergyBalanceCompositeAuxiliary::getvaporPressure() { return this->vaporPressure; }
double EnergyBalanceCompositeAuxiliary::getextraSolarRadiation() { return this->extraSolarRadiation; }
double EnergyBalanceCompositeAuxiliary::getsolarRadiation() { return this->solarRadiation; }
double EnergyBalanceCompositeAuxiliary::getplantHeight() { return this->plantHeight; }
double EnergyBalanceCompositeAuxiliary::getwind() { return this->wind; }
double EnergyBalanceCompositeAuxiliary::gethslope() { return this->hslope; }
double EnergyBalanceCompositeAuxiliary::getVPDair() { return this->VPDair; }
double EnergyBalanceCompositeAuxiliary::getnetOutGoingLongWaveRadiation() { return this->netOutGoingLongWaveRadiation; }
double EnergyBalanceCompositeAuxiliary::getnetRadiation() { return this->netRadiation; }
double EnergyBalanceCompositeAuxiliary::getnetRadiationEquivalentEvaporation() { return this->netRadiationEquivalentEvaporation; }

void EnergyBalanceCompositeAuxiliary::setmaxTair(double _maxTair) { this->maxTair = _maxTair; }
void EnergyBalanceCompositeAuxiliary::setminTair(double _minTair) { this->minTair = _minTair; }
void EnergyBalanceCompositeAuxiliary::setvaporPressure(double _vaporPressure) { this->vaporPressure = _vaporPressure; }
void EnergyBalanceCompositeAuxiliary::setextraSolarRadiation(double _extraSolarRadiation) { this->extraSolarRadiation = _extraSolarRadiation; }
void EnergyBalanceCompositeAuxiliary::setsolarRadiation(double _solarRadiation) { this->solarRadiation = _solarRadiation; }
void EnergyBalanceCompositeAuxiliary::setplantHeight(double _plantHeight) { this->plantHeight = _plantHeight; }
void EnergyBalanceCompositeAuxiliary::setwind(double _wind) { this->wind = _wind; }
void EnergyBalanceCompositeAuxiliary::sethslope(double _hslope) { this->hslope = _hslope; }
void EnergyBalanceCompositeAuxiliary::setVPDair(double _VPDair) { this->VPDair = _VPDair; }
void EnergyBalanceCompositeAuxiliary::setnetOutGoingLongWaveRadiation(double _netOutGoingLongWaveRadiation) { this->netOutGoingLongWaveRadiation = _netOutGoingLongWaveRadiation; }
void EnergyBalanceCompositeAuxiliary::setnetRadiation(double _netRadiation) { this->netRadiation = _netRadiation; }
void EnergyBalanceCompositeAuxiliary::setnetRadiationEquivalentEvaporation(double _netRadiationEquivalentEvaporation) { this->netRadiationEquivalentEvaporation = _netRadiationEquivalentEvaporation; }