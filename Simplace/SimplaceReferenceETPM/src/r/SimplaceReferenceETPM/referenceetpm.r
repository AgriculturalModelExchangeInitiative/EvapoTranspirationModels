library(gsubfn)

#' ReferenceETPM model
#'
#' This function compute the ReferenceETPM model
#' @param cAltitude (http://www.wurvoc.org/vocabularies/om-1.8/metre) elevation above sea level constant (0.0, -) 
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param iActualVapourPressure (http://www.wurvoc.org/vocabularies/om-1.8/kilopascal) actual vapour pressure exogenous (0.0, -) 
#' @param iNetRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) net radiation exogenous (0.0, -) 
#' @param iWindspeed (http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time) wind speed at 2m height exogenous (0.0, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceetpm <- function (cAltitude,
         iTMax,
         iTMin,
         iActualVapourPressure,
         iNetRadiation,
         iWindspeed){
    ReferenceCropEvapotranspiration <- 0.0
    T <- 0.0
    e_s <- 0.0
    T <- (iTMax + iTMin) / 2
    e_s <- MeanSaturatedVapourPressure(iTMax, iTMin)
    if (iActualVapourPressure > e_s)
    {
        iActualVapourPressure <- e_s
    }
    ReferenceCropEvapotranspiration <- ReferenceEvapotranspiration(T, iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude)
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}

SaturationVapourPressureAtTemperature <- function (T){
    return( 0.6108 * exp(17.27 * T / (T + 237.3)))
}

MeanSaturatedVapourPressure <- function (T_max,
         T_min){
    return( (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2)
}

SlopeOfSaturationVapPressureCurve <- function (T){
    tempT <- 0.0
    tempT <- T + 237.3
    return( 4098 * (0.6108 * exp(17.27 * T / tempT)) / tempT ^ 2)
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

AtmosphericPressure <- function (z){
    return( 101.3 * ((293 - (0.0065 * z)) / 293) ^ 5.26)
}

ReferenceEvapotranspiration <- function (T,
         R_n,
         u_2,
         e_s,
         e_a,
         z){
    P <- 0.0
    gamma <- 0.0
    Delta <- 0.0
    G <- 0.0
    ET0 <- 0.0
    P <- AtmosphericPressure(z)
    gamma <- PsychrometricConstant(P)
    Delta <- SlopeOfSaturationVapPressureCurve(T)
    G <- as.double(0)
    ET0 <- (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))))
    return( ET0)
}