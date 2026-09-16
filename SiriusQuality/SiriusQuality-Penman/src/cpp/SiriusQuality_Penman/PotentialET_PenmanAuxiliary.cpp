#include "PotentialET_PenmanAuxiliary.h"
using namespace SiriusQuality_Penman;

PotentialET_PenmanAuxiliary::PotentialET_PenmanAuxiliary() {}

double PotentialET_PenmanAuxiliary::getnetRadiation() { return this->netRadiation; }
double PotentialET_PenmanAuxiliary::getsolarRadiation() { return this->solarRadiation; }
double PotentialET_PenmanAuxiliary::gethslope() { return this->hslope; }
double PotentialET_PenmanAuxiliary::getVPDair() { return this->VPDair; }
double PotentialET_PenmanAuxiliary::getconductance() { return this->conductance; }

void PotentialET_PenmanAuxiliary::setnetRadiation(double _netRadiation) { this->netRadiation = _netRadiation; }
void PotentialET_PenmanAuxiliary::setsolarRadiation(double _solarRadiation) { this->solarRadiation = _solarRadiation; }
void PotentialET_PenmanAuxiliary::sethslope(double _hslope) { this->hslope = _hslope; }
void PotentialET_PenmanAuxiliary::setVPDair(double _VPDair) { this->VPDair = _VPDair; }
void PotentialET_PenmanAuxiliary::setconductance(double _conductance) { this->conductance = _conductance; }