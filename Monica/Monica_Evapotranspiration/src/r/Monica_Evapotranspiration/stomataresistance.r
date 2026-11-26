library(gsubfn)

#' MONICA stomata resistance
#'
#' This function compute the MONICA stomata resistance
#' @param saturation_beta () Original: Yu et al. 2001; beta = 3.5 constant (2.5, -) 
#' @param stomata_conductance_alpha (mmol/m2/s) Original: Yu et al. 2001; alpha = 0.06 mol/m2/s constant (40, -) 
#' @param carboxylation_pathway (dimensionless) Is it a C3 (=1) or C4 (=2) crop. (0 = no crop) constant (0, 0-2) 
#' @param atmospheric_co2_concentration (ppm) CO2 concentration in the atmosphere. Optional if no crop. exogenous (430, 0-) 
#' @param saturation_vapor_pressure_deficit (kPa) saturation_vapor_pressure_deficit auxiliary (0, 0-) 
#' @param gross_photosynthesis_reference_mol ([mol m-2 s-1] or [cm3 cm-2 s-1]) gross_photosynthesis_reference_mol (-1 = not supplied = no crop) auxiliary (-1, 0-) 
#'
#' @return
#' \describe{
#'   \item{stomata_resistance (s/m)}{stomata resistance (FAO default value is 100) auxiliary (0-)} 
#' }
#' @export
model_stomataresistance <- function (saturation_beta,
         stomata_conductance_alpha,
         carboxylation_pathway,
         atmospheric_co2_concentration,
         saturation_vapor_pressure_deficit,
         gross_photosynthesis_reference_mol){
    stomata_resistance <- 0.0
    if (carboxylation_pathway > 0)
    {
        if (gross_photosynthesis_reference_mol <= 0.0)
        {
            stomata_resistance <- 999999.9
        }
        else if ( carboxylation_pathway == 1)
        {
            stomata_resistance <- atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
        }
        else
        {
            stomata_resistance <- atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
        }
    }
    return (list('stomata_resistance' = stomata_resistance))
}