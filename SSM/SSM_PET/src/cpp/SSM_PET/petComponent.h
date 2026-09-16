#include "PotentialEvapotranspiration.h"

namespace SSM_PET {
class petComponent
{
    private:
        double albedo ;
    public:
        petComponent();
        petComponent(petComponent& copy);
        void Calculate_Model(petState &s, petState &s1, petRate &r, petAuxiliary &a, petExogenous &ex);
        void Init(petState &s, petState &s1, petRate &r, petAuxiliary &a, petExogenous &ex);
        double getalbedo();
        void setalbedo(double _albedo);

        PotentialEvapotranspiration _PotentialEvapotranspiration;

};
}
