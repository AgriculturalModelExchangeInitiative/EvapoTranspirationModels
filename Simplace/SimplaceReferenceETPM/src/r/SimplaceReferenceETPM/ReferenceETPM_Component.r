library(gsubfn)

#' ReferenceETPM_ model
#'
#' This function compute the ReferenceETPM_ model
#' @param iNetRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) net radiation exogenous (0.0, -) 
#' @param cAltitude (http://www.wurvoc.org/vocabularies/om-1.8/metre) elevation above sea level constant (0.0, -) 
#' @param iActualVapourPressure (http://www.wurvoc.org/vocabularies/om-1.8/kilopascal) actual vapour pressure exogenous (0.0, -) 
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param iWindspeed (http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time) wind speed at 2m height exogenous (0.0, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceetpm_ <- function (iNetRadiation,
         cAltitude,
         iActualVapourPressure,
         iTMax,
         iTMin,
         iWindspeed){
    ReferenceCropEvapotranspiration <- 0.0
    ReferenceCropEvapotranspiration <- model_referenceetpm(cAltitude, iTMax, iTMin, iActualVapourPressure, iNetRadiation, iWindspeed)
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}