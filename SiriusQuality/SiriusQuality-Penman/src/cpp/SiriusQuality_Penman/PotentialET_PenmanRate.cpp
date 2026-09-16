#include "PotentialET_PenmanRate.h"
using namespace SiriusQuality_Penman;


PotentialET_PenmanRate::PotentialET_PenmanRate() {}

double PotentialET_PenmanRate::getevapoTranspirationPenman() { return this->evapoTranspirationPenman; }
double PotentialET_PenmanRate::getevapoTranspirationPriestlyTaylor() { return this->evapoTranspirationPriestlyTaylor; }

void PotentialET_PenmanRate::setevapoTranspirationPenman(double _evapoTranspirationPenman) { this->evapoTranspirationPenman = _evapoTranspirationPenman; }
void PotentialET_PenmanRate::setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor) { this->evapoTranspirationPriestlyTaylor = _evapoTranspirationPriestlyTaylor; }