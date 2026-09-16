#include "PotentialET_PenmanComponent.h"
using namespace SiriusQuality-Penman;
PotentialET_PenmanComponent::PotentialET_PenmanComponent()
{
       
}


double PotentialET_PenmanComponent::getlambdaV(){ return this->lambdaV; }
double PotentialET_PenmanComponent::getpsychrometricConstant(){ return this->psychrometricConstant; }
double PotentialET_PenmanComponent::getAlpha(){ return this->Alpha; }
int PotentialET_PenmanComponent::getih(){ return this->ih; }
double PotentialET_PenmanComponent::getspecificHeatCapacityAir(){ return this->specificHeatCapacityAir; }
double PotentialET_PenmanComponent::getrhoDensityAir(){ return this->rhoDensityAir; }

void PotentialET_PenmanComponent::setlambdaV(double _lambdaV)
{
    _PriestlyTaylor.setlambdaV(_lambdaV);
    _Penman.setlambdaV(_lambdaV);
}
void PotentialET_PenmanComponent::setpsychrometricConstant(double _psychrometricConstant)
{
    _PriestlyTaylor.setpsychrometricConstant(_psychrometricConstant);
    _Penman.setpsychrometricConstant(_psychrometricConstant);
}
void PotentialET_PenmanComponent::setAlpha(double _Alpha)
{
    _PriestlyTaylor.setAlpha(_Alpha);
    _Penman.setAlpha(_Alpha);
}
void PotentialET_PenmanComponent::setih(int _ih)
{
    _PriestlyTaylor.setih(_ih);
}
void PotentialET_PenmanComponent::setspecificHeatCapacityAir(double _specificHeatCapacityAir)
{
    _Penman.setspecificHeatCapacityAir(_specificHeatCapacityAir);
}
void PotentialET_PenmanComponent::setrhoDensityAir(double _rhoDensityAir)
{
    _Penman.setrhoDensityAir(_rhoDensityAir);
}
void PotentialET_PenmanComponent::Calculate_Model(PotentialET_PenmanState &s, PotentialET_PenmanState &s1, PotentialET_PenmanRate &r, PotentialET_PenmanAuxiliary &a, PotentialET_PenmanExogenous &ex)
{
    _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
    _Penman.Calculate_Model(s, s1, r, a, ex);
}
PotentialET_PenmanComponent::PotentialET_PenmanComponent(PotentialET_PenmanComponent& toCopy)
{
    lambdaV = toCopy.getlambdaV();
    psychrometricConstant = toCopy.getpsychrometricConstant();
    Alpha = toCopy.getAlpha();
    ih = toCopy.getih();
    specificHeatCapacityAir = toCopy.getspecificHeatCapacityAir();
    rhoDensityAir = toCopy.getrhoDensityAir();
}