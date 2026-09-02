MODULE Priestlytaylormod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_priestlytaylor(ih, &
        psychrometricConstant, &
        netRadiationEquivalentEvaporation, &
        Alpha, &
        hslope, &
        solarRadiation, &
        evapoTranspirationPriestlyTaylor)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: psychrometricConstant
        REAL, INTENT(IN) :: netRadiationEquivalentEvaporation
        REAL, INTENT(IN) :: Alpha
        REAL, INTENT(IN) :: hslope
        REAL, INTENT(IN) :: solarRadiation
        REAL, INTENT(OUT) :: evapoTranspirationPriestlyTaylor
        REAL:: a_G_Rn
        !- Name: PriestlyTaylor -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: evapoTranspirationPriestlyTaylor  Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: Calculate Energy Balance
    !            * ShortDescription: It uses Priestly-Taylor method
        !- inputs:
    !            * name: ih
    !                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    !                          ** inputtype : variable
    !                          ** parametercategory : state
    !                          ** datatype : INT
    !                          ** max : 24
    !                          ** min : 999
    !                          ** default : 999
    !                          ** unit : 
    !            * name: psychrometricConstant
    !                          ** description : psychrometric constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.66
    !                          ** unit : 
    !            * name: netRadiationEquivalentEvaporation
    !                          ** description : net Radiation in Equivalent Evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** default : 638.142
    !                          ** unit : g m-2 d-1
    !            * name: Alpha
    !                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 1.5
    !                          ** unit : 
    !            * name: hslope
    !                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 0.584
    !                          ** unit : hPa degC-1
    !            * name: solarRadiation
    !                          ** description : solar Radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : MJ m-2 d-1
        !- outputs:
    !            * name: evapoTranspirationPriestlyTaylor
    !                          ** description : evapoTranspiration of Priestly Taylor
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : rate
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        a_G_Rn = 1.00
        IF(ih .NE. -999) THEN
            IF(solarRadiation .LT. 0.001) THEN
                a_G_Rn = 0.50
            ELSE
                a_G_Rn = 0.90
            END IF
        END IF
        evapoTranspirationPriestlyTaylor = MAX(Alpha * hslope *  &
                netRadiationEquivalentEvaporation * a_G_Rn / (hslope +  &
                psychrometricConstant), 0.00)
    END SUBROUTINE model_priestlytaylor

END MODULE
