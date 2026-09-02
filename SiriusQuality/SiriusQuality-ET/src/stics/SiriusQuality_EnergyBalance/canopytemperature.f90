MODULE Canopytemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_canopytemperature(minTair, &
        cropHeatFlux, &
        specificHeatCapacityAir, &
        conductance, &
        lambdaV, &
        rhoDensityAir, &
        maxTair, &
        maxCanopyTemperature, &
        minCanopyTemperature)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: minTair
        REAL, INTENT(IN) :: cropHeatFlux
        REAL, INTENT(IN) :: specificHeatCapacityAir
        REAL, INTENT(IN) :: conductance
        REAL, INTENT(IN) :: lambdaV
        REAL, INTENT(IN) :: rhoDensityAir
        REAL, INTENT(IN) :: maxTair
        REAL, INTENT(OUT) :: maxCanopyTemperature
        REAL, INTENT(OUT) :: minCanopyTemperature
        !- Name: CanopyTemperature -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: CanopyTemperature Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: It is calculated from the crop heat flux and the boundary layer conductance
    !            * ShortDescription: It is calculated from the crop heat flux and the boundary layer conductance
        !- inputs:
    !            * name: minTair
    !                          ** description : minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 45
    !                          ** min : 30
    !                          ** default : 0.7
    !                          ** unit : degC
    !            * name: cropHeatFlux
    !                          ** description : Crop heat flux
    !                          ** inputtype : variable
    !                          ** variablecategory : rate
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 447.912
    !                          ** unit : g/m**2/d
    !            * name: specificHeatCapacityAir
    !                          ** description : Specific heat capacity of dry air
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : None
    !                          ** min : None
    !                          ** default : 0.00101
    !                          ** unit : MJ/kg/degC
    !            * name: conductance
    !                          ** description : the boundary layer conductance
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 598.685
    !                          ** unit : m/d
    !            * name: lambdaV
    !                          ** description : latent heat of vaporization of water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2.454
    !                          ** unit : MJ/kg
    !            * name: rhoDensityAir
    !                          ** description : Density of air
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : None
    !                          ** min : None
    !                          ** default : 1.225
    !                          ** unit : kg/m**3
    !            * name: maxTair
    !                          ** description : maximum air Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 45
    !                          ** min : 30
    !                          ** default : 7.2
    !                          ** unit : degC
        !- outputs:
    !            * name: maxCanopyTemperature
    !                          ** description : maximal Canopy Temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 45
    !                          ** min : 30
    !                          ** unit : degC
    !            * name: minCanopyTemperature
    !                          ** description : minimal Canopy Temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 45
    !                          ** min : 30
    !                          ** unit : degC
        IF(minTair .EQ. REAL(999) .AND. maxTair .EQ. REAL(-999)) THEN
            minCanopyTemperature = REAL(999)
            maxCanopyTemperature = REAL(-999)
        ELSE
            minCanopyTemperature = minTair + (cropHeatFlux / (rhoDensityAir *  &
                    specificHeatCapacityAir * conductance / lambdaV * 1000.00))
            maxCanopyTemperature = maxTair + (cropHeatFlux / (rhoDensityAir *  &
                    specificHeatCapacityAir * conductance / lambdaV * 1000.00))
        END IF
    END SUBROUTINE model_canopytemperature

END MODULE
