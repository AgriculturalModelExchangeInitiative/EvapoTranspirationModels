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


public class Conductance extends FWSimComponent
{
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> wind;
    private FWSimVariable<Double> heightWeatherMeasurements;
    private FWSimVariable<Double> vonKarman;
    private FWSimVariable<Double> plantHeight;
    private FWSimVariable<Double> zh;
    private FWSimVariable<Double> zm;
    private FWSimVariable<Double> d;
    private FWSimVariable<Double> conductance;

    public Conductance(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Conductance(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.constant,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("wind", "wind", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m/d", 0, 1000000, 124000, this));
        addVariable(FWSimVariable.createSimVariable("heightWeatherMeasurements", "reference height of wind and humidity measurements", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 0, 10, 2, this));
        addVariable(FWSimVariable.createSimVariable("vonKarman", "von Karman constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0, 1, 0.42, this));
        addVariable(FWSimVariable.createSimVariable("plantHeight", "plant Height", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, 1000, 0, this));
        addVariable(FWSimVariable.createSimVariable("zh", "roughness length governing transfer of heat and vapour, FAO", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 0, 1, 0.013, this));
        addVariable(FWSimVariable.createSimVariable("zm", "roughness length governing momentum transfer, FAO", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 0, 1, 0.13, this));
        addVariable(FWSimVariable.createSimVariable("d", "corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0, 1, 0.67, this));
        addVariable(FWSimVariable.createSimVariable("conductance", "the boundary layer conductance", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"m/d", 0, 10000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Integer t_ih = ih.getValue();
        double t_wind = wind.getValue();
        double t_heightWeatherMeasurements = heightWeatherMeasurements.getValue();
        double t_vonKarman = vonKarman.getValue();
        double t_plantHeight = plantHeight.getValue();
        double t_zh = zh.getValue();
        double t_zm = zm.getValue();
        double t_d = d.getValue();
        double t_conductance = conductance.getDefault();
        double h;
        double clim;
        clim = 0.10d;
        if (t_ih != -999)
        {
            clim = 36.00d;
        }
        h = Math.max(10.00d, t_plantHeight) / 100.00d;
        t_conductance = t_wind * Math.pow(t_vonKarman, 2) / (Math.log((t_heightWeatherMeasurements - (t_d * h)) / (t_zm * h)) * Math.log((t_heightWeatherMeasurements - (t_d * h)) / (t_zh * h)));
        t_conductance = Math.max(clim, t_conductance);
        conductance.setValue(t_conductance, this);
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
        return new Conductance(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}