#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Monica_Reference_Evapotranspiration {
struct AMEIRefETExogenous
{
    double mean_air_temperature{0};
    double wind_speed{0};
    double wind_speed_height{2};
};
}