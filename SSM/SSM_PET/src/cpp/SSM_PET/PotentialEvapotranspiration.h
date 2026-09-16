
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "petState.h"
#include "petRate.h"
#include "petAuxiliary.h"
#include "petExogenous.h"
namespace SSM_PET {
class PotentialEvapotranspiration
{
    private:
        double albedo ;
    public:
        PotentialEvapotranspiration();
        void Calculate_Model(petState &s, petState &s1, petRate &r, petAuxiliary &a, petExogenous &ex);
        double getalbedo();
        void setalbedo(double _albedo);

};
}
