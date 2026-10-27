MODULE Netradiationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_netradiation(height_nn, &
        reference_albedo, &
        global_radiation, &
        max_air_temperature, &
        min_air_temperature, &
        extraterrestrial_radiation, &
        vapor_pressure, &
        net_radiation)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: height_nn
        REAL, INTENT(IN) :: reference_albedo
        REAL, INTENT(IN) :: global_radiation
        REAL, INTENT(IN) :: max_air_temperature
        REAL, INTENT(IN) :: min_air_temperature
        REAL, INTENT(IN) :: extraterrestrial_radiation
        REAL, INTENT(IN) :: vapor_pressure
        REAL, INTENT(OUT) :: net_radiation
        REAL:: clear_sky_solar_radiation
        REAL:: relative_shortwave_radiation
        REAL:: bolzmann_constant
        REAL:: shortwave_radiation
        REAL:: longwave_radiation
        bolzmann_constant = 0.0000000049
        !- Name: NetRadiation -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA net radiation calculation
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: 
    !        
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: 
    !        
    !            * ShortDescription: None
        !- inputs:
    !            * name: height_nn
    !                          ** description : height above sea level
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : -9999
    !                          ** default : 0
    !                          ** unit : m
    !            * name: reference_albedo
    !                          ** description : reference albedo
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : dimensionless
    !            * name: global_radiation
    !                          ** description : global radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : MJ/m2
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
    !            * name: extraterrestrial_radiation
    !                          ** description : extraterrestrial_radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : MJ/m2
    !            * name: vapor_pressure
    !                          ** description : vapor pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : kPa
        !- outputs:
    !            * name: net_radiation
    !                          ** description : net_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
        clear_sky_solar_radiation = (0.75 + (0.00002 * height_nn)) *  &
                extraterrestrial_radiation
        IF (clear_sky_solar_radiation .GT. 0.0) THEN
            relative_shortwave_radiation=MIN(global_radiation /  &
                    clear_sky_solar_radiation, 1.0)
        ELSE
            relative_shortwave_radiation=1.0
        END IF
        shortwave_radiation = (1.0 - reference_albedo) * global_radiation
        longwave_radiation = bolzmann_constant * (( ((min_air_temperature +  &
                273.16) ** 4.0) +  ((max_air_temperature + 273.16) ** 4.0)) / 2.0) *  &
                (1.35 * relative_shortwave_radiation - 0.35) * (0.34 - (0.14 *  &
                SQRT(vapor_pressure)))
        net_radiation = shortwave_radiation - longwave_radiation
    END SUBROUTINE model_netradiation

END MODULE
