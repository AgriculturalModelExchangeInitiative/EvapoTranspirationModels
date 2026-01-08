
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "ReferenceETHargreaves_State.h"
#include "ReferenceETHargreaves_Rate.h"
#include "ReferenceETHargreaves_Auxiliary.h"
#include "ReferenceETHargreaves_Exogenous.h"
namespace SimplaceETHargreaves {
class ReferenceETHargreaves
{
private:
    bool cConvertLeByTemp{false};
public:
    ReferenceETHargreaves();

    void Calculate_Model(ReferenceETHargreaves_State &s, ReferenceETHargreaves_State &s1, ReferenceETHargreaves_Rate &r, ReferenceETHargreaves_Auxiliary &a, ReferenceETHargreaves_Exogenous &ex);

    double EvaporationEquivalentToRadiation1(double Radiation, double DailyMeanTemperature);

    double EvaporationEquivalentToRadiation2(double Radiation);

    double ReferenceEvapoTranspirationFromSolarRadiation(double R_s, double T_max, double T_min);

    bool getcConvertLeByTemp();
    void setcConvertLeByTemp(bool _cConvertLeByTemp);
};
}