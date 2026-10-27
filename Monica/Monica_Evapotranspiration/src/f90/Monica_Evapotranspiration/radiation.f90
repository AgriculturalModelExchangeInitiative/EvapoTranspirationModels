MODULE Radiationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_radiation(latitude, &
        global_radiation, &
        julian_day, &
        sunshine_hours, &
        declination, &
        astronomic_daylength, &
        effective_daylength, &
        photoperiodic_daylength, &
        sunshine_hours_global_radiation, &
        extraterrestrial_radiation, &
        clear_day_radiation, &
        overcast_day_radiation, &
        phot_act_radiation_mean)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: latitude
        REAL, INTENT(IN) :: global_radiation
        INTEGER, INTENT(IN) :: julian_day
        REAL, INTENT(IN) :: sunshine_hours
        REAL, INTENT(OUT) :: declination
        REAL, INTENT(OUT) :: astronomic_daylength
        REAL, INTENT(OUT) :: effective_daylength
        REAL, INTENT(OUT) :: photoperiodic_daylength
        REAL, INTENT(OUT) :: sunshine_hours_global_radiation
        REAL, INTENT(OUT) :: extraterrestrial_radiation
        REAL, INTENT(OUT) :: clear_day_radiation
        REAL, INTENT(OUT) :: overcast_day_radiation
        REAL, INTENT(OUT) :: phot_act_radiation_mean
        REAL:: decl_sin
        REAL:: decl_cos
        REAL:: arg_phot_act
        REAL:: solar_constant
        REAL:: SC
        REAL:: solar_angle
        REAL:: sunset_solar_angle
        !- Name: Radiation -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA radiation calculations
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: 
    !            Taken from the original HERMES model, Kersebaum, K.C. and Richter J.
    !            (1991): Modelling nitrogen dynamics in a plant-soil system with a
    !            simple model for advisory purposes. Fert. Res. 27 (2-3), 273 - 281.
    !        
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: 
    !        
    !            * ShortDescription: Calculates the MONICA reference evapotranspiration
        !- inputs:
    !            * name: latitude
    !                          ** description : latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 90
    !                          ** min : -90
    !                          ** default : 0
    !                          ** unit : degree
    !            * name: global_radiation
    !                          ** description : global radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : MJ/m2
    !            * name: julian_day
    !                          ** description : day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 366
    !                          ** min : 1
    !                          ** default : 1
    !                          ** unit : day
    !            * name: sunshine_hours
    !                          ** description : number of sunshine hours
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : h
        !- outputs:
    !            * name: declination
    !                          ** description : declination
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : 
    !            * name: astronomic_daylength
    !                          ** description : astronomic_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: effective_daylength
    !                          ** description : effective_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: photoperiodic_daylength
    !                          ** description : photoperiodic_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: sunshine_hours_global_radiation
    !                          ** description : global radiation calculated from sunshine hours
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: extraterrestrial_radiation
    !                          ** description : extraterrestrial_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: clear_day_radiation
    !                          ** description : clear_day_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: overcast_day_radiation
    !                          ** description : overcast_day_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: phot_act_radiation_mean
    !                          ** description : phot_act_radiation_mean
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : J/m2
        call calc_declinations(latitude,  &
                julian_day,declination,decl_sin,decl_cos)
        astronomic_daylength = calc_astronomic_daylength(latitude, julian_day)
        effective_daylength = calc_effective_daylength(latitude, julian_day)
        photoperiodic_daylength = calc_photoperiodic_daylength(latitude,  &
                julian_day)
        arg_phot_act = MIN(1.0, decl_sin / decl_cos * (decl_sin / decl_cos))
        phot_act_radiation_mean = 3600.0 * (decl_sin * astronomic_daylength +  &
                (24.0 / 3.14159265 * decl_cos * SQRT((1.0 - arg_phot_act))))
        IF(phot_act_radiation_mean .GT. 0.0 .AND. astronomic_daylength .GT.  &
                0.0) THEN
            clear_day_radiation = 0.5 * 1300.0 * phot_act_radiation_mean *  &
                    EXP((-0.14) / (phot_act_radiation_mean / (astronomic_daylength *  &
                    3600.0)))
        END IF
        overcast_day_radiation = 0.2 * clear_day_radiation
        solar_constant = 0.082
        SC = 24.0 * 60.0 / 3.14159265 * solar_constant * (1.0 + (0.033 *  &
                COS(2.0 * 3.14159265 * julian_day / 365.0)))
        solar_angle = (-TAN(latitude * 3.14159265 / 180.0)) * TAN(declination  &
                * 3.14159265 / 180.0)
        solar_angle = bound(-1.0, solar_angle, 1.0)
        sunset_solar_angle = ACOS(solar_angle)
        extraterrestrial_radiation = SC * (sunset_solar_angle * decl_sin +  &
                (decl_cos * SIN(sunset_solar_angle)))
        IF(sunshine_hours .GT. 0.0) THEN
            IF(global_radiation .LE. 0.0 .AND. astronomic_daylength .GT. 0.0) THEN
                sunshine_hours_global_radiation = extraterrestrial_radiation * (0.19  &
                        + (0.55 * sunshine_hours / astronomic_daylength))
            ELSE
                sunshine_hours_global_radiation = 0.0
            END IF
        END IF
    END SUBROUTINE model_radiation

    FUNCTION bound(lower, &
        value, &
        upper) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: lower
        REAL, INTENT(IN) :: value
        REAL, INTENT(IN) :: upper
        REAL:: res_cyml
        IF(value .LT. lower) THEN
            res_cyml = lower
            RETURN
        END IF
        IF(value .GT. upper) THEN
            res_cyml = upper
            RETURN
        END IF
        res_cyml = value
        RETURN
    END FUNCTION bound

    SUBROUTINE calc_declinations(latitude, &
        julian_day, &
        declination, &
        decl_sin, &
        decl_cos)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: latitude
        INTEGER, INTENT(IN) :: julian_day
        REAL, INTENT(OUT) :: declination
        REAL, INTENT(OUT) :: decl_sin
        REAL, INTENT(OUT) :: decl_cos
        declination = (-23.4) * COS(2.0 * 3.14159265 * ((julian_day + 10.0) /  &
                365.0))
        decl_sin = SIN(declination * 3.14159265 / 180.0) * SIN(latitude *  &
                3.14159265 / 180.0)
        decl_cos = COS(declination * 3.14159265 / 180.0) * COS(latitude *  &
                3.14159265 / 180.0)
    END SUBROUTINE calc_declinations

    FUNCTION calc_astronomic_daylength(latitude, &
        julian_day) RESULT(astronomic_daylength)
        IMPLICIT NONE
        REAL, INTENT(IN) :: latitude
        INTEGER, INTENT(IN) :: julian_day
        REAL:: astronomic_daylength
        REAL:: declination
        REAL:: decl_sin
        REAL:: decl_cos
        REAL:: astro_daylength
        REAL:: res_cyml
        call calc_declinations(latitude,  &
                julian_day,declination,decl_sin,decl_cos)
        astro_daylength = decl_sin / decl_cos
        astro_daylength = bound(-1.0, astro_daylength, 1.0)
        astronomic_daylength = 12.0 * (3.14159265 + (2.0 *  &
                ASIN(astro_daylength))) / 3.14159265
    END FUNCTION calc_astronomic_daylength

    FUNCTION calc_effective_daylength(latitude, &
        julian_day) RESULT(effective_daylength)
        IMPLICIT NONE
        REAL, INTENT(IN) :: latitude
        INTEGER, INTENT(IN) :: julian_day
        REAL:: effective_daylength
        REAL:: declination
        REAL:: decl_sin
        REAL:: decl_cos
        REAL:: eff_daylength
        REAL:: res_cyml
        call calc_declinations(latitude,  &
                julian_day,declination,decl_sin,decl_cos)
        eff_daylength = (-SIN(8.0 * 3.14159265 / 180.0) + decl_sin) / decl_cos
        eff_daylength = bound(-1.0, eff_daylength, 1.0)
        effective_daylength = 12.0 * (3.14159265 + (2.0 *  &
                ASIN(eff_daylength))) / 3.14159265
    END FUNCTION calc_effective_daylength

    FUNCTION calc_photoperiodic_daylength(latitude, &
        julian_day) RESULT(photoperiodic_daylength)
        IMPLICIT NONE
        REAL, INTENT(IN) :: latitude
        INTEGER, INTENT(IN) :: julian_day
        REAL:: photoperiodic_daylength
        REAL:: declination
        REAL:: decl_sin
        REAL:: decl_cos
        REAL:: photo_daylength
        REAL:: res_cyml
        call calc_declinations(latitude,  &
                julian_day,declination,decl_sin,decl_cos)
        photo_daylength = (-SIN((-6.0) * 3.14159265 / 180.0) + decl_sin) /  &
                decl_cos
        photo_daylength = bound(-1.0, photo_daylength, 1.0)
        photoperiodic_daylength = 12.0 * (3.14159265 + (2.0 *  &
                ASIN(photo_daylength))) / 3.14159265
    END FUNCTION calc_photoperiodic_daylength

END MODULE
