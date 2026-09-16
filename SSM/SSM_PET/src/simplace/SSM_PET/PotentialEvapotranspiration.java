package net.simplace.sim.components.SSM_PET;
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


public class PotentialEvapotranspiration extends FWSimComponent
{
    private FWSimVariable<Double> tmax;
    private FWSimVariable<Double> tmin;
    private FWSimVariable<Double> srad;
    private FWSimVariable<Double> albedo;
    private FWSimVariable<Double> pet;

    public PotentialEvapotranspiration(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public PotentialEvapotranspiration(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("tmax", "Daily maximum temperature.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -60.0, 60.0, null, this));
        addVariable(FWSimVariable.createSimVariable("tmin", "Daily minimum temperature.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"°C", -60.0, 60.0, null, this));
        addVariable(FWSimVariable.createSimVariable("srad", "Daily solar radiation.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 day-1", 0.0, 120.0, null, this));
        addVariable(FWSimVariable.createSimVariable("albedo", "Surface albedo.", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"-", 0.0, 10.0, 1.0, this));
        addVariable(FWSimVariable.createSimVariable("pet", "Potential evapotranspiration.", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm day-1", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_tmax = tmax.getValue();
        double t_tmin = tmin.getValue();
        double t_srad = srad.getValue();
        double t_albedo = albedo.getValue();
        double t_pet = pet.getDefault();
        double td;
        double eeq;
        td = 0.6d * t_tmax + (0.4d * t_tmin);
        eeq = t_srad * (0.004876d - (0.004374d * t_albedo)) * (td + 29.0d);
        if (t_tmax > 5.0d && t_tmax < 34.0d)
        {
            t_pet = eeq * 1.1d;
        }
        else if ( t_tmax >= 34.0d)
        {
            t_pet = eeq * ((t_tmax - 34.0d) * 0.05d + 1.1d);
        }
        else
        {
            t_pet = eeq * 0.01d * Math.exp(0.18d * (t_tmax + 20.0d));
        }
        pet.setValue(t_pet, this);
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
        return new PotentialEvapotranspiration(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}