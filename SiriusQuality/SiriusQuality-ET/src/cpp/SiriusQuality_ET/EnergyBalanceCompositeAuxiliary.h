#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SiriusQuality_ET {
class EnergyBalanceCompositeAuxiliary
{
    private:
        double maxTair ;
        double minTair ;
        double vaporPressure ;
        double extraSolarRadiation ;
        double solarRadiation ;
        double plantHeight ;
        double wind ;
        double hslope ;
        double VPDair ;
        double netOutGoingLongWaveRadiation ;
        double netRadiation ;
        double netRadiationEquivalentEvaporation ;
    public:
        EnergyBalanceCompositeAuxiliary();
        double getmaxTair();
        void setmaxTair(double _maxTair);
        double getminTair();
        void setminTair(double _minTair);
        double getvaporPressure();
        void setvaporPressure(double _vaporPressure);
        double getextraSolarRadiation();
        void setextraSolarRadiation(double _extraSolarRadiation);
        double getsolarRadiation();
        void setsolarRadiation(double _solarRadiation);
        double getplantHeight();
        void setplantHeight(double _plantHeight);
        double getwind();
        void setwind(double _wind);
        double gethslope();
        void sethslope(double _hslope);
        double getVPDair();
        void setVPDair(double _VPDair);
        double getnetOutGoingLongWaveRadiation();
        void setnetOutGoingLongWaveRadiation(double _netOutGoingLongWaveRadiation);
        double getnetRadiation();
        void setnetRadiation(double _netRadiation);
        double getnetRadiationEquivalentEvaporation();
        void setnetRadiationEquivalentEvaporation(double _netRadiationEquivalentEvaporation);

};
}
