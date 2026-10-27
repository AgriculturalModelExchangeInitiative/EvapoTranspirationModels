using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_ET.DomainClass;
using Crop2ML_ET.Strategies;

namespace Model.Model.ET
{
    class ETWrapper :  UniverseLink
    {
        private ETState s;
        private ETState s1;
        private ETRate r;
        private ETAuxiliary a;
        private ETExogenous ex;
        private ETComponent etComponent;

        public ETWrapper(Universe universe) : base(universe)
        {
            s = new ETState();
            r = new ETRate();
            a = new ETAuxiliary();
            ex = new ETExogenous();
            etComponent = new ET();
            loadParameters();
        }

        public double declination{ get { return a.declination;}} 
     
        public double astronomic_daylength{ get { return a.astronomic_daylength;}} 
     
        public double effective_daylength{ get { return a.effective_daylength;}} 
     
        public double photoperiodic_daylength{ get { return a.photoperiodic_daylength;}} 
     
        public double sunshine_hours_global_radiation{ get { return a.sunshine_hours_global_radiation;}} 
     
        public double extraterrestrial_radiation{ get { return a.extraterrestrial_radiation;}} 
     
        public double clear_day_radiation{ get { return a.clear_day_radiation;}} 
     
        public double overcast_day_radiation{ get { return a.overcast_day_radiation;}} 
     
        public double phot_act_radiation_mean{ get { return a.phot_act_radiation_mean;}} 
     
        public double reference_evapotranspiration{ get { return a.reference_evapotranspiration;}} 
     
        public double potential_evapotranspiration{ get { return a.potential_evapotranspiration;}} 
     

        public ETWrapper(Universe universe, ETWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new ETState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new ETRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new ETAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new ETExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                etComponent = (toCopy.etComponent != null) ? new ET(toCopy.etComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            etComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            etComponent.latitude = 0; 
            etComponent.reference_albedo = 0; 
            etComponent.height_nn = 0; 
            etComponent.saturation_beta = 2.5; 
            etComponent.stomata_conductance_alpha = 40; 
            etComponent.carboxylation_pathway = 0; 
            etComponent.evaporation_zeta = 40; 
            etComponent.maximum_evaporation_impact_depth = 5; 
            etComponent.evaporation_reduction_method = 1; 
            etComponent.xsa_critical_soil_moisture = 0.1; 
            etComponent.no_of_soil_layers = 20; 
            etComponent.no_of_soil_moisture_layers = 21; 
            etComponent.layer_thickness = null; // To be modified
            etComponent.permanent_wilting_point = null; // To be modified
            etComponent.field_capacity = null; // To be modified
        }

        public void EstimateET(bool use_external_vapor_pressure, double external_vapor_pressure, bool calc_stomata_resistance, double fixed_stomata_resistance, double gross_photosynthesis_reference_mol, bool use_external_et0, double external_et0, double internal_vapor_pressure, double internal_et0, double calculated_stomata_resistance, double global_radiation, int julian_day, double sunshine_hours, double max_air_temperature, double min_air_temperature, double relative_humidity, double atmospheric_co2_concentration, double mean_air_temperature, double wind_speed, double wind_speed_height, double kc_factor, int developmental_stage, double crop_remaining_evapotranspiration, bool has_snow_cover, double[] crop_transpiration, double crop_evaporated_from_intercepted, double percentage_soil_coverage)
        {
            a.use_external_vapor_pressure = use_external_vapor_pressure;
            a.external_vapor_pressure = external_vapor_pressure;
            a.calc_stomata_resistance = calc_stomata_resistance;
            a.fixed_stomata_resistance = fixed_stomata_resistance;
            a.gross_photosynthesis_reference_mol = gross_photosynthesis_reference_mol;
            a.use_external_et0 = use_external_et0;
            a.external_et0 = external_et0;
            a.internal_vapor_pressure = internal_vapor_pressure;
            a.internal_et0 = internal_et0;
            a.calculated_stomata_resistance = calculated_stomata_resistance;
            ex.global_radiation = global_radiation;
            ex.julian_day = julian_day;
            ex.sunshine_hours = sunshine_hours;
            ex.max_air_temperature = max_air_temperature;
            ex.min_air_temperature = min_air_temperature;
            ex.relative_humidity = relative_humidity;
            ex.atmospheric_co2_concentration = atmospheric_co2_concentration;
            ex.mean_air_temperature = mean_air_temperature;
            ex.wind_speed = wind_speed;
            ex.wind_speed_height = wind_speed_height;
            ex.kc_factor = kc_factor;
            ex.developmental_stage = developmental_stage;
            ex.crop_remaining_evapotranspiration = crop_remaining_evapotranspiration;
            ex.has_snow_cover = has_snow_cover;
            ex.crop_transpiration = crop_transpiration;
            ex.crop_evaporated_from_intercepted = crop_evaporated_from_intercepted;
            ex.percentage_soil_coverage = percentage_soil_coverage;
            etComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}