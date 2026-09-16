#include "petExogenous.h"
using namespace SSM_PET;


petExogenous::petExogenous() {}

double petExogenous::gettmax() { return this->tmax; }
double petExogenous::gettmin() { return this->tmin; }
double petExogenous::getsrad() { return this->srad; }

void petExogenous::settmax(double _tmax) { this->tmax = _tmax; }
void petExogenous::settmin(double _tmin) { this->tmin = _tmin; }
void petExogenous::setsrad(double _srad) { this->srad = _srad; }