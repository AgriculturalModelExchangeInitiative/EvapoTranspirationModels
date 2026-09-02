MODULE Energybalancemod
    USE Netradiationmod
    USE Conductancemod
    USE Diffusionlimitedevaporationmod
    USE Netradiationequivalentevaporationmod
    USE Priestlytaylormod
    USE Ptsoilmod
    USE Penmanmod
    USE Soilevaporationmod
    USE Evapotranspirationmod
    USE Soilheatfluxmod
    USE Potentialtranspirationmod
    USE Cropheatfluxmod
    USE Canopytemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_energybalance(albedoCoefficientCan, &
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
        wind, &
        heightWeatherMeasurements, &
        vonKarman, &
        plantHeight, &
        zh, &
        zm, &
        d, &
        soilDiffusionConstant, &
        deficitOnTopLayers, &
        lambdaV, &
        psychrometricConstant, &
        Alpha, &
        hslope, &
        tauAlpha, &
        specificHeatCapacityAir, &
        rhoDensityAir, &
        VPDair, &
        isWindVpDefined, &
        conductance, &
        netOutGoingLongWaveRadiation, &
        maxCanopyTemperature, &
        minCanopyTemperature, &
        diffusionLimitedEvaporation)
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
        REAL, INTENT(IN) :: wind
        REAL, INTENT(IN) :: heightWeatherMeasurements
        REAL, INTENT(IN) :: vonKarman
        REAL, INTENT(IN) :: plantHeight
        REAL, INTENT(IN) :: zh
        REAL, INTENT(IN) :: zm
        REAL, INTENT(IN) :: d
        REAL, INTENT(IN) :: soilDiffusionConstant
        REAL, INTENT(IN) :: deficitOnTopLayers
        REAL, INTENT(IN) :: lambdaV
        REAL, INTENT(IN) :: psychrometricConstant
        REAL, INTENT(IN) :: Alpha
        REAL, INTENT(IN) :: hslope
        REAL, INTENT(IN) :: tauAlpha
        REAL, INTENT(IN) :: specificHeatCapacityAir
        REAL, INTENT(IN) :: rhoDensityAir
        REAL, INTENT(IN) :: VPDair
        INTEGER, INTENT(IN) :: isWindVpDefined
        REAL, INTENT(OUT) :: netOutGoingLongWaveRadiation
        REAL:: netRadiation
        REAL, INTENT(OUT) :: conductance
        REAL, INTENT(OUT) :: diffusionLimitedEvaporation
        REAL:: netRadiationEquivalentEvaporation
        REAL:: evapoTranspirationPriestlyTaylor
        REAL:: energyLimitedEvaporation
        REAL:: evapoTranspirationPenman
        REAL:: soilEvaporation
        REAL:: evapoTranspiration
        REAL:: soilHeatFlux
        REAL:: potentialTranspiration
        REAL:: cropHeatFlux
        REAL, INTENT(OUT) :: maxCanopyTemperature
        REAL, INTENT(OUT) :: minCanopyTemperature
        !- Name: EnergyBalance -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: EnergyBalance Component
    !            * Authors: SQ
    !            * Reference: None
    !            * Institution: INRAE
    !            * ExtendedDescription: https://pimlday26.sciencesconf.org/program?lang=en
    !            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
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
    !            * name: wind
    !                          ** description : wind
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000000
    !                          ** min : 0
    !                          ** default : 124000
    !                          ** unit : m/d
    !            * name: heightWeatherMeasurements
    !                          ** description : reference height of wind and humidity measurements
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2
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
    !            * name: d
    !                          ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.67
    !                          ** unit : dimensionless
    !            * name: soilDiffusionConstant
    !                          ** description : soil Diffusion Constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 4.2
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
    !            * name: tauAlpha
    !                          ** description : Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.3
    !                          ** unit : 
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
    !            * name: VPDair
    !                          ** description : vapour pressure density
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 2.19
    !                          ** unit : hPa
    !            * name: isWindVpDefined
    !                          ** description : if wind and vapour pressure are defined
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 1
    !                          ** unit : 
        !- outputs:
    !            * name: conductance
    !                          ** description : the boundary layer conductance
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : m/d
    !            * name: netOutGoingLongWaveRadiation
    !                          ** description : net OutGoing Long Wave Radiation
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
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
    !            * name: diffusionLimitedEvaporation
    !                          ** description : the evaporation from the diffusion limited soil
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 5000
    !                          ** min : 0
    !                          ** unit : g m-2 d-1
        call model_netradiation(albedoCoefficientCan, vaporPressure,  &
                stefanBoltzman, maxTair, solarRadiation, ih, minTair,  &
                extraSolarRadiation, tau, elevation,  &
                albedoCoefficient,netOutGoingLongWaveRadiation,netRadiation)
        call model_conductance(ih, wind, heightWeatherMeasurements,  &
                vonKarman, plantHeight, zh, zm, d,conductance)
        call model_diffusionlimitedevaporation(soilDiffusionConstant, ih,  &
                deficitOnTopLayers,diffusionLimitedEvaporation)
        call model_netradiationequivalentevaporation(netRadiation,  &
                lambdaV,netRadiationEquivalentEvaporation)
        call model_priestlytaylor(ih, psychrometricConstant,  &
                netRadiationEquivalentEvaporation, Alpha, hslope,  &
                solarRadiation,evapoTranspirationPriestlyTaylor)
        call model_ptsoil(ih, Alpha, tauAlpha,  &
                evapoTranspirationPriestlyTaylor, tau,energyLimitedEvaporation)
        call model_penman(psychrometricConstant, specificHeatCapacityAir,  &
                Alpha, hslope, conductance, lambdaV, rhoDensityAir, VPDair,  &
                evapoTranspirationPriestlyTaylor,evapoTranspirationPenman)
        call model_soilevaporation(ih, energyLimitedEvaporation,  &
                diffusionLimitedEvaporation,soilEvaporation)
        call model_evapotranspiration(isWindVpDefined,  &
                evapoTranspirationPenman,  &
                evapoTranspirationPriestlyTaylor,evapoTranspiration)
        call model_soilheatflux(ih, netRadiationEquivalentEvaporation,  &
                soilEvaporation, tau, solarRadiation,soilHeatFlux)
        call model_potentialtranspiration(evapoTranspiration,  &
                tau,potentialTranspiration)
        call model_cropheatflux(ih, potentialTranspiration,  &
                netRadiationEquivalentEvaporation, soilHeatFlux,cropHeatFlux)
        call model_canopytemperature(minTair, cropHeatFlux,  &
                specificHeatCapacityAir, conductance, lambdaV, rhoDensityAir,  &
                maxTair,maxCanopyTemperature,minCanopyTemperature)
    END SUBROUTINE model_energybalance

END MODULE
