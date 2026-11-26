library(gsubfn)

#' If Else unit 
#'
#' This function compute the If Else unit 
#' @param use_external_et0 () boolean condition to be met auxiliary (false, None-None) 
#' @param external_et0 (mm) value to be returned if condition is true auxiliary (0, 0-) 
#' @param internal_et0 (mm) value to be returned if condition is false auxiliary (0, 0-) 
#'
#' @return
#' \describe{
#'   \item{et0 (mm)}{the output value auxiliary (0-)} 
#' }
#' @export
model_useextet0 <- function (use_external_et0,
         external_et0,
         internal_et0){
    et0 <- 0.0
    if (use_external_et0)
    {
        et0 <- external_et0
    }
    else
    {
        et0 <- internal_et0
    }
    return (list('et0' = et0))
}