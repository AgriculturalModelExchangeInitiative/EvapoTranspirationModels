MODULE Potentialtranspirationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_potentialtranspiration(evapoTranspiration, &
        tau, &
        potentialTranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: evapoTranspiration
        REAL, INTENT(IN) :: tau
        REAL, INTENT(OUT) :: potentialTranspiration
        !- Name: PotentialTranspiration -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: PotentialTranspiration Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: SiriusQuality2 uses availability of water from the soil reservoir as a method to restrict
    !transpiration as soil moisture is depleted
    !            * ShortDescription: It uses the availability of water from the soil reservoir as a method to restrict
    !transpiration as soil moisture is depleted
        !- inputs:
    !            * name: evapoTranspiration
    !                          ** description : evapoTranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : rate
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 830.958
    !                          ** unit : mm
    !            * name: tau
    !                          ** description : plant cover factor
    !                          ** inputtype : parameter
    !                          ** parametercategory : species
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.9983
    !                          ** unit : 
        !- outputs:
    !            * name: potentialTranspiration
    !                          ** description : potential Transpiration
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : rate
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        potentialTranspiration = evapoTranspiration * (1.00 - tau)
    END SUBROUTINE model_potentialtranspiration

END MODULE
