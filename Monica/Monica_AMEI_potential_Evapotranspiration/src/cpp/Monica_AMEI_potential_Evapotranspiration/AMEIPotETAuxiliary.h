#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_AMEI_potential_Evapotranspiration {
class AMEIPotETAuxiliary
{
    private:
        double vapor_pressure ;
        double saturated_vapor_pressure ;
        double stomata_resistance ;
        double net_radiation ;
        double reference_evapotranspiration ;
        double potential_evapotranspiration ;
        double saturation_vapor_pressure_deficit ;
    public:
        AMEIPotETAuxiliary();
        double getvapor_pressure();
        void setvapor_pressure(double _vapor_pressure);
        double getsaturated_vapor_pressure();
        void setsaturated_vapor_pressure(double _saturated_vapor_pressure);
        double getstomata_resistance();
        void setstomata_resistance(double _stomata_resistance);
        double getnet_radiation();
        void setnet_radiation(double _net_radiation);
        double getreference_evapotranspiration();
        void setreference_evapotranspiration(double _reference_evapotranspiration);
        double getpotential_evapotranspiration();
        void setpotential_evapotranspiration(double _potential_evapotranspiration);
        double getsaturation_vapor_pressure_deficit();
        void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit);

};
}
