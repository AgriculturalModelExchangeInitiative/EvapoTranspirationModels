#include "PotentialET_PTRate.h"
using namespace SiriusQuality_Priestly_Taylor;


PotentialET_PTRate::PotentialET_PTRate() {}

double PotentialET_PTRate::getevapoTranspirationPriestlyTaylor() { return this->evapoTranspirationPriestlyTaylor; }

void PotentialET_PTRate::setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor) { this->evapoTranspirationPriestlyTaylor = _evapoTranspirationPriestlyTaylor; }