#include "petState.h"
using namespace SSM_PET;

petState::petState() {}

double petState::getpet() { return this->pet; }

void petState::setpet(double _pet) { this->pet = _pet; }