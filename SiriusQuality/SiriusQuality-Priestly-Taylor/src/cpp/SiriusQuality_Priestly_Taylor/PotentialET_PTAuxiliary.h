#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_Priestly_Taylor {
class PotentialET_PTAuxiliary
{
    private:
        double solarRadiation ;
        double hslope ;
        double netRadiation ;
    public:
        PotentialET_PTAuxiliary();
        double getsolarRadiation();
        void setsolarRadiation(double _solarRadiation);
        double gethslope();
        void sethslope(double _hslope);
        double getnetRadiation();
        void setnetRadiation(double _netRadiation);

};
}
