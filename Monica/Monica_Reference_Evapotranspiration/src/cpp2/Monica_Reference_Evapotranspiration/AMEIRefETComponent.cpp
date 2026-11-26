#include "AMEIRefETComponent.h"
using namespace Monica_Reference_Evapotranspiration;
AMEIRefETComponent::AMEIRefETComponent()
{
       
}


double AMEIRefETComponent::getheight_nn(){ return this->height_nn; }

void AMEIRefETComponent::setheight_nn(double _height_nn)
{
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
}
void AMEIRefETComponent::Calculate_Model(AMEIRefETState &s, AMEIRefETState &s1, AMEIRefETRate &r, AMEIRefETAuxiliary &a, AMEIRefETExogenous &ex)
{
    _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
}
AMEIRefETComponent::AMEIRefETComponent(AMEIRefETComponent& toCopy)
{
    height_nn = toCopy.getheight_nn();
}