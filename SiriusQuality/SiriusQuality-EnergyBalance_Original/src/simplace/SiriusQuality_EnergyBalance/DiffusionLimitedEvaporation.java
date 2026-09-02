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


public class DiffusionLimitedEvaporation extends FWSimComponent
{
    private FWSimVariable<Double> soilDiffusionConstant;
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> deficitOnTopLayers;
    private FWSimVariable<Double> diffusionLimitedEvaporation;

    public DiffusionLimitedEvaporation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public DiffusionLimitedEvaporation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("soilDiffusionConstant", "soil Diffusion Constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 10, 4.2, this));
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("deficitOnTopLayers", "deficit On TopLayers", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"g m-2 d-1", 0, 10000, 5341, this));
        addVariable(FWSimVariable.createSimVariable("diffusionLimitedEvaporation", "the evaporation from the diffusion limited soil", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"g m-2 d-1", 0, 5000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_soilDiffusionConstant = soilDiffusionConstant.getValue();
        Integer t_ih = ih.getValue();
        double t_deficitOnTopLayers = deficitOnTopLayers.getValue();
        double t_diffusionLimitedEvaporation = diffusionLimitedEvaporation.getDefault();
        if (t_ih == -999)
        {
            if (t_deficitOnTopLayers / 1000.00d <= 0.00d)
            {
                t_diffusionLimitedEvaporation = 8.30d * 1000.00d;
            }
            else
            {
                if (t_deficitOnTopLayers / 1000.00d < 25.00d)
                {
                    t_diffusionLimitedEvaporation = 2.00d * t_soilDiffusionConstant * t_soilDiffusionConstant / (t_deficitOnTopLayers / 1000.00d) * 1000.00d;
                }
                else
                {
                    t_diffusionLimitedEvaporation = 0.00d;
                }
            }
        }
        else
        {
            t_diffusionLimitedEvaporation = 0.00d;
        }
        diffusionLimitedEvaporation.setValue(t_diffusionLimitedEvaporation, this);
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
        return new DiffusionLimitedEvaporation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}