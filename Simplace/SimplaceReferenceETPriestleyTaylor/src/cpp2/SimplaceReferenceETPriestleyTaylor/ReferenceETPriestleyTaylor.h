
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "ReferenceETPriestleyTaylor_State.h"
#include "ReferenceETPriestleyTaylor_Rate.h"
#include "ReferenceETPriestleyTaylor_Auxiliary.h"
#include "ReferenceETPriestleyTaylor_Exogenous.h"
namespace SimplaceReferenceETPriestleyTaylor {
class ReferenceETPriestleyTaylor
{
private:
    double cAltitude{0.0};
    double cAlphaPT{1.26};
public:
    ReferenceETPriestleyTaylor();

    void Calculate_Model(ReferenceETPriestleyTaylor_State &s, ReferenceETPriestleyTaylor_State &s1, ReferenceETPriestleyTaylor_Rate &r, ReferenceETPriestleyTaylor_Auxiliary &a, ReferenceETPriestleyTaylor_Exogenous &ex);

    double SlopeOfSaturationVapPressureCurve(double T);

    double AtmosphericPressure(double z);

    double PsychrometricConstant(double P);

    double getcAltitude();
    void setcAltitude(double _cAltitude);

    double getcAlphaPT();
    void setcAlphaPT(double _cAlphaPT);
};
}