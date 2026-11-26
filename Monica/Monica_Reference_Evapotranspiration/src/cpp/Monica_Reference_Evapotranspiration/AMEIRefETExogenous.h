#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_Reference_Evapotranspiration {
class AMEIRefETExogenous
{
    private:
        double mean_air_temperature ;
        double wind_speed ;
        double wind_speed_height ;
    public:
        AMEIRefETExogenous();
        double getmean_air_temperature();
        void setmean_air_temperature(double _mean_air_temperature);
        double getwind_speed();
        void setwind_speed(double _wind_speed);
        double getwind_speed_height();
        void setwind_speed_height(double _wind_speed_height);

};
}
