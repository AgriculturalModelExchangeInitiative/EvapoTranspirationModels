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


public class NetRadiation extends FWSimComponent
{
    private FWSimVariable<Double> albedoCoefficient;
    private FWSimVariable<Double> maxTair;
    private FWSimVariable<Double> minTair;
    private FWSimVariable<Double> vaporPressure;
    private FWSimVariable<Integer> ih;
    private FWSimVariable<Double> extraSolarRadiation;
    private FWSimVariable<Double> solarRadiation;
    private FWSimVariable<Double> tau;
    private FWSimVariable<Double> elevation;
    private FWSimVariable<Double> stefanBoltzman;
    private FWSimVariable<Double> albedoCoefficientCan;
    private FWSimVariable<Double> netRadiation;
    private FWSimVariable<Double> netOutGoingLongWaveRadiation;

    public NetRadiation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public NetRadiation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("albedoCoefficient", "albedo Coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 1, 0.23, this));
        addVariable(FWSimVariable.createSimVariable("maxTair", "maximum air Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 30, 45, 7.2, this));
        addVariable(FWSimVariable.createSimVariable("minTair", "minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 30, 45, 0.7, this));
        addVariable(FWSimVariable.createSimVariable("vaporPressure", "vapor Pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"hPa", 0, 1000, 6.1, this));
        addVariable(FWSimVariable.createSimVariable("ih", "hour of the day if the component is hourly, -999 if the component is daily", DATA_TYPE.INT, CONTENT_TYPE.state,"", 999, 24, 999, this));
        addVariable(FWSimVariable.createSimVariable("extraSolarRadiation", "extra Solar Radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m2 d-1", 0, 1000, 11.7, this));
        addVariable(FWSimVariable.createSimVariable("solarRadiation", "solar Radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ m-2 d-1", 0, 1000, 3, this));
        addVariable(FWSimVariable.createSimVariable("tau", "plant cover factor", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 100, 0.9983, this));
        addVariable(FWSimVariable.createSimVariable("elevation", "elevation", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 500, 10000, 0, this));
        addVariable(FWSimVariable.createSimVariable("stefanBoltzman", "stefan Boltzman constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 1, 4.903E-09, this));
        addVariable(FWSimVariable.createSimVariable("albedoCoefficientCan", "albedo Coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 1, 0.23, this));
        addVariable(FWSimVariable.createSimVariable("netRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ m-2 d-1", 0, 5000, null, this));
        addVariable(FWSimVariable.createSimVariable("netOutGoingLongWaveRadiation", "net OutGoing Long Wave Radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"g m-2 d-1", 0, 5000, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_albedoCoefficient = albedoCoefficient.getValue();
        double t_maxTair = maxTair.getValue();
        double t_minTair = minTair.getValue();
        double t_vaporPressure = vaporPressure.getValue();
        Integer t_ih = ih.getValue();
        double t_extraSolarRadiation = extraSolarRadiation.getValue();
        double t_solarRadiation = solarRadiation.getValue();
        double t_tau = tau.getValue();
        double t_elevation = elevation.getValue();
        double t_stefanBoltzman = stefanBoltzman.getValue();
        double t_albedoCoefficientCan = albedoCoefficientCan.getValue();
        double t_netRadiation = netRadiation.getDefault();
        double t_netOutGoingLongWaveRadiation = netOutGoingLongWaveRadiation.getDefault();
        double Nsr;
        double clearSkySolarRadiation;
        double averageT;
        double surfaceEmissivity;
        double cloudCoverFactor;
        double Nolr;
        double cov;
        if (t_ih == -999)
        {
            Nsr = t_solarRadiation * (1 - (t_albedoCoefficientCan * t_tau + (t_albedoCoefficient * (1.00d - t_tau))));
        }
        else
        {
            cov = (double)(1);
            if (t_solarRadiation > 0.01d)
            {
                if (t_ih <= 7)
                {
                    cov = 0.30d;
                }
                else if ( t_ih > 7 && t_ih < 11)
                {
                    cov = 0.30d - (0.09d / 3.00d * (t_ih - 7.00d));
                }
                else if ( t_ih == 11)
                {
                    cov = 0.21d;
                }
                else if ( t_ih > 11 && t_ih < 15)
                {
                    cov = 0.21d + (0.09d / 3.00d * (t_ih - 11.00d));
                }
                else
                {
                    cov = 0.30d;
                }
            }
            Nsr = (1 - cov) * t_solarRadiation;
        }
        clearSkySolarRadiation = (0.750d + (2 * Math.pow(10.00d, -5) * t_elevation)) * t_extraSolarRadiation;
        averageT = (Math.pow(t_maxTair + 273.160d, 4) + Math.pow(t_minTair + 273.160d, 4)) / 2.00d;
        surfaceEmissivity = 0.340d - (0.140d * Math.sqrt(t_vaporPressure / 10.00d));
        cloudCoverFactor = 1.350d * (t_solarRadiation / clearSkySolarRadiation) - 0.350d;
        Nolr = t_stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;
        if (t_ih != -999)
        {
            Nolr = Nolr / 24.00d;
        }
        t_netRadiation = Nsr - Nolr;
        t_netOutGoingLongWaveRadiation = Nolr;
        netRadiation.setValue(t_netRadiation, this);
        netOutGoingLongWaveRadiation.setValue(t_netOutGoingLongWaveRadiation, this);
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
        return new NetRadiation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}