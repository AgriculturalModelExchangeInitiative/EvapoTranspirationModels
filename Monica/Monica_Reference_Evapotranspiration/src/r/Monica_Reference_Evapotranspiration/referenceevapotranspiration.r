library(gsubfn)

#' MONICA reference evapotranspiration
#'
#' This function compute the MONICA reference evapotranspiration
#' @param height_nn (m) height above sea level constant (0, -9999-9999) 
#' @param latent_heat_of_vaporization (MJ/kg) latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure) constant (0, 0-10) 
#' @param mean_air_temperature (°C) daily average air temperature exogenous (0, -100-100) 
#' @param wind_speed (m/s) wind speed measured at wind speed height exogenous (0, 0-9999) 
#' @param wind_speed_height (m) height at which the wind speed has been measured exogenous (2, 0.1-9999) 
#' @param net_radiation (MJ/m2) net radiation auxiliary (0, 0-) 
#' @param stomata_resistance (s/m) stomata resistance (FAO default value is 100) auxiliary (100, 0-10000) 
#' @param saturation_vapor_pressure_deficit (kPa) saturation_vapor_pressure_deficit auxiliary (0, 0-) 
#' @param saturated_vapor_pressure_slope (kPa/°C) slope of the saturation vapour pressure curve (negative: calculated from the mean air temperature) auxiliary (-1, -1-) 
#' @param psychrometric_constant (kPa/°C) psychrometric constant (negative: calculated from height_nn and latent_heat_of_vaporization) auxiliary (-1, -1-) 
#'
#' @return
#' \describe{
#'   \item{reference_evapotranspiration (mm)}{reference evapotranspiration (ET0) auxiliary (0-)} 
#' }
#' @export
model_referenceevapotranspiration <- function (height_nn,
         latent_heat_of_vaporization,
         mean_air_temperature,
         wind_speed,
         wind_speed_height,
         net_radiation,
         stomata_resistance,
         saturation_vapor_pressure_deficit,
         saturated_vapor_pressure_slope,
         psychrometric_constant){
    reference_evapotranspiration <- 0.0
    atmospheric_pressure <- 0.0
    atmospheric_pressure <- 101.3 * ((293.0 - (0.0065 * height_nn)) / 293.0) ^ 5.26
    psycrometer_constant <- 0.0
    if (psychrometric_constant >= 0.0)
    {
        psycrometer_constant <- psychrometric_constant
    }
    else if ( latent_heat_of_vaporization > 0.0)
    {
        psycrometer_constant <- 1.013e-3 * atmospheric_pressure / (0.622 * latent_heat_of_vaporization)
    }
    else
    {
        psycrometer_constant <- 0.000665 * atmospheric_pressure
    }
    saturated_vapour_pressure_slope <- 0.0
    if (saturated_vapor_pressure_slope >= 0.0)
    {
        saturated_vapour_pressure_slope <- saturated_vapor_pressure_slope
    }
    else
    {
        saturated_vapour_pressure_slope <- 4098.0 * (0.6108 * exp(17.27 * mean_air_temperature / (mean_air_temperature + 237.3))) / ((mean_air_temperature + 237.3) * (mean_air_temperature + 237.3))
    }
    inverse_lambda <- 0.0
    if (latent_heat_of_vaporization > 0.0)
    {
        inverse_lambda <- 1.0 / latent_heat_of_vaporization
    }
    else
    {
        inverse_lambda <- 0.408
    }
    wind_speed_2m <- 0.0
    wind_speed_2m <- max(0.5, wind_speed * (4.87 / log((67.8 * wind_speed_height - 5.42))))
    aerodynamic_resistance <- 0.0
    aerodynamic_resistance <- 208.0 / wind_speed_2m
    surface_resistance <- 0.0
    surface_resistance <- stomata_resistance / 1.44
    reference_evapotranspiration <- (inverse_lambda * saturated_vapour_pressure_slope * net_radiation + (psycrometer_constant * (900.0 / (mean_air_temperature + 273.0)) * wind_speed_2m * saturation_vapor_pressure_deficit)) / (saturated_vapour_pressure_slope + (psycrometer_constant * (1.0 + (surface_resistance / aerodynamic_resistance))))
    if (reference_evapotranspiration < 0.0)
    {
        reference_evapotranspiration <- 0.0
    }
    return (list('reference_evapotranspiration' = reference_evapotranspiration))
}