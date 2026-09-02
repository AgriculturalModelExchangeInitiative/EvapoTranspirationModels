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


public class CropHeatFlux extends FWSimComponent
{
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> potentialTranspiration;
    private FWSimVariable<Double> netRadiationEquivalentEvaporation;
    private FWSimVariable<Double> soilHeatFlux;
    private FWSimVariable<Double> cropHeatFlux;

    public CropHeatFlux(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CropHeatFlux(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("potentialTranspiration", "potential Transpiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 1000, 1.413, this));
        addVariable(FWSimVariable.createSimVariable("netRadiationEquivalentEvaporation", "net Radiation Equivalent Evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"g m-2 d-1", 0, 10000, 638.142, this));
        addVariable(FWSimVariable.createSimVariable("soilHeatFlux", "soil Heat Flux", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 1000, 188.817, this));
        addVariable(FWSimVariable.createSimVariable("cropHeatFlux", "crop Heat Flux", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 10000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_ih = ih.getValue();
        double t_potentialTranspiration = potentialTranspiration.getValue();
        double t_netRadiationEquivalentEvaporation = netRadiationEquivalentEvaporation.getValue();
        double t_soilHeatFlux = soilHeatFlux.getValue();
        double t_cropHeatFlux = cropHeatFlux.getDefault();
        double cHfliminf;
        double cHflimsup;
        cHfliminf = -100.00d;
        if (t_ih == -999)
        {
            cHfliminf = -10E6d;
        }
        cHflimsup = 100.00d;
        if (t_ih == -999)
        {
            cHflimsup = 10E6d;
        }
        t_cropHeatFlux = t_netRadiationEquivalentEvaporation - t_soilHeatFlux - t_potentialTranspiration;
        t_cropHeatFlux = Math.min(cHflimsup, Math.max(cHfliminf, t_cropHeatFlux));
        cropHeatFlux.setValue(t_cropHeatFlux, this);
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
        return new CropHeatFlux(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}