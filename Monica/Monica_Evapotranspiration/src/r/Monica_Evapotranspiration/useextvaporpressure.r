library(gsubfn)

#' If Else unit 
#'
#' This function compute the If Else unit 
#' @param use_external_vapor_pressure (mm) boolean condition to be met auxiliary (false, None-None) 
#' @param external_vapor_pressure (kPa) value to be returned if condition is true auxiliary (0, 0-) 
#' @param internal_vapor_pressure (kPa) value to be returned if condition is false auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{vapor_pressure (mm)}{the output value auxiliary (0-)} 
#' }
#' @export
model_useextvaporpressure <- function (use_external_vapor_pressure,
         external_vapor_pressure,
         internal_vapor_pressure){
    vapor_pressure <- 0.0
    if (use_external_vapor_pressure)
    {
        vapor_pressure <- external_vapor_pressure
    }
    else
    {
        vapor_pressure <- internal_vapor_pressure
    }
    return (list('vapor_pressure' = vapor_pressure))
}