#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_AMEI_potential_Evapotranspiration {
class AMEIPotETExogenous
{
    private:
        double mean_air_temperature ;
        double wind_speed ;
        double wind_speed_height ;
        double kc_factor ;
        int developmental_stage ;
        double crop_remaining_evapotranspiration ;
    public:
        AMEIPotETExogenous();
        double getmean_air_temperature();
        void setmean_air_temperature(double _mean_air_temperature);
        double getwind_speed();
        void setwind_speed(double _wind_speed);
        double getwind_speed_height();
        void setwind_speed_height(double _wind_speed_height);
        double getkc_factor();
        void setkc_factor(double _kc_factor);
        int getdevelopmental_stage();
        void setdevelopmental_stage(int _developmental_stage);
        double getcrop_remaining_evapotranspiration();
        void setcrop_remaining_evapotranspiration(double _crop_remaining_evapotranspiration);

};
}
