using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the ET component
/// </summary>
public class ETAuxiliary
{
    private bool _use_external_vapor_pressure;
    private double _external_vapor_pressure;
    private bool _calc_stomata_resistance;
    private double _fixed_stomata_resistance;
    private double _gross_photosynthesis_reference_mol;
    private double _stomata_resistance;
    private double _net_radiation;
    private bool _use_external_et0;
    private double _external_et0;
    private double _declination;
    private double _astronomic_daylength;
    private double _effective_daylength;
    private double _photoperiodic_daylength;
    private double _sunshine_hours_global_radiation;
    private double _extraterrestrial_radiation;
    private double _clear_day_radiation;
    private double _overcast_day_radiation;
    private double _phot_act_radiation_mean;
    private double _reference_evapotranspiration;
    private double _potential_evapotranspiration;
    private double _vapor_pressure;
    private double _internal_vapor_pressure;
    private double _internal_et0;
    private double _saturated_vapor_pressure;
    private double _saturation_vapor_pressure_deficit;
    private double _calculated_stomata_resistance;
    private double _et0;

    /// <summary>
    /// Constructor ETAuxiliary domain class
    /// </summary>
    public ETAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public ETAuxiliary(ETAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            use_external_vapor_pressure = toCopy.use_external_vapor_pressure;
            external_vapor_pressure = toCopy.external_vapor_pressure;
            calc_stomata_resistance = toCopy.calc_stomata_resistance;
            fixed_stomata_resistance = toCopy.fixed_stomata_resistance;
            gross_photosynthesis_reference_mol = toCopy.gross_photosynthesis_reference_mol;
            stomata_resistance = toCopy.stomata_resistance;
            net_radiation = toCopy.net_radiation;
            use_external_et0 = toCopy.use_external_et0;
            external_et0 = toCopy.external_et0;
            declination = toCopy.declination;
            astronomic_daylength = toCopy.astronomic_daylength;
            effective_daylength = toCopy.effective_daylength;
            photoperiodic_daylength = toCopy.photoperiodic_daylength;
            sunshine_hours_global_radiation = toCopy.sunshine_hours_global_radiation;
            extraterrestrial_radiation = toCopy.extraterrestrial_radiation;
            clear_day_radiation = toCopy.clear_day_radiation;
            overcast_day_radiation = toCopy.overcast_day_radiation;
            phot_act_radiation_mean = toCopy.phot_act_radiation_mean;
            reference_evapotranspiration = toCopy.reference_evapotranspiration;
            potential_evapotranspiration = toCopy.potential_evapotranspiration;
            vapor_pressure = toCopy.vapor_pressure;
            internal_vapor_pressure = toCopy.internal_vapor_pressure;
            internal_et0 = toCopy.internal_et0;
            saturated_vapor_pressure = toCopy.saturated_vapor_pressure;
            saturation_vapor_pressure_deficit = toCopy.saturation_vapor_pressure_deficit;
            calculated_stomata_resistance = toCopy.calculated_stomata_resistance;
            et0 = toCopy.et0;
        }
    }

    /// <summary>
    /// Gets and sets the boolean condition to be met
    /// </summary>
    [Description("boolean condition to be met")] 
    [Units("mm")] 
    public bool use_external_vapor_pressure
    {
        get { return this._use_external_vapor_pressure; }
        set { this._use_external_vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is true
    /// </summary>
    [Description("value to be returned if condition is true")] 
    [Units("kPa")] 
    public double external_vapor_pressure
    {
        get { return this._external_vapor_pressure; }
        set { this._external_vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the boolean condition to be met
    /// </summary>
    [Description("boolean condition to be met")] 
    [Units("")] 
    public bool calc_stomata_resistance
    {
        get { return this._calc_stomata_resistance; }
        set { this._calc_stomata_resistance= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is false
    /// </summary>
    [Description("value to be returned if condition is false")] 
    [Units("s/m")] 
    public double fixed_stomata_resistance
    {
        get { return this._fixed_stomata_resistance; }
        set { this._fixed_stomata_resistance= value; } 
    }

    /// <summary>
    /// Gets and sets the gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
    /// </summary>
    [Description("gross_photosynthesis_reference_mol (-1 = not supplied = no crop)")] 
    [Units("[mol m-2 s-1] or [cm3 cm-2 s-1]")] 
    public double gross_photosynthesis_reference_mol
    {
        get { return this._gross_photosynthesis_reference_mol; }
        set { this._gross_photosynthesis_reference_mol= value; } 
    }

    /// <summary>
    /// Gets and sets the stomata resistance (FAO default value is 100)
    /// </summary>
    [Description("stomata resistance (FAO default value is 100)")] 
    [Units("s/m")] 
    public double stomata_resistance
    {
        get { return this._stomata_resistance; }
        set { this._stomata_resistance= value; } 
    }

    /// <summary>
    /// Gets and sets the net radiation
    /// </summary>
    [Description("net radiation")] 
    [Units("MJ/m2")] 
    public double net_radiation
    {
        get { return this._net_radiation; }
        set { this._net_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the boolean condition to be met
    /// </summary>
    [Description("boolean condition to be met")] 
    [Units("")] 
    public bool use_external_et0
    {
        get { return this._use_external_et0; }
        set { this._use_external_et0= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is true
    /// </summary>
    [Description("value to be returned if condition is true")] 
    [Units("mm")] 
    public double external_et0
    {
        get { return this._external_et0; }
        set { this._external_et0= value; } 
    }

    /// <summary>
    /// Gets and sets the declination
    /// </summary>
    [Description("declination")] 
    [Units("")] 
    public double declination
    {
        get { return this._declination; }
        set { this._declination= value; } 
    }

    /// <summary>
    /// Gets and sets the astronomic_daylength
    /// </summary>
    [Description("astronomic_daylength")] 
    [Units("mm")] 
    public double astronomic_daylength
    {
        get { return this._astronomic_daylength; }
        set { this._astronomic_daylength= value; } 
    }

    /// <summary>
    /// Gets and sets the effective_daylength
    /// </summary>
    [Description("effective_daylength")] 
    [Units("mm")] 
    public double effective_daylength
    {
        get { return this._effective_daylength; }
        set { this._effective_daylength= value; } 
    }

    /// <summary>
    /// Gets and sets the photoperiodic_daylength
    /// </summary>
    [Description("photoperiodic_daylength")] 
    [Units("mm")] 
    public double photoperiodic_daylength
    {
        get { return this._photoperiodic_daylength; }
        set { this._photoperiodic_daylength= value; } 
    }

    /// <summary>
    /// Gets and sets the global radiation calculated from sunshine hours
    /// </summary>
    [Description("global radiation calculated from sunshine hours")] 
    [Units("MJ/m2")] 
    public double sunshine_hours_global_radiation
    {
        get { return this._sunshine_hours_global_radiation; }
        set { this._sunshine_hours_global_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the extraterrestrial_radiation
    /// </summary>
    [Description("extraterrestrial_radiation")] 
    [Units("MJ/m2")] 
    public double extraterrestrial_radiation
    {
        get { return this._extraterrestrial_radiation; }
        set { this._extraterrestrial_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the clear_day_radiation
    /// </summary>
    [Description("clear_day_radiation")] 
    [Units("MJ/m2")] 
    public double clear_day_radiation
    {
        get { return this._clear_day_radiation; }
        set { this._clear_day_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the overcast_day_radiation
    /// </summary>
    [Description("overcast_day_radiation")] 
    [Units("MJ/m2")] 
    public double overcast_day_radiation
    {
        get { return this._overcast_day_radiation; }
        set { this._overcast_day_radiation= value; } 
    }

    /// <summary>
    /// Gets and sets the phot_act_radiation_mean
    /// </summary>
    [Description("phot_act_radiation_mean")] 
    [Units("J/m2")] 
    public double phot_act_radiation_mean
    {
        get { return this._phot_act_radiation_mean; }
        set { this._phot_act_radiation_mean= value; } 
    }

    /// <summary>
    /// Gets and sets the reference evapotranspiration (ET0)
    /// </summary>
    [Description("reference evapotranspiration (ET0)")] 
    [Units("mm")] 
    public double reference_evapotranspiration
    {
        get { return this._reference_evapotranspiration; }
        set { this._reference_evapotranspiration= value; } 
    }

    /// <summary>
    /// Gets and sets the the potential evapotranspiration
    /// </summary>
    [Description("the potential evapotranspiration")] 
    [Units("mm")] 
    public double potential_evapotranspiration
    {
        get { return this._potential_evapotranspiration; }
        set { this._potential_evapotranspiration= value; } 
    }

    /// <summary>
    /// Gets and sets the vapor pressure from relative humidity and saturated vapor pressure
    /// </summary>
    [Description("vapor pressure from relative humidity and saturated vapor pressure")] 
    [Units("kPa")] 
    public double vapor_pressure
    {
        get { return this._vapor_pressure; }
        set { this._vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is false
    /// </summary>
    [Description("value to be returned if condition is false")] 
    [Units("kPa")] 
    public double internal_vapor_pressure
    {
        get { return this._internal_vapor_pressure; }
        set { this._internal_vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is false
    /// </summary>
    [Description("value to be returned if condition is false")] 
    [Units("mm")] 
    public double internal_et0
    {
        get { return this._internal_et0; }
        set { this._internal_et0= value; } 
    }

    /// <summary>
    /// Gets and sets the saturated vapor pressure
    /// </summary>
    [Description("saturated vapor pressure")] 
    [Units("kPa")] 
    public double saturated_vapor_pressure
    {
        get { return this._saturated_vapor_pressure; }
        set { this._saturated_vapor_pressure= value; } 
    }

    /// <summary>
    /// Gets and sets the saturation vapor pressure deficit
    /// </summary>
    [Description("saturation vapor pressure deficit")] 
    [Units("kPa")] 
    public double saturation_vapor_pressure_deficit
    {
        get { return this._saturation_vapor_pressure_deficit; }
        set { this._saturation_vapor_pressure_deficit= value; } 
    }

    /// <summary>
    /// Gets and sets the value to be returned if condition is true
    /// </summary>
    [Description("value to be returned if condition is true")] 
    [Units("s/m")] 
    public double calculated_stomata_resistance
    {
        get { return this._calculated_stomata_resistance; }
        set { this._calculated_stomata_resistance= value; } 
    }

    /// <summary>
    /// Gets and sets the the output value
    /// </summary>
    [Description("the output value")] 
    [Units("mm")] 
    public double et0
    {
        get { return this._et0; }
        set { this._et0= value; } 
    }

}