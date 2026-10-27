MODULE Potentialevapotranspirationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_potentialevapotranspiration(potential_evapotranspiration_cap, &
        kc_factor, &
        developmental_stage, &
        crop_remaining_evapotranspiration, &
        reference_evapotranspiration, &
        potential_evapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: potential_evapotranspiration_cap
        REAL, INTENT(IN) :: kc_factor
        INTEGER, INTENT(IN) :: developmental_stage
        REAL, INTENT(IN) :: crop_remaining_evapotranspiration
        REAL, INTENT(IN) :: reference_evapotranspiration
        REAL, INTENT(OUT) :: potential_evapotranspiration
        !- Name: PotentialEvapotranspiration -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA potential evapotranspiration calculation
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: Calculates the MONICA potential evapotranspiration
        !- inputs:
    !            * name: potential_evapotranspiration_cap
    !                          ** description : cap ET0 to this value
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 6.5
    !                          ** unit : mm
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
    !            * name: reference_evapotranspiration
    !                          ** description : ET0 either from external ET0 or crop specific ET0
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
        !- outputs:
    !            * name: potential_evapotranspiration
    !                          ** description : the potential evapotranspiration
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
        IF(developmental_stage .GT. 0) THEN
            potential_evapotranspiration = crop_remaining_evapotranspiration
        ELSE
            potential_evapotranspiration = reference_evapotranspiration *  &
                    kc_factor
        END IF
        IF(potential_evapotranspiration .GT.  &
                potential_evapotranspiration_cap) THEN
            potential_evapotranspiration = potential_evapotranspiration_cap
        END IF
    END SUBROUTINE model_potentialevapotranspiration

END MODULE
