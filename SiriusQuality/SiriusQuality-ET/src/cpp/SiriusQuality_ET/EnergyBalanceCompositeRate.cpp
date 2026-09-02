#include "EnergyBalanceCompositeRate.h"
using namespace SiriusQuality_ET;

EnergyBalanceCompositeRate::EnergyBalanceCompositeRate() {}

double EnergyBalanceCompositeRate::getevapoTranspirationPriestlyTaylor() { return this->evapoTranspirationPriestlyTaylor; }
double EnergyBalanceCompositeRate::getevapoTranspirationPenman() { return this->evapoTranspirationPenman; }

void EnergyBalanceCompositeRate::setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor) { this->evapoTranspirationPriestlyTaylor = _evapoTranspirationPriestlyTaylor; }
void EnergyBalanceCompositeRate::setevapoTranspirationPenman(double _evapoTranspirationPenman) { this->evapoTranspirationPenman = _evapoTranspirationPenman; }