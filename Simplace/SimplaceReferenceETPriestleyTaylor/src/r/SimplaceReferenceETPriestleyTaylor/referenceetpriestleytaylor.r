library(gsubfn)

#' ReferenceETPriestleyTaylor model
#'
#' This function compute the ReferenceETPriestleyTaylor model
#' @param cAltitude (http://www.wurvoc.org/vocabularies/om-1.8/metre) altitude constant (0.0, -) 
#' @param cAlphaPT (http://www.wurvoc.org/vocabularies/om-1.8/one) Priestley-Taylor coefficient constant (1.26, 0.0-) 
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param iNetRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) net radiation exogenous (0.0, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceetpriestleytaylor <- function (cAltitude,
         cAlphaPT,
         iTMax,
         iTMin,
         iNetRadiation){
    ReferenceCropEvapotranspiration <- 0.0
    lambdav <- 0.0
    T <- 0.0
    Delta <- 0.0
    AtmPres <- 0.0
    Gamma <- 0.0
    G <- 0.0
    lambdav <- 2.45
    T <- (iTMax + iTMin) / 2.0
    Delta <- SlopeOfSaturationVapPressureCurve(T)
    AtmPres <- AtmosphericPressure(cAltitude)
    Gamma <- PsychrometricConstant(AtmPres)
    G <- 0.0
    ReferenceCropEvapotranspiration <- max(0, cAlphaPT * Delta / (Delta + Gamma) * (iNetRadiation - G) / lambdav)
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}

SlopeOfSaturationVapPressureCurve <- function (T){
    tempT <- 0.0
    tempT <- T + 237.3
    return( 4098 * (0.6108 * exp(17.27 * T / tempT)) / tempT ^ 2)
}

AtmosphericPressure <- function (z){
    return( 101.3 * ((293 - (0.0065 * z)) / 293) ^ 5.26)
}

PsychrometricConstant <- function (P){
    lambdav <- 0.0
    c_p <- 0.0
    epsilon <- 0.0
    factor <- 0.0
    lambdav <- 2.45
    c_p <- 1.013E-3
    epsilon <- 0.622
    factor <- round(c_p / (epsilon * lambdav) * 10E6) / 10E6
    return( factor * P)
}