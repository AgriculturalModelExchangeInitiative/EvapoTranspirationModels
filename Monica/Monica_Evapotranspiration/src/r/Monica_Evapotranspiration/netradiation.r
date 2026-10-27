library(gsubfn)

#' MONICA net radiation calculation
#'
#' This function compute the MONICA net radiation calculation
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param reference_albedo (dimensionless) reference albedo constant (0, 0-1) 
#' @param global_radiation (MJ/m2) global radiation exogenous (0, 0-50) 
#' @param max_air_temperature (°C) daily maximum air temperature exogenous (0, -100-100) 
#' @param min_air_temperature (°C) daily minimum air temperature exogenous (0, -100-100) 
#' @param extraterrestrial_radiation (MJ/m2) extraterrestrial_radiation auxiliary (0, 0-50) 
#' @param vapor_pressure (kPa) vapor pressure auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{net_radiation (MJ/m2)}{net_radiation auxiliary (0-)} 
#' }
#' @export
model_netradiation <- function (height_nn,
         reference_albedo,
         global_radiation,
         max_air_temperature,
         min_air_temperature,
         extraterrestrial_radiation,
         vapor_pressure){
    net_radiation <- 0.0
    clear_sky_solar_radiation <- 0.0
    clear_sky_solar_radiation <- (0.75 + (0.00002 * height_nn)) * extraterrestrial_radiation
    relative_shortwave_radiation <- 0.0
    relative_shortwave_radiation <-  if (clear_sky_solar_radiation > 0.0)min(global_radiation / clear_sky_solar_radiation, 1.0) else 1.0
    bolzmann_constant <- 0.0000000049
    shortwave_radiation <- 0.0
    shortwave_radiation <- (1.0 - reference_albedo) * global_radiation
    longwave_radiation <- 0.0
    longwave_radiation <- bolzmann_constant * (((min_air_temperature + 273.16) ^ 4.0 + (max_air_temperature + 273.16) ^ 4.0) / 2.0) * (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 * sqrt(vapor_pressure)))
    net_radiation <- shortwave_radiation - longwave_radiation
    return (list('net_radiation' = net_radiation))
}