MODULE Saturatedvaporpressuremod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_saturatedvaporpressure(max_air_temperature, &
        min_air_temperature, &
        relative_humidity, &
        saturated_vapor_pressure, &
        vapor_pressure)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: max_air_temperature
        REAL, INTENT(IN) :: min_air_temperature
        REAL, INTENT(IN) :: relative_humidity
        REAL, INTENT(OUT) :: saturated_vapor_pressure
        REAL, INTENT(OUT) :: vapor_pressure
        REAL:: saturated_vapor_pressure_max
        REAL:: saturated_vapor_pressure_min
        !- Name: SaturatedVaporPressure -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA saturated vapor pressure
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: 
    !        
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: 
    !        
    !            * ShortDescription: Calculates saturated vapor pressure as in the MONICA model
        !- inputs:
    !            * name: max_air_temperature
    !                          ** description : daily maximum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: min_air_temperature
    !                          ** description : daily minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: relative_humidity
    !                          ** description : relative humidity
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : fraction
        !- outputs:
    !            * name: saturated_vapor_pressure
    !                          ** description : saturated vapor pressure
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
    !            * name: vapor_pressure
    !                          ** description : vapor pressure from relative humidity and saturated vapor pressure
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
        saturated_vapor_pressure_max = 0.6108 * EXP(17.27 *  &
                max_air_temperature / (237.3 + max_air_temperature))
        saturated_vapor_pressure_min = 0.6108 * EXP(17.27 *  &
                min_air_temperature / (237.3 + min_air_temperature))
        saturated_vapor_pressure = (saturated_vapor_pressure_max +  &
                saturated_vapor_pressure_min) / 2.0
        IF(relative_humidity .LE. 0.0) THEN
            vapor_pressure = saturated_vapor_pressure_min
        ELSE
            vapor_pressure = relative_humidity * saturated_vapor_pressure
        END IF
    END SUBROUTINE model_saturatedvaporpressure

END MODULE
