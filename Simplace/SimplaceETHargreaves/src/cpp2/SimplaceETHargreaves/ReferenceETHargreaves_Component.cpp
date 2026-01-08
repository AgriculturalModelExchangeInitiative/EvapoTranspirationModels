#include "ReferenceETHargreaves_Component.h"
using namespace SimplaceETHargreaves;
ReferenceETHargreaves_Component::ReferenceETHargreaves_Component()
{
       
}


bool ReferenceETHargreaves_Component::getcConvertLeByTemp(){ return this->cConvertLeByTemp; }

void ReferenceETHargreaves_Component::setcConvertLeByTemp(bool _cConvertLeByTemp)
{
    _ReferenceETHargreaves.setcConvertLeByTemp(_cConvertLeByTemp);
}
void ReferenceETHargreaves_Component::Calculate_Model(ReferenceETHargreaves_State &s, ReferenceETHargreaves_State &s1, ReferenceETHargreaves_Rate &r, ReferenceETHargreaves_Auxiliary &a, ReferenceETHargreaves_Exogenous &ex)
{
    _ReferenceETHargreaves.Calculate_Model(s, s1, r, a, ex);
}
ReferenceETHargreaves_Component::ReferenceETHargreaves_Component(ReferenceETHargreaves_Component& toCopy)
{
    cConvertLeByTemp = toCopy.getcConvertLeByTemp();
}