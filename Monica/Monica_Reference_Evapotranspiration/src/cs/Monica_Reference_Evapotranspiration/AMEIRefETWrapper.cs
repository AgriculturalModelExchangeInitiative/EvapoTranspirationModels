using System;
using System.Collections.Generic;
using System.Linq;
class AMEIRefETWrapper
{
    private AMEIRefETState s;
    private AMEIRefETState s1;
    private AMEIRefETRate r;
    private AMEIRefETAuxiliary a;
    private AMEIRefETExogenous ex;
    private AMEIRefETComponent ameirefetComponent;

    public AMEIRefETWrapper()
    {
        s = new AMEIRefETState();
        r = new AMEIRefETRate();
        a = new AMEIRefETAuxiliary();
        ex = new AMEIRefETExogenous();
        ameirefetComponent = new AMEIRefETComponent();
        loadParameters();
    }

        double height_nn;

    public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     

    public AMEIRefETWrapper(AMEIRefETWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new AMEIRefETState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new AMEIRefETRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new AMEIRefETAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new AMEIRefETExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            ameirefetComponent = (toCopy.ameirefetComponent != null) ? new AMEIRefETComponent(toCopy.ameirefetComponent) : null;
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

    private void setExogenous()
    {
        ex.mean_air_temperature = null; // To be modified
        ex.wind_speed = null; // To be modified
        ex.wind_speed_height = null; // To be modified
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