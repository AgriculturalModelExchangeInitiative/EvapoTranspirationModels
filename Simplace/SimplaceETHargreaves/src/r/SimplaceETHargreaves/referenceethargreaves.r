library(gsubfn)

#' ReferenceETHargreaves model
#'
#' This function compute the ReferenceETHargreaves model
#' @param cConvertLeByTemp () Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day. constant (false, -) 
#' @param iTMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) maximum daily temperature exogenous (0.0, -) 
#' @param iTMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) minimum daily temperature exogenous (0.0, -) 
#' @param iSolarRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day) solar radiation exogenous (0.0, -) 
#'
#' @return
#' \describe{
#'   \item{ReferenceCropEvapotranspiration (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day)}{reference evapotranspiration (ET0) auxiliary (-)} 
#' }
#' @export
model_referenceethargreaves <- function (cConvertLeByTemp,
         iTMax,
         iTMin,
         iSolarRadiation){
    ReferenceCropEvapotranspiration <- 0.0
    R_s_eveq <- 0.0
    if (cConvertLeByTemp)
    {
        R_s_eveq <- EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 * (iTMax + iTMin))
    }
    else
    {
        R_s_eveq <- EvaporationEquivalentToRadiation2(iSolarRadiation)
    }
    ReferenceCropEvapotranspiration <- max(0, ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin))
    return (list('ReferenceCropEvapotranspiration' = ReferenceCropEvapotranspiration))
}

EvaporationEquivalentToRadiation1 <- function (Radiation,
         DailyMeanTemperature){
    return( 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation)
}

EvaporationEquivalentToRadiation2 <- function (Radiation){
    return( 0.408 * Radiation)
}

ReferenceEvapoTranspirationFromSolarRadiation <- function (R_s,
         T_max,
         T_min){
    T_mean <- 0.0
    T_mean <- (T_max + T_min) / 2
    return( 0.0135 * (T_mean + 17.8) * R_s)
}