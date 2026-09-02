#include "EnergyBalanceCompositeComponent.h"
using namespace SiriusQuality-ET;
EnergyBalanceCompositeComponent::EnergyBalanceCompositeComponent()
{
       
}


double EnergyBalanceCompositeComponent::getalbedoCoefficient(){ return this->albedoCoefficient; }
double EnergyBalanceCompositeComponent::gettau(){ return this->tau; }
double EnergyBalanceCompositeComponent::getelevation(){ return this->elevation; }
double EnergyBalanceCompositeComponent::getstefanBoltzman(){ return this->stefanBoltzman; }
double EnergyBalanceCompositeComponent::getalbedoCoefficientCan(){ return this->albedoCoefficientCan; }
double EnergyBalanceCompositeComponent::getd(){ return this->d; }
double EnergyBalanceCompositeComponent::getheightWeatherMeasurements(){ return this->heightWeatherMeasurements; }
double EnergyBalanceCompositeComponent::getzh(){ return this->zh; }
double EnergyBalanceCompositeComponent::getzm(){ return this->zm; }
double EnergyBalanceCompositeComponent::getvonKarman(){ return this->vonKarman; }
double EnergyBalanceCompositeComponent::getlambdaV(){ return this->lambdaV; }
double EnergyBalanceCompositeComponent::getpsychrometricConstant(){ return this->psychrometricConstant; }
double EnergyBalanceCompositeComponent::getAlpha(){ return this->Alpha; }
double EnergyBalanceCompositeComponent::getspecificHeatCapacityAir(){ return this->specificHeatCapacityAir; }
double EnergyBalanceCompositeComponent::getrhoDensityAir(){ return this->rhoDensityAir; }

void EnergyBalanceCompositeComponent::setalbedoCoefficient(double _albedoCoefficient)
{
    _NetRadiation.setalbedoCoefficient(_albedoCoefficient);
}
void EnergyBalanceCompositeComponent::settau(double _tau)
{
    _NetRadiation.settau(_tau);
}
void EnergyBalanceCompositeComponent::setelevation(double _elevation)
{
    _NetRadiation.setelevation(_elevation);
}
void EnergyBalanceCompositeComponent::setstefanBoltzman(double _stefanBoltzman)
{
    _NetRadiation.setstefanBoltzman(_stefanBoltzman);
}
void EnergyBalanceCompositeComponent::setalbedoCoefficientCan(double _albedoCoefficientCan)
{
    _NetRadiation.setalbedoCoefficientCan(_albedoCoefficientCan);
}
void EnergyBalanceCompositeComponent::setd(double _d)
{
    _Conductance.setd(_d);
}
void EnergyBalanceCompositeComponent::setheightWeatherMeasurements(double _heightWeatherMeasurements)
{
    _Conductance.setheightWeatherMeasurements(_heightWeatherMeasurements);
}
void EnergyBalanceCompositeComponent::setzh(double _zh)
{
    _Conductance.setzh(_zh);
}
void EnergyBalanceCompositeComponent::setzm(double _zm)
{
    _Conductance.setzm(_zm);
}
void EnergyBalanceCompositeComponent::setvonKarman(double _vonKarman)
{
    _Conductance.setvonKarman(_vonKarman);
}
void EnergyBalanceCompositeComponent::setlambdaV(double _lambdaV)
{
    _NetRadiationEquivalentEvaporation.setlambdaV(_lambdaV);
    _Penman.setlambdaV(_lambdaV);
}
void EnergyBalanceCompositeComponent::setpsychrometricConstant(double _psychrometricConstant)
{
    _PriestlyTaylor.setpsychrometricConstant(_psychrometricConstant);
    _Penman.setpsychrometricConstant(_psychrometricConstant);
}
void EnergyBalanceCompositeComponent::setAlpha(double _Alpha)
{
    _PriestlyTaylor.setAlpha(_Alpha);
    _Penman.setAlpha(_Alpha);
}
void EnergyBalanceCompositeComponent::setspecificHeatCapacityAir(double _specificHeatCapacityAir)
{
    _Penman.setspecificHeatCapacityAir(_specificHeatCapacityAir);
}
void EnergyBalanceCompositeComponent::setrhoDensityAir(double _rhoDensityAir)
{
    _Penman.setrhoDensityAir(_rhoDensityAir);
}
void EnergyBalanceCompositeComponent::Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex)
{
    _NetRadiation.Calculate_Model(s, s1, r, a, ex);
    _Conductance.Calculate_Model(s, s1, r, a, ex);
    _NetRadiationEquivalentEvaporation.Calculate_Model(s, s1, r, a, ex);
    _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
    _Penman.Calculate_Model(s, s1, r, a, ex);
}
EnergyBalanceCompositeComponent::EnergyBalanceCompositeComponent(EnergyBalanceCompositeComponent& toCopy)
{
    albedoCoefficient = toCopy.getalbedoCoefficient();
    tau = toCopy.gettau();
    elevation = toCopy.getelevation();
    stefanBoltzman = toCopy.getstefanBoltzman();
    albedoCoefficientCan = toCopy.getalbedoCoefficientCan();
    d = toCopy.getd();
    heightWeatherMeasurements = toCopy.getheightWeatherMeasurements();
    zh = toCopy.getzh();
    zm = toCopy.getzm();
    vonKarman = toCopy.getvonKarman();
    lambdaV = toCopy.getlambdaV();
    psychrometricConstant = toCopy.getpsychrometricConstant();
    Alpha = toCopy.getAlpha();
    specificHeatCapacityAir = toCopy.getspecificHeatCapacityAir();
    rhoDensityAir = toCopy.getrhoDensityAir();
}