MODULE Netradiationequivalentevaporationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_netradiationequivalentevaporation(netRadiation, &
        lambdaV, &
        netRadiationEquivalentEvaporation)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: netRadiation
        REAL, INTENT(IN) :: lambdaV
        REAL, INTENT(OUT) :: netRadiationEquivalentEvaporation
        !- Name: NetRadiationEquivalentEvaporation -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: NetRadiationEquivalentEvaporation Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: It is given by dividing net radiation by latent heat of vaporization of water
    !            * ShortDescription: It is given by dividing net radiation by latent heat of vaporization of water
        !- inputs:
    !            * name: netRadiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** default : 1.566
    !                          ** unit : MJ m-2 d-1
    !            * name: lambdaV
    !                          ** description : latent heat of vaporization of water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2.454
    !                          ** unit : MJ kg-1
        !- outputs:
    !            * name: netRadiationEquivalentEvaporation
    !                          ** description : net Radiation in Equivalent Evaporation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        netRadiationEquivalentEvaporation = netRadiation / lambdaV * 1000.00
    END SUBROUTINE model_netradiationequivalentevaporation

END MODULE
