#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace SiriusQuality_ET {
class EnergyBalanceCompositeState
{
    private:
        int ih ;
        double conductance ;
    public:
        EnergyBalanceCompositeState();
        int getih();
        void setih(int _ih);
        double getconductance();
        void setconductance(double _conductance);

};
}
