package net.simplace.sim.components.SiriusQuality-EnergyBalance;
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


public class SoilEvaporation extends FWSimComponent
{
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> energyLimitedEvaporation;
    private FWSimVariable<Double> diffusionLimitedEvaporation;
    private FWSimVariable<Double> soilEvaporation;

    public SoilEvaporation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SoilEvaporation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("energyLimitedEvaporation", "energy Limited Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"g m-2 d-1", 0, 1000, 448.240, this));
        addVariable(FWSimVariable.createSimVariable("diffusionLimitedEvaporation", "diffusion Limited Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"g m-2 d-1", 0, 10000, 6605.505, this));
        addVariable(FWSimVariable.createSimVariable("soilEvaporation", "soil Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"g m-2 d-1", 0, 5000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_ih = ih.getValue();
        double t_energyLimitedEvaporation = energyLimitedEvaporation.getValue();
        double t_diffusionLimitedEvaporation = diffusionLimitedEvaporation.getValue();
        double t_soilEvaporation = soilEvaporation.getDefault();
        if (t_ih == -999)
        {
            t_soilEvaporation = Math.min(t_diffusionLimitedEvaporation, t_energyLimitedEvaporation);
        }
        else
        {
            t_soilEvaporation = 0.0d;
        }
        soilEvaporation.setValue(t_soilEvaporation, this);
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
        return new SoilEvaporation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}