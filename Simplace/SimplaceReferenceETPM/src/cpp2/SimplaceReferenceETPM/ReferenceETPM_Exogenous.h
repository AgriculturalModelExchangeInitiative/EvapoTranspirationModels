#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace SimplaceReferenceETPM {
struct ReferenceETPM_Exogenous
{
    double iNetRadiation{0.0};
    double iActualVapourPressure{0.0};
    double iTMax{0.0};
    double iTMin{0.0};
    double iWindspeed{0.0};
};
}