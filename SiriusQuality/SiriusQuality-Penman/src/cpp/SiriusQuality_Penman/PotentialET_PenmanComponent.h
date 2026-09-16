#include "PriestlyTaylor.h"
#include "Penman.h"

namespace SiriusQuality_Penman {
class PotentialET_PenmanComponent
{
    private:
        double lambdaV ;
        double psychrometricConstant ;
        double Alpha ;
        int ih ;
        double specificHeatCapacityAir ;
        double rhoDensityAir ;
    public:
        PotentialET_PenmanComponent();
        PotentialET_PenmanComponent(PotentialET_PenmanComponent& copy);
        void Calculate_Model(PotentialET_PenmanState &s, PotentialET_PenmanState &s1, PotentialET_PenmanRate &r, PotentialET_PenmanAuxiliary &a, PotentialET_PenmanExogenous &ex);
        void Init(PotentialET_PenmanState &s, PotentialET_PenmanState &s1, PotentialET_PenmanRate &r, PotentialET_PenmanAuxiliary &a, PotentialET_PenmanExogenous &ex);
        double getlambdaV();
        void setlambdaV(double _lambdaV);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getAlpha();
        void setAlpha(double _Alpha);
        int getih();
        void setih(int _ih);
        double getspecificHeatCapacityAir();
        void setspecificHeatCapacityAir(double _specificHeatCapacityAir);
        double getrhoDensityAir();
        void setrhoDensityAir(double _rhoDensityAir);

        PriestlyTaylor _PriestlyTaylor;
        Penman _Penman;

};
}
