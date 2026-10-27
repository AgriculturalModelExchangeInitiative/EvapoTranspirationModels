using System;
using System.Collections.Generic;
using System.Linq;
class AMEIPotETWrapper
{
    private AMEIPotETState s;
    private AMEIPotETState s1;
    private AMEIPotETRate r;
    private AMEIPotETAuxiliary a;
    private AMEIPotETExogenous ex;
    private AMEIPotETComponent ameipotetComponent;

    public AMEIPotETWrapper()
    {
        s = new AMEIPotETState();
        r = new AMEIPotETRate();
        a = new AMEIPotETAuxiliary();
        ex = new AMEIPotETExogenous();
        ameipotetComponent = new AMEIPotETComponent();
        loadParameters();
    }

        double height_nn;

    public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     
    public double potential_evapotranspiration{ get { return a.potential_evapotranspiration;}} 
     

    public AMEIPotETWrapper(AMEIPotETWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new AMEIPotETState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new AMEIPotETRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new AMEIPotETAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new AMEIPotETExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            ameipotetComponent = (toCopy.ameipotetComponent != null) ? new AMEIPotETComponent(toCopy.ameipotetComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        ameipotetComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        ameipotetComponent.height_nn = 0; 
    }

    private void setExogenous()
    {
        ex.mean_air_temperature = null; // To be modified
        ex.wind_speed = null; // To be modified
        ex.wind_speed_height = null; // To be modified
        ex.kc_factor = null; // To be modified
        ex.developmental_stage = null; // To be modified
        ex.crop_remaining_evapotranspiration = null; // To be modified
    }

    public void EstimateAMEIPotET(double vapor_pressure, double saturated_vapor_pressure, double stomata_resistance, double net_radiation, double mean_air_temperature, double wind_speed, double wind_speed_height, double kc_factor, int developmental_stage, double crop_remaining_evapotranspiration)
    {
        a.vapor_pressure = vapor_pressure;
        a.saturated_vapor_pressure = saturated_vapor_pressure;
        a.stomata_resistance = stomata_resistance;
        a.net_radiation = net_radiation;
        ex.mean_air_temperature = mean_air_temperature;
        ex.wind_speed = wind_speed;
        ex.wind_speed_height = wind_speed_height;
        ex.kc_factor = kc_factor;
        ex.developmental_stage = developmental_stage;
        ex.crop_remaining_evapotranspiration = crop_remaining_evapotranspiration;
        ameipotetComponent.CalculateModel(s,s1, r, a, ex);
    }

}