library(gsubfn)

#' MONICA evapotranspiration model
#'
#' This function compute the MONICA evapotranspiration model
#' @param latitude (degree) latitude constant (0, -90-90) 
#' @param global_radiation (MJ/m2) global radiation exogenous (0, 0-50) 
#' @param julian_day (day) day of year exogenous (1, 1-366) 
#' @param sunshine_hours (h) number of sunshine hours exogenous (0, 0-24) 
#' @param reference_albedo (dimensionless) reference albedo constant (0, 0-1) 
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param max_air_temperature (°C) daily maximum air temperature exogenous (0, -100-100) 
#' @param min_air_temperature (°C) daily minimum air temperature exogenous (0, -100-100) 
#' @param use_external_vapor_pressure (mm) boolean condition to be met auxiliary (false, None-None) 
#' @param external_vapor_pressure (kPa) value to be returned if condition is true auxiliary (0, 0-) 
#' @param relative_humidity (fraction) relative humidity exogenous (0, 0-1) 
#' @param calc_stomata_resistance () boolean condition to be met auxiliary (false, None-None) 
#' @param fixed_stomata_resistance (s/m) value to be returned if condition is false auxiliary (100, 0-10000) 
#' @param saturation_beta () Original: Yu et al. 2001; beta = 3.5 constant (2.5, -) 
#' @param stomata_conductance_alpha (mmol/m2/s) Original: Yu et al. 2001; alpha = 0.06 mol/m2/s constant (40, -) 
#' @param carboxylation_pathway (dimensionless) Is it a C3 (=1) or C4 (=2) crop. (0 = no crop) constant (0, 0-2) 
#' @param gross_photosynthesis_reference_mol ([mol m-2 s-1] or [cm3 cm-2 s-1]) gross_photosynthesis_reference_mol (-1 = not supplied = no crop) auxiliary (-1, 0-) 
#' @param atmospheric_co2_concentration (ppm) CO2 concentration in the atmosphere. Optional if no crop. exogenous (430, 0-) 
#' @param mean_air_temperature (°C) daily average air temperature exogenous (0, -100-100) 
#' @param wind_speed (m/s) wind speed measured at wind speed height exogenous (0, 0-9999) 
#' @param wind_speed_height (m) height at which the wind speed has been measured exogenous (2, 0.1-9999) 
#' @param stomata_resistance (s/m) stomata resistance (FAO default value is 100) auxiliary (100, 0-10000) 
#' @param net_radiation (MJ/m2) net radiation auxiliary (0, 0-) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_remaining_evapotranspiration (mm) crop remaining evapotranspiration exogenous (, -) 
#' @param evaporation_zeta (dimensionless) shape factor constant (40, 0-40) 
#' @param maximum_evaporation_impact_depth (dm) maximumEvaporationImpactDepth constant (5, 0-) 
#' @param evaporation_reduction_method (dimensionless) THESEUS (0) or HERMES (1) evaporation reduction method constant (1, 0-1) 
#' @param xsa_critical_soil_moisture (m3/m3) XSACriticalSoilMoisture constant (0.1, 0-1.5) 
#' @param no_of_soil_layers (dimensionless) number of soil layers constant (20, 0-) 
#' @param no_of_soil_moisture_layers (dimensionless) number of soil layers + 1 constant (21, 0-) 
#' @param layer_thickness (m) layer thickness array constant (, -) 
#' @param permanent_wilting_point (m3/m3) permanent wilting point array constant (, -) 
#' @param field_capacity (m3/m3) field capacity array constant (, -) 
#' @param has_snow_cover (dimensionless) is the soil covered by snow exogenous (false, None-None) 
#' @param crop_transpiration (mm) crop transpiration array exogenous (, -) 
#' @param crop_evaporated_from_intercepted (mm) crop evaporated water from intercepted water exogenous (, -) 
#' @param percentage_soil_coverage (m2/m2) fraction of soil covered by crop exogenous (0, 0-1) 
#' @param surface_water_storage (mm) Simulates a virtual layer that contains the surface water state (0, 0-) 
#' @param evaporated_from_surface (mm) evaporated_from_surface state (0, 0-) 
#' @param actual_evaporation (mm) actual evaporation state (0, 0-) 
#' @param actual_transpiration (mm) actual transpiration state (0, 0-) 
#' @param soil_moisture (m3/m3) soil moisture array state (, -) 
#' @param evaporation (mm) evaporation array state (, -) 
#' @param transpiration (mm) transpiration array state (, -) 
#' @param evapotranspiration (mm) evapotranspiration array state (, -) 
#' @param actual_evapotranspiration (mm) actual evapotranspiration state (0, 0-) 
#' @param use_external_et0 () boolean condition to be met auxiliary (false, None-None) 
#' @param external_et0 (mm) value to be returned if condition is true auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{declination ()}{declination auxiliary (0-)} 
#'   \item{astronomic_daylength (mm)}{astronomic_daylength auxiliary (0-)} 
#'   \item{effective_daylength (mm)}{effective_daylength auxiliary (0-)} 
#'   \item{photoperiodic_daylength (mm)}{photoperiodic_daylength auxiliary (0-)} 
#'   \item{sunshine_hours_global_radiation (MJ/m2)}{global radiation calculated from sunshine hours auxiliary (0-)} 
#'   \item{extraterrestrial_radiation (MJ/m2)}{extraterrestrial_radiation auxiliary (0-)} 
#'   \item{clear_day_radiation (MJ/m2)}{clear_day_radiation auxiliary (0-)} 
#'   \item{overcast_day_radiation (MJ/m2)}{overcast_day_radiation auxiliary (0-)} 
#'   \item{phot_act_radiation_mean (J/m2)}{phot_act_radiation_mean auxiliary (0-)} 
#'   \item{reference_evapotranspiration (mm)}{reference evapotranspiration (ET0) auxiliary (0-)} 
#'   \item{potential_evapotranspiration (mm)}{the potential evapotranspiration auxiliary (0-)} 
#' }
#' @export
model_et <- function (latitude,
         global_radiation,
         julian_day,
         sunshine_hours,
         reference_albedo,
         height_nn,
         max_air_temperature,
         min_air_temperature,
         use_external_vapor_pressure,
         external_vapor_pressure,
         relative_humidity,
         calc_stomata_resistance,
         fixed_stomata_resistance,
         saturation_beta,
         stomata_conductance_alpha,
         carboxylation_pathway,
         gross_photosynthesis_reference_mol,
         atmospheric_co2_concentration,
         mean_air_temperature,
         wind_speed,
         wind_speed_height,
         stomata_resistance,
         net_radiation,
         kc_factor,
         developmental_stage,
         crop_remaining_evapotranspiration,
         evaporation_zeta,
         maximum_evaporation_impact_depth,
         evaporation_reduction_method,
         xsa_critical_soil_moisture,
         no_of_soil_layers,
         no_of_soil_moisture_layers,
         layer_thickness,
         permanent_wilting_point,
         field_capacity,
         has_snow_cover,
         crop_transpiration,
         crop_evaporated_from_intercepted,
         percentage_soil_coverage,
         surface_water_storage,
         evaporated_from_surface,
         actual_evaporation,
         actual_transpiration,
         soil_moisture,
         evaporation,
         transpiration,
         evapotranspiration,
         actual_evapotranspiration,
         use_external_et0,
         external_et0){
    declination <- 0.0
    astronomic_daylength <- 0.0
    effective_daylength <- 0.0
    photoperiodic_daylength <- 0.0
    sunshine_hours_global_radiation <- 0.0
    extraterrestrial_radiation <- 0.0
    clear_day_radiation <- 0.0
    overcast_day_radiation <- 0.0
    phot_act_radiation_mean <- 0.0
    vapor_pressure <- 0.0
    saturation_vapor_pressure_deficit <- 0.0
    calculated_stomata_resistance <- 0.0
    saturated_vapor_pressure <- 0.0
    reference_evapotranspiration <- 0.0
    potential_evapotranspiration_cap <- 0.0
    potential_evapotranspiration <- 0.0
    internal_et0 <- 0.0
    et0 <- 0.0
    internal_vapor_pressure <- 0.0
    result <-  model_radiation(latitude, global_radiation, julian_day, sunshine_hours)
    declination <- result[[1]]
    astronomic_daylength <- result[[2]]
    effective_daylength <- result[[3]]
    photoperiodic_daylength <- result[[4]]
    sunshine_hours_global_radiation <- result[[5]]
    extraterrestrial_radiation <- result[[6]]
    clear_day_radiation <- result[[7]]
    overcast_day_radiation <- result[[8]]
    phot_act_radiation_mean <- result[[9]]
    result <-  model_saturatedvaporpressure(max_air_temperature, min_air_temperature, relative_humidity)
    saturated_vapor_pressure <- result[[1]]
    vapor_pressure <- result[[2]]
    internal_vapor_pressure <- vapor_pressure
    vapor_pressure <- model_useextvaporpressure(use_external_vapor_pressure, external_vapor_pressure, internal_vapor_pressure)
    net_radiation <- model_netradiation(height_nn, reference_albedo, global_radiation, max_air_temperature, min_air_temperature, extraterrestrial_radiation, vapor_pressure)
    saturation_vapor_pressure_deficit <- model_saturationvaporpressuredeficit(saturated_vapor_pressure, vapor_pressure)
    stomata_resistance <- model_stomataresistance(saturation_beta, stomata_conductance_alpha, carboxylation_pathway, atmospheric_co2_concentration, saturation_vapor_pressure_deficit, gross_photosynthesis_reference_mol)
    calculated_stomata_resistance <- stomata_resistance
    stomata_resistance <- model_calcstomataresistance(calc_stomata_resistance, calculated_stomata_resistance, fixed_stomata_resistance)
    reference_evapotranspiration <- model_referenceevapotranspiration(height_nn, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit)
    internal_et0 <- reference_evapotranspiration
    et0 <- model_useextet0(use_external_et0, external_et0, internal_et0)
    reference_evapotranspiration <- et0
    potential_evapotranspiration <- model_potentialevapotranspiration(potential_evapotranspiration_cap, kc_factor, developmental_stage, crop_remaining_evapotranspiration, reference_evapotranspiration)
    result <-  model_evapotranspiration(evaporation_zeta, maximum_evaporation_impact_depth, evaporation_reduction_method, xsa_critical_soil_moisture, no_of_soil_layers, no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point, field_capacity, kc_factor, has_snow_cover, developmental_stage, crop_transpiration, crop_evaporated_from_intercepted, percentage_soil_coverage, potential_evapotranspiration, surface_water_storage, evaporated_from_surface, actual_evaporation, actual_transpiration, soil_moisture, evaporation, transpiration, evapotranspiration, actual_evapotranspiration)
    evaporated_from_surface <- result[[1]]
    actual_evapotranspiration <- result[[2]]
    actual_evaporation <- result[[3]]
    actual_transpiration <- result[[4]]
    surface_water_storage <- result[[5]]
    soil_moisture <- result[[6]]
    return (list ("declination" = declination,"astronomic_daylength" = astronomic_daylength,"effective_daylength" = effective_daylength,"photoperiodic_daylength" = photoperiodic_daylength,"sunshine_hours_global_radiation" = sunshine_hours_global_radiation,"extraterrestrial_radiation" = extraterrestrial_radiation,"clear_day_radiation" = clear_day_radiation,"overcast_day_radiation" = overcast_day_radiation,"phot_act_radiation_mean" = phot_act_radiation_mean,"reference_evapotranspiration" = reference_evapotranspiration,"potential_evapotranspiration" = potential_evapotranspiration))
}

#' Initialization of the MONICA evapotranspiration model
#' 
#' This function initialize the MONICA evapotranspiration model
#' @param latitude (degree) latitude constant (0, -90-90) 
#' @param global_radiation (MJ/m2) global radiation exogenous (0, 0-50) 
#' @param julian_day (day) day of year exogenous (1, 1-366) 
#' @param sunshine_hours (h) number of sunshine hours exogenous (0, 0-24) 
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param reference_albedo (dimensionless) reference albedo constant (0, 0-1) 
#' @param max_air_temperature (°C) daily maximum air temperature exogenous (0, -100-100) 
#' @param min_air_temperature (°C) daily minimum air temperature exogenous (0, -100-100) 
#' @param saturation_beta () Original: Yu et al. 2001; beta = 3.5 constant (2.5, -) 
#' @param stomata_conductance_alpha (mmol/m2/s) Original: Yu et al. 2001; alpha = 0.06 mol/m2/s constant (40, -) 
#' @param carboxylation_pathway (dimensionless) Is it a C3 (=1) or C4 (=2) crop. (0 = no crop) constant (0, 0-2) 
#' @param atmospheric_co2_concentration (ppm) CO2 concentration in the atmosphere. Optional if no crop. exogenous (430, 0-) 
#' @param relative_humidity (fraction) relative humidity exogenous (0, 0-1) 
#' @param mean_air_temperature (°C) daily average air temperature exogenous (0, -100-100) 
#' @param wind_speed (m/s) wind speed measured at wind speed height exogenous (0, 0-9999) 
#' @param wind_speed_height (m) height at which the wind speed has been measured exogenous (2, 0.1-9999) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_remaining_evapotranspiration (mm) crop remaining evapotranspiration exogenous (, -) 
#' @param evaporation_zeta (dimensionless) shape factor constant (40, 0-40) 
#' @param maximum_evaporation_impact_depth (dm) maximumEvaporationImpactDepth constant (5, 0-) 
#' @param evaporation_reduction_method (dimensionless) THESEUS (0) or HERMES (1) evaporation reduction method constant (1, 0-1) 
#' @param xsa_critical_soil_moisture (m3/m3) XSACriticalSoilMoisture constant (0.1, 0-1.5) 
#' @param no_of_soil_layers (dimensionless) number of soil layers constant (20, 0-) 
#' @param no_of_soil_moisture_layers (dimensionless) number of soil layers + 1 constant (21, 0-) 
#' @param layer_thickness (m) layer thickness array constant (, -) 
#' @param permanent_wilting_point (m3/m3) permanent wilting point array constant (, -) 
#' @param field_capacity (m3/m3) field capacity array constant (, -) 
#' @param has_snow_cover (dimensionless) is the soil covered by snow exogenous (false, None-None) 
#' @param crop_transpiration (mm) crop transpiration array exogenous (, -) 
#' @param crop_evaporated_from_intercepted (mm) crop evaporated water from intercepted water exogenous (, -) 
#' @param percentage_soil_coverage (m2/m2) fraction of soil covered by crop exogenous (0, 0-1) 
#'
#' @return
#' \describe{
#' }
#' @export
init_et <- function (latitude,
         global_radiation,
         julian_day,
         sunshine_hours,
         height_nn,
         reference_albedo,
         max_air_temperature,
         min_air_temperature,
         saturation_beta,
         stomata_conductance_alpha,
         carboxylation_pathway,
         atmospheric_co2_concentration,
         relative_humidity,
         mean_air_temperature,
         wind_speed,
         wind_speed_height,
         potential_evapotranspiration_cap,
         kc_factor,
         developmental_stage,
         crop_remaining_evapotranspiration,
         evaporation_zeta,
         maximum_evaporation_impact_depth,
         evaporation_reduction_method,
         xsa_critical_soil_moisture,
         no_of_soil_layers,
         no_of_soil_moisture_layers,
         layer_thickness,
         permanent_wilting_point,
         field_capacity,
         has_snow_cover,
         crop_transpiration,
         crop_evaporated_from_intercepted,
         percentage_soil_coverage){
    surface_water_storage <- 0.0
    evaporated_from_surface <- 0.0
    actual_evaporation <- 0.0
    actual_transpiration <- 0.0
    soil_moisture <- vector(,no_of_soil_moisture_layers)
    evaporation <- vector(,no_of_soil_moisture_layers)
    transpiration <- vector(,no_of_soil_moisture_layers)
    evapotranspiration <- vector(,no_of_soil_moisture_layers)
    actual_evapotranspiration <- 0.0
    result <-  init_evapotranspiration(evaporation_zeta, maximum_evaporation_impact_depth, evaporation_reduction_method, xsa_critical_soil_moisture, no_of_soil_layers, no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point, field_capacity, kc_factor, has_snow_cover, developmental_stage, crop_transpiration, crop_evaporated_from_intercepted, percentage_soil_coverage)
    surface_water_storage <- result[[1]]
    evaporated_from_surface <- result[[2]]
    actual_evaporation <- result[[3]]
    actual_transpiration <- result[[4]]
    soil_moisture <- result[[5]]
    evaporation <- result[[6]]
    transpiration <- result[[7]]
    evapotranspiration <- result[[8]]
    actual_evapotranspiration <- result[[9]]
    return (list ("surface_water_storage" = surface_water_storage,"evaporated_from_surface" = evaporated_from_surface,"actual_evaporation" = actual_evaporation,"actual_transpiration" = actual_transpiration,"soil_moisture" = soil_moisture,"evaporation" = evaporation,"transpiration" = transpiration,"evapotranspiration" = evapotranspiration,"actual_evapotranspiration" = actual_evapotranspiration))
}