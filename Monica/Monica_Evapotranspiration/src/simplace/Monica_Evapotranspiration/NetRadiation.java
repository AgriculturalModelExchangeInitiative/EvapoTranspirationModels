package net.simplace.sim.components.Monica_Evapotranspiration;
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


public class NetRadiation extends FWSimComponent
{
    private FWSimVariable<Double> height_nn;
    private FWSimVariable<Double> reference_albedo;
    private FWSimVariable<Double> global_radiation;
    private FWSimVariable<Double> max_air_temperature;
    private FWSimVariable<Double> min_air_temperature;
    private FWSimVariable<Double> extraterrestrial_radiation;
    private FWSimVariable<Double> vapor_pressure;
    private FWSimVariable<Double> net_radiation;

    public NetRadiation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public NetRadiation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("height_nn", "height above sea level", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", -9999.0, 9999.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("reference_albedo", "reference albedo", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0.0, 1.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("global_radiation", "global radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2", 0.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("max_air_temperature", "daily maximum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -100.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("min_air_temperature", "daily minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -100.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("extraterrestrial_radiation", "extraterrestrial_radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2", 0.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("vapor_pressure", "vapor pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("net_radiation", "net_radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ/m2", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_height_nn = height_nn.getValue();
        double t_reference_albedo = reference_albedo.getValue();
        double t_global_radiation = global_radiation.getValue();
        double t_max_air_temperature = max_air_temperature.getValue();
        double t_min_air_temperature = min_air_temperature.getValue();
        double t_extraterrestrial_radiation = extraterrestrial_radiation.getValue();
        double t_vapor_pressure = vapor_pressure.getValue();
        double t_net_radiation = net_radiation.getDefault();
        double clear_sky_solar_radiation;
        clear_sky_solar_radiation = (0.75d + (0.00002d * t_height_nn)) * t_extraterrestrial_radiation;
        double relative_shortwave_radiation;
        relative_shortwave_radiation = clear_sky_solar_radiation > 0.0d ? Math.min(t_global_radiation / clear_sky_solar_radiation, 1.0d) : 1.0d;
        double bolzmann_constant = 0.0000000049;
        double shortwave_radiation;
        shortwave_radiation = (1.0d - t_reference_albedo) * t_global_radiation;
        double longwave_radiation;
        longwave_radiation = bolzmann_constant * ((Math.pow(t_min_air_temperature + 273.16d, 4.0d) + Math.pow(t_max_air_temperature + 273.16d, 4.0d)) / 2.0d) * (1.35d * relative_shortwave_radiation - 0.35d) * (0.34d - (0.14d * Math.sqrt(t_vapor_pressure)));
        t_net_radiation = shortwave_radiation - longwave_radiation;
        net_radiation.setValue(t_net_radiation, this);
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
        return new NetRadiation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}