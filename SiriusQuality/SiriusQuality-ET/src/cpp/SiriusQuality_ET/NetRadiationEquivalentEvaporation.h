
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "EnergyBalanceCompositeState.h"
#include "EnergyBalanceCompositeRate.h"
#include "EnergyBalanceCompositeAuxiliary.h"
#include "EnergyBalanceCompositeExogenous.h"
namespace SiriusQuality_ET {
class NetRadiationEquivalentEvaporation
{
    private:
        double lambdaV ;
    public:
        NetRadiationEquivalentEvaporation();
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getlambdaV();
        void setlambdaV(double _lambdaV);

};
}
