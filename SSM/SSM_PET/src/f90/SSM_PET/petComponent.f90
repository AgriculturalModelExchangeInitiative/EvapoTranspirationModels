MODULE Petmod
    USE Potentialevapotranspirationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_pet(tmax, &
        tmin, &
        srad, &
        etlai, &
        ket, &
        calb, &
        salb, &
        pet)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: tmax
        REAL, INTENT(IN) :: tmin
        REAL, INTENT(IN) :: srad
        REAL, INTENT(IN) :: etlai
        REAL, INTENT(IN) :: ket
        REAL, INTENT(IN) :: calb
        REAL, INTENT(IN) :: salb
        REAL, INTENT(OUT) :: pet
        !- Name: pet -Version: 0.1, -Time step: 1
        !- Description:
    !            * Title: PET
    !            * Authors: -
    !            * Reference: None
    !            * Institution: -
    !            * ExtendedDescription: Computes daily potential evapotranspiration (PET, mm d-1) following Soltani & Sinclair (2012) using an equilibrium evaporation (EEQ) term adjusted by temperature-dependent multipliers. Average daytime temperature is TD = 0.6·Tmax + 0.4·Tmin. The surface albedo blends crop and soil albedos weighted by the fraction of surface energy reaching soil, exp(−KET·ETLAI): ALBEDO = CALB·(1 − exp(−KET·ETLAI)) + SALB·exp(−KET·ETLAI). EEQ is then EEQ = SRAD·(0.004876 − 0.004374·ALBEDO)·(TD + 29). PET is derived from EEQ with three regimes: PET = 1.1·EEQ for 5 < Tmax < 34; PET = EEQ·((Tmax − 34)·0.05 + 1.1) for Tmax ≥ 34 (advection); PET = EEQ·0.01·exp(0.18·(Tmax + 20)) for Tmax ≤ 5 (cold/frozen conditions). The uncovered-soil fraction follows the Beer–Bouguer–Lambert law via ETLAI and KET. Methodology relates to Priestley–Taylor (1972) and the modifications summarized by Ritchie (1998) as presented in Soltani & Sinclair (2012).
    !            * ShortDescription: PET component using EEQ with Beer–Lambert canopy attenuation and temperature-based modifiers per Soltani & Sinclair (2012).
        !- inputs:
    !            * name: tmax
    !                          ** description : Daily maximum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !                          ** uri : -
    !            * name: tmin
    !                          ** description : Daily minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !                          ** uri : -
    !            * name: srad
    !                          ** description : Daily solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : MJ m-2 day-1
    !                          ** uri : -
    !            * name: etlai
    !                          ** description : Leaf area index effective in evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : m2 m-2
    !                          ** uri : -
    !            * name: ket
    !                          ** description : Extinction coefficient for canopy
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 2.
    !                          ** min : 0.1
    !                          ** default : 0.5
    !                          ** unit : -
    !                          ** uri : -
    !            * name: calb
    !                          ** description : Crop albedo
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1.
    !                          ** min : 0.
    !                          ** default : 0.23
    !                          ** unit : -
    !                          ** uri : -
    !            * name: salb
    !                          ** description : Soil albedo
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1.
    !                          ** min : 0.
    !                          ** default : 0.13
    !                          ** unit : -
    !                          ** uri : -
        !- outputs:
    !            * name: pet
    !                          ** description : Potential evapotranspiration
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm day-1
    !                          ** uri : -
        call model_potentialevapotranspiration(tmax, tmin, srad, etlai, ket,  &
                calb, salb,pet)
    END SUBROUTINE model_pet

END MODULE
