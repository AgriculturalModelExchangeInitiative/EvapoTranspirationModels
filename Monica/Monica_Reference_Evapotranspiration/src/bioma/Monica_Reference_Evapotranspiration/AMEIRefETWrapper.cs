using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_AMEIRefET.DomainClass;
using Crop2ML_AMEIRefET.Strategies;

namespace Model.Model.AMEIRefET
{
    class AMEIRefETWrapper :  UniverseLink
    {
        private AMEIRefETState s;
        private AMEIRefETState s1;
        private AMEIRefETRate r;
        private AMEIRefETAuxiliary a;
        private AMEIRefETExogenous ex;
        private AMEIRefETComponent ameirefetComponent;

        public AMEIRefETWrapper(Universe universe) : base(universe)
        {
            s = new AMEIRefETState();
            r = new AMEIRefETRate();
            a = new AMEIRefETAuxiliary();
            ex = new AMEIRefETExogenous();
            ameirefetComponent = new AMEIRefET();
            loadParameters();
        }

        public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     

        public AMEIRefETWrapper(Universe universe, AMEIRefETWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new AMEIRefETState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new AMEIRefETRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new AMEIRefETAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new AMEIRefETExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                ameirefetComponent = (toCopy.ameirefetComponent != null) ? new AMEIRefET(toCopy.ameirefetComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            ameirefetComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            ameirefetComponent.height_nn = 0; 
        }

        public void EstimateAMEIRefET(double stomata_resistance, double net_radiation, double saturation_vapor_pressure_deficit, double mean_air_temperature, double wind_speed, double wind_speed_height)
        {
            a.stomata_resistance = stomata_resistance;
            a.net_radiation = net_radiation;
            a.saturation_vapor_pressure_deficit = saturation_vapor_pressure_deficit;
            ex.mean_air_temperature = mean_air_temperature;
            ex.wind_speed = wind_speed;
            ex.wind_speed_height = wind_speed_height;
            ameirefetComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}