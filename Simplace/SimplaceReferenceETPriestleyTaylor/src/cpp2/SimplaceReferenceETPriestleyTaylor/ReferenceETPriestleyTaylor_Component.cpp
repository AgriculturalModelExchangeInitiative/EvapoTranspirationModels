#include "ReferenceETPriestleyTaylor_Component.h"
using namespace SimplaceReferenceETPriestleyTaylor;
ReferenceETPriestleyTaylor_Component::ReferenceETPriestleyTaylor_Component()
{
       
}


double ReferenceETPriestleyTaylor_Component::getcAlphaPT(){ return this->cAlphaPT; }
double ReferenceETPriestleyTaylor_Component::getcAltitude(){ return this->cAltitude; }

void ReferenceETPriestleyTaylor_Component::setcAlphaPT(double _cAlphaPT)
{
    _ReferenceETPriestleyTaylor.setcAlphaPT(_cAlphaPT);
}
void ReferenceETPriestleyTaylor_Component::setcAltitude(double _cAltitude)
{
    _ReferenceETPriestleyTaylor.setcAltitude(_cAltitude);
}
void ReferenceETPriestleyTaylor_Component::Calculate_Model(ReferenceETPriestleyTaylor_State &s, ReferenceETPriestleyTaylor_State &s1, ReferenceETPriestleyTaylor_Rate &r, ReferenceETPriestleyTaylor_Auxiliary &a, ReferenceETPriestleyTaylor_Exogenous &ex)
{
    _ReferenceETPriestleyTaylor.Calculate_Model(s, s1, r, a, ex);
}
ReferenceETPriestleyTaylor_Component::ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component& toCopy)
{
    cAlphaPT = toCopy.getcAlphaPT();
    cAltitude = toCopy.getcAltitude();
}