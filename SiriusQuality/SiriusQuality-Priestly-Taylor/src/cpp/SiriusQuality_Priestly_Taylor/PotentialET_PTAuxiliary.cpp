#include "PotentialET_PTAuxiliary.h"
using namespace SiriusQuality_Priestly_Taylor;

PotentialET_PTAuxiliary::PotentialET_PTAuxiliary() {}

double PotentialET_PTAuxiliary::getsolarRadiation() { return this->solarRadiation; }
double PotentialET_PTAuxiliary::gethslope() { return this->hslope; }
double PotentialET_PTAuxiliary::getnetRadiation() { return this->netRadiation; }

void PotentialET_PTAuxiliary::setsolarRadiation(double _solarRadiation) { this->solarRadiation = _solarRadiation; }
void PotentialET_PTAuxiliary::sethslope(double _hslope) { this->hslope = _hslope; }
void PotentialET_PTAuxiliary::setnetRadiation(double _netRadiation) { this->netRadiation = _netRadiation; }