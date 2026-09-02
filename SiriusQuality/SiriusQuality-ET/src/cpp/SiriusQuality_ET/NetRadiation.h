
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
class NetRadiation
{
    private:
        double albedoCoefficient ;
        double tau ;
        double elevation ;
        double stefanBoltzman ;
        double albedoCoefficientCan ;
    public:
        NetRadiation();
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getalbedoCoefficient();
        void setalbedoCoefficient(double _albedoCoefficient);
        double gettau();
        void settau(double _tau);
        double getelevation();
        void setelevation(double _elevation);
        double getstefanBoltzman();
        void setstefanBoltzman(double _stefanBoltzman);
        double getalbedoCoefficientCan();
        void setalbedoCoefficientCan(double _albedoCoefficientCan);

};
}
