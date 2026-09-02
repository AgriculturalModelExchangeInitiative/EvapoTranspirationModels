MODULE Netradiationmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_netradiation(albedoCoefficientCan, &
        vaporPressure, &
        stefanBoltzman, &
        maxTair, &
        solarRadiation, &
        ih, &
        minTair, &
        extraSolarRadiation, &
        tau, &
        elevation, &
        albedoCoefficient, &
        netOutGoingLongWaveRadiation, &
        netRadiation)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: albedoCoefficientCan
        REAL, INTENT(IN) :: vaporPressure
        REAL, INTENT(IN) :: stefanBoltzman
        REAL, INTENT(IN) :: maxTair
        REAL, INTENT(IN) :: solarRadiation
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: minTair
        REAL, INTENT(IN) :: extraSolarRadiation
        REAL, INTENT(IN) :: tau
        REAL, INTENT(IN) :: elevation
        REAL, INTENT(IN) :: albedoCoefficient
        REAL, INTENT(OUT) :: netOutGoingLongWaveRadiation
        REAL, INTENT(OUT) :: netRadiation
        REAL:: Nsr
        REAL:: clearSkySolarRadiation
        REAL:: averageT
        REAL:: surfaceEmissivity
        REAL:: cloudCoverFactor
        REAL:: Nolr
        REAL:: cov
        !- Name: NetRadiation -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: NetRadiation Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both short
    !and long wavelength radiation
    !            * ShortDescription: It refers as difference between incoming and outgoing radiation of both short
    !and long wavelength radiation
        !- inputs:
    !            * name: albedoCoefficientCan
    !                          ** description : albedo Coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.23
    !                          ** unit : 
    !            * name: vaporPressure
    !                          ** description : vapor Pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 6.1
    !                          ** unit : hPa
    !            * name: stefanBoltzman
    !                          ** description : stefan Boltzman constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 4.903E-09
    !                          ** unit : 
    !            * name: maxTair
    !                          ** description : maximum air Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 45
    !                          ** min : 30
    !                          ** default : 7.2
    !                          ** unit : degC
    !            * name: solarRadiation
    !                          ** description : solar Radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : MJ m-2 d-1
    !            * name: ih
    !                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    !                          ** inputtype : variable
    !                          ** parametercategory : state
    !                          ** datatype : INT
    !                          ** max : 24
    !                          ** min : 999
    !                          ** default : 999
    !                          ** unit : 
    !            * name: minTair
    !                          ** description : minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 45
    !                          ** min : 30
    !                          ** default : 0.7
    !                          ** unit : degC
    !            * name: extraSolarRadiation
    !                          ** description : extra Solar Radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 11.7
    !                          ** unit : MJ m2 d-1
    !            * name: tau
    !                          ** description : plant cover factor
    !                          ** inputtype : parameter
    !                          ** parametercategory : species
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 0.9983
    !                          ** unit : 
    !            * name: elevation
    !                          ** description : elevation
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 500
    !                          ** default : 0
    !                          ** unit : m
    !            * name: albedoCoefficient
    !                          ** description : albedo Coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.23
    !                          ** unit : 
        !- outputs:
    !            * name: netOutGoingLongWaveRadiation
    !                          ** description : net OutGoing Long Wave Radiation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
    !            * name: netRadiation
    !                          ** description : net radiation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : MJ m-2 d-1
        IF(ih .EQ. -999) THEN
            Nsr = solarRadiation * (1 - (albedoCoefficientCan * tau +  &
                    (albedoCoefficient * (1.00 - tau))))
        ELSE
            cov = REAL(1)
            IF(solarRadiation .GT. 0.01) THEN
                IF(ih .LE. 7) THEN
                    cov = 0.30
                ELSE IF ( ih .GT. 7 .AND. ih .LT. 11) THEN
                    cov = 0.30 - (0.09 / 3.00 * (ih - 7.00))
                ELSE IF ( ih .EQ. 11) THEN
                    cov = 0.21
                ELSE IF ( ih .GT. 11 .AND. ih .LT. 15) THEN
                    cov = 0.21 + (0.09 / 3.00 * (ih - 11.00))
                ELSE
                    cov = 0.30
                END IF
            END IF
            Nsr = (1 - cov) * solarRadiation
        END IF
        clearSkySolarRadiation = (0.750 + (2 *  (10.00 ** (-5)) * elevation))  &
                * extraSolarRadiation
        averageT = ( ((maxTair + 273.160) ** 4) +  ((minTair + 273.160) **  &
                4)) / 2.00
        surfaceEmissivity = 0.340 - (0.140 * SQRT(vaporPressure / 10.00))
        cloudCoverFactor = 1.350 * (solarRadiation / clearSkySolarRadiation)  &
                - 0.350
        Nolr = stefanBoltzman * averageT * surfaceEmissivity *  &
                cloudCoverFactor
        IF(ih .NE. -999) THEN
            Nolr = Nolr / 24.00
        END IF
        netRadiation = Nsr - Nolr
        netOutGoingLongWaveRadiation = Nolr
    END SUBROUTINE model_netradiation

END MODULE
