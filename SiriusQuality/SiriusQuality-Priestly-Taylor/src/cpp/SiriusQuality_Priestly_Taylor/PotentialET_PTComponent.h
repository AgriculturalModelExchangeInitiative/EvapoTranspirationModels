#include "PriestlyTaylor.h"

namespace SiriusQuality_Priestly_Taylor {
class PotentialET_PTComponent
{
    private:
        double lambdaV ;
        double psychrometricConstant ;
        double Alpha ;
        int ih ;
    public:
        PotentialET_PTComponent();
        PotentialET_PTComponent(PotentialET_PTComponent& copy);
        void Calculate_Model(PotentialET_PTState &s, PotentialET_PTState &s1, PotentialET_PTRate &r, PotentialET_PTAuxiliary &a, PotentialET_PTExogenous &ex);
        void Init(PotentialET_PTState &s, PotentialET_PTState &s1, PotentialET_PTRate &r, PotentialET_PTAuxiliary &a, PotentialET_PTExogenous &ex);
        double getlambdaV();
        void setlambdaV(double _lambdaV);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getAlpha();
        void setAlpha(double _Alpha);
        int getih();
        void setih(int _ih);

        PriestlyTaylor _PriestlyTaylor;

};
}
