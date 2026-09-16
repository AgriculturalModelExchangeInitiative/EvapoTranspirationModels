
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "PotentialET_PTState.h"
#include "PotentialET_PTRate.h"
#include "PotentialET_PTAuxiliary.h"
#include "PotentialET_PTExogenous.h"
namespace SiriusQuality_Priestly_Taylor {
class PriestlyTaylor
{
    private:
        double lambdaV ;
        double psychrometricConstant ;
        double Alpha ;
        int ih ;
    public:
        PriestlyTaylor();
        void Calculate_Model(PotentialET_PTState &s, PotentialET_PTState &s1, PotentialET_PTRate &r, PotentialET_PTAuxiliary &a, PotentialET_PTExogenous &ex);
        double getlambdaV();
        void setlambdaV(double _lambdaV);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getAlpha();
        void setAlpha(double _Alpha);
        int getih();
        void setih(int _ih);

};
}
