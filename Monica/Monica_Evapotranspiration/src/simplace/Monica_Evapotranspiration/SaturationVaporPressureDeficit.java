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


public class SaturationVaporPressureDeficit extends FWSimComponent
{
    private FWSimVariable<Double> saturated_vapor_pressure;
    private FWSimVariable<Double> vapor_pressure;
    private FWSimVariable<Double> saturation_vapor_pressure_deficit;

    public SaturationVaporPressureDeficit(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SaturationVaporPressureDeficit(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("saturated_vapor_pressure", "saturated vapor pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("vapor_pressure", "vapor pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("saturation_vapor_pressure_deficit", "saturation vapor pressure deficit", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"kPa", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_saturated_vapor_pressure = saturated_vapor_pressure.getValue();
        double t_vapor_pressure = vapor_pressure.getValue();
        double t_saturation_vapor_pressure_deficit = saturation_vapor_pressure_deficit.getDefault();
        t_saturation_vapor_pressure_deficit = t_saturated_vapor_pressure - t_vapor_pressure;
        saturation_vapor_pressure_deficit.setValue(t_saturation_vapor_pressure_deficit, this);
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
        return new SaturationVaporPressureDeficit(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}