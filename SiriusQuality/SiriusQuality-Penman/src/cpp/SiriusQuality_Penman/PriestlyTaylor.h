
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "PotentialET_PenmanState.h"
#include "PotentialET_PenmanRate.h"
#include "PotentialET_PenmanAuxiliary.h"
#include "PotentialET_PenmanExogenous.h"
namespace SiriusQuality_Penman {
class PriestlyTaylor
{
    private:
        double lambdaV ;
        double psychrometricConstant ;
        double Alpha ;
        int ih ;
    public:
        PriestlyTaylor();
        void Calculate_Model(PotentialET_PenmanState &s, PotentialET_PenmanState &s1, PotentialET_PenmanRate &r, PotentialET_PenmanAuxiliary &a, PotentialET_PenmanExogenous &ex);
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
