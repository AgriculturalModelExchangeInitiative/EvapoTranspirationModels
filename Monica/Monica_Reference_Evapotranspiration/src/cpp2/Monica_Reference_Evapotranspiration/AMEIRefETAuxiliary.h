#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Monica_Reference_Evapotranspiration {
struct AMEIRefETAuxiliary
{
    double stomata_resistance{100};
    double net_radiation{0};
    double saturation_vapor_pressure_deficit{0};
    double reference_evapotranspiration{0.0};
};
}