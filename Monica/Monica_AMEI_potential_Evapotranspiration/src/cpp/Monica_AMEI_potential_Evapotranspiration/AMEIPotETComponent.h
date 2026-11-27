#include "SaturationVaporPressureDeficit.h"
#include "ReferenceEvapotranspiration.h"
#include "PotentialEvapotranspiration.h"

namespace Monica_AMEI_potential_Evapotranspiration {
class AMEIPotETComponent
{
    private:
        double height_nn ;
        double latent_heat_of_vaporization ;
    public:
        AMEIPotETComponent();
        AMEIPotETComponent(AMEIPotETComponent& copy);
        void Calculate_Model(AMEIPotETState &s, AMEIPotETState &s1, AMEIPotETRate &r, AMEIPotETAuxiliary &a, AMEIPotETExogenous &ex);
        void Init(AMEIPotETState &s, AMEIPotETState &s1, AMEIPotETRate &r, AMEIPotETAuxiliary &a, AMEIPotETExogenous &ex);
        double getheight_nn();
        void setheight_nn(double _height_nn);
        double getlatent_heat_of_vaporization();
        void setlatent_heat_of_vaporization(double _latent_heat_of_vaporization);

        SaturationVaporPressureDeficit _SaturationVaporPressureDeficit;
        ReferenceEvapotranspiration _ReferenceEvapotranspiration;
        PotentialEvapotranspiration _PotentialEvapotranspiration;

};
}
