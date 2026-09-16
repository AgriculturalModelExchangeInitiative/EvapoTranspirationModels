#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_Penman {
class PotentialET_PenmanRate
{
    private:
        double evapoTranspirationPenman ;
        double evapoTranspirationPriestlyTaylor ;
    public:
        PotentialET_PenmanRate();
        double getevapoTranspirationPenman();
        void setevapoTranspirationPenman(double _evapoTranspirationPenman);
        double getevapoTranspirationPriestlyTaylor();
        void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor);

};
}
