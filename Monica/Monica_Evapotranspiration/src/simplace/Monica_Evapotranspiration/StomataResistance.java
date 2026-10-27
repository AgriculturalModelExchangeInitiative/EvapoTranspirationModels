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


public class StomataResistance extends FWSimComponent
{
    private FWSimVariable<Double> saturation_beta;
    private FWSimVariable<Double> stomata_conductance_alpha;
    private FWSimVariable<Integer> carboxylation_pathway;
    private FWSimVariable<Double> atmospheric_co2_concentration;
    private FWSimVariable<Double> saturation_vapor_pressure_deficit;
    private FWSimVariable<Double> gross_photosynthesis_reference_mol;
    private FWSimVariable<Double> stomata_resistance;

    public StomataResistance(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public StomataResistance(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("saturation_beta", "Original: Yu et al. 2001; beta = 3.5", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0.0, 0.0, 2.5, this));
        addVariable(FWSimVariable.createSimVariable("stomata_conductance_alpha", "Original: Yu et al. 2001; alpha = 0.06 mol/m2/s", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mmol/m2/s", 0.0, 0.0, 40.0, this));
        addVariable(FWSimVariable.createSimVariable("carboxylation_pathway", "Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", 0, 2, 0, this));
        addVariable(FWSimVariable.createSimVariable("atmospheric_co2_concentration", "CO2 concentration in the atmosphere. Optional if no crop.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"ppm", 0.0, 0.0, 430.0, this));
        addVariable(FWSimVariable.createSimVariable("saturation_vapor_pressure_deficit", "saturation_vapor_pressure_deficit", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kPa", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("gross_photosynthesis_reference_mol", "gross_photosynthesis_reference_mol (-1 = not supplied = no crop)", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"[mol m-2 s-1] or [cm3 cm-2 s-1]", 0.0, 0.0, -1.0, this));
        addVariable(FWSimVariable.createSimVariable("stomata_resistance", "stomata resistance (FAO default value is 100)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"s/m", 0.0, 10000.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_saturation_beta = saturation_beta.getValue();
        double t_stomata_conductance_alpha = stomata_conductance_alpha.getValue();
        Integer t_carboxylation_pathway = carboxylation_pathway.getValue();
        double t_atmospheric_co2_concentration = atmospheric_co2_concentration.getValue();
        double t_saturation_vapor_pressure_deficit = saturation_vapor_pressure_deficit.getValue();
        double t_gross_photosynthesis_reference_mol = gross_photosynthesis_reference_mol.getValue();
        double t_stomata_resistance = stomata_resistance.getDefault();
        if (t_carboxylation_pathway > 0)
        {
            if (t_gross_photosynthesis_reference_mol <= 0.0d)
            {
                t_stomata_resistance = 999999.9d;
            }
            else if ( t_carboxylation_pathway == 1)
            {
                t_stomata_resistance = t_atmospheric_co2_concentration * (1.0d + (t_saturation_vapor_pressure_deficit / t_saturation_beta)) / (t_stomata_conductance_alpha * t_gross_photosynthesis_reference_mol);
            }
            else
            {
                t_stomata_resistance = t_atmospheric_co2_concentration * (1.0d + (t_saturation_vapor_pressure_deficit / t_saturation_beta)) / (t_stomata_conductance_alpha * t_gross_photosynthesis_reference_mol);
            }
        }
        stomata_resistance.setValue(t_stomata_resistance, this);
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
        return new StomataResistance(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}