library(gsubfn)

#' Initialization of the MONICA evapotranspiration model
#' 
#' This function initialize the MONICA evapotranspiration model
#' @param evaporation_zeta (dimensionless) shape factor constant (40, 0-40) 
#' @param maximum_evaporation_impact_depth (dm) maximumEvaporationImpactDepth constant (5, 0-) 
#' @param evaporation_reduction_method (dimensionless) THESEUS (0) or HERMES (1) evaporation reduction method constant (1, 0-1) 
#' @param xsa_critical_soil_moisture (m3/m3) XSACriticalSoilMoisture constant (0.1, 0-1.5) 
#' @param no_of_soil_layers (dimensionless) number of soil layers constant (20, 0-) 
#' @param no_of_soil_moisture_layers (dimensionless) number of soil layers + 1 constant (21, 0-) 
#' @param layer_thickness (m) layer thickness array constant (, -) 
#' @param permanent_wilting_point (m3/m3) permanent wilting point array constant (, -) 
#' @param field_capacity (m3/m3) field capacity array constant (, -) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param has_snow_cover (dimensionless) is the soil covered by snow exogenous (false, None-None) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_transpiration (mm) crop transpiration array exogenous (, -) 
#' @param crop_evaporated_from_intercepted (mm) crop evaporated water from intercepted water exogenous (, -) 
#' @param percentage_soil_coverage (m2/m2) fraction of soil covered by crop exogenous (0, 0-1) 
#'
#' @return
#' \describe{
#'   \item{evaporated_from_surface (mm)}{ state (0-)}
#'   \item{actual_evapotranspiration (mm)}{actual evapotranspiration state (0-)}
#'   \item{actual_evaporation (mm)}{actual evaporation state (0-)}
#'   \item{actual_transpiration (mm)}{actual transpiration state (0-)}
#'   \item{surface_water_storage (mm)}{Simulates a virtual layer that contains the surface water state (0-)}
#'   \item{soil_moisture (m3/m3)}{soil moisture array state (-)}
#' }
#' @export
init_evapotranspiration <- function (evaporation_zeta,
         maximum_evaporation_impact_depth,
         evaporation_reduction_method,
         xsa_critical_soil_moisture,
         no_of_soil_layers,
         no_of_soil_moisture_layers,
         layer_thickness,
         permanent_wilting_point,
         field_capacity,
         kc_factor,
         has_snow_cover,
         developmental_stage,
         crop_transpiration,
         crop_evaporated_from_intercepted,
         percentage_soil_coverage){
    surface_water_storage <- 0.0
    evaporated_from_surface <- 0.0
    actual_evaporation <- 0.0
    actual_transpiration <- 0.0
    soil_moisture <- vector(,no_of_soil_moisture_layers)
    evaporation <- vector(,no_of_soil_moisture_layers)
    transpiration <- vector(,no_of_soil_moisture_layers)
    evapotranspiration <- vector(,no_of_soil_moisture_layers)
    actual_evapotranspiration <- 0.0
    soil_moisture <-  rep(0.0,no_of_soil_moisture_layers)
    evaporation <-  rep(0.0,no_of_soil_moisture_layers)
    transpiration <-  rep(0.0,no_of_soil_moisture_layers)
    evapotranspiration <-  rep(0.0,no_of_soil_moisture_layers)
    return (list ("surface_water_storage" = surface_water_storage,"evaporated_from_surface" = evaporated_from_surface,"actual_evaporation" = actual_evaporation,"actual_transpiration" = actual_transpiration,"soil_moisture" = soil_moisture,"evaporation" = evaporation,"transpiration" = transpiration,"evapotranspiration" = evapotranspiration,"actual_evapotranspiration" = actual_evapotranspiration))
}

#' MONICA evapotranspiration model
#'
#' This function compute the MONICA evapotranspiration model
#' @param evaporation_zeta (dimensionless) shape factor constant (40, 0-40) 
#' @param maximum_evaporation_impact_depth (dm) maximumEvaporationImpactDepth constant (5, 0-) 
#' @param evaporation_reduction_method (dimensionless) THESEUS (0) or HERMES (1) evaporation reduction method constant (1, 0-1) 
#' @param xsa_critical_soil_moisture (m3/m3) XSACriticalSoilMoisture constant (0.1, 0-1.5) 
#' @param no_of_soil_layers (dimensionless) number of soil layers constant (20, 0-) 
#' @param no_of_soil_moisture_layers (dimensionless) number of soil layers + 1 constant (21, 0-) 
#' @param layer_thickness (m) layer thickness array constant (, -) 
#' @param permanent_wilting_point (m3/m3) permanent wilting point array constant (, -) 
#' @param field_capacity (m3/m3) field capacity array constant (, -) 
#' @param kc_factor (dimensionless) crop coefficient ETc/ET0 exogenous (0.75, 0-) 
#' @param has_snow_cover (dimensionless) is the soil covered by snow exogenous (false, None-None) 
#' @param developmental_stage (dimensionless) MONICA crop developmental stage exogenous (0, 0-6) 
#' @param crop_transpiration (mm) crop transpiration array exogenous (, -) 
#' @param crop_evaporated_from_intercepted (mm) crop evaporated water from intercepted water exogenous (, -) 
#' @param percentage_soil_coverage (m2/m2) fraction of soil covered by crop exogenous (0, 0-1) 
#' @param potential_evapotranspiration (mm) the potential evapotranspiration auxiliary (0, 0-) 
#' @param surface_water_storage (mm) Simulates a virtual layer that contains the surface water state (0, 0-) 
#' @param evaporated_from_surface (mm) evaporated_from_surface state (0, 0-) 
#' @param actual_evaporation (mm) actual evaporation state (0, 0-) 
#' @param actual_transpiration (mm) actual transpiration state (0, 0-) 
#' @param soil_moisture (m3/m3) soil moisture array state (, -) 
#' @param evaporation (mm) evaporation array state (, -) 
#' @param transpiration (mm) transpiration array state (, -) 
#' @param evapotranspiration (mm) evapotranspiration array state (, -) 
#' @param actual_evapotranspiration (mm) actual evapotranspiration state (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{evaporated_from_surface (mm)}{ state (0-)} 
#'   \item{actual_evapotranspiration (mm)}{actual evapotranspiration state (0-)} 
#'   \item{actual_evaporation (mm)}{actual evaporation state (0-)} 
#'   \item{actual_transpiration (mm)}{actual transpiration state (0-)} 
#'   \item{surface_water_storage (mm)}{Simulates a virtual layer that contains the surface water state (0-)} 
#'   \item{soil_moisture (m3/m3)}{soil moisture array state (-)} 
#' }
#' @export
model_evapotranspiration <- function (evaporation_zeta,
         maximum_evaporation_impact_depth,
         evaporation_reduction_method,
         xsa_critical_soil_moisture,
         no_of_soil_layers,
         no_of_soil_moisture_layers,
         layer_thickness,
         permanent_wilting_point,
         field_capacity,
         kc_factor,
         has_snow_cover,
         developmental_stage,
         crop_transpiration,
         crop_evaporated_from_intercepted,
         percentage_soil_coverage,
         potential_evapotranspiration,
         surface_water_storage,
         evaporated_from_surface,
         actual_evaporation,
         actual_transpiration,
         soil_moisture,
         evaporation,
         transpiration,
         evapotranspiration,
         actual_evapotranspiration){
    evaporated_from_intercept <- 0.0
    if (developmental_stage > 0)
    {
        evaporated_from_intercept <- crop_evaporated_from_intercepted
    }
    else
    {
        evaporated_from_intercept <- 0.0
    }
    evaporated_from_surface <- 0.0
    actual_evaporation <- 0.0
    actual_transpiration <- 0.0
    evaporation_from_surface <- FALSE
    eRed1 <- 0.0
    eRed2 <- 0.0
    eRed3 <- 0.0
    eReducer <- 0.0
    i <- 0
    if (potential_evapotranspiration > 0.0)
    {
        evaporation_from_surface <- FALSE
        if (surface_water_storage > 0.0)
        {
            evaporation_from_surface <- TRUE
            potential_evapotranspiration <- potential_evapotranspiration * (1.1 / kc_factor)
            if (has_snow_cover)
            {
                evaporated_from_surface <- 0.0
            }
            else if ( surface_water_storage < potential_evapotranspiration)
            {
                potential_evapotranspiration <- potential_evapotranspiration - surface_water_storage
                evaporated_from_surface <- surface_water_storage
                surface_water_storage <- 0.0
            }
            else
            {
                surface_water_storage <- surface_water_storage - potential_evapotranspiration
                evaporated_from_surface <- potential_evapotranspiration
                potential_evapotranspiration <- 0.0
            }
            potential_evapotranspiration <- potential_evapotranspiration * (kc_factor / 1.1)
        }
        if (potential_evapotranspiration > 0.0)
        {
            for( i in seq(0, no_of_soil_layers-1, 1)){
                eRed1 <- e_reducer_1(permanent_wilting_point[i+1], field_capacity[i+1], soil_moisture[i+1], percentage_soil_coverage, potential_evapotranspiration, evaporation_reduction_method, xsa_critical_soil_moisture)
                eRed2 <- 0.0
                if (as.double(i) >= maximum_evaporation_impact_depth)
                {
                    eRed2 <- 0.0
                }
                else
                {
                    eRed2 <- get_deprivation_factor(i + 1, maximum_evaporation_impact_depth, evaporation_zeta, layer_thickness[i+1])
                }
                eRed3 <- 0.0
                if (i > 0 && soil_moisture[i+1] < soil_moisture[i - 1+1])
                {
                    eRed3 <- 0.1
                }
                else
                {
                    eRed3 <- 1.0
                }
                eReducer <- eRed1 * eRed2 * eRed3
                if (developmental_stage > 0)
                {
                    if (percentage_soil_coverage >= 0.0 && percentage_soil_coverage < 1.0)
                    {
                        evaporation[i+1] <- (1.0 - percentage_soil_coverage) * eReducer * potential_evapotranspiration
                    }
                    else if ( percentage_soil_coverage >= 1.0)
                    {
                        evaporation[i+1] <- 0.0
                    }
                    if (has_snow_cover)
                    {
                        evaporation[i+1] <- 0.0
                    }
                    transpiration[i+1] <- crop_transpiration[i+1]
                    if (evaporation_from_surface)
                    {
                        transpiration[i+1] <- percentage_soil_coverage * eReducer * potential_evapotranspiration
                    }
                }
                else
                {
                    if (has_snow_cover)
                    {
                        evaporation[i+1] <- 0.0
                    }
                    else
                    {
                        evaporation[i+1] <- potential_evapotranspiration * eReducer
                    }
                    transpiration[i+1] <- 0.0
                }
                evapotranspiration[i+1] <- evaporation[i+1] + transpiration[i+1]
                soil_moisture[i+1] <- soil_moisture[i+1] - (evapotranspiration[i+1] / 1000.0 / layer_thickness[i+1])
                if (soil_moisture[i+1] < 0.01)
                {
                    soil_moisture[i+1] <- 0.01
                }
                actual_transpiration <- actual_transpiration + transpiration[i+1]
                actual_evaporation <- actual_evaporation + evaporation[i+1]
            }
        }
    }
    actual_evapotranspiration <- actual_transpiration + actual_evaporation + evaporated_from_intercept + evaporated_from_surface
    return (list ("evaporated_from_surface" = evaporated_from_surface,"actual_evapotranspiration" = actual_evapotranspiration,"actual_evaporation" = actual_evaporation,"actual_transpiration" = actual_transpiration,"surface_water_storage" = surface_water_storage,"soil_moisture" = soil_moisture))
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

get_deprivation_factor <- function (layer_no,
         deprivation_depth,
         zeta,
         layer_thickness){
    ltf <- 0.0
    ltf <- deprivation_depth / (layer_thickness * 10.0)
    deprivation_factor <- 0.0
    c2 <- 0.0
    c3 <- 0.0
    if (abs(zeta) < 0.0003)
    {
        deprivation_factor <- 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no - 1))
    }
    else
    {
        c2 <- log((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))))
        c3 <- zeta / (ltf * (zeta + 1.0))
        deprivation_factor <- (c2 - c3) / (log(zeta + 1.0) - (zeta / (zeta + 1.0)))
    }
    return( deprivation_factor)
}

e_reducer_1 <- function (pwp,
         fc,
         sm,
         percentage_soil_coverage,
         reference_evapotranspiration,
         evaporation_reduction_method,
         xsa_critical_soil_moisture){
    sm <- max(0.33 * pwp, sm)
    relative_evaporable_water <- 0.0
    relative_evaporable_water <- min(1.0, (sm - (0.33 * pwp)) / (fc - (0.33 * pwp)))
    e_reduction_factor <- 0.0
    critical_soil_moisture <- 0.0
    reducer <- 0.0
    xsa <- 0.0
    if (evaporation_reduction_method == 0)
    {
        critical_soil_moisture <- 0.65 * fc
        if (percentage_soil_coverage > 0.0)
        {
            reducer <- 1.0
            if (reference_evapotranspiration > 2.5)
            {
                xsa <- (0.65 * fc - pwp) * (fc - pwp)
                reducer <- xsa + ((1 - xsa) / 17.5 * (reference_evapotranspiration - 2.5))
            }
            else
            {
                reducer <- xsa_critical_soil_moisture / 2.5 * reference_evapotranspiration
            }
            critical_soil_moisture <- fc * reducer
        }
        if (sm > critical_soil_moisture)
        {
            e_reduction_factor <- 1.0
        }
        else if ( sm > (0.33 * pwp))
        {
            e_reduction_factor <- relative_evaporable_water
        }
        else
        {
            e_reduction_factor <- 0.0
        }
    }
    else
    {
        if (relative_evaporable_water > 0.33)
        {
            e_reduction_factor <- 1.0 - (0.1 * (1.0 - relative_evaporable_water) / (1.0 - 0.33))
        }
        else if ( relative_evaporable_water > 0.22)
        {
            e_reduction_factor <- 0.9 - (0.625 * (0.33 - relative_evaporable_water) / (0.33 - 0.22))
        }
        else if ( relative_evaporable_water > 0.2)
        {
            e_reduction_factor <- 0.275 - (0.225 * (0.22 - relative_evaporable_water) / (0.22 - 0.2))
        }
        else
        {
            e_reduction_factor <- 0.05 - (0.05 * (0.2 - relative_evaporable_water) / 0.2)
        }
    }
    return( e_reduction_factor)
}