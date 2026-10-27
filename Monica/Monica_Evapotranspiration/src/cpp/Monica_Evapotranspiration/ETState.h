#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Monica_Evapotranspiration {
class ETState
{
    private:
        double surface_water_storage ;
        double evaporated_from_surface ;
        double actual_evaporation ;
        double actual_transpiration ;
        std::vector<double> soil_moisture ;
        std::vector<double> evaporation ;
        std::vector<double> transpiration ;
        std::vector<double> evapotranspiration ;
        double actual_evapotranspiration ;
    public:
        ETState();
        double getsurface_water_storage();
        void setsurface_water_storage(double _surface_water_storage);
        double getevaporated_from_surface();
        void setevaporated_from_surface(double _evaporated_from_surface);
        double getactual_evaporation();
        void setactual_evaporation(double _actual_evaporation);
        double getactual_transpiration();
        void setactual_transpiration(double _actual_transpiration);
        std::vector<double> & getsoil_moisture();
        void setsoil_moisture(const std::vector<double> &  _soil_moisture);
        std::vector<double> & getevaporation();
        void setevaporation(const std::vector<double> &  _evaporation);
        std::vector<double> & gettranspiration();
        void settranspiration(const std::vector<double> &  _transpiration);
        std::vector<double> & getevapotranspiration();
        void setevapotranspiration(const std::vector<double> &  _evapotranspiration);
        double getactual_evapotranspiration();
        void setactual_evapotranspiration(double _actual_evapotranspiration);

};
}
