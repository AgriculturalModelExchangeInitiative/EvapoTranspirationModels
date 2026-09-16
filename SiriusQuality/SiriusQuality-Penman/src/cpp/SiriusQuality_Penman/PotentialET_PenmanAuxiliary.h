#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_Penman {
class PotentialET_PenmanAuxiliary
{
    private:
        double netRadiation ;
        double solarRadiation ;
        double hslope ;
        double VPDair ;
        double conductance ;
    public:
        PotentialET_PenmanAuxiliary();
        double getnetRadiation();
        void setnetRadiation(double _netRadiation);
        double getsolarRadiation();
        void setsolarRadiation(double _solarRadiation);
        double gethslope();
        void sethslope(double _hslope);
        double getVPDair();
        void setVPDair(double _VPDair);
        double getconductance();
        void setconductance(double _conductance);

};
}
