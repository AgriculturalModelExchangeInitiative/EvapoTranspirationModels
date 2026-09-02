MODULE Diffusionlimitedevaporationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_diffusionlimitedevaporation(soilDiffusionConstant, &
        ih, &
        deficitOnTopLayers, &
        diffusionLimitedEvaporation)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: soilDiffusionConstant
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: deficitOnTopLayers
        REAL, INTENT(OUT) :: diffusionLimitedEvaporation
        !- Name: DiffusionLimitedEvaporation -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: DiffusionLimitedEvaporation Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: the evaporation from the diffusion limited soil
    !            * ShortDescription: It calculates the diffusion limited evaropration
    !
        !- inputs:
    !            * name: soilDiffusionConstant
    !                          ** description : soil Diffusion Constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 4.2
    !                          ** unit : 
    !            * name: ih
    !                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    !                          ** inputtype : variable
    !                          ** parametercategory : state
    !                          ** datatype : INT
    !                          ** max : 24
    !                          ** min : 999
    !                          ** default : 999
    !                          ** unit : 
    !            * name: deficitOnTopLayers
    !                          ** description : deficit On TopLayers
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 5341
    !                          ** unit : g m-2 d-1
        !- outputs:
    !            * name: diffusionLimitedEvaporation
    !                          ** description : the evaporation from the diffusion limited soil
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        IF(ih .EQ. -999) THEN
            IF(deficitOnTopLayers / 1000.00 .LE. 0.00) THEN
                diffusionLimitedEvaporation = 8.30 * 1000.00
            ELSE
                IF(deficitOnTopLayers / 1000.00 .LT. 25.00) THEN
                    diffusionLimitedEvaporation = 2.00 * soilDiffusionConstant *  &
                            soilDiffusionConstant / (deficitOnTopLayers / 1000.00) * 1000.00
                ELSE
                    diffusionLimitedEvaporation = 0.00
                END IF
            END IF
        ELSE
            diffusionLimitedEvaporation = 0.00
        END IF
    END SUBROUTINE model_diffusionlimitedevaporation

END MODULE
