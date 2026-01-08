#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace SimplaceReferenceETPriestleyTaylor {
struct ReferenceETPriestleyTaylor_Exogenous
{
    double iTMin{0.0};
    double iNetRadiation{0.0};
    double iTMax{0.0};
};
}