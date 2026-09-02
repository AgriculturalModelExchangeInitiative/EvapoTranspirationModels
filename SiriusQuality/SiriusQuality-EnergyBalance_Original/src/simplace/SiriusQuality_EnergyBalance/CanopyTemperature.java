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


public class CanopyTemperature extends FWSimComponent
{
    private FWSimVariable<Double> minTair;
    private FWSimVariable<Double> cropHeatFlux;
    private FWSimVariable<Double> specificHeatCapacityAir;
    private FWSimVariable<Double> conductance;
    private FWSimVariable<Double> lambdaV;
    private FWSimVariable<Double> rhoDensityAir;
    private FWSimVariable<Double> maxTair;
    private FWSimVariable<Double> maxCanopyTemperature;
    private FWSimVariable<Double> minCanopyTemperature;

    public CanopyTemperature(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CanopyTemperature(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("minTair", "minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 30, 45, 0.7, this));
        addVariable(FWSimVariable.createSimVariable("cropHeatFlux", "Crop heat flux", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g/m**2/d", 0, 10000, 447.912, this));
        addVariable(FWSimVariable.createSimVariable("specificHeatCapacityAir", "Specific heat capacity of dry air", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"MJ/kg/degC", None, None, 0.00101, this));
        addVariable(FWSimVariable.createSimVariable("conductance", "the boundary layer conductance", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"m/d", 0, 10000, 598.685, this));
        addVariable(FWSimVariable.createSimVariable("lambdaV", "latent heat of vaporization of water", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"MJ/kg", 0, 10, 2.454, this));
        addVariable(FWSimVariable.createSimVariable("rhoDensityAir", "Density of air", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"kg/m**3", None, None, 1.225, this));
        addVariable(FWSimVariable.createSimVariable("maxTair", "maximum air Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 30, 45, 7.2, this));
        addVariable(FWSimVariable.createSimVariable("maxCanopyTemperature", "maximal Canopy Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 30, 45, null, this));
        addVariable(FWSimVariable.createSimVariable("minCanopyTemperature", "minimal Canopy Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 30, 45, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_minTair = minTair.getValue();
        double t_cropHeatFlux = cropHeatFlux.getValue();
        double t_specificHeatCapacityAir = specificHeatCapacityAir.getValue();
        double t_conductance = conductance.getValue();
        double t_lambdaV = lambdaV.getValue();
        double t_rhoDensityAir = rhoDensityAir.getValue();
        double t_maxTair = maxTair.getValue();
        double t_maxCanopyTemperature = maxCanopyTemperature.getDefault();
        double t_minCanopyTemperature = minCanopyTemperature.getDefault();
        if (t_minTair == (double)(999) && t_maxTair == (double)(-999))
        {
            t_minCanopyTemperature = (double)(999);
            t_maxCanopyTemperature = (double)(-999);
        }
        else
        {
            t_minCanopyTemperature = t_minTair + (t_cropHeatFlux / (t_rhoDensityAir * t_specificHeatCapacityAir * t_conductance / t_lambdaV * 1000.00d));
            t_maxCanopyTemperature = t_maxTair + (t_cropHeatFlux / (t_rhoDensityAir * t_specificHeatCapacityAir * t_conductance / t_lambdaV * 1000.00d));
        }
        maxCanopyTemperature.setValue(t_maxCanopyTemperature, this);
        minCanopyTemperature.setValue(t_minCanopyTemperature, this);
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
        return new CanopyTemperature(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}