library(gsubfn)

#' MONICA saturated vapor pressure
#'
#' This function compute the MONICA saturated vapor pressure
#' @param max_air_temperature (°C) daily maximum air temperature exogenous (0, -100-100) 
#' @param min_air_temperature (°C) daily minimum air temperature exogenous (0, -100-100) 
#' @param relative_humidity (fraction) relative humidity exogenous (0, 0-1) 
#'
#' @return
#' \describe{
#'   \item{saturated_vapor_pressure (kPa)}{saturated vapor pressure auxiliary (0-1)} 
#'   \item{vapor_pressure (kPa)}{vapor pressure from relative humidity and saturated vapor pressure auxiliary (0-1)} 
#' }
#' @export
model_saturatedvaporpressure <- function (max_air_temperature,
         min_air_temperature,
         relative_humidity){
    saturated_vapor_pressure <- 0.0
    vapor_pressure <- 0.0
    saturated_vapor_pressure_max <- 0.0
    saturated_vapor_pressure_max <- 0.6108 * exp(17.27 * max_air_temperature / (237.3 + max_air_temperature))
    saturated_vapor_pressure_min <- 0.0
    saturated_vapor_pressure_min <- 0.6108 * exp(17.27 * min_air_temperature / (237.3 + min_air_temperature))
    saturated_vapor_pressure <- (saturated_vapor_pressure_max + saturated_vapor_pressure_min) / 2.0
    if (relative_humidity <= 0.0)
    {
        vapor_pressure <- saturated_vapor_pressure_min
    }
    else
    {
        vapor_pressure <- relative_humidity * saturated_vapor_pressure
    }
    return (list ("saturated_vapor_pressure" = saturated_vapor_pressure,"vapor_pressure" = vapor_pressure))
}