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


public class PtSoil extends FWSimComponent
{
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> Alpha;
    private FWSimVariable<Double> tauAlpha;
    private FWSimVariable<Double> evapoTranspirationPriestlyTaylor;
    private FWSimVariable<Double> tau;
    private FWSimVariable<Double> energyLimitedEvaporation;

    public PtSoil(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public PtSoil(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("Alpha", "Priestley-Taylor evapotranspiration proportionality constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 100, 1.5, this));
        addVariable(FWSimVariable.createSimVariable("tauAlpha", "Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 1, 0.3, this));
        addVariable(FWSimVariable.createSimVariable("evapoTranspirationPriestlyTaylor", "evapoTranspiration Priestly Taylor", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 1000, 120, this));
        addVariable(FWSimVariable.createSimVariable("tau", "soil cover factor", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", 0, 1, 120, this));
        addVariable(FWSimVariable.createSimVariable("energyLimitedEvaporation", "energy Limited Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"g m-2 d-1", 0, 5000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_ih = ih.getValue();
        double t_Alpha = Alpha.getValue();
        double t_tauAlpha = tauAlpha.getValue();
        double t_evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor.getValue();
        double t_tau = tau.getValue();
        double t_energyLimitedEvaporation = energyLimitedEvaporation.getDefault();
        double AlphaE;
        if (t_ih == -999)
        {
            if (t_tau < t_tauAlpha)
            {
                AlphaE = 1.00d;
            }
            else
            {
                AlphaE = t_Alpha - ((t_Alpha - 1.00d) * (1.00d - t_tau) / (1.00d - t_tauAlpha));
            }
            t_energyLimitedEvaporation = t_evapoTranspirationPriestlyTaylor / t_Alpha * AlphaE * t_tau;
        }
        else
        {
            t_energyLimitedEvaporation = 0.00d;
        }
        energyLimitedEvaporation.setValue(t_energyLimitedEvaporation, this);
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
        return new PtSoil(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}