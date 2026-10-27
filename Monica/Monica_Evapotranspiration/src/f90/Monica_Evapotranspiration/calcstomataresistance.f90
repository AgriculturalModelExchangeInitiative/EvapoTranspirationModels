MODULE Calcstomataresistancemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_calcstomataresistance(calc_stomata_resistance, &
        calculated_stomata_resistance, &
        fixed_stomata_resistance, &
        stomata_resistance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        LOGICAL, INTENT(IN) :: calc_stomata_resistance
        REAL, INTENT(IN) :: calculated_stomata_resistance
        REAL, INTENT(IN) :: fixed_stomata_resistance
        REAL, INTENT(OUT) :: stomata_resistance
        !- Name: CalcStomataResistance -Version: 1, -Time step: 1
        !- Description:
    !            * Title: If Else unit 
    !            * Authors: Michael Berg-Mohnicke
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: switches between two input values 
        !- inputs:
    !            * name: calc_stomata_resistance
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : 
    !            * name: calculated_stomata_resistance
    !                          ** description : value to be returned if condition is true
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 100
    !                          ** unit : s/m
    !            * name: fixed_stomata_resistance
    !                          ** description : value to be returned if condition is false
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 100
    !                          ** unit : s/m
        !- outputs:
    !            * name: stomata_resistance
    !                          ** description : the output value
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : s/m
        IF(calc_stomata_resistance) THEN
            stomata_resistance = calculated_stomata_resistance
        ELSE
            stomata_resistance = fixed_stomata_resistance
        END IF
    END SUBROUTINE model_calcstomataresistance

END MODULE
