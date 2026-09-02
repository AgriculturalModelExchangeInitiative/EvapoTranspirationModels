#include "EnergyBalanceCompositeState.h"
using namespace SiriusQuality_ET;

EnergyBalanceCompositeState::EnergyBalanceCompositeState() {}

int EnergyBalanceCompositeState::getih() { return this->ih; }
double EnergyBalanceCompositeState::getconductance() { return this->conductance; }

void EnergyBalanceCompositeState::setih(int _ih) { this->ih = _ih; }
void EnergyBalanceCompositeState::setconductance(double _conductance) { this->conductance = _conductance; }