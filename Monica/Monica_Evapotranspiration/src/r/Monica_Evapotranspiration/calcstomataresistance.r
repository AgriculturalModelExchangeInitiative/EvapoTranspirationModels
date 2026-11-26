library(gsubfn)

#' If Else unit 
#'
#' This function compute the If Else unit 
#' @param calc_stomata_resistance () boolean condition to be met auxiliary (false, None-None) 
#' @param calculated_stomata_resistance (s/m) value to be returned if condition is true auxiliary (100, 0-10000) 
#' @param fixed_stomata_resistance (s/m) value to be returned if condition is false auxiliary (100, 0-10000) 
#'
#' @return
#' \describe{
#'   \item{stomata_resistance (s/m)}{the output value auxiliary (0-10000)} 
#' }
#' @export
model_calcstomataresistance <- function (calc_stomata_resistance,
         calculated_stomata_resistance,
         fixed_stomata_resistance){
    stomata_resistance <- 0.0
    if (calc_stomata_resistance)
    {
        stomata_resistance <- calculated_stomata_resistance
    }
    else
    {
        stomata_resistance <- fixed_stomata_resistance
    }
    return (list('stomata_resistance' = stomata_resistance))
}