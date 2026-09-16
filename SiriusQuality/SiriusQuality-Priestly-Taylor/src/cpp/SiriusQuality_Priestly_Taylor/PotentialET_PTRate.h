#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_Priestly_Taylor {
class PotentialET_PTRate
{
    private:
        double evapoTranspirationPriestlyTaylor ;
    public:
        PotentialET_PTRate();
        double getevapoTranspirationPriestlyTaylor();
        void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor);

};
}
