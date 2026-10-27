MODULE Useextet0mod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_useextet0(use_external_et0, &
        external_et0, &
        internal_et0, &
        et0)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        LOGICAL, INTENT(IN) :: use_external_et0
        REAL, INTENT(IN) :: external_et0
        REAL, INTENT(IN) :: internal_et0
        REAL, INTENT(OUT) :: et0
        !- Name: UseExtET0 -Version: 1, -Time step: 1
        !- Description:
    !            * Title: If Else unit 
    !            * Authors: Michael Berg-Mohnicke
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: switches between two input values 
        !- inputs:
    !            * name: use_external_et0
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : 
    !            * name: external_et0
    !                          ** description : value to be returned if condition is true
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: internal_et0
    !                          ** description : value to be returned if condition is false
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
        !- outputs:
    !            * name: et0
    !                          ** description : the output value
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
        IF(use_external_et0) THEN
            et0 = external_et0
        ELSE
            et0 = internal_et0
        END IF
    END SUBROUTINE model_useextet0

END MODULE
