#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_Evapotranspiration {
class ETExogenous
{
    private:
        double global_radiation ;
        int julian_day ;
        double sunshine_hours ;
        double max_air_temperature ;
        double min_air_temperature ;
        double relative_humidity ;
        double atmospheric_co2_concentration ;
        double mean_air_temperature ;
        double wind_speed ;
        double wind_speed_height ;
        double kc_factor ;
        int developmental_stage ;
        double crop_remaining_evapotranspiration ;
        bool has_snow_cover ;
        std::vector<double> crop_transpiration ;
        double crop_evaporated_from_intercepted ;
        double percentage_soil_coverage ;
    public:
        ETExogenous();
        double getglobal_radiation();
        void setglobal_radiation(double _global_radiation);
        int getjulian_day();
        void setjulian_day(int _julian_day);
        double getsunshine_hours();
        void setsunshine_hours(double _sunshine_hours);
        double getmax_air_temperature();
        void setmax_air_temperature(double _max_air_temperature);
        double getmin_air_temperature();
        void setmin_air_temperature(double _min_air_temperature);
        double getrelative_humidity();
        void setrelative_humidity(double _relative_humidity);
        double getatmospheric_co2_concentration();
        void setatmospheric_co2_concentration(double _atmospheric_co2_concentration);
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
        bool gethas_snow_cover();
        void sethas_snow_cover(bool _has_snow_cover);
        std::vector<double> & getcrop_transpiration();
        void setcrop_transpiration(const std::vector<double> &  _crop_transpiration);
        double getcrop_evaporated_from_intercepted();
        void setcrop_evaporated_from_intercepted(double _crop_evaporated_from_intercepted);
        double getpercentage_soil_coverage();
        void setpercentage_soil_coverage(double _percentage_soil_coverage);

};
}
