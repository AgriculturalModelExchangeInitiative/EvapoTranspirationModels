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


public class SaturatedVaporPressure extends FWSimComponent
{
    private FWSimVariable<Double> max_air_temperature;
    private FWSimVariable<Double> min_air_temperature;
    private FWSimVariable<Double> relative_humidity;
    private FWSimVariable<Double> saturated_vapor_pressure;
    private FWSimVariable<Double> vapor_pressure;

    public SaturatedVaporPressure(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SaturatedVaporPressure(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("max_air_temperature", "daily maximum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -100.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("min_air_temperature", "daily minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -100.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("relative_humidity", "relative humidity", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"fraction", 0.0, 1.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("saturated_vapor_pressure", "saturated vapor pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("vapor_pressure", "vapor pressure from relative humidity and saturated vapor pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"kPa", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_max_air_temperature = max_air_temperature.getValue();
        double t_min_air_temperature = min_air_temperature.getValue();
        double t_relative_humidity = relative_humidity.getValue();
        double t_saturated_vapor_pressure = saturated_vapor_pressure.getDefault();
        double t_vapor_pressure = vapor_pressure.getDefault();
        double saturated_vapor_pressure_max;
        saturated_vapor_pressure_max = 0.6108d * Math.exp(17.27d * t_max_air_temperature / (237.3d + t_max_air_temperature));
        double saturated_vapor_pressure_min;
        saturated_vapor_pressure_min = 0.6108d * Math.exp(17.27d * t_min_air_temperature / (237.3d + t_min_air_temperature));
        t_saturated_vapor_pressure = (saturated_vapor_pressure_max + saturated_vapor_pressure_min) / 2.0d;
        if (t_relative_humidity <= 0.0d)
        {
            t_vapor_pressure = saturated_vapor_pressure_min;
        }
        else
        {
            t_vapor_pressure = t_relative_humidity * t_saturated_vapor_pressure;
        }
        saturated_vapor_pressure.setValue(t_saturated_vapor_pressure, this);
        vapor_pressure.setValue(t_vapor_pressure, this);
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
        return new SaturatedVaporPressure(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}