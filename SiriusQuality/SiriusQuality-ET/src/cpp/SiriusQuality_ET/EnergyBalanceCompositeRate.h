#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_ET {
class EnergyBalanceCompositeRate
{
    private:
        double evapoTranspirationPriestlyTaylor ;
        double evapoTranspirationPenman ;
    public:
        EnergyBalanceCompositeRate();
        double getevapoTranspirationPriestlyTaylor();
        void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor);
        double getevapoTranspirationPenman();
        void setevapoTranspirationPenman(double _evapoTranspirationPenman);

};
}
