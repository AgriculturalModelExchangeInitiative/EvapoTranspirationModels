
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
class Conductance
{
    private:
        double d ;
        double heightWeatherMeasurements ;
        double zh ;
        double zm ;
        double vonKarman ;
        int ih ;
    public:
        Conductance();
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getd();
        void setd(double _d);
        double getheightWeatherMeasurements();
        void setheightWeatherMeasurements(double _heightWeatherMeasurements);
        double getzh();
        void setzh(double _zh);
        double getzm();
        void setzm(double _zm);
        double getvonKarman();
        void setvonKarman(double _vonKarman);
        int getih();
        void setih(int _ih);

};
}
