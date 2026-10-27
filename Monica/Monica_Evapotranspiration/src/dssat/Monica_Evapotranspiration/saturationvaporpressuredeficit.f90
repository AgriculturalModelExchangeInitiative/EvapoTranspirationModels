MODULE Saturationvaporpressuredeficitmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_saturationvaporpressuredeficit(saturated_vapor_pressure, &
        vapor_pressure, &
        saturation_vapor_pressure_deficit)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: saturated_vapor_pressure
        REAL, INTENT(IN) :: vapor_pressure
        REAL, INTENT(OUT) :: saturation_vapor_pressure_deficit
        !- Name: SaturationVaporPressureDeficit -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA saturation vapor pressure deficit
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: 
    !        
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: 
    !        
    !            * ShortDescription: Calculates saturation vapor pressure deficit as in the MONICA model
        !- inputs:
    !            * name: saturated_vapor_pressure
    !                          ** description : saturated vapor pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
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
    !            * name: saturation_vapor_pressure_deficit
    !                          ** description : saturation vapor pressure deficit
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
        saturation_vapor_pressure_deficit = saturated_vapor_pressure -  &
                vapor_pressure
    END SUBROUTINE model_saturationvaporpressuredeficit

END MODULE
