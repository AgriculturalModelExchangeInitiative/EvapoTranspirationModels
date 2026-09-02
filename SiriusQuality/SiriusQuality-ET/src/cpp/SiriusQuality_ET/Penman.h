
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
class Penman
{
    private:
        double specificHeatCapacityAir ;
        double psychrometricConstant ;
        double rhoDensityAir ;
        double Alpha ;
        double lambdaV ;
    public:
        Penman();
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getspecificHeatCapacityAir();
        void setspecificHeatCapacityAir(double _specificHeatCapacityAir);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getrhoDensityAir();
        void setrhoDensityAir(double _rhoDensityAir);
        double getAlpha();
        void setAlpha(double _Alpha);
        double getlambdaV();
        void setlambdaV(double _lambdaV);

};
}
