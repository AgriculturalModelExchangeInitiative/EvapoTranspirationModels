
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
class PriestlyTaylor
{
    private:
        double psychrometricConstant ;
        double Alpha ;
        int ih ;
    public:
        PriestlyTaylor();
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getAlpha();
        void setAlpha(double _Alpha);
        int getih();
        void setih(int _ih);

};
}
