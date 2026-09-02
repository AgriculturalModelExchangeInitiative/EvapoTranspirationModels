MODULE Energybalancecompositemod
    USE Netradiationmod
    USE Conductancemod
    USE Netradiationequivalentevaporationmod
    USE Priestlytaylormod
    USE Penmanmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_energybalancecomposite(albedoCoefficient, &
        maxTair, &
        minTair, &
        vaporPressure, &
        ih, &
        extraSolarRadiation, &
        solarRadiation, &
        tau, &
        elevation, &
        stefanBoltzman, &
        albedoCoefficientCan, &
        d, &
        heightWeatherMeasurements, &
        plantHeight, &
        zh, &
        zm, &
        vonKarman, &
        wind, &
        lambdaV, &
        psychrometricConstant, &
        Alpha, &
        hslope, &
        VPDair, &
        specificHeatCapacityAir, &
        rhoDensityAir, &
        netOutGoingLongWaveRadiation, &
        conductance, &
        netRadiation, &
        evapoTranspirationPriestlyTaylor, &
        evapoTranspirationPenman)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: albedoCoefficient
        REAL, INTENT(IN) :: maxTair
        REAL, INTENT(IN) :: minTair
        REAL, INTENT(IN) :: vaporPressure
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: extraSolarRadiation
        REAL, INTENT(IN) :: solarRadiation
        REAL, INTENT(IN) :: tau
        REAL, INTENT(IN) :: elevation
        REAL, INTENT(IN) :: stefanBoltzman
        REAL, INTENT(IN) :: albedoCoefficientCan
        REAL, INTENT(IN) :: d
        REAL, INTENT(IN) :: heightWeatherMeasurements
        REAL, INTENT(IN) :: plantHeight
        REAL, INTENT(IN) :: zh
        REAL, INTENT(IN) :: zm
        REAL, INTENT(IN) :: vonKarman
        REAL, INTENT(IN) :: wind
        REAL, INTENT(IN) :: lambdaV
        REAL, INTENT(IN) :: psychrometricConstant
        REAL, INTENT(IN) :: Alpha
        REAL, INTENT(IN) :: hslope
        REAL, INTENT(IN) :: VPDair
        REAL, INTENT(IN) :: specificHeatCapacityAir
        REAL, INTENT(IN) :: rhoDensityAir
        REAL, INTENT(OUT) :: netRadiation
        REAL, INTENT(OUT) :: netOutGoingLongWaveRadiation
        REAL, INTENT(OUT) :: conductance
        REAL:: netRadiationEquivalentEvaporation
        REAL, INTENT(OUT) :: evapoTranspirationPriestlyTaylor
        REAL, INTENT(OUT) :: evapoTranspirationPenman
        !- Name: EnergyBalanceComposite -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: EnergyBalance Component
    !            * Authors: SQ
    !            * Reference: None
    !            * Institution: INRAE
    !            * ExtendedDescription: https://pimlday26.sciencesconf.org/program?lang=en
    !            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
        !- inputs:
    !            * name: albedoCoefficient
    !                          ** description : albedo Coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.23
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
    !            * name: minTair
    !                          ** description : minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 45
    !                          ** min : 30
    !                          ** default : 0.7
    !                          ** unit : degC
    !            * name: vaporPressure
    !                          ** description : vapor Pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 6.1
    !                          ** unit : hPa
    !            * name: ih
    !                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 24
    !                          ** min : 999
    !                          ** default : 999
    !                          ** unit : 
    !            * name: extraSolarRadiation
    !                          ** description : extra Solar Radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 11.7
    !                          ** unit : MJ m2 d-1
    !            * name: solarRadiation
    !                          ** description : solar Radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : MJ m-2 d-1
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
    !            * name: stefanBoltzman
    !                          ** description : stefan Boltzman constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 4.903E-09
    !                          ** unit : 
    !            * name: albedoCoefficientCan
    !                          ** description : albedo Coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.23
    !                          ** unit : 
    !            * name: d
    !                          ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.67
    !                          ** unit : dimensionless
    !            * name: heightWeatherMeasurements
    !                          ** description : reference height of wind and humidity measurements
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2
    !                          ** unit : m
    !            * name: plantHeight
    !                          ** description : plant Height
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: zh
    !                          ** description : roughness length governing transfer of heat and vapour, FAO
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.013
    !                          ** unit : m
    !            * name: zm
    !                          ** description : roughness length governing momentum transfer, FAO
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.13
    !                          ** unit : m
    !            * name: vonKarman
    !                          ** description : von Karman constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.42
    !                          ** unit : dimensionless
    !            * name: wind
    !                          ** description : wind
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000000
    !                          ** min : 0
    !                          ** default : 124000
    !                          ** unit : m/d
    !            * name: lambdaV
    !                          ** description : latent heat of vaporization of water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2.454
    !                          ** unit : MJ kg-1
    !            * name: psychrometricConstant
    !                          ** description : psychrometric constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.66
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
    !            * name: hslope
    !                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 0.584
    !                          ** unit : hPa degC-1
    !            * name: VPDair
    !                          ** description : vapour pressure density
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 2.19
    !                          ** unit : hPa
    !            * name: specificHeatCapacityAir
    !                          ** description : Specific heat capacity of dry air
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.00101
    !                          ** unit : 
    !            * name: rhoDensityAir
    !                          ** description : Density of air
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : None
    !                          ** min : None
    !                          ** default : 1.225
    !                          ** unit : 
        !- outputs:
    !            * name: netOutGoingLongWaveRadiation
    !                          ** description : net OutGoing Long Wave Radiation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
    !            * name: conductance
    !                          ** description : the boundary layer conductance
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : m/d
    !            * name: netRadiation
    !                          ** description : net radiation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : MJ m-2 d-1
    !            * name: evapoTranspirationPriestlyTaylor
    !                          ** description : evapoTranspiration of Priestly Taylor
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : rate
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
    !            * name: evapoTranspirationPenman
    !                          ** description : evapoTranspiration of Penman Monteith
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : rate
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        call model_netradiation(albedoCoefficient, maxTair, minTair,  &
                vaporPressure, ih, extraSolarRadiation, solarRadiation, tau,  &
                elevation, stefanBoltzman,  &
                albedoCoefficientCan,netRadiation,netOutGoingLongWaveRadiation)
        call model_conductance(d, heightWeatherMeasurements, plantHeight, zh,  &
                zm, vonKarman, ih, wind,conductance)
        call model_netradiationequivalentevaporation(lambdaV,  &
                netRadiation,netRadiationEquivalentEvaporation)
        call model_priestlytaylor(netRadiationEquivalentEvaporation,  &
                psychrometricConstant, Alpha, solarRadiation, hslope,  &
                ih,evapoTranspirationPriestlyTaylor)
        call model_penman(VPDair, specificHeatCapacityAir,  &
                psychrometricConstant, rhoDensityAir, Alpha,  &
                evapoTranspirationPriestlyTaylor, lambdaV, hslope,  &
                conductance,evapoTranspirationPenman)
    END SUBROUTINE model_energybalancecomposite

END MODULE
