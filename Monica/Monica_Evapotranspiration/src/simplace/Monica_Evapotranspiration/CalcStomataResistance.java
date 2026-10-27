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


public class CalcStomataResistance extends FWSimComponent
{
    private FWSimVariable<Boolean> calc_stomata_resistance;
    private FWSimVariable<Double> calculated_stomata_resistance;
    private FWSimVariable<Double> fixed_stomata_resistance;
    private FWSimVariable<Double> stomata_resistance;

    public CalcStomataResistance(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CalcStomataResistance(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("calc_stomata_resistance", "boolean condition to be met", DATA_TYPE.BOOLEAN, CONTENT_TYPE.input,"", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("calculated_stomata_resistance", "value to be returned if condition is true", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"s/m", 0.0, 10000.0, 100.0, this));
        addVariable(FWSimVariable.createSimVariable("fixed_stomata_resistance", "value to be returned if condition is false", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"s/m", 0.0, 10000.0, 100.0, this));
        addVariable(FWSimVariable.createSimVariable("stomata_resistance", "the output value", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"s/m", 0.0, 10000.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Boolean t_calc_stomata_resistance = calc_stomata_resistance.getValue();
        double t_calculated_stomata_resistance = calculated_stomata_resistance.getValue();
        double t_fixed_stomata_resistance = fixed_stomata_resistance.getValue();
        double t_stomata_resistance = stomata_resistance.getDefault();
        if (t_calc_stomata_resistance)
        {
            t_stomata_resistance = t_calculated_stomata_resistance;
        }
        else
        {
            t_stomata_resistance = t_fixed_stomata_resistance;
        }
        stomata_resistance.setValue(t_stomata_resistance, this);
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
        return new CalcStomataResistance(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}