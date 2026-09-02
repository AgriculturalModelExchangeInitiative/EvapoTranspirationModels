MODULE Ptsoilmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_ptsoil(ih, &
        Alpha, &
        tauAlpha, &
        evapoTranspirationPriestlyTaylor, &
        tau, &
        energyLimitedEvaporation)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: Alpha
        REAL, INTENT(IN) :: tauAlpha
        REAL, INTENT(IN) :: evapoTranspirationPriestlyTaylor
        REAL, INTENT(IN) :: tau
        REAL, INTENT(OUT) :: energyLimitedEvaporation
        REAL:: AlphaE
        !- Name: PtSoil -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: PtSoil EnergyLimitedEvaporation Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: Evaporation from the soil in the energy-limited stage
    !            * ShortDescription: Evaporation from the soil in the energy-limited stage
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
    !            * name: Alpha
    !                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 1.5
    !                          ** unit : 
    !            * name: tauAlpha
    !                          ** description : Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.3
    !                          ** unit : 
    !            * name: evapoTranspirationPriestlyTaylor
    !                          ** description : evapoTranspiration Priestly Taylor
    !                          ** inputtype : variable
    !                          ** variablecategory : rate
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 120
    !                          ** unit : g m-2 d-1
    !            * name: tau
    !                          ** description : soil cover factor
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 120
    !                          ** unit : 
        !- outputs:
    !            * name: energyLimitedEvaporation
    !                          ** description : energy Limited Evaporation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        IF(ih .EQ. -999) THEN
            IF(tau .LT. tauAlpha) THEN
                AlphaE = 1.00
            ELSE
                AlphaE = Alpha - ((Alpha - 1.00) * (1.00 - tau) / (1.00 - tauAlpha))
            END IF
            energyLimitedEvaporation = evapoTranspirationPriestlyTaylor / Alpha *  &
                    AlphaE * tau
        ELSE
            energyLimitedEvaporation = 0.00
        END IF
    END SUBROUTINE model_ptsoil

END MODULE
