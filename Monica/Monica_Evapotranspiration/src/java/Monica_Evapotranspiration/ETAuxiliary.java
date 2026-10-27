import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class ETAuxiliary
{
    private Boolean use_external_vapor_pressure;
    private double external_vapor_pressure;
    private Boolean calc_stomata_resistance;
    private double fixed_stomata_resistance;
    private double gross_photosynthesis_reference_mol;
    private double stomata_resistance;
    private double net_radiation;
    private Boolean use_external_et0;
    private double external_et0;
    private double declination;
    private double astronomic_daylength;
    private double effective_daylength;
    private double photoperiodic_daylength;
    private double sunshine_hours_global_radiation;
    private double extraterrestrial_radiation;
    private double clear_day_radiation;
    private double overcast_day_radiation;
    private double phot_act_radiation_mean;
    private double reference_evapotranspiration;
    private double potential_evapotranspiration;
    private double vapor_pressure;
    private double internal_vapor_pressure;
    private double internal_et0;
    private double saturated_vapor_pressure;
    private double saturation_vapor_pressure_deficit;
    private double calculated_stomata_resistance;
    private double et0;
    
    public ETAuxiliary() { }
    
    public ETAuxiliary(ETAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.use_external_vapor_pressure = toCopy.getuse_external_vapor_pressure();
            this.external_vapor_pressure = toCopy.getexternal_vapor_pressure();
            this.calc_stomata_resistance = toCopy.getcalc_stomata_resistance();
            this.fixed_stomata_resistance = toCopy.getfixed_stomata_resistance();
            this.gross_photosynthesis_reference_mol = toCopy.getgross_photosynthesis_reference_mol();
            this.stomata_resistance = toCopy.getstomata_resistance();
            this.net_radiation = toCopy.getnet_radiation();
            this.use_external_et0 = toCopy.getuse_external_et0();
            this.external_et0 = toCopy.getexternal_et0();
            this.declination = toCopy.getdeclination();
            this.astronomic_daylength = toCopy.getastronomic_daylength();
            this.effective_daylength = toCopy.geteffective_daylength();
            this.photoperiodic_daylength = toCopy.getphotoperiodic_daylength();
            this.sunshine_hours_global_radiation = toCopy.getsunshine_hours_global_radiation();
            this.extraterrestrial_radiation = toCopy.getextraterrestrial_radiation();
            this.clear_day_radiation = toCopy.getclear_day_radiation();
            this.overcast_day_radiation = toCopy.getovercast_day_radiation();
            this.phot_act_radiation_mean = toCopy.getphot_act_radiation_mean();
            this.reference_evapotranspiration = toCopy.getreference_evapotranspiration();
            this.potential_evapotranspiration = toCopy.getpotential_evapotranspiration();
            this.vapor_pressure = toCopy.getvapor_pressure();
            this.internal_vapor_pressure = toCopy.getinternal_vapor_pressure();
            this.reference_evapotranspiration = toCopy.getreference_evapotranspiration();
            this.internal_et0 = toCopy.getinternal_et0();
            this.extraterrestrial_radiation = toCopy.getextraterrestrial_radiation();
            this.saturated_vapor_pressure = toCopy.getsaturated_vapor_pressure();
            this.saturation_vapor_pressure_deficit = toCopy.getsaturation_vapor_pressure_deficit();
            this.stomata_resistance = toCopy.getstomata_resistance();
            this.calculated_stomata_resistance = toCopy.getcalculated_stomata_resistance();
            this.net_radiation = toCopy.getnet_radiation();
            this.et0 = toCopy.getet0();
            this.potential_evapotranspiration = toCopy.getpotential_evapotranspiration();
        }
    }
    public Boolean getuse_external_vapor_pressure()
    { return use_external_vapor_pressure; }

    public void setuse_external_vapor_pressure(Boolean _use_external_vapor_pressure)
    { this.use_external_vapor_pressure= _use_external_vapor_pressure; } 
    
    public double getexternal_vapor_pressure()
    { return external_vapor_pressure; }

    public void setexternal_vapor_pressure(double _external_vapor_pressure)
    { this.external_vapor_pressure= _external_vapor_pressure; } 
    
    public Boolean getcalc_stomata_resistance()
    { return calc_stomata_resistance; }

    public void setcalc_stomata_resistance(Boolean _calc_stomata_resistance)
    { this.calc_stomata_resistance= _calc_stomata_resistance; } 
    
    public double getfixed_stomata_resistance()
    { return fixed_stomata_resistance; }

    public void setfixed_stomata_resistance(double _fixed_stomata_resistance)
    { this.fixed_stomata_resistance= _fixed_stomata_resistance; } 
    
    public double getgross_photosynthesis_reference_mol()
    { return gross_photosynthesis_reference_mol; }

    public void setgross_photosynthesis_reference_mol(double _gross_photosynthesis_reference_mol)
    { this.gross_photosynthesis_reference_mol= _gross_photosynthesis_reference_mol; } 
    
    public double getstomata_resistance()
    { return stomata_resistance; }

    public void setstomata_resistance(double _stomata_resistance)
    { this.stomata_resistance= _stomata_resistance; } 
    
    public double getnet_radiation()
    { return net_radiation; }

    public void setnet_radiation(double _net_radiation)
    { this.net_radiation= _net_radiation; } 
    
    public Boolean getuse_external_et0()
    { return use_external_et0; }

    public void setuse_external_et0(Boolean _use_external_et0)
    { this.use_external_et0= _use_external_et0; } 
    
    public double getexternal_et0()
    { return external_et0; }

    public void setexternal_et0(double _external_et0)
    { this.external_et0= _external_et0; } 
    
    public double getdeclination()
    { return declination; }

    public void setdeclination(double _declination)
    { this.declination= _declination; } 
    
    public double getastronomic_daylength()
    { return astronomic_daylength; }

    public void setastronomic_daylength(double _astronomic_daylength)
    { this.astronomic_daylength= _astronomic_daylength; } 
    
    public double geteffective_daylength()
    { return effective_daylength; }

    public void seteffective_daylength(double _effective_daylength)
    { this.effective_daylength= _effective_daylength; } 
    
    public double getphotoperiodic_daylength()
    { return photoperiodic_daylength; }

    public void setphotoperiodic_daylength(double _photoperiodic_daylength)
    { this.photoperiodic_daylength= _photoperiodic_daylength; } 
    
    public double getsunshine_hours_global_radiation()
    { return sunshine_hours_global_radiation; }

    public void setsunshine_hours_global_radiation(double _sunshine_hours_global_radiation)
    { this.sunshine_hours_global_radiation= _sunshine_hours_global_radiation; } 
    
    public double getextraterrestrial_radiation()
    { return extraterrestrial_radiation; }

    public void setextraterrestrial_radiation(double _extraterrestrial_radiation)
    { this.extraterrestrial_radiation= _extraterrestrial_radiation; } 
    
    public double getclear_day_radiation()
    { return clear_day_radiation; }

    public void setclear_day_radiation(double _clear_day_radiation)
    { this.clear_day_radiation= _clear_day_radiation; } 
    
    public double getovercast_day_radiation()
    { return overcast_day_radiation; }

    public void setovercast_day_radiation(double _overcast_day_radiation)
    { this.overcast_day_radiation= _overcast_day_radiation; } 
    
    public double getphot_act_radiation_mean()
    { return phot_act_radiation_mean; }

    public void setphot_act_radiation_mean(double _phot_act_radiation_mean)
    { this.phot_act_radiation_mean= _phot_act_radiation_mean; } 
    
    public double getreference_evapotranspiration()
    { return reference_evapotranspiration; }

    public void setreference_evapotranspiration(double _reference_evapotranspiration)
    { this.reference_evapotranspiration= _reference_evapotranspiration; } 
    
    public double getpotential_evapotranspiration()
    { return potential_evapotranspiration; }

    public void setpotential_evapotranspiration(double _potential_evapotranspiration)
    { this.potential_evapotranspiration= _potential_evapotranspiration; } 
    
    public double getvapor_pressure()
    { return vapor_pressure; }

    public void setvapor_pressure(double _vapor_pressure)
    { this.vapor_pressure= _vapor_pressure; } 
    
    public double getinternal_vapor_pressure()
    { return internal_vapor_pressure; }

    public void setinternal_vapor_pressure(double _internal_vapor_pressure)
    { this.internal_vapor_pressure= _internal_vapor_pressure; } 
    
    public double getinternal_et0()
    { return internal_et0; }

    public void setinternal_et0(double _internal_et0)
    { this.internal_et0= _internal_et0; } 
    
    public double getsaturated_vapor_pressure()
    { return saturated_vapor_pressure; }

    public void setsaturated_vapor_pressure(double _saturated_vapor_pressure)
    { this.saturated_vapor_pressure= _saturated_vapor_pressure; } 
    
    public double getsaturation_vapor_pressure_deficit()
    { return saturation_vapor_pressure_deficit; }

    public void setsaturation_vapor_pressure_deficit(double _saturation_vapor_pressure_deficit)
    { this.saturation_vapor_pressure_deficit= _saturation_vapor_pressure_deficit; } 
    
    public double getcalculated_stomata_resistance()
    { return calculated_stomata_resistance; }

    public void setcalculated_stomata_resistance(double _calculated_stomata_resistance)
    { this.calculated_stomata_resistance= _calculated_stomata_resistance; } 
    
    public double getet0()
    { return et0; }

    public void setet0(double _et0)
    { this.et0= _et0; } 
    
}