MODULE Useextvaporpressuremod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_useextvaporpressure(use_external_vapor_pressure, &
        external_vapor_pressure, &
        internal_vapor_pressure, &
        vapor_pressure)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        LOGICAL, INTENT(IN) :: use_external_vapor_pressure
        REAL, INTENT(IN) :: external_vapor_pressure
        REAL, INTENT(IN) :: internal_vapor_pressure
        REAL, INTENT(OUT) :: vapor_pressure
        !- Name: UseExtVaporPressure -Version: 1, -Time step: 1
        !- Description:
    !            * Title: If Else unit 
    !            * Authors: Michael Berg-Mohnicke
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: switches between two input values 
        !- inputs:
    !            * name: use_external_vapor_pressure
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : mm
    !            * name: external_vapor_pressure
    !                          ** description : value to be returned if condition is true
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : kPa
    !            * name: internal_vapor_pressure
    !                          ** description : value to be returned if condition is false
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : kPa
        !- outputs:
    !            * name: vapor_pressure
    !                          ** description : the output value
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
        IF(use_external_vapor_pressure) THEN
            vapor_pressure = external_vapor_pressure
        ELSE
            vapor_pressure = internal_vapor_pressure
        END IF
    END SUBROUTINE model_useextvaporpressure

END MODULE
