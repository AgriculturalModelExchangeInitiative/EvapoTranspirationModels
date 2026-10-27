package net.simplace.sim.components.Monica_AMEI_potential_Evapotranspiration;
import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class ReferenceEvapotranspiration extends FWSimComponent
{
    private FWSimVariable<Double> height_nn;
    private FWSimVariable<Double> mean_air_temperature;
    private FWSimVariable<Double> wind_speed;
    private FWSimVariable<Double> wind_speed_height;
    private FWSimVariable<Double> net_radiation;
    private FWSimVariable<Double> stomata_resistance;
    private FWSimVariable<Double> saturation_vapor_pressure_deficit;
    private FWSimVariable<Double> reference_evapotranspiration;

    public ReferenceEvapotranspiration(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ReferenceEvapotranspiration(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("height_nn", "height above sea level", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", -9999.0, 9999.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("mean_air_temperature", "daily average air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -100.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("wind_speed", "wind speed measured at wind speed height", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m/s", 0.0, 9999.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("wind_speed_height", "height at which the wind speed has been measured", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m", -9999.0, 9999.0, 2.0, this));
        addVariable(FWSimVariable.createSimVariable("net_radiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("stomata_resistance", "stomata resistance (FAO default value is 100)", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"s/m", 0.0, 10000.0, 100.0, this));
        addVariable(FWSimVariable.createSimVariable("saturation_vapor_pressure_deficit", "saturation_vapor_pressure_deficit", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("reference_evapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_height_nn = height_nn.getValue();
        double t_mean_air_temperature = mean_air_temperature.getValue();
        double t_wind_speed = wind_speed.getValue();
        double t_wind_speed_height = wind_speed_height.getValue();
        double t_net_radiation = net_radiation.getValue();
        double t_stomata_resistance = stomata_resistance.getValue();
        double t_saturation_vapor_pressure_deficit = saturation_vapor_pressure_deficit.getValue();
        double t_reference_evapotranspiration = reference_evapotranspiration.getDefault();
        double atmospheric_pressure;
        atmospheric_pressure = 101.3d * Math.pow((293.0d - (0.0065d * t_height_nn)) / 293.0d, 5.26d);
        double psycrometer_constant;
        psycrometer_constant = 0.000665d * atmospheric_pressure;
        double saturated_vapour_pressure_slope;
        saturated_vapour_pressure_slope = 4098.0d * (0.6108d * Math.exp(17.27d * t_mean_air_temperature / (t_mean_air_temperature + 237.3d))) / ((t_mean_air_temperature + 237.3d) * (t_mean_air_temperature + 237.3d));
        double wind_speed_2m;
        wind_speed_2m = Math.max(0.5d, t_wind_speed * (4.87d / Math.log((67.8d * t_wind_speed_height - 5.42d))));
        double aerodynamic_resistance;
        aerodynamic_resistance = 208.0d / wind_speed_2m;
        double surface_resistance;
        surface_resistance = t_stomata_resistance / 1.44d;
        t_reference_evapotranspiration = (0.408d * saturated_vapour_pressure_slope * t_net_radiation + (psycrometer_constant * (900.0d / (t_mean_air_temperature + 273.0d)) * wind_speed_2m * t_saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0d + (surface_resistance / aerodynamic_resistance))));
        if (t_reference_evapotranspiration < 0.0d)
        {
            t_reference_evapotranspiration = 0.0d;
        }
        reference_evapotranspiration.setValue(t_reference_evapotranspiration, this);
    }

    @Override
    protected void init()
    {
    }
    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new ReferenceEvapotranspiration(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}