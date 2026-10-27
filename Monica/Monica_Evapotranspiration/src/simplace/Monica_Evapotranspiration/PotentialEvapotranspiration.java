package net.simplace.sim.components.Monica_Evapotranspiration;
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


public class PotentialEvapotranspiration extends FWSimComponent
{
    private FWSimVariable<Double> potential_evapotranspiration_cap;
    private FWSimVariable<Double> kc_factor;
    private FWSimVariable<Integer> developmental_stage;
    private FWSimVariable<Double> crop_remaining_evapotranspiration;
    private FWSimVariable<Double> reference_evapotranspiration;
    private FWSimVariable<Double> potential_evapotranspiration;

    public PotentialEvapotranspiration(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public PotentialEvapotranspiration(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("potential_evapotranspiration_cap", "cap ET0 to this value", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", 0.0, 0.0, 6.5, this));
        addVariable(FWSimVariable.createSimVariable("kc_factor", "crop coefficient ETc/ET0", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"dimensionless", 0.0, 0.0, 0.75, this));
        addVariable(FWSimVariable.createSimVariable("developmental_stage", "MONICA crop developmental stage", DATA_TYPE.INT, CONTENT_TYPE.input,"dimensionless", 0, 6, 0, this));
        addVariable(FWSimVariable.createSimVariable("crop_remaining_evapotranspiration", "crop remaining evapotranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("reference_evapotranspiration", "ET0 either from external ET0 or crop specific ET0", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("potential_evapotranspiration", "the potential evapotranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_potential_evapotranspiration_cap = potential_evapotranspiration_cap.getValue();
        double t_kc_factor = kc_factor.getValue();
        Integer t_developmental_stage = developmental_stage.getValue();
        double t_crop_remaining_evapotranspiration = crop_remaining_evapotranspiration.getValue();
        double t_reference_evapotranspiration = reference_evapotranspiration.getValue();
        double t_potential_evapotranspiration = potential_evapotranspiration.getDefault();
        if (t_developmental_stage > 0)
        {
            t_potential_evapotranspiration = t_crop_remaining_evapotranspiration;
        }
        else
        {
            t_potential_evapotranspiration = t_reference_evapotranspiration * t_kc_factor;
        }
        if (t_potential_evapotranspiration > t_potential_evapotranspiration_cap)
        {
            t_potential_evapotranspiration = t_potential_evapotranspiration_cap;
        }
        potential_evapotranspiration.setValue(t_potential_evapotranspiration, this);
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
        return new PotentialEvapotranspiration(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}