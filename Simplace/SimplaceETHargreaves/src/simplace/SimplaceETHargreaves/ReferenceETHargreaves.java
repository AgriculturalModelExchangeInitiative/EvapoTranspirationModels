package net.simplace.sim.components.SimplaceETHargreaves;
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


public class ReferenceETHargreaves extends FWSimComponent
{
    private FWSimVariable<Boolean> cConvertLeByTemp;
    private FWSimVariable<Double> iTMax;
    private FWSimVariable<Double> iTMin;
    private FWSimVariable<Double> iSolarRadiation;
    private FWSimVariable<Double> ReferenceCropEvapotranspiration;

    public ReferenceETHargreaves(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ReferenceETHargreaves(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("cConvertLeByTemp", "Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.", DATA_TYPE.BOOLEAN, CONTENT_TYPE.constant,"", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("iSolarRadiation", "solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("ReferenceCropEvapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Boolean t_cConvertLeByTemp = cConvertLeByTemp.getValue();
        double t_iTMax = iTMax.getValue();
        double t_iTMin = iTMin.getValue();
        double t_iSolarRadiation = iSolarRadiation.getValue();
        double t_ReferenceCropEvapotranspiration = ReferenceCropEvapotranspiration.getDefault();
        double R_s_eveq;
        if (t_cConvertLeByTemp)
        {
            R_s_eveq = EvaporationEquivalentToRadiation1(t_iSolarRadiation, 0.5d * (t_iTMax + t_iTMin));
        }
        else
        {
            R_s_eveq = EvaporationEquivalentToRadiation2(t_iSolarRadiation);
        }
        t_ReferenceCropEvapotranspiration = Math.max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, t_iTMax, t_iTMin));
        ReferenceCropEvapotranspiration.setValue(t_ReferenceCropEvapotranspiration, this);
    }
    public static double EvaporationEquivalentToRadiation1(double Radiation, double DailyMeanTemperature)
    {
        return 1 / (2.501d - (0.002361d * DailyMeanTemperature)) * Radiation;
    }
    public static double EvaporationEquivalentToRadiation2(double Radiation)
    {
        return 0.408d * Radiation;
    }
    public static double ReferenceEvapoTranspirationFromSolarRadiation(double R_s, double T_max, double T_min)
    {
        double T_mean;
        T_mean = (T_max + T_min) / 2;
        return 0.0135d * (T_mean + 17.8d) * R_s;
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
        return new ReferenceETHargreaves(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}