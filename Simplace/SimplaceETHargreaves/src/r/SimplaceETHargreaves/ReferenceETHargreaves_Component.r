library(gsubfn)

#' ReferenceETHargreaves_ model
#'
#' This function compute the ReferenceETHargreaves_ model
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param iSolarRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) solar radiation exogenous (0.0, -) 
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param cConvertLeByTemp () Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day. constant (false, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceethargreaves_ <- function (iTMax,
         iSolarRadiation,
         iTMin,
         cConvertLeByTemp){
    ReferenceCropEvapotranspiration <- 0.0
    ReferenceCropEvapotranspiration <- model_referenceethargreaves(cConvertLeByTemp, iTMax, iTMin, iSolarRadiation)
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}