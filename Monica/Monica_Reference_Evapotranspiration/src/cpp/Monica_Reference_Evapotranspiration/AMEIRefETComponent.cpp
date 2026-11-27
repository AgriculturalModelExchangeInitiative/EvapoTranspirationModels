#include "AMEIRefETComponent.h"
using namespace Monica_Reference_Evapotranspiration;
AMEIRefETComponent::AMEIRefETComponent()
{
       
}


double AMEIRefETComponent::getheight_nn(){ return this->height_nn; }
double AMEIRefETComponent::getlatent_heat_of_vaporization(){ return this->latent_heat_of_vaporization; }

void AMEIRefETComponent::setheight_nn(double _height_nn)
{
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
}
void AMEIRefETComponent::setlatent_heat_of_vaporization(double _latent_heat_of_vaporization)
{
    _ReferenceEvapotranspiration.setlatent_heat_of_vaporization(_latent_heat_of_vaporization);
}
void AMEIRefETComponent::Calculate_Model(AMEIRefETState &s, AMEIRefETState &s1, AMEIRefETRate &r, AMEIRefETAuxiliary &a, AMEIRefETExogenous &ex)
{
    _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
}
AMEIRefETComponent::AMEIRefETComponent(AMEIRefETComponent& toCopy)
{
    height_nn = toCopy.getheight_nn();
    latent_heat_of_vaporization = toCopy.getlatent_heat_of_vaporization();
}