#include "ReferenceETPM.h"

namespace SimplaceReferenceETPM {
class ReferenceETPM_Component
{
private:
    double cAltitude{0.0};
public:
    ReferenceETPM_Component();

    ReferenceETPM_Component(ReferenceETPM_Component& copy);

    void Calculate_Model(ReferenceETPM_State &s, ReferenceETPM_State &s1, ReferenceETPM_Rate &r, ReferenceETPM_Auxiliary &a, ReferenceETPM_Exogenous &ex);

    void Init(ReferenceETPM_State &s, ReferenceETPM_State &s1, ReferenceETPM_Rate &r, ReferenceETPM_Auxiliary &a, ReferenceETPM_Exogenous &ex);

    double getcAltitude();
    void setcAltitude(double _cAltitude);

    ReferenceETPM _ReferenceETPM;

};
}