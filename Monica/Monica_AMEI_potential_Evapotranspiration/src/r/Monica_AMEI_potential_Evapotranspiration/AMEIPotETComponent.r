library(gsubfn)

#' AMEI ET MONICA potential evapotranspiration model
#'
#' This function compute the AMEI ET MONICA potential evapotranspiration model
#' @param vapor_pressure (kPa) vapor pressure auxiliary (0, 0-) 
#' @param saturated_vapor_pressure (kPa) saturated vapor pressure auxiliary (0, 0-) 
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param latent_heat_of_vaporization (MJ/kg) latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure) constant (0, 0-10) 
#' @param mean_air_temperature (°C) daily average air temperature exogenous (0, -100-100) 
#' @param wind_speed (m/s) wind speed measured at wind speed height exogenous (0, 0-9999) 
#' @param wind_speed_height (m) height at which the wind speed has been measured exogenous (2, 0.1-9999) 
#' @param stomata_resistance (s/m) stomata resistance (FAO default value is 100) auxiliary (100, 0-10000) 
#' @param net_radiation (MJ/m2) net radiation auxiliary (0, 0-) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_remaining_evapotranspiration (mm) crop remaining evapotranspiration exogenous (, -) 
#'
#' @return
#' \describe{
#'   \item{reference_evapotranspiration (mm)}{reference evapotranspiration (ET0) auxiliary (0-)} 
#'   \item{potential_evapotranspiration (mm)}{the potential evapotranspiration auxiliary (0-)} 
#' }
#' @export
model_ameipotet <- function (vapor_pressure,
         saturated_vapor_pressure,
         height_nn,
         latent_heat_of_vaporization,
         mean_air_temperature,
         wind_speed,
         wind_speed_height,
         stomata_resistance,
         net_radiation,
         kc_factor,
         developmental_stage,
         crop_remaining_evapotranspiration){
    saturation_vapor_pressure_deficit <- 0.0
    reference_evapotranspiration <- 0.0
    potential_evapotranspiration_cap <- 0.0
    potential_evapotranspiration <- 0.0
    saturation_vapor_pressure_deficit <- model_saturationvaporpressuredeficit(saturated_vapor_pressure, vapor_pressure)
    reference_evapotranspiration <- model_referenceevapotranspiration(height_nn, latent_heat_of_vaporization, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit)
    potential_evapotranspiration <- model_potentialevapotranspiration(potential_evapotranspiration_cap, kc_factor, developmental_stage, crop_remaining_evapotranspiration, reference_evapotranspiration)
    return (list ("reference_evapotranspiration" = reference_evapotranspiration,"potential_evapotranspiration" = potential_evapotranspiration))
}