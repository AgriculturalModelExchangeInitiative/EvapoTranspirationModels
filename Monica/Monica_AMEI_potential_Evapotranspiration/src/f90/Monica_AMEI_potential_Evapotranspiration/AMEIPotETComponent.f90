MODULE Ameipotetmod
    USE Saturationvaporpressuredeficitmod
    USE Referenceevapotranspirationmod
    USE Potentialevapotranspirationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_ameipotet(vapor_pressure, &
        saturated_vapor_pressure, &
        height_nn, &
        mean_air_temperature, &
        wind_speed, &
        wind_speed_height, &
        stomata_resistance, &
        net_radiation, &
        kc_factor, &
        developmental_stage, &
        crop_remaining_evapotranspiration, &
        reference_evapotranspiration, &
        potential_evapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: vapor_pressure
        REAL, INTENT(IN) :: saturated_vapor_pressure
        REAL, INTENT(IN) :: height_nn
        REAL, INTENT(IN) :: mean_air_temperature
        REAL, INTENT(IN) :: wind_speed
        REAL, INTENT(IN) :: wind_speed_height
        REAL, INTENT(IN) :: stomata_resistance
        REAL, INTENT(IN) :: net_radiation
        REAL, INTENT(IN) :: kc_factor
        INTEGER, INTENT(IN) :: developmental_stage
        REAL, INTENT(IN) :: crop_remaining_evapotranspiration
        REAL:: saturation_vapor_pressure_deficit
        REAL, INTENT(OUT) :: reference_evapotranspiration
        REAL:: potential_evapotranspiration_cap
        REAL, INTENT(OUT) :: potential_evapotranspiration
        !- Name: AMEIPotET -Version: 1, -Time step: 1
        !- Description:
    !            * Title: AMEI ET MONICA potential evapotranspiration model
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: Calculates the MONICA potential evapotranspiration for AMEI ET exercise
        !- inputs:
    !            * name: vapor_pressure
    !                          ** description : vapor pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : kPa
    !            * name: saturated_vapor_pressure
    !                          ** description : saturated vapor pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
    !            * name: height_nn
    !                          ** description : height above sea level
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : -9999
    !                          ** default : 0
    !                          ** unit : m
    !            * name: mean_air_temperature
    !                          ** description : daily average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: wind_speed
    !                          ** description : wind speed measured at wind speed height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : m/s
    !            * name: wind_speed_height
    !                          ** description : height at which the wind speed has been measured
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : -9999
    !                          ** default : 2
    !                          ** unit : m
    !            * name: stomata_resistance
    !                          ** description : stomata resistance (FAO default value is 100)
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 100
    !                          ** unit : s/m
    !            * name: net_radiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: kc_factor
    !                          ** description : crop coefficient ETc/ET0
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0.75
    !                          ** unit : dimensionless
    !            * name: developmental_stage
    !                          ** description : MONICA crop developmental stage
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 6
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : dimensionless
    !            * name: crop_remaining_evapotranspiration
    !                          ** description : crop remaining evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
        !- outputs:
    !            * name: reference_evapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: potential_evapotranspiration
    !                          ** description : the potential evapotranspiration
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
        call model_saturationvaporpressuredeficit(saturated_vapor_pressure,  &
                vapor_pressure,saturation_vapor_pressure_deficit)
        call model_referenceevapotranspiration(height_nn,  &
                mean_air_temperature, wind_speed, wind_speed_height, net_radiation,  &
                stomata_resistance,  &
                saturation_vapor_pressure_deficit,reference_evapotranspiration)
        call  &
                model_potentialevapotranspiration(potential_evapotranspiration_cap,  &
                kc_factor, developmental_stage, crop_remaining_evapotranspiration,  &
                reference_evapotranspiration,potential_evapotranspiration)
    END SUBROUTINE model_ameipotet

END MODULE
