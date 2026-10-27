
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       

using SiriusQualityET.DomainClass;
namespace SiriusQualityET.Strategies
{
    public class ETComponent : IStrategySiriusQualityET
    {
        public ETComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_Radiation, "latitude");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_NetRadiation, "reference_albedo");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_NetRadiation, "height_nn");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_ReferenceEvapotranspiration, "height_nn");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_StomataResistance, "saturation_beta");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_StomataResistance, "stomata_conductance_alpha");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_StomataResistance, "carboxylation_pathway");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_Evapotranspiration, "evaporation_zeta");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_Evapotranspiration, "maximum_evaporation_impact_depth");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_Evapotranspiration, "evaporation_reduction_method");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_Evapotranspiration, "xsa_critical_soil_moisture");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_Evapotranspiration, "no_of_soil_layers");
            _parameters0_0.Add(v12);
            VarInfo v13 = new CompositeStrategyVarInfo(_Evapotranspiration, "no_of_soil_moisture_layers");
            _parameters0_0.Add(v13);
            VarInfo v14 = new CompositeStrategyVarInfo(_Evapotranspiration, "layer_thickness");
            _parameters0_0.Add(v14);
            VarInfo v15 = new CompositeStrategyVarInfo(_Evapotranspiration, "permanent_wilting_point");
            _parameters0_0.Add(v15);
            VarInfo v16 = new CompositeStrategyVarInfo(_Evapotranspiration, "field_capacity");
            _parameters0_0.Add(v16);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd1.PropertyName = "global_radiation";
            pd1.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd2.PropertyName = "julian_day";
            pd2.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd3.PropertyName = "sunshine_hours";
            pd3.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd4.PropertyName = "max_air_temperature";
            pd4.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.max_air_temperature).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.max_air_temperature);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd5.PropertyName = "min_air_temperature";
            pd5.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.min_air_temperature).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.min_air_temperature);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd6.PropertyName = "use_external_vapor_pressure";
            pd6.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_vapor_pressure).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_vapor_pressure);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd7.PropertyName = "external_vapor_pressure";
            pd7.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_vapor_pressure).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_vapor_pressure);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd8.PropertyName = "relative_humidity";
            pd8.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.relative_humidity).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.relative_humidity);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd9.PropertyName = "calc_stomata_resistance";
            pd9.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd10.PropertyName = "fixed_stomata_resistance";
            pd10.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd11.PropertyName = "gross_photosynthesis_reference_mol";
            pd11.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd12.PropertyName = "atmospheric_co2_concentration";
            pd12.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd13.PropertyName = "mean_air_temperature";
            pd13.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.mean_air_temperature).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.mean_air_temperature);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd14.PropertyName = "wind_speed";
            pd14.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd15.PropertyName = "wind_speed_height";
            pd15.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed_height).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed_height);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd16.PropertyName = "stomata_resistance";
            pd16.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd17.PropertyName = "net_radiation";
            pd17.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.net_radiation).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd18.PropertyName = "kc_factor";
            pd18.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.kc_factor).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.kc_factor);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd19.PropertyName = "developmental_stage";
            pd19.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.developmental_stage).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.developmental_stage);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd20.PropertyName = "crop_remaining_evapotranspiration";
            pd20.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_remaining_evapotranspiration).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_remaining_evapotranspiration);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd21.PropertyName = "has_snow_cover";
            pd21.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.has_snow_cover).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.has_snow_cover);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd22.PropertyName = "crop_transpiration";
            pd22.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_transpiration).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_transpiration);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd23.PropertyName = "crop_evaporated_from_intercepted";
            pd23.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SiriusQualityET.DomainClass.ETExogenous);
            pd24.PropertyName = "percentage_soil_coverage";
            pd24.PropertyType = (SiriusQualityET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SiriusQualityET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd25.PropertyName = "surface_water_storage";
            pd25.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.surface_water_storage).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.surface_water_storage);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd26.PropertyName = "evaporated_from_surface";
            pd26.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.evaporated_from_surface).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.evaporated_from_surface);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd27.PropertyName = "actual_evaporation";
            pd27.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.actual_evaporation).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.actual_evaporation);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd28.PropertyName = "actual_transpiration";
            pd28.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.actual_transpiration).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.actual_transpiration);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd29.PropertyName = "soil_moisture";
            pd29.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.soil_moisture).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.soil_moisture);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd30.PropertyName = "evaporation";
            pd30.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.evaporation).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.evaporation);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd31.PropertyName = "transpiration";
            pd31.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.transpiration).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.transpiration);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd32.PropertyName = "evapotranspiration";
            pd32.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.evapotranspiration).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.evapotranspiration);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(SiriusQualityET.DomainClass.ETState);
            pd33.PropertyName = "actual_evapotranspiration";
            pd33.PropertyType = (SiriusQualityET.DomainClass.ETStateVarInfo.actual_evapotranspiration).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(SiriusQualityET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd34.PropertyName = "use_external_et0";
            pd34.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd35.PropertyName = "external_et0";
            pd35.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0);
            _inputs0_0.Add(pd35);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd36.PropertyName = "declination";
            pd36.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination);
            _outputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd37.PropertyName = "astronomic_daylength";
            pd37.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength);
            _outputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd38.PropertyName = "effective_daylength";
            pd38.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength);
            _outputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd39.PropertyName = "photoperiodic_daylength";
            pd39.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength);
            _outputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd40.PropertyName = "sunshine_hours_global_radiation";
            pd40.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation);
            _outputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd41.PropertyName = "extraterrestrial_radiation";
            pd41.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
            _outputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd42.PropertyName = "clear_day_radiation";
            pd42.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation);
            _outputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd43.PropertyName = "overcast_day_radiation";
            pd43.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation);
            _outputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd44.PropertyName = "phot_act_radiation_mean";
            pd44.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean);
            _outputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd45.PropertyName = "reference_evapotranspiration";
            pd45.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration);
            _outputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(SiriusQualityET.DomainClass.ETAuxiliary);
            pd46.PropertyName = "potential_evapotranspiration";
            pd46.PropertyType = (SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration);
            _outputs0_0.Add(pd46);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.Radiation).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.NetRadiation).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.StomataResistance).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.CalcStomataResistance).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.SaturatedVaporPressure).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.SaturationVaporPressureDeficit).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.ReferenceEvapotranspiration).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.PotentialEvapotranspiration).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.Evapotranspiration).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.UseExtET0).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualityET.Strategies.UseExtVaporPressure).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "ZALF e.V. "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualityET.DomainClass.ETState), typeof(SiriusQualityET.DomainClass.ETState), typeof(SiriusQualityET.DomainClass.ETRate), typeof(SiriusQualityET.DomainClass.ETAuxiliary), typeof(SiriusQualityET.DomainClass.ETExogenous)};
        }

        public double latitude
        {
            get
            {
                 return _Radiation.latitude; 
            }
            set
            {
                _Radiation.latitude = value;
            }
        }
        public double reference_albedo
        {
            get
            {
                 return _NetRadiation.reference_albedo; 
            }
            set
            {
                _NetRadiation.reference_albedo = value;
            }
        }
        public double height_nn
        {
            get
            {
                 return _NetRadiation.height_nn; 
            }
            set
            {
                _NetRadiation.height_nn = value;
                _ReferenceEvapotranspiration.height_nn = value;
            }
        }
        public double saturation_beta
        {
            get
            {
                 return _StomataResistance.saturation_beta; 
            }
            set
            {
                _StomataResistance.saturation_beta = value;
            }
        }
        public double stomata_conductance_alpha
        {
            get
            {
                 return _StomataResistance.stomata_conductance_alpha; 
            }
            set
            {
                _StomataResistance.stomata_conductance_alpha = value;
            }
        }
        public int carboxylation_pathway
        {
            get
            {
                 return _StomataResistance.carboxylation_pathway; 
            }
            set
            {
                _StomataResistance.carboxylation_pathway = value;
            }
        }
        public double evaporation_zeta
        {
            get
            {
                 return _Evapotranspiration.evaporation_zeta; 
            }
            set
            {
                _Evapotranspiration.evaporation_zeta = value;
            }
        }
        public double maximum_evaporation_impact_depth
        {
            get
            {
                 return _Evapotranspiration.maximum_evaporation_impact_depth; 
            }
            set
            {
                _Evapotranspiration.maximum_evaporation_impact_depth = value;
            }
        }
        public int evaporation_reduction_method
        {
            get
            {
                 return _Evapotranspiration.evaporation_reduction_method; 
            }
            set
            {
                _Evapotranspiration.evaporation_reduction_method = value;
            }
        }
        public double xsa_critical_soil_moisture
        {
            get
            {
                 return _Evapotranspiration.xsa_critical_soil_moisture; 
            }
            set
            {
                _Evapotranspiration.xsa_critical_soil_moisture = value;
            }
        }
        public int no_of_soil_layers
        {
            get
            {
                 return _Evapotranspiration.no_of_soil_layers; 
            }
            set
            {
                _Evapotranspiration.no_of_soil_layers = value;
            }
        }
        public int no_of_soil_moisture_layers
        {
            get
            {
                 return _Evapotranspiration.no_of_soil_moisture_layers; 
            }
            set
            {
                _Evapotranspiration.no_of_soil_moisture_layers = value;
            }
        }
        public double[] layer_thickness
        {
            get
            {
                 return _Evapotranspiration.layer_thickness; 
            }
            set
            {
                _Evapotranspiration.layer_thickness = value;
            }
        }
        public double[] permanent_wilting_point
        {
            get
            {
                 return _Evapotranspiration.permanent_wilting_point; 
            }
            set
            {
                _Evapotranspiration.permanent_wilting_point = value;
            }
        }
        public double[] field_capacity
        {
            get
            {
                 return _Evapotranspiration.field_capacity; 
            }
            set
            {
                _Evapotranspiration.field_capacity = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _Radiation.SetParametersDefaultValue();
            _NetRadiation.SetParametersDefaultValue();
            _StomataResistance.SetParametersDefaultValue();
            _CalcStomataResistance.SetParametersDefaultValue();
            _SaturatedVaporPressure.SetParametersDefaultValue();
            _SaturationVaporPressureDeficit.SetParametersDefaultValue();
            _ReferenceEvapotranspiration.SetParametersDefaultValue();
            _PotentialEvapotranspiration.SetParametersDefaultValue();
            _Evapotranspiration.SetParametersDefaultValue();
            _UseExtET0.SetParametersDefaultValue();
            _UseExtVaporPressure.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            latitudeVarInfo.Name = "latitude";
            latitudeVarInfo.Description = "latitude";
            latitudeVarInfo.MaxValue = 90;
            latitudeVarInfo.MinValue = -90;
            latitudeVarInfo.DefaultValue = 0;
            latitudeVarInfo.Units = "degree";
            latitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            reference_albedoVarInfo.Name = "reference_albedo";
            reference_albedoVarInfo.Description = "reference albedo";
            reference_albedoVarInfo.MaxValue = 1;
            reference_albedoVarInfo.MinValue = 0;
            reference_albedoVarInfo.DefaultValue = 0;
            reference_albedoVarInfo.Units = "dimensionless";
            reference_albedoVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            height_nnVarInfo.Name = "height_nn";
            height_nnVarInfo.Description = "height above sea level";
            height_nnVarInfo.MaxValue = 9999;
            height_nnVarInfo.MinValue = -9999;
            height_nnVarInfo.DefaultValue = 0;
            height_nnVarInfo.Units = "m";
            height_nnVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            saturation_betaVarInfo.Name = "saturation_beta";
            saturation_betaVarInfo.Description = "Original: Yu et al. 2001; beta = 3.5";
            saturation_betaVarInfo.MaxValue = -1D;
            saturation_betaVarInfo.MinValue = -1D;
            saturation_betaVarInfo.DefaultValue = 2.5;
            saturation_betaVarInfo.Units = "";
            saturation_betaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stomata_conductance_alphaVarInfo.Name = "stomata_conductance_alpha";
            stomata_conductance_alphaVarInfo.Description = "Original: Yu et al. 2001; alpha = 0.06 mol/m2/s";
            stomata_conductance_alphaVarInfo.MaxValue = -1D;
            stomata_conductance_alphaVarInfo.MinValue = -1D;
            stomata_conductance_alphaVarInfo.DefaultValue = 40;
            stomata_conductance_alphaVarInfo.Units = "mmol/m2/s";
            stomata_conductance_alphaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            carboxylation_pathwayVarInfo.Name = "carboxylation_pathway";
            carboxylation_pathwayVarInfo.Description = "Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)";
            carboxylation_pathwayVarInfo.MaxValue = 2;
            carboxylation_pathwayVarInfo.MinValue = 0;
            carboxylation_pathwayVarInfo.DefaultValue = 0;
            carboxylation_pathwayVarInfo.Units = "dimensionless";
            carboxylation_pathwayVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            evaporation_zetaVarInfo.Name = "evaporation_zeta";
            evaporation_zetaVarInfo.Description = "shape factor";
            evaporation_zetaVarInfo.MaxValue = 40;
            evaporation_zetaVarInfo.MinValue = 0;
            evaporation_zetaVarInfo.DefaultValue = 40;
            evaporation_zetaVarInfo.Units = "dimensionless";
            evaporation_zetaVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            maximum_evaporation_impact_depthVarInfo.Name = "maximum_evaporation_impact_depth";
            maximum_evaporation_impact_depthVarInfo.Description = "maximumEvaporationImpactDepth";
            maximum_evaporation_impact_depthVarInfo.MaxValue = -1D;
            maximum_evaporation_impact_depthVarInfo.MinValue = 0;
            maximum_evaporation_impact_depthVarInfo.DefaultValue = 5;
            maximum_evaporation_impact_depthVarInfo.Units = "dm";
            maximum_evaporation_impact_depthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            evaporation_reduction_methodVarInfo.Name = "evaporation_reduction_method";
            evaporation_reduction_methodVarInfo.Description = "THESEUS (0) or HERMES (1) evaporation reduction method";
            evaporation_reduction_methodVarInfo.MaxValue = 1;
            evaporation_reduction_methodVarInfo.MinValue = 0;
            evaporation_reduction_methodVarInfo.DefaultValue = 1;
            evaporation_reduction_methodVarInfo.Units = "dimensionless";
            evaporation_reduction_methodVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            xsa_critical_soil_moistureVarInfo.Name = "xsa_critical_soil_moisture";
            xsa_critical_soil_moistureVarInfo.Description = "XSACriticalSoilMoisture";
            xsa_critical_soil_moistureVarInfo.MaxValue = 1.5;
            xsa_critical_soil_moistureVarInfo.MinValue = 0;
            xsa_critical_soil_moistureVarInfo.DefaultValue = 0.1;
            xsa_critical_soil_moistureVarInfo.Units = "m3/m3";
            xsa_critical_soil_moistureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            no_of_soil_layersVarInfo.Name = "no_of_soil_layers";
            no_of_soil_layersVarInfo.Description = "number of soil layers";
            no_of_soil_layersVarInfo.MaxValue = -1D;
            no_of_soil_layersVarInfo.MinValue = 0;
            no_of_soil_layersVarInfo.DefaultValue = 20;
            no_of_soil_layersVarInfo.Units = "dimensionless";
            no_of_soil_layersVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            no_of_soil_moisture_layersVarInfo.Name = "no_of_soil_moisture_layers";
            no_of_soil_moisture_layersVarInfo.Description = "number of soil layers + 1";
            no_of_soil_moisture_layersVarInfo.MaxValue = -1D;
            no_of_soil_moisture_layersVarInfo.MinValue = 0;
            no_of_soil_moisture_layersVarInfo.DefaultValue = 21;
            no_of_soil_moisture_layersVarInfo.Units = "dimensionless";
            no_of_soil_moisture_layersVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            layer_thicknessVarInfo.Name = "layer_thickness";
            layer_thicknessVarInfo.Description = "layer thickness array";
            layer_thicknessVarInfo.MaxValue = -1D;
            layer_thicknessVarInfo.MinValue = -1D;
            layer_thicknessVarInfo.DefaultValue = -1D;
            layer_thicknessVarInfo.Units = "m";
            layer_thicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            permanent_wilting_pointVarInfo.Name = "permanent_wilting_point";
            permanent_wilting_pointVarInfo.Description = "permanent wilting point array";
            permanent_wilting_pointVarInfo.MaxValue = -1D;
            permanent_wilting_pointVarInfo.MinValue = -1D;
            permanent_wilting_pointVarInfo.DefaultValue = -1D;
            permanent_wilting_pointVarInfo.Units = "m3/m3";
            permanent_wilting_pointVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            field_capacityVarInfo.Name = "field_capacity";
            field_capacityVarInfo.Description = "field capacity array";
            field_capacityVarInfo.MaxValue = -1D;
            field_capacityVarInfo.MinValue = -1D;
            field_capacityVarInfo.DefaultValue = -1D;
            field_capacityVarInfo.Units = "m3/m3";
            field_capacityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        public static VarInfo latitudeVarInfo
        {
            get { return SiriusQualityET.Strategies.Radiation.latitudeVarInfo;} 
        }

        public static VarInfo reference_albedoVarInfo
        {
            get { return SiriusQualityET.Strategies.NetRadiation.reference_albedoVarInfo;} 
        }

        public static VarInfo height_nnVarInfo
        {
            get { return SiriusQualityET.Strategies.NetRadiation.height_nnVarInfo;} 
        }

        public static VarInfo saturation_betaVarInfo
        {
            get { return SiriusQualityET.Strategies.StomataResistance.saturation_betaVarInfo;} 
        }

        public static VarInfo stomata_conductance_alphaVarInfo
        {
            get { return SiriusQualityET.Strategies.StomataResistance.stomata_conductance_alphaVarInfo;} 
        }

        public static VarInfo carboxylation_pathwayVarInfo
        {
            get { return SiriusQualityET.Strategies.StomataResistance.carboxylation_pathwayVarInfo;} 
        }

        public static VarInfo evaporation_zetaVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.evaporation_zetaVarInfo;} 
        }

        public static VarInfo maximum_evaporation_impact_depthVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.maximum_evaporation_impact_depthVarInfo;} 
        }

        public static VarInfo evaporation_reduction_methodVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.evaporation_reduction_methodVarInfo;} 
        }

        public static VarInfo xsa_critical_soil_moistureVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.xsa_critical_soil_moistureVarInfo;} 
        }

        public static VarInfo no_of_soil_layersVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.no_of_soil_layersVarInfo;} 
        }

        public static VarInfo no_of_soil_moisture_layersVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.no_of_soil_moisture_layersVarInfo;} 
        }

        public static VarInfo layer_thicknessVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.layer_thicknessVarInfo;} 
        }

        public static VarInfo permanent_wilting_pointVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.permanent_wilting_pointVarInfo;} 
        }

        public static VarInfo field_capacityVarInfo
        {
            get { return SiriusQualityET.Strategies.Evapotranspiration.field_capacityVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination.CurrentValue=a.declination;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength.CurrentValue=a.astronomic_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength.CurrentValue=a.effective_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength.CurrentValue=a.photoperiodic_daylength;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation.CurrentValue=a.sunshine_hours_global_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.CurrentValue=a.extraterrestrial_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation.CurrentValue=a.clear_day_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation.CurrentValue=a.overcast_day_radiation;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean.CurrentValue=a.phot_act_radiation_mean;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration.CurrentValue=a.reference_evapotranspiration;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration.CurrentValue=a.potential_evapotranspiration;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r51 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination);
                if(r51.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.declination.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength);
                if(r52.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.astronomic_daylength.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength);
                if(r53.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.effective_daylength.ValueType)){prc.AddCondition(r53);}
                RangeBasedCondition r54 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength);
                if(r54.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.photoperiodic_daylength.ValueType)){prc.AddCondition(r54);}
                RangeBasedCondition r55 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation);
                if(r55.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.sunshine_hours_global_radiation.ValueType)){prc.AddCondition(r55);}
                RangeBasedCondition r56 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation);
                if(r56.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.extraterrestrial_radiation.ValueType)){prc.AddCondition(r56);}
                RangeBasedCondition r57 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation);
                if(r57.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.clear_day_radiation.ValueType)){prc.AddCondition(r57);}
                RangeBasedCondition r58 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation);
                if(r58.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.overcast_day_radiation.ValueType)){prc.AddCondition(r58);}
                RangeBasedCondition r59 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean);
                if(r59.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.phot_act_radiation_mean.ValueType)){prc.AddCondition(r59);}
                RangeBasedCondition r60 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration);
                if(r60.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.reference_evapotranspiration.ValueType)){prc.AddCondition(r60);}
                RangeBasedCondition r61 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration);
                if(r61.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.potential_evapotranspiration.ValueType)){prc.AddCondition(r61);}

                string ret = "";
                ret += _Radiation.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _NetRadiation.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _StomataResistance.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _CalcStomataResistance.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _SaturatedVaporPressure.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _SaturationVaporPressureDeficit.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _ReferenceEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _PotentialEvapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _Evapotranspiration.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _UseExtET0.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _UseExtVaporPressure.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation.CurrentValue=ex.global_radiation;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day.CurrentValue=ex.julian_day;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours.CurrentValue=ex.sunshine_hours;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.max_air_temperature.CurrentValue=ex.max_air_temperature;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.min_air_temperature.CurrentValue=ex.min_air_temperature;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_vapor_pressure.CurrentValue=a.use_external_vapor_pressure;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_vapor_pressure.CurrentValue=a.external_vapor_pressure;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.relative_humidity.CurrentValue=ex.relative_humidity;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance.CurrentValue=a.calc_stomata_resistance;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance.CurrentValue=a.fixed_stomata_resistance;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol.CurrentValue=a.gross_photosynthesis_reference_mol;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration.CurrentValue=ex.atmospheric_co2_concentration;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.mean_air_temperature.CurrentValue=ex.mean_air_temperature;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed.CurrentValue=ex.wind_speed;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed_height.CurrentValue=ex.wind_speed_height;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.CurrentValue=a.stomata_resistance;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.net_radiation.CurrentValue=a.net_radiation;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.kc_factor.CurrentValue=ex.kc_factor;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.developmental_stage.CurrentValue=ex.developmental_stage;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_remaining_evapotranspiration.CurrentValue=ex.crop_remaining_evapotranspiration;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.has_snow_cover.CurrentValue=ex.has_snow_cover;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_transpiration.CurrentValue=ex.crop_transpiration;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted.CurrentValue=ex.crop_evaporated_from_intercepted;
                SiriusQualityET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage.CurrentValue=ex.percentage_soil_coverage;
                SiriusQualityET.DomainClass.ETStateVarInfo.surface_water_storage.CurrentValue=s.surface_water_storage;
                SiriusQualityET.DomainClass.ETStateVarInfo.evaporated_from_surface.CurrentValue=s.evaporated_from_surface;
                SiriusQualityET.DomainClass.ETStateVarInfo.actual_evaporation.CurrentValue=s.actual_evaporation;
                SiriusQualityET.DomainClass.ETStateVarInfo.actual_transpiration.CurrentValue=s.actual_transpiration;
                SiriusQualityET.DomainClass.ETStateVarInfo.soil_moisture.CurrentValue=s.soil_moisture;
                SiriusQualityET.DomainClass.ETStateVarInfo.evaporation.CurrentValue=s.evaporation;
                SiriusQualityET.DomainClass.ETStateVarInfo.transpiration.CurrentValue=s.transpiration;
                SiriusQualityET.DomainClass.ETStateVarInfo.evapotranspiration.CurrentValue=s.evapotranspiration;
                SiriusQualityET.DomainClass.ETStateVarInfo.actual_evapotranspiration.CurrentValue=s.actual_evapotranspiration;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0.CurrentValue=a.use_external_et0;
                SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0.CurrentValue=a.external_et0;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.global_radiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.julian_day.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.sunshine_hours.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.max_air_temperature);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.max_air_temperature.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.min_air_temperature);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.min_air_temperature.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_vapor_pressure);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_vapor_pressure.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_vapor_pressure);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_vapor_pressure.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.relative_humidity);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.relative_humidity.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.calc_stomata_resistance.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.fixed_stomata_resistance.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.gross_photosynthesis_reference_mol.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.atmospheric_co2_concentration.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.mean_air_temperature);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.mean_air_temperature.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed_height);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.wind_speed_height.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance);
                if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.stomata_resistance.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.net_radiation);
                if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.net_radiation.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.kc_factor);
                if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.kc_factor.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.developmental_stage);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.developmental_stage.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_remaining_evapotranspiration);
                if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_remaining_evapotranspiration.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.has_snow_cover);
                if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.has_snow_cover.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_transpiration);
                if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_transpiration.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted);
                if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.crop_evaporated_from_intercepted.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage);
                if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETExogenousVarInfo.percentage_soil_coverage.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.surface_water_storage);
                if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.surface_water_storage.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.evaporated_from_surface);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.evaporated_from_surface.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.actual_evaporation);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.actual_evaporation.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.actual_transpiration);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.actual_transpiration.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.soil_moisture);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.soil_moisture.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.evaporation);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.evaporation.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.transpiration);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.transpiration.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.evapotranspiration);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.evapotranspiration.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETStateVarInfo.actual_evapotranspiration);
                if(r33.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETStateVarInfo.actual_evapotranspiration.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0);
                if(r34.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.use_external_et0.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0);
                if(r35.ApplicableVarInfoValueTypes.Contains( SiriusQualityET.DomainClass.ETAuxiliaryVarInfo.external_et0.ValueType)){prc.AddCondition(r35);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latitude")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("reference_albedo")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("height_nn")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("saturation_beta")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stomata_conductance_alpha")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("carboxylation_pathway")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("evaporation_zeta")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("maximum_evaporation_impact_depth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("evaporation_reduction_method")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("xsa_critical_soil_moisture")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("no_of_soil_layers")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("no_of_soil_moisture_layers")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layer_thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("permanent_wilting_point")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("field_capacity")));
                string ret = "";
                ret += _Radiation.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _NetRadiation.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _StomataResistance.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _CalcStomataResistance.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _SaturatedVaporPressure.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _SaturationVaporPressureDeficit.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _ReferenceEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _PotentialEvapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _Evapotranspiration.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _UseExtET0.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                ret += _UseExtVaporPressure.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityET.Strategies.ET");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.ET, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityET, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Radiation _Radiation = new Radiation();
        NetRadiation _NetRadiation = new NetRadiation();
        StomataResistance _StomataResistance = new StomataResistance();
        CalcStomataResistance _CalcStomataResistance = new CalcStomataResistance();
        SaturatedVaporPressure _SaturatedVaporPressure = new SaturatedVaporPressure();
        SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
        ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
        PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();
        Evapotranspiration _Evapotranspiration = new Evapotranspiration();
        UseExtET0 _UseExtET0 = new UseExtET0();
        UseExtVaporPressure _UseExtVaporPressure = new UseExtVaporPressure();

        private void EstimateOfAssociatedClasses(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            _Radiation.Estimate(s,s1, r, a, ex);
            _SaturatedVaporPressure.Estimate(s,s1, r, a, ex);
            a.internal_vapor_pressure = a.vapor_pressure;
            _UseExtVaporPressure.Estimate(s,s1, r, a, ex);
            _NetRadiation.Estimate(s,s1, r, a, ex);
            _SaturationVaporPressureDeficit.Estimate(s,s1, r, a, ex);
            _StomataResistance.Estimate(s,s1, r, a, ex);
            a.calculated_stomata_resistance = a.stomata_resistance;
            _CalcStomataResistance.Estimate(s,s1, r, a, ex);
            _ReferenceEvapotranspiration.Estimate(s,s1, r, a, ex);
            a.internal_et0 = a.reference_evapotranspiration;
            _UseExtET0.Estimate(s,s1, r, a, ex);
            a.reference_evapotranspiration = a.et0;
            _PotentialEvapotranspiration.Estimate(s,s1, r, a, ex);
            _Evapotranspiration.Estimate(s,s1, r, a, ex);
        }

        public void Init(SiriusQualityET.DomainClass.ETState s,SiriusQualityET.DomainClass.ETState s1,SiriusQualityET.DomainClass.ETRate r,SiriusQualityET.DomainClass.ETAuxiliary a,SiriusQualityET.DomainClass.ETExogenous ex)
        {
            Tuple.Create(s.surface_water_storage, s.evaporated_from_surface, s.actual_evaporation, s.actual_transpiration, s.soil_moisture, s.evaporation, s.transpiration, s.evapotranspiration, s.actual_evapotranspiration) = init_evapotranspiration(evaporation_zeta, maximum_evaporation_impact_depth, evaporation_reduction_method, xsa_critical_soil_moisture, no_of_soil_layers, no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point, field_capacity, ex.kc_factor, ex.has_snow_cover, ex.developmental_stage, ex.crop_transpiration, ex.crop_evaporated_from_intercepted, ex.percentage_soil_coverage);
        }

        public ETComponent(ETComponent toCopy): this() // copy constructor 
        {
                latitude = toCopy.latitude;
                reference_albedo = toCopy.reference_albedo;
                height_nn = toCopy.height_nn;
                saturation_beta = toCopy.saturation_beta;
                stomata_conductance_alpha = toCopy.stomata_conductance_alpha;
                carboxylation_pathway = toCopy.carboxylation_pathway;
                evaporation_zeta = toCopy.evaporation_zeta;
                maximum_evaporation_impact_depth = toCopy.maximum_evaporation_impact_depth;
                evaporation_reduction_method = toCopy.evaporation_reduction_method;
                xsa_critical_soil_moisture = toCopy.xsa_critical_soil_moisture;
                no_of_soil_layers = toCopy.no_of_soil_layers;
                no_of_soil_moisture_layers = toCopy.no_of_soil_moisture_layers;
                
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { layer_thickness[i] = toCopy.layer_thickness[i]; }
    
                
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { permanent_wilting_point[i] = toCopy.permanent_wilting_point[i]; }
    
                
        for (int i = 0; i < no_of_soil_moisture_layers; i++)
            { field_capacity[i] = toCopy.field_capacity[i]; }
    
            }
        }
    }