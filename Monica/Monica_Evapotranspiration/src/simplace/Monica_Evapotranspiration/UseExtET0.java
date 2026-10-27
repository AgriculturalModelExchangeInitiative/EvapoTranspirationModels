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


public class UseExtET0 extends FWSimComponent
{
    private FWSimVariable<Boolean> use_external_et0;
    private FWSimVariable<Double> external_et0;
    private FWSimVariable<Double> internal_et0;
    private FWSimVariable<Double> et0;

    public UseExtET0(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public UseExtET0(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("use_external_et0", "boolean condition to be met", DATA_TYPE.BOOLEAN, CONTENT_TYPE.input,"", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("external_et0", "value to be returned if condition is true", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("internal_et0", "value to be returned if condition is false", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("et0", "the output value", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Boolean t_use_external_et0 = use_external_et0.getValue();
        double t_external_et0 = external_et0.getValue();
        double t_internal_et0 = internal_et0.getValue();
        double t_et0 = et0.getDefault();
        if (t_use_external_et0)
        {
            t_et0 = t_external_et0;
        }
        else
        {
            t_et0 = t_internal_et0;
        }
        et0.setValue(t_et0, this);
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
        return new UseExtET0(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}