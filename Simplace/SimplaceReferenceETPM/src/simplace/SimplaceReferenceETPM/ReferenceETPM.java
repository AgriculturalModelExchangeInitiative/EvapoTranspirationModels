package net.simplace.sim.components.SimplaceReferenceETPM;
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


public class ReferenceETPM extends FWSimComponent
{
    private FWSimVariable<Double> cAltitude;
    private FWSimVariable<Double> iTMax;
    private FWSimVariable<Double> iTMin;
    private FWSimVariable<Double> iActualVapourPressure;
    private FWSimVariable<Double> iNetRadiation;
    private FWSimVariable<Double> iWindspeed;
    private FWSimVariable<Double> ReferenceCropEvapotranspiration;

    public ReferenceETPM(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ReferenceETPM(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("cAltitude", "elevation above sea level", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"http://www.wurvoc.org/vocabularies/om-1.8/metre", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iActualVapourPressure", "actual vapour pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/kilopascal", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iNetRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iWindspeed", "wind speed at 2m height", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("ReferenceCropEvapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_cAltitude = cAltitude.getValue();
        double t_iTMax = iTMax.getValue();
        double t_iTMin = iTMin.getValue();
        double t_iActualVapourPressure = iActualVapourPressure.getValue();
        double t_iNetRadiation = iNetRadiation.getValue();
        double t_iWindspeed = iWindspeed.getValue();
        double t_ReferenceCropEvapotranspiration = ReferenceCropEvapotranspiration.getDefault();
        double T;
        double e_s;
        T = (t_iTMax + t_iTMin) / 2;
        e_s = MeanSaturatedVapourPressure(t_iTMax, t_iTMin);
        if (t_iActualVapourPressure > e_s)
        {
            t_iActualVapourPressure = e_s;
        }
        t_ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T, t_iNetRadiation, t_iWindspeed, e_s, t_iActualVapourPressure, t_cAltitude);
        ReferenceCropEvapotranspiration.setValue(t_ReferenceCropEvapotranspiration, this);
    }
    public static double SaturationVapourPressureAtTemperature(double T)
    {
        return 0.6108d * Math.exp(17.27d * T / (T + 237.3d));
    }
    public static double MeanSaturatedVapourPressure(double T_max, double T_min)
    {
        return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2;
    }
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3d;
        return 4098 * (0.6108d * Math.exp(17.27d * T / tempT)) / Math.pow(tempT, 2);
    }
    public static double PsychrometricConstant(double P)
    {
        double lambdav;
        double c_p;
        double epsilon;
        double factor;
        lambdav = 2.45d;
        c_p = 1.013E-3d;
        epsilon = 0.622d;
        factor = Math.round(c_p / (epsilon * lambdav) * 10E6d) / 10E6d;
        return factor * P;
    }
    public static double AtmosphericPressure(double z)
    {
        return 101.3d * Math.pow((293 - (0.0065d * z)) / 293, 5.26d);
    }
    public static double ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z)
    {
        double P;
        double gamma;
        double Delta;
        double G;
        double ET0;
        P = AtmosphericPressure(z);
        gamma = PsychrometricConstant(P);
        Delta = SlopeOfSaturationVapPressureCurve(T);
        G = (double)(0);
        ET0 = (0.408d * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34d * u_2))));
        return ET0;
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
        return new ReferenceETPM(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}