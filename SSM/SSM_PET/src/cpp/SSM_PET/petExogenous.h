#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SSM_PET {
class petExogenous
{
    private:
        double tmax ;
        double tmin ;
        double srad ;
    public:
        petExogenous();
        double gettmax();
        void settmax(double _tmax);
        double gettmin();
        void settmin(double _tmin);
        double getsrad();
        void setsrad(double _srad);

};
}
