package net.simplace.sim.components.SiriusQuality-ET;
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


public class NetRadiationEquivalentEvaporation extends FWSimComponent
{
    private FWSimVariable<Double> lambdaV;
    private FWSimVariable<Double> netRadiation;
    private FWSimVariable<Double> netRadiationEquivalentEvaporation;

    public NetRadiationEquivalentEvaporation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public NetRadiationEquivalentEvaporation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("lambdaV", "latent heat of vaporization of water", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"MJ kg-1", 0, 10, 2.454, this));
        addVariable(FWSimVariable.createSimVariable("netRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 d-1", 0, 5000, 1.566, this));
        addVariable(FWSimVariable.createSimVariable("netRadiationEquivalentEvaporation", "net Radiation in Equivalent Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"g m-2 d-1", 0, 5000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_lambdaV = lambdaV.getValue();
        double t_netRadiation = netRadiation.getValue();
        double t_netRadiationEquivalentEvaporation = netRadiationEquivalentEvaporation.getDefault();
        t_netRadiationEquivalentEvaporation = t_netRadiation / t_lambdaV * 1000.00d;
        netRadiationEquivalentEvaporation.setValue(t_netRadiationEquivalentEvaporation, this);
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
        return new NetRadiationEquivalentEvaporation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}