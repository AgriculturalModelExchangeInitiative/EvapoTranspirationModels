#include "ReferenceETHargreaves.h"

namespace SimplaceETHargreaves {
class ReferenceETHargreaves_Component
{
private:
    bool cConvertLeByTemp{false};
public:
    ReferenceETHargreaves_Component();

    ReferenceETHargreaves_Component(ReferenceETHargreaves_Component& copy);

    void Calculate_Model(ReferenceETHargreaves_State &s, ReferenceETHargreaves_State &s1, ReferenceETHargreaves_Rate &r, ReferenceETHargreaves_Auxiliary &a, ReferenceETHargreaves_Exogenous &ex);

    void Init(ReferenceETHargreaves_State &s, ReferenceETHargreaves_State &s1, ReferenceETHargreaves_Rate &r, ReferenceETHargreaves_Auxiliary &a, ReferenceETHargreaves_Exogenous &ex);

    bool getcConvertLeByTemp();
    void setcConvertLeByTemp(bool _cConvertLeByTemp);

    ReferenceETHargreaves _ReferenceETHargreaves;

};
}