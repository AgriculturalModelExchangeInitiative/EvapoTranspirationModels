package net.simplace.sim.components.SiriusQuality-Priestly-Taylor;
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


public class PriestlyTaylor extends FWSimComponent
{
    private FWSimVariable<Double> lambdaV;
    private FWSimVariable<Double> netRadiation;
    private FWSimVariable<Double> psychrometricConstant;
    private FWSimVariable<Double> Alpha;
    private FWSimVariable<Double> solarRadiation;
    private FWSimVariable<Double> hslope;
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> evapoTranspirationPriestlyTaylor;

    public PriestlyTaylor(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public PriestlyTaylor(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("lambdaV", "latent heat of vaporization of water", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"MJ kg-1", 0.0, 10.0, 2.454, this));
        addVariable(FWSimVariable.createSimVariable("netRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 d-1", 0.0, 5000.0, 1.566, this));
        addVariable(FWSimVariable.createSimVariable("psychrometricConstant", "psychrometric constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0.0, 1.0, 0.66, this));
        addVariable(FWSimVariable.createSimVariable("Alpha", "Priestley-Taylor evapotranspiration proportionality constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0.0, 100.0, 1.5, this));
        addVariable(FWSimVariable.createSimVariable("solarRadiation", "solar Radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 d-1", 0.0, 1000.0, 3.0, this));
        addVariable(FWSimVariable.createSimVariable("hslope", "the slope of saturated vapor pressure temperature curve at a given temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"hPa degC-1", 0.0, 1000.0, 0.584, this));
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", -999, 24, -999, this));
        addVariable(FWSimVariable.createSimVariable("evapoTranspirationPriestlyTaylor", "evapoTranspiration of Priestly Taylor", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0.0, 10000.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_lambdaV = lambdaV.getValue();
        double t_netRadiation = netRadiation.getValue();
        double t_psychrometricConstant = psychrometricConstant.getValue();
        double t_Alpha = Alpha.getValue();
        double t_solarRadiation = solarRadiation.getValue();
        double t_hslope = hslope.getValue();
        Integer t_ih = ih.getValue();
        double t_evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor.getDefault();
        double a_G_Rn;
        a_G_Rn = 1.00d;
        if (t_ih != -999)
        {
            if (t_solarRadiation < 0.001d)
            {
                a_G_Rn = 0.50d;
            }
            else
            {
                a_G_Rn = 0.90d;
            }
        }
        t_evapoTranspirationPriestlyTaylor = Math.max(t_Alpha * t_hslope * (t_netRadiation / t_lambdaV * 1000.00d) * a_G_Rn / (t_hslope + t_psychrometricConstant), 0.00d);
        evapoTranspirationPriestlyTaylor.setValue(t_evapoTranspirationPriestlyTaylor, this);
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
        return new PriestlyTaylor(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}