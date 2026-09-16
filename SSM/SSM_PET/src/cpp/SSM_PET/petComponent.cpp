#include "petComponent.h"
using namespace SSM_PET;
petComponent::petComponent()
{
       
}


double petComponent::getalbedo(){ return this->albedo; }

void petComponent::setalbedo(double _albedo)
{
    _PotentialEvapotranspiration.setalbedo(_albedo);
}
void petComponent::Calculate_Model(petState &s, petState &s1, petRate &r, petAuxiliary &a, petExogenous &ex)
{
    _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
}
petComponent::petComponent(petComponent& toCopy)
{
    albedo = toCopy.getalbedo();
}