#include "NetRadiation.h"
#include "Conductance.h"
#include "NetRadiationEquivalentEvaporation.h"
#include "PriestlyTaylor.h"
#include "Penman.h"

namespace SiriusQuality_ET {
class EnergyBalanceCompositeComponent
{
    private:
        double albedoCoefficient ;
        double tau ;
        double elevation ;
        double stefanBoltzman ;
        double albedoCoefficientCan ;
        double d ;
        double heightWeatherMeasurements ;
        double zh ;
        double zm ;
        double vonKarman ;
        double lambdaV ;
        double psychrometricConstant ;
        double Alpha ;
        double specificHeatCapacityAir ;
        double rhoDensityAir ;
    public:
        EnergyBalanceCompositeComponent();
        EnergyBalanceCompositeComponent(EnergyBalanceCompositeComponent& copy);
        void Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        void Init(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex);
        double getalbedoCoefficient();
        void setalbedoCoefficient(double _albedoCoefficient);
        double gettau();
        void settau(double _tau);
        double getelevation();
        void setelevation(double _elevation);
        double getstefanBoltzman();
        void setstefanBoltzman(double _stefanBoltzman);
        double getalbedoCoefficientCan();
        void setalbedoCoefficientCan(double _albedoCoefficientCan);
        double getd();
        void setd(double _d);
        double getheightWeatherMeasurements();
        void setheightWeatherMeasurements(double _heightWeatherMeasurements);
        double getzh();
        void setzh(double _zh);
        double getzm();
        void setzm(double _zm);
        double getvonKarman();
        void setvonKarman(double _vonKarman);
        double getlambdaV();
        void setlambdaV(double _lambdaV);
        double getpsychrometricConstant();
        void setpsychrometricConstant(double _psychrometricConstant);
        double getAlpha();
        void setAlpha(double _Alpha);
        double getspecificHeatCapacityAir();
        void setspecificHeatCapacityAir(double _specificHeatCapacityAir);
        double getrhoDensityAir();
        void setrhoDensityAir(double _rhoDensityAir);

        NetRadiation _NetRadiation;
        Conductance _Conductance;
        NetRadiationEquivalentEvaporation _NetRadiationEquivalentEvaporation;
        PriestlyTaylor _PriestlyTaylor;
        Penman _Penman;

};
}
