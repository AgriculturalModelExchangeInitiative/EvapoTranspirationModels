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


public class Radiation extends FWSimComponent
{
    private FWSimVariable<Double> latitude;
    private FWSimVariable<Double> global_radiation;
    private FWSimVariable<Integer> julian_day;
    private FWSimVariable<Double> sunshine_hours;
    private FWSimVariable<Double> declination;
    private FWSimVariable<Double> astronomic_daylength;
    private FWSimVariable<Double> effective_daylength;
    private FWSimVariable<Double> photoperiodic_daylength;
    private FWSimVariable<Double> sunshine_hours_global_radiation;
    private FWSimVariable<Double> extraterrestrial_radiation;
    private FWSimVariable<Double> clear_day_radiation;
    private FWSimVariable<Double> overcast_day_radiation;
    private FWSimVariable<Double> phot_act_radiation_mean;

    public Radiation(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Radiation(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("latitude", "latitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"degree", -90.0, 90.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("global_radiation", "global radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2", 0.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("julian_day", "day of year", DATA_TYPE.INT, CONTENT_TYPE.input,"day", 1, 366, 1, this));
        addVariable(FWSimVariable.createSimVariable("sunshine_hours", "number of sunshine hours", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"h", 0.0, 24.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("declination", "declination", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("astronomic_daylength", "astronomic_daylength", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("effective_daylength", "effective_daylength", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("photoperiodic_daylength", "photoperiodic_daylength", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"mm", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("sunshine_hours_global_radiation", "global radiation calculated from sunshine hours", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ/m2", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("extraterrestrial_radiation", "extraterrestrial_radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ/m2", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("clear_day_radiation", "clear_day_radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ/m2", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("overcast_day_radiation", "overcast_day_radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"MJ/m2", 0.0, 0.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("phot_act_radiation_mean", "phot_act_radiation_mean", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"J/m2", 0.0, 0.0, 0.0, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        calc_declinations zz_calc_declinations;
        double t_latitude = latitude.getValue();
        double t_global_radiation = global_radiation.getValue();
        Integer t_julian_day = julian_day.getValue();
        double t_sunshine_hours = sunshine_hours.getValue();
        double t_declination = declination.getDefault();
        double t_astronomic_daylength = astronomic_daylength.getDefault();
        double t_effective_daylength = effective_daylength.getDefault();
        double t_photoperiodic_daylength = photoperiodic_daylength.getDefault();
        double t_sunshine_hours_global_radiation = sunshine_hours_global_radiation.getDefault();
        double t_extraterrestrial_radiation = extraterrestrial_radiation.getDefault();
        double t_clear_day_radiation = clear_day_radiation.getDefault();
        double t_overcast_day_radiation = overcast_day_radiation.getDefault();
        double t_phot_act_radiation_mean = phot_act_radiation_mean.getDefault();
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(t_latitude, t_julian_day);
        t_declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        t_astronomic_daylength = calc_astronomic_daylength(t_latitude, t_julian_day);
        t_effective_daylength = calc_effective_daylength(t_latitude, t_julian_day);
        t_photoperiodic_daylength = calc_photoperiodic_daylength(t_latitude, t_julian_day);
        double arg_phot_act;
        arg_phot_act = Math.min(1.0d, decl_sin / decl_cos * (decl_sin / decl_cos));
        t_phot_act_radiation_mean = 3600.0d * (decl_sin * t_astronomic_daylength + (24.0d / Math.PI * decl_cos * Math.sqrt((1.0d - arg_phot_act))));
        if (t_phot_act_radiation_mean > 0.0d && t_astronomic_daylength > 0.0d)
        {
            t_clear_day_radiation = 0.5d * 1300.0d * t_phot_act_radiation_mean * Math.exp(-0.14d / (t_phot_act_radiation_mean / (t_astronomic_daylength * 3600.0d)));
        }
        t_overcast_day_radiation = 0.2d * t_clear_day_radiation;
        double solar_constant;
        solar_constant = 0.082d;
        double SC;
        SC = 24.0d * 60.0d / Math.PI * solar_constant * (1.0d + (0.033d * Math.cos(2.0d * Math.PI * t_julian_day / 365.0d)));
        double solar_angle;
        solar_angle = -Math.tan((t_latitude * Math.PI / 180.0d)) * Math.tan(t_declination * Math.PI / 180.0d);
        solar_angle = bound(-1.0d, solar_angle, 1.0d);
        double sunset_solar_angle;
        sunset_solar_angle = Math.acos(solar_angle);
        t_extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin + (decl_cos * Math.sin(sunset_solar_angle)));
        if (t_sunshine_hours > 0.0d)
        {
            if (t_global_radiation <= 0.0d && t_astronomic_daylength > 0.0d)
            {
                t_sunshine_hours_global_radiation = t_extraterrestrial_radiation * (0.19d + (0.55d * t_sunshine_hours / t_astronomic_daylength));
            }
            else
            {
                t_sunshine_hours_global_radiation = 0.0d;
            }
        }
        declination.setValue(t_declination, this);
        astronomic_daylength.setValue(t_astronomic_daylength, this);
        effective_daylength.setValue(t_effective_daylength, this);
        photoperiodic_daylength.setValue(t_photoperiodic_daylength, this);
        sunshine_hours_global_radiation.setValue(t_sunshine_hours_global_radiation, this);
        extraterrestrial_radiation.setValue(t_extraterrestrial_radiation, this);
        clear_day_radiation.setValue(t_clear_day_radiation, this);
        overcast_day_radiation.setValue(t_overcast_day_radiation, this);
        phot_act_radiation_mean.setValue(t_phot_act_radiation_mean, this);
    }
    public static double bound(double lower, double value, double upper)
    {
        if (value < lower)
        {
            return lower;
        }
        if (value > upper)
        {
            return upper;
        }
        return value;
    }
    public calc_declinations Calculate_calc_declinations (double latitude, Integer julian_day)
    {
        double t_declination;
        declination = -23.4d * Math.cos(2.0d * Math.PI * ((julian_day + 10.0d) / 365.0d));
        double decl_sin;
        decl_sin = Math.sin(declination * Math.PI / 180.0d) * Math.sin(latitude * Math.PI / 180.0d);
        double decl_cos;
        decl_cos = Math.cos(declination * Math.PI / 180.0d) * Math.cos(latitude * Math.PI / 180.0d);
        return new calc_declinations(declination, decl_sin, decl_cos);
    }
    public static double calc_astronomic_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double t_declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double astro_daylength;
        astro_daylength = decl_sin / decl_cos;
        astro_daylength = bound(-1.0d, astro_daylength, 1.0d);
        double t_astronomic_daylength;
        astronomic_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(astro_daylength))) / Math.PI;
        return astronomic_daylength;
    }
    public static double calc_effective_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double t_declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double eff_daylength;
        eff_daylength = (-Math.sin((8.0d * Math.PI / 180.0d)) + decl_sin) / decl_cos;
        eff_daylength = bound(-1.0d, eff_daylength, 1.0d);
        double t_effective_daylength;
        effective_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(eff_daylength))) / Math.PI;
        return effective_daylength;
    }
    public static double calc_photoperiodic_daylength(double latitude, Integer julian_day)
    {
        calc_declinations zz_calc_declinations;
        double t_declination;
        double decl_sin;
        double decl_cos;
        zz_calc_declinations = Calculate_calc_declinations(latitude, julian_day);
        declination = zz_calc_declinations.getdeclination();
        decl_sin = zz_calc_declinations.getdecl_sin();
        decl_cos = zz_calc_declinations.getdecl_cos();
        double photo_daylength;
        photo_daylength = (-Math.sin((-6.0d * Math.PI / 180.0d)) + decl_sin) / decl_cos;
        photo_daylength = bound(-1.0d, photo_daylength, 1.0d);
        double t_photoperiodic_daylength;
        photoperiodic_daylength = 12.0d * (Math.PI + (2.0d * Math.asin(photo_daylength))) / Math.PI;
        return photoperiodic_daylength;
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
        return new Radiation(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}
final class calc_declinations {
    private double declination;
    public double getdeclination()
    { return declination; }

    public void setdeclination(double _declination)
    { this.declination= _declination; } 
    
    private double decl_sin;
    public double getdecl_sin()
    { return decl_sin; }

    public void setdecl_sin(double _decl_sin)
    { this.decl_sin= _decl_sin; } 
    
    private double decl_cos;
    public double getdecl_cos()
    { return decl_cos; }

    public void setdecl_cos(double _decl_cos)
    { this.decl_cos= _decl_cos; } 
    
    public calc_declinations(double declination,double decl_sin,double decl_cos)
    {
        this.declination = declination;
        this.decl_sin = decl_sin;
        this.decl_cos = decl_cos;
    }
}