#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace SSM_PET {
class petState
{
    private:
        double pet ;
    public:
        petState();
        double getpet();
        void setpet(double _pet);

};
}
