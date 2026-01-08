
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "ReferenceETPM_State.h"
#include "ReferenceETPM_Rate.h"
#include "ReferenceETPM_Auxiliary.h"
#include "ReferenceETPM_Exogenous.h"
namespace SimplaceReferenceETPM {
class ReferenceETPM
{
private:
    double cAltitude{0.0};
public:
    ReferenceETPM();

    void Calculate_Model(ReferenceETPM_State &s, ReferenceETPM_State &s1, ReferenceETPM_Rate &r, ReferenceETPM_Auxiliary &a, ReferenceETPM_Exogenous &ex);

    double SaturationVapourPressureAtTemperature(double T);

    double MeanSaturatedVapourPressure(double T_max, double T_min);

    double SlopeOfSaturationVapPressureCurve(double T);

    double PsychrometricConstant(double P);

    double AtmosphericPressure(double z);

    double ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z);

    double getcAltitude();
    void setcAltitude(double _cAltitude);
};
}