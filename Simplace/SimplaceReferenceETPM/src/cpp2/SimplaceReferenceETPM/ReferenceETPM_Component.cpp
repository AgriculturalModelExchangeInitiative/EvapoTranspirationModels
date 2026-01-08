#include "ReferenceETPM_Component.h"
using namespace SimplaceReferenceETPM;
ReferenceETPM_Component::ReferenceETPM_Component()
{
       
}


double ReferenceETPM_Component::getcAltitude(){ return this->cAltitude; }

void ReferenceETPM_Component::setcAltitude(double _cAltitude)
{
    _ReferenceETPM.setcAltitude(_cAltitude);
}
void ReferenceETPM_Component::Calculate_Model(ReferenceETPM_State &s, ReferenceETPM_State &s1, ReferenceETPM_Rate &r, ReferenceETPM_Auxiliary &a, ReferenceETPM_Exogenous &ex)
{
    _ReferenceETPM.Calculate_Model(s, s1, r, a, ex);
}
ReferenceETPM_Component::ReferenceETPM_Component(ReferenceETPM_Component& toCopy)
{
    cAltitude = toCopy.getcAltitude();
}