#include "PotentialET_PTComponent.h"
using namespace SiriusQuality-Priestly-Taylor;
PotentialET_PTComponent::PotentialET_PTComponent()
{
       
}


double PotentialET_PTComponent::getlambdaV(){ return this->lambdaV; }
double PotentialET_PTComponent::getpsychrometricConstant(){ return this->psychrometricConstant; }
double PotentialET_PTComponent::getAlpha(){ return this->Alpha; }
int PotentialET_PTComponent::getih(){ return this->ih; }

void PotentialET_PTComponent::setlambdaV(double _lambdaV)
{
    _PriestlyTaylor.setlambdaV(_lambdaV);
}
void PotentialET_PTComponent::setpsychrometricConstant(double _psychrometricConstant)
{
    _PriestlyTaylor.setpsychrometricConstant(_psychrometricConstant);
}
void PotentialET_PTComponent::setAlpha(double _Alpha)
{
    _PriestlyTaylor.setAlpha(_Alpha);
}
void PotentialET_PTComponent::setih(int _ih)
{
    _PriestlyTaylor.setih(_ih);
}
void PotentialET_PTComponent::Calculate_Model(PotentialET_PTState &s, PotentialET_PTState &s1, PotentialET_PTRate &r, PotentialET_PTAuxiliary &a, PotentialET_PTExogenous &ex)
{
    _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
}
PotentialET_PTComponent::PotentialET_PTComponent(PotentialET_PTComponent& toCopy)
{
    lambdaV = toCopy.getlambdaV();
    psychrometricConstant = toCopy.getpsychrometricConstant();
    Alpha = toCopy.getAlpha();
    ih = toCopy.getih();
}