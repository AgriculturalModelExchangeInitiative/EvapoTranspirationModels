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


public class EvapoTranspiration extends FWSimComponent
{
    private FWSimVariable<Integer> isWindVpDefined;
    private FWSimVariable<Double> evapoTranspirationPenman;
    private FWSimVariable<Double> evapoTranspirationPriestlyTaylor;
    private FWSimVariable<Double> evapoTranspiration;

    public EvapoTranspiration(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public EvapoTranspiration(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("isWindVpDefined", "if wind and vapour pressure are defined", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 0, 1, 1, this));
        addVariable(FWSimVariable.createSimVariable("evapoTranspirationPenman", "evapoTranspiration of Penman", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"mm", 0, 10000, 830.958, this));
        addVariable(FWSimVariable.createSimVariable("evapoTranspirationPriestlyTaylor", "evapoTranspiration of Priestly Taylor", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"mm", 0, 10000, 449.367, this));
        addVariable(FWSimVariable.createSimVariable("evapoTranspiration", "evapoTranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"mm", 0, 10000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_isWindVpDefined = isWindVpDefined.getValue();
        double t_evapoTranspirationPenman = evapoTranspirationPenman.getValue();
        double t_evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor.getValue();
        double t_evapoTranspiration = evapoTranspiration.getDefault();
        if (t_isWindVpDefined == 1)
        {
            t_evapoTranspiration = t_evapoTranspirationPenman;
        }
        else
        {
            t_evapoTranspiration = t_evapoTranspirationPriestlyTaylor;
        }
        evapoTranspiration.setValue(t_evapoTranspiration, this);
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
        return new EvapoTranspiration(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}