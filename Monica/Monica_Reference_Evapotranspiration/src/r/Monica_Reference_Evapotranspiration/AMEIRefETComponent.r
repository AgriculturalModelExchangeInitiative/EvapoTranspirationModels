library(gsubfn)

#' AMEI ET MONICA reference evapotranspiration model
#'
#' This function compute the AMEI ET MONICA reference evapotranspiration model
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param latent_heat_of_vaporization (MJ/kg) latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure) constant (0, 0-10) 
#' @param mean_air_temperature (°C) daily average air temperature exogenous (0, -100-100) 
#' @param wind_speed (m/s) wind speed measured at wind speed height exogenous (0, 0-9999) 
#' @param wind_speed_height (m) height at which the wind speed has been measured exogenous (2, 0.1-9999) 
#' @param stomata_resistance (s/m) stomata resistance (FAO default value is 100) auxiliary (100, 0-10000) 
#' @param net_radiation (MJ/m2) net radiation auxiliary (0, 0-) 
#' @param saturation_vapor_pressure_deficit (kPa) saturation_vapor_pressure_deficit auxiliary (0, 0-) 
#' @param saturated_vapor_pressure_slope (kPa/°C) slope of the saturation vapour pressure curve (negative: calculated from the mean air temperature) auxiliary (-1, -1-) 
#' @param psychrometric_constant (kPa/°C) psychrometric constant (negative: calculated from height_nn and latent_heat_of_vaporization) auxiliary (-1, -1-) 
#'
#' @return
#' \describe{
#'   \item{reference_evapotranspiration (mm)}{reference evapotranspiration (ET0) auxiliary (0-)} 
#' }
#' @export
model_ameirefet <- function (height_nn,
         latent_heat_of_vaporization,
         mean_air_temperature,
         wind_speed,
         wind_speed_height,
         stomata_resistance,
         net_radiation,
         saturation_vapor_pressure_deficit,
         saturated_vapor_pressure_slope,
         psychrometric_constant){
    reference_evapotranspiration <- 0.0
    reference_evapotranspiration <- model_referenceevapotranspiration(height_nn, latent_heat_of_vaporization, mean_air_temperature, wind_speed, wind_speed_height, net_radiation, stomata_resistance, saturation_vapor_pressure_deficit, saturated_vapor_pressure_slope, psychrometric_constant)
    return (list('reference_evapotranspiration' = reference_evapotranspiration))
}