#include "ReferenceETPriestleyTaylor.h"

namespace SimplaceReferenceETPriestleyTaylor {
class ReferenceETPriestleyTaylor_Component
{
private:
    double cAlphaPT{1.26};
    double cAltitude{0.0};
public:
    ReferenceETPriestleyTaylor_Component();

    ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component& copy);

    void Calculate_Model(ReferenceETPriestleyTaylor_State &s, ReferenceETPriestleyTaylor_State &s1, ReferenceETPriestleyTaylor_Rate &r, ReferenceETPriestleyTaylor_Auxiliary &a, ReferenceETPriestleyTaylor_Exogenous &ex);

    void Init(ReferenceETPriestleyTaylor_State &s, ReferenceETPriestleyTaylor_State &s1, ReferenceETPriestleyTaylor_Rate &r, ReferenceETPriestleyTaylor_Auxiliary &a, ReferenceETPriestleyTaylor_Exogenous &ex);

    double getcAlphaPT();
    void setcAlphaPT(double _cAlphaPT);

    double getcAltitude();
    void setcAltitude(double _cAltitude);

    ReferenceETPriestleyTaylor _ReferenceETPriestleyTaylor;

};
}