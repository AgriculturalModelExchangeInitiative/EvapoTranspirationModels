library(gsubfn)

#' MONICA saturation vapor pressure deficit
#'
#' This function compute the MONICA saturation vapor pressure deficit
#' @param saturated_vapor_pressure (kPa) saturated vapor pressure auxiliary (0, 0-) 
#' @param vapor_pressure (kPa) vapor pressure auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{saturation_vapor_pressure_deficit (kPa)}{saturation vapor pressure deficit auxiliary (0-)} 
#' }
#' @export
model_saturationvaporpressuredeficit <- function (saturated_vapor_pressure,
         vapor_pressure){
    saturation_vapor_pressure_deficit <- 0.0
    saturation_vapor_pressure_deficit <- saturated_vapor_pressure - vapor_pressure
    return (list('saturation_vapor_pressure_deficit' = saturation_vapor_pressure_deficit))
}