library(gsubfn)

#' MONICA potential evapotranspiration calculation
#'
#' This function compute the MONICA potential evapotranspiration calculation
#' @param potential_evapotranspiration_cap (mm) cap ET0 to this value constant (6.5, 0-) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_remaining_evapotranspiration (mm) crop remaining evapotranspiration exogenous (, -) 
#' @param reference_evapotranspiration (mm) ET0 either from external ET0 or crop specific ET0 auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{potential_evapotranspiration (mm)}{the potential evapotranspiration auxiliary (0-)} 
#' }
#' @export
model_potentialevapotranspiration <- function (potential_evapotranspiration_cap,
         kc_factor,
         developmental_stage,
         crop_remaining_evapotranspiration,
         reference_evapotranspiration){
    potential_evapotranspiration <- 0.0
    if (developmental_stage > 0)
    {
        potential_evapotranspiration <- crop_remaining_evapotranspiration
    }
    else
    {
        potential_evapotranspiration <- reference_evapotranspiration * kc_factor
    }
    if (potential_evapotranspiration > potential_evapotranspiration_cap)
    {
        potential_evapotranspiration <- potential_evapotranspiration_cap
    }
    return (list('potential_evapotranspiration' = potential_evapotranspiration))
}