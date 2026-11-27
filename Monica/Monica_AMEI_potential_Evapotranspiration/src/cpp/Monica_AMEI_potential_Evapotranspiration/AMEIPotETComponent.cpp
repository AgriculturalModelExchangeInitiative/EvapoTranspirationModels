#include "AMEIPotETComponent.h"
using namespace Monica_AMEI_potential_Evapotranspiration;
AMEIPotETComponent::AMEIPotETComponent()
{
       
}


double AMEIPotETComponent::getheight_nn(){ return this->height_nn; }
double AMEIPotETComponent::getlatent_heat_of_vaporization(){ return this->latent_heat_of_vaporization; }

void AMEIPotETComponent::setheight_nn(double _height_nn)
{
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
}
void AMEIPotETComponent::setlatent_heat_of_vaporization(double _latent_heat_of_vaporization)
{
    _ReferenceEvapotranspiration.setlatent_heat_of_vaporization(_latent_heat_of_vaporization);
}
void AMEIPotETComponent::Calculate_Model(AMEIPotETState &s, AMEIPotETState &s1, AMEIPotETRate &r, AMEIPotETAuxiliary &a, AMEIPotETExogenous &ex)
{
    _SaturationVaporPressureDeficit.Calculate_Model(s, s1, r, a, ex);
    _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
}
AMEIPotETComponent::AMEIPotETComponent(AMEIPotETComponent& toCopy)
{
    height_nn = toCopy.getheight_nn();
    latent_heat_of_vaporization = toCopy.getlatent_heat_of_vaporization();
}