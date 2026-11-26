library(gsubfn)

#' MONICA radiation calculations
#'
#' This function compute the MONICA radiation calculations
#' @param latitude (degree) latitude constant (0, -90-90) 
#' @param global_radiation (MJ/m2) global radiation exogenous (0, 0-50) 
#' @param julian_day (day) day of year exogenous (1, 1-366) 
#' @param sunshine_hours (h) number of sunshine hours exogenous (0, 0-24) 
#'
#' @return
#' \describe{
#'   \item{declination ()}{declination auxiliary (0-24)} 
#'   \item{astronomic_daylength (mm)}{astronomic_daylength auxiliary (0-24)} 
#'   \item{effective_daylength (mm)}{effective_daylength auxiliary (0-24)} 
#'   \item{photoperiodic_daylength (mm)}{photoperiodic_daylength auxiliary (0-24)} 
#'   \item{sunshine_hours_global_radiation (MJ/m2)}{global radiation calculated from sunshine hours auxiliary (0-24)} 
#'   \item{extraterrestrial_radiation (MJ/m2)}{extraterrestrial_radiation auxiliary (0-24)} 
#'   \item{clear_day_radiation (MJ/m2)}{clear_day_radiation auxiliary (0-24)} 
#'   \item{overcast_day_radiation (MJ/m2)}{overcast_day_radiation auxiliary (0-24)} 
#'   \item{phot_act_radiation_mean (J/m2)}{phot_act_radiation_mean auxiliary (0-24)} 
#' }
#' @export
model_radiation <- function (latitude,
         global_radiation,
         julian_day,
         sunshine_hours){
    declination <- 0.0
    astronomic_daylength <- 0.0
    effective_daylength <- 0.0
    photoperiodic_daylength <- 0.0
    sunshine_hours_global_radiation <- 0.0
    extraterrestrial_radiation <- 0.0
    clear_day_radiation <- 0.0
    overcast_day_radiation <- 0.0
    phot_act_radiation_mean <- 0.0
    decl_sin <- 0.0
    decl_cos <- 0.0
    result <-  calc_declinations(latitude, julian_day)
    declination <- result[[1]]
    decl_sin <- result[[2]]
    decl_cos <- result[[3]]
    astronomic_daylength <- calc_astronomic_daylength(latitude, julian_day)
    effective_daylength <- calc_effective_daylength(latitude, julian_day)
    photoperiodic_daylength <- calc_photoperiodic_daylength(latitude, julian_day)
    arg_phot_act <- 0.0
    arg_phot_act <- min(1.0, decl_sin / decl_cos * (decl_sin / decl_cos))
    phot_act_radiation_mean <- 3600.0 * (decl_sin * astronomic_daylength + (24.0 / pi * decl_cos * sqrt((1.0 - arg_phot_act))))
    if (phot_act_radiation_mean > 0.0 && astronomic_daylength > 0.0)
    {
        clear_day_radiation <- 0.5 * 1300.0 * phot_act_radiation_mean * exp(-0.14 / (phot_act_radiation_mean / (astronomic_daylength * 3600.0)))
    }
    overcast_day_radiation <- 0.2 * clear_day_radiation
    solar_constant <- 0.0
    solar_constant <- 0.082
    SC <- 0.0
    SC <- 24.0 * 60.0 / pi * solar_constant * (1.0 + (0.033 * cos(2.0 * pi * julian_day / 365.0)))
    solar_angle <- 0.0
    solar_angle <- -tan((latitude * pi / 180.0)) * tan(declination * pi / 180.0)
    solar_angle <- bound(-1.0, solar_angle, 1.0)
    sunset_solar_angle <- 0.0
    sunset_solar_angle <- acos(solar_angle)
    extraterrestrial_radiation <- SC * (sunset_solar_angle * decl_sin + (decl_cos * sin(sunset_solar_angle)))
    if (sunshine_hours > 0.0)
    {
        if (global_radiation <= 0.0 && astronomic_daylength > 0.0)
        {
            sunshine_hours_global_radiation <- extraterrestrial_radiation * (0.19 + (0.55 * sunshine_hours / astronomic_daylength))
        }
        else
        {
            sunshine_hours_global_radiation <- 0.0
        }
    }
    return (list ("declination" = declination,"astronomic_daylength" = astronomic_daylength,"effective_daylength" = effective_daylength,"photoperiodic_daylength" = photoperiodic_daylength,"sunshine_hours_global_radiation" = sunshine_hours_global_radiation,"extraterrestrial_radiation" = extraterrestrial_radiation,"clear_day_radiation" = clear_day_radiation,"overcast_day_radiation" = overcast_day_radiation,"phot_act_radiation_mean" = phot_act_radiation_mean))
}

bound <- function (lower,
         value,
         upper){
    if (value < lower)
    {
        return( lower)
    }
    if (value > upper)
    {
        return( upper)
    }
    return( value)
}

calc_declinations <- function (latitude,
         julian_day){
    declination <- 0.0
    declination <- -23.4 * cos(2.0 * pi * ((julian_day + 10.0) / 365.0))
    decl_sin <- 0.0
    decl_sin <- sin(declination * pi / 180.0) * sin(latitude * pi / 180.0)
    decl_cos <- 0.0
    decl_cos <- cos(declination * pi / 180.0) * cos(latitude * pi / 180.0)
    return (list ("declination" = declination,"decl_sin" = decl_sin,"decl_cos" = decl_cos))
}

calc_astronomic_daylength <- function (latitude,
         julian_day){
    declination <- 0.0
    decl_sin <- 0.0
    decl_cos <- 0.0
    result <-  calc_declinations(latitude, julian_day)
    declination <- result[[1]]
    decl_sin <- result[[2]]
    decl_cos <- result[[3]]
    astro_daylength <- 0.0
    astro_daylength <- decl_sin / decl_cos
    astro_daylength <- bound(-1.0, astro_daylength, 1.0)
    astronomic_daylength <- 0.0
    astronomic_daylength <- 12.0 * (pi + (2.0 * asin(astro_daylength))) / pi
    return( astronomic_daylength)
}

calc_effective_daylength <- function (latitude,
         julian_day){
    declination <- 0.0
    decl_sin <- 0.0
    decl_cos <- 0.0
    result <-  calc_declinations(latitude, julian_day)
    declination <- result[[1]]
    decl_sin <- result[[2]]
    decl_cos <- result[[3]]
    eff_daylength <- 0.0
    eff_daylength <- (-sin((8.0 * pi / 180.0)) + decl_sin) / decl_cos
    eff_daylength <- bound(-1.0, eff_daylength, 1.0)
    effective_daylength <- 0.0
    effective_daylength <- 12.0 * (pi + (2.0 * asin(eff_daylength))) / pi
    return( effective_daylength)
}

calc_photoperiodic_daylength <- function (latitude,
         julian_day){
    declination <- 0.0
    decl_sin <- 0.0
    decl_cos <- 0.0
    result <-  calc_declinations(latitude, julian_day)
    declination <- result[[1]]
    decl_sin <- result[[2]]
    decl_cos <- result[[3]]
    photo_daylength <- 0.0
    photo_daylength <- (-sin((-6.0 * pi / 180.0)) + decl_sin) / decl_cos
    photo_daylength <- bound(-1.0, photo_daylength, 1.0)
    photoperiodic_daylength <- 0.0
    photoperiodic_daylength <- 12.0 * (pi + (2.0 * asin(photo_daylength))) / pi
    return( photoperiodic_daylength)
}