package net.simplace.sim.components.SimplaceReferenceETPriestleyTaylor;
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


public class ReferenceETPriestleyTaylor extends FWSimComponent
{
    private FWSimVariable<Double> cAltitude;
    private FWSimVariable<Double> cAlphaPT;
    private FWSimVariable<Double> iTMax;
    private FWSimVariable<Double> iTMin;
    private FWSimVariable<Double> iNetRadiation;
    private FWSimVariable<Double> ReferenceCropEvapotranspiration;

    public ReferenceETPriestleyTaylor(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ReferenceETPriestleyTaylor(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("cAltitude", "altitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"http://www.wurvoc.org/vocabularies/om-1.8/metre", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("cAlphaPT", "Priestley-Taylor coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"http://www.wurvoc.org/vocabularies/om-1.8/one", 0.0, null, 1.26, this));
        addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iNetRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("ReferenceCropEvapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_cAltitude = cAltitude.getValue();
        double t_cAlphaPT = cAlphaPT.getValue();
        double t_iTMax = iTMax.getValue();
        double t_iTMin = iTMin.getValue();
        double t_iNetRadiation = iNetRadiation.getValue();
        double t_ReferenceCropEvapotranspiration = ReferenceCropEvapotranspiration.getDefault();
        double lambdav;
        double T;
        double Delta;
        double AtmPres;
        double Gamma;
        double G;
        lambdav = 2.45d;
        T = (t_iTMax + t_iTMin) / 2.0d;
        Delta = SlopeOfSaturationVapPressureCurve(T);
        AtmPres = AtmosphericPressure(t_cAltitude);
        Gamma = PsychrometricConstant(AtmPres);
        G = 0.0d;
        t_ReferenceCropEvapotranspiration = Math.max(0, t_cAlphaPT * Delta / (Delta + Gamma) * (t_iNetRadiation - G) / lambdav);
        ReferenceCropEvapotranspiration.setValue(t_ReferenceCropEvapotranspiration, this);
    }
    public static double SlopeOfSaturationVapPressureCurve(double T)
    {
        double tempT;
        tempT = T + 237.3d;
        return 4098 * (0.6108d * Math.exp(17.27d * T / tempT)) / Math.pow(tempT, 2);
    }
    public static double AtmosphericPressure(double z)
    {
        return 101.3d * Math.pow((293 - (0.0065d * z)) / 293, 5.26d);
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
        return new ReferenceETPriestleyTaylor(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}