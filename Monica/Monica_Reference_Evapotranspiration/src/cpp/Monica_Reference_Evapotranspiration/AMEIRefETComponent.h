#include "ReferenceEvapotranspiration.h"

namespace Monica_Reference_Evapotranspiration {
class AMEIRefETComponent
{
    private:
        double height_nn ;
        double latent_heat_of_vaporization ;
    public:
        AMEIRefETComponent();
        AMEIRefETComponent(AMEIRefETComponent& copy);
        void Calculate_Model(AMEIRefETState &s, AMEIRefETState &s1, AMEIRefETRate &r, AMEIRefETAuxiliary &a, AMEIRefETExogenous &ex);
        void Init(AMEIRefETState &s, AMEIRefETState &s1, AMEIRefETRate &r, AMEIRefETAuxiliary &a, AMEIRefETExogenous &ex);
        double getheight_nn();
        void setheight_nn(double _height_nn);
        double getlatent_heat_of_vaporization();
        void setlatent_heat_of_vaporization(double _latent_heat_of_vaporization);

        ReferenceEvapotranspiration _ReferenceEvapotranspiration;

};
}
