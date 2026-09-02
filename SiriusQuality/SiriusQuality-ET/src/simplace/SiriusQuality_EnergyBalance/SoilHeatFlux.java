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


public class SoilHeatFlux extends FWSimComponent
{
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> netRadiationEquivalentEvaporation;
    private FWSimVariable<Double> soilEvaporation;
    private FWSimVariable<Double> tau;
    private FWSimVariable<Double> solarRadiation;
    private FWSimVariable<Double> soilHeatFlux;

    public SoilHeatFlux(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SoilHeatFlux(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("netRadiationEquivalentEvaporation", "net Radiation Equivalent Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"g m-2 d-1", 0, 5000, 638.142, this));
        addVariable(FWSimVariable.createSimVariable("soilEvaporation", "soil Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"g m-2 d-1", 0, 10000, 448.240, this));
        addVariable(FWSimVariable.createSimVariable("tau", "plant cover factor", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 100, 0.9983, this));
        addVariable(FWSimVariable.createSimVariable("solarRadiation", "solar Radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 d-1", 0, 1000, 3, this));
        addVariable(FWSimVariable.createSimVariable("soilHeatFlux", "soil Heat Flux", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 10000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_ih = ih.getValue();
        double t_netRadiationEquivalentEvaporation = netRadiationEquivalentEvaporation.getValue();
        double t_soilEvaporation = soilEvaporation.getValue();
        double t_tau = tau.getValue();
        double t_solarRadiation = solarRadiation.getValue();
        double t_soilHeatFlux = soilHeatFlux.getDefault();
        if (t_ih == -999)
        {
            t_soilHeatFlux = t_tau * t_netRadiationEquivalentEvaporation - t_soilEvaporation;
        }
        else
        {
            if (t_solarRadiation < 0.001d)
            {
                t_soilHeatFlux = t_netRadiationEquivalentEvaporation * 0.50d;
            }
            else
            {
                t_soilHeatFlux = t_netRadiationEquivalentEvaporation * 0.10d;
            }
        }
        soilHeatFlux.setValue(t_soilHeatFlux, this);
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
        return new SoilHeatFlux(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}