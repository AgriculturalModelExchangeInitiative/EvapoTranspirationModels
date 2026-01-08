library(gsubfn)

#' ReferenceETPriestleyTaylor_ model
#'
#' This function compute the ReferenceETPriestleyTaylor_ model
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param cAlphaPT (http://www.wurvoc.org/vocabularies/om-1.8/one) Priestley-Taylor coefficient constant (1.26, 0.0-) 
#' @param iNetRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) net radiation exogenous (0.0, -) 
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param cAltitude (http://www.wurvoc.org/vocabularies/om-1.8/metre) altitude constant (0.0, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceetpriestleytaylor_ <- function (iTMin,
         cAlphaPT,
         iNetRadiation,
         iTMax,
         cAltitude){
    ReferenceCropEvapotranspiration <- 0.0
    ReferenceCropEvapotranspiration <- model_referenceetpriestleytaylor(cAltitude, cAlphaPT, iTMax, iTMin, iNetRadiation)
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}