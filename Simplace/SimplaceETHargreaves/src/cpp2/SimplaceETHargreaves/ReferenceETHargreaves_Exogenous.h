#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace SimplaceETHargreaves {
struct ReferenceETHargreaves_Exogenous
{
    double iTMax{0.0};
    double iSolarRadiation{0.0};
    double iTMin{0.0};
};
}