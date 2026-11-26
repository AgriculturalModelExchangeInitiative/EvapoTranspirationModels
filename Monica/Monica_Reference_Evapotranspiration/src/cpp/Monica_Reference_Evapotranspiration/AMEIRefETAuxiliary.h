#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_Reference_Evapotranspiration {
class AMEIRefETAuxiliary
{
    private:
        double stomata_resistance ;
        double net_radiation ;
        double saturation_vapor_pressure_deficit ;
        double reference_evapotranspiration ;
    public:
        AMEIRefETAuxiliary();
        double getstomata_resistance();
        void setstomata_resistance(double _stomata_resistance);
        double getnet_radiation();
        void setnet_radiation(double _net_radiation);
        double getsaturation_vapor_pressure_deficit();
        void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit);
        double getreference_evapotranspiration();
        void setreference_evapotranspiration(double _reference_evapotranspiration);

};
}
