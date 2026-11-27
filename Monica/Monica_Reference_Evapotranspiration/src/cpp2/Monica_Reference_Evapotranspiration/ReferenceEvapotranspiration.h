
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "AMEIRefETState.h"
#include "AMEIRefETRate.h"
#include "AMEIRefETAuxiliary.h"
#include "AMEIRefETExogenous.h"
namespace Monica_Reference_Evapotranspiration {
class ReferenceEvapotranspiration
{
private:
    double height_nn{0};
    double latent_heat_of_vaporization{0};
public:
    ReferenceEvapotranspiration();

    void Calculate_Model(AMEIRefETState &s, AMEIRefETState &s1, AMEIRefETRate &r, AMEIRefETAuxiliary &a, AMEIRefETExogenous &ex);

    double getheight_nn();
    void setheight_nn(double _height_nn);

    double getlatent_heat_of_vaporization();
    void setlatent_heat_of_vaporization(double _latent_heat_of_vaporization);
};
}