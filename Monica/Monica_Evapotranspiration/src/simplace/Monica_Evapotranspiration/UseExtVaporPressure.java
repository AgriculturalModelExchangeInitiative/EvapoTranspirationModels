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


public class UseExtVaporPressure extends FWSimComponent
{
    private FWSimVariable<Boolean> use_external_vapor_pressure;
    private FWSimVariable<Double> external_vapor_pressure;
    private FWSimVariable<Double> internal_vapor_pressure;
    private FWSimVariable<Double> vapor_pressure;

    public UseExtVaporPressure(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public UseExtVaporPressure(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("use_external_vapor_pressure", "boolean condition to be met", DATA_TYPE.BOOLEAN, CONTENT_TYPE.input,"mm", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("external_vapor_pressure", "value to be returned if condition is true", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("internal_vapor_pressure", "value to be returned if condition is false", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("vapor_pressure", "the output value", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Boolean t_use_external_vapor_pressure = use_external_vapor_pressure.getValue();
        double t_external_vapor_pressure = external_vapor_pressure.getValue();
        double t_internal_vapor_pressure = internal_vapor_pressure.getValue();
        double t_vapor_pressure = vapor_pressure.getDefault();
        if (t_use_external_vapor_pressure)
        {
            t_vapor_pressure = t_external_vapor_pressure;
        }
        else
        {
            t_vapor_pressure = t_internal_vapor_pressure;
        }
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
        return new UseExtVaporPressure(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}