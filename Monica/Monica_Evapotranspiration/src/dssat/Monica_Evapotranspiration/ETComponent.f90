MODULE Etmod
    USE Radiationmod
    USE Netradiationmod
    USE Stomataresistancemod
    USE Calcstomataresistancemod
    USE Saturatedvaporpressuremod
    USE Saturationvaporpressuredeficitmod
    USE Referenceevapotranspirationmod
    USE Potentialevapotranspirationmod
    USE Evapotranspirationmod
    USE Useextet0mod
    USE Useextvaporpressuremod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_et(latitude, &
        global_radiation, &
        julian_day, &
        sunshine_hours, &
        reference_albedo, &
        height_nn, &
        max_air_temperature, &
        min_air_temperature, &
        use_external_vapor_pressure, &
        external_vapor_pressure, &
        relative_humidity, &
        calc_stomata_resistance, &
        fixed_stomata_resistance, &
        saturation_beta, &
        stomata_conductance_alpha, &
        carboxylation_pathway, &
        gross_photosynthesis_reference_mol, &
        atmospheric_co2_concentration, &
        mean_air_temperature, &
        wind_speed, &
        wind_speed_height, &
        stomata_resistance, &
        net_radiation, &
        kc_factor, &
        developmental_stage, &
        crop_remaining_evapotranspiration, &
        evaporation_zeta, &
        maximum_evaporation_impact_depth, &
        evaporation_reduction_method, &
        xsa_critical_soil_moisture, &
        no_of_soil_layers, &
        no_of_soil_moisture_layers, &
        layer_thickness, &
        permanent_wilting_point, &
        field_capacity, &
        has_snow_cover, &
        crop_transpiration, &
        crop_evaporated_from_intercepted, &
        percentage_soil_coverage, &
        surface_water_storage, &
        evaporated_from_surface, &
        actual_evaporation, &
        actual_transpiration, &
        soil_moisture, &
        evaporation, &
        transpiration, &
        evapotranspiration, &
        actual_evapotranspiration, &
        use_external_et0, &
        external_et0, &
        declination, &
        astronomic_daylength, &
        effective_daylength, &
        photoperiodic_daylength, &
        sunshine_hours_global_radiation, &
        extraterrestrial_radiation, &
        clear_day_radiation, &
        overcast_day_radiation, &
        phot_act_radiation_mean, &
        reference_evapotranspiration, &
        potential_evapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: latitude
        REAL, INTENT(IN) :: global_radiation
        INTEGER, INTENT(IN) :: julian_day
        REAL, INTENT(IN) :: sunshine_hours
        REAL, INTENT(IN) :: reference_albedo
        REAL, INTENT(IN) :: height_nn
        REAL, INTENT(IN) :: max_air_temperature
        REAL, INTENT(IN) :: min_air_temperature
        LOGICAL, INTENT(IN) :: use_external_vapor_pressure
        REAL, INTENT(IN) :: external_vapor_pressure
        REAL, INTENT(IN) :: relative_humidity
        LOGICAL, INTENT(IN) :: calc_stomata_resistance
        REAL, INTENT(IN) :: fixed_stomata_resistance
        REAL, INTENT(IN) :: saturation_beta
        REAL, INTENT(IN) :: stomata_conductance_alpha
        INTEGER, INTENT(IN) :: carboxylation_pathway
        REAL, INTENT(IN) :: gross_photosynthesis_reference_mol
        REAL, INTENT(IN) :: atmospheric_co2_concentration
        REAL, INTENT(IN) :: mean_air_temperature
        REAL, INTENT(IN) :: wind_speed
        REAL, INTENT(IN) :: wind_speed_height
        REAL, INTENT(IN) :: stomata_resistance
        REAL, INTENT(IN) :: net_radiation
        REAL, INTENT(IN) :: kc_factor
        INTEGER, INTENT(IN) :: developmental_stage
        REAL, INTENT(IN) :: crop_remaining_evapotranspiration
        REAL, INTENT(IN) :: evaporation_zeta
        REAL, INTENT(IN) :: maximum_evaporation_impact_depth
        INTEGER, INTENT(IN) :: evaporation_reduction_method
        REAL, INTENT(IN) :: xsa_critical_soil_moisture
        INTEGER, INTENT(IN) :: no_of_soil_layers
        INTEGER, INTENT(IN) :: no_of_soil_moisture_layers
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                layer_thickness
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                permanent_wilting_point
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                field_capacity
        LOGICAL, INTENT(IN) :: has_snow_cover
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                crop_transpiration
        REAL, INTENT(IN) :: crop_evaporated_from_intercepted
        REAL, INTENT(IN) :: percentage_soil_coverage
        REAL, INTENT(IN) :: surface_water_storage
        REAL, INTENT(IN) :: evaporated_from_surface
        REAL, INTENT(IN) :: actual_evaporation
        REAL, INTENT(IN) :: actual_transpiration
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                soil_moisture
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                evaporation
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                transpiration
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                evapotranspiration
        REAL, INTENT(IN) :: actual_evapotranspiration
        LOGICAL, INTENT(IN) :: use_external_et0
        REAL, INTENT(IN) :: external_et0
        REAL, INTENT(OUT) :: declination
        REAL, INTENT(OUT) :: astronomic_daylength
        REAL, INTENT(OUT) :: effective_daylength
        REAL, INTENT(OUT) :: photoperiodic_daylength
        REAL, INTENT(OUT) :: sunshine_hours_global_radiation
        REAL, INTENT(OUT) :: extraterrestrial_radiation
        REAL, INTENT(OUT) :: clear_day_radiation
        REAL, INTENT(OUT) :: overcast_day_radiation
        REAL, INTENT(OUT) :: phot_act_radiation_mean
        REAL:: vapor_pressure
        REAL:: saturation_vapor_pressure_deficit
        REAL:: calculated_stomata_resistance
        REAL:: saturated_vapor_pressure
        REAL, INTENT(OUT) :: reference_evapotranspiration
        REAL:: potential_evapotranspiration_cap
        REAL, INTENT(OUT) :: potential_evapotranspiration
        REAL:: internal_et0
        REAL:: et0
        REAL:: internal_vapor_pressure
        !- Name: ET -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA evapotranspiration model
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: Calculates the MONICA evapotranspiration
        !- inputs:
    !            * name: latitude
    !                          ** description : latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 90
    !                          ** min : -90
    !                          ** default : 0
    !                          ** unit : degree
    !            * name: global_radiation
    !                          ** description : global radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : MJ/m2
    !            * name: julian_day
    !                          ** description : day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 366
    !                          ** min : 1
    !                          ** default : 1
    !                          ** unit : day
    !            * name: sunshine_hours
    !                          ** description : number of sunshine hours
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : h
    !            * name: reference_albedo
    !                          ** description : reference albedo
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : dimensionless
    !            * name: height_nn
    !                          ** description : height above sea level
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : -9999
    !                          ** default : 0
    !                          ** unit : m
    !            * name: max_air_temperature
    !                          ** description : daily maximum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: min_air_temperature
    !                          ** description : daily minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: use_external_vapor_pressure
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : mm
    !            * name: external_vapor_pressure
    !                          ** description : value to be returned if condition is true
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : kPa
    !            * name: relative_humidity
    !                          ** description : relative humidity
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : fraction
    !            * name: calc_stomata_resistance
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : 
    !            * name: fixed_stomata_resistance
    !                          ** description : value to be returned if condition is false
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 100
    !                          ** unit : s/m
    !            * name: saturation_beta
    !                          ** description : Original: Yu et al. 2001; beta = 3.5
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2.5
    !                          ** unit : 
    !            * name: stomata_conductance_alpha
    !                          ** description : Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 40
    !                          ** unit : mmol/m2/s
    !            * name: carboxylation_pathway
    !                          ** description : Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 2
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : dimensionless
    !            * name: gross_photosynthesis_reference_mol
    !                          ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : -1
    !                          ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
    !            * name: atmospheric_co2_concentration
    !                          ** description : CO2 concentration in the atmosphere. Optional if no crop.
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 430
    !                          ** unit : ppm
    !            * name: mean_air_temperature
    !                          ** description : daily average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 0
    !                          ** unit : °C
    !            * name: wind_speed
    !                          ** description : wind speed measured at wind speed height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : m/s
    !            * name: wind_speed_height
    !                          ** description : height at which the wind speed has been measured
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 9999
    !                          ** min : -9999
    !                          ** default : 2
    !                          ** unit : m
    !            * name: stomata_resistance
    !                          ** description : stomata resistance (FAO default value is 100)
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** default : 100
    !                          ** unit : s/m
    !            * name: net_radiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: kc_factor
    !                          ** description : crop coefficient ETc/ET0
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0.75
    !                          ** unit : dimensionless
    !            * name: developmental_stage
    !                          ** description : MONICA crop developmental stage
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 6
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : dimensionless
    !            * name: crop_remaining_evapotranspiration
    !                          ** description : crop remaining evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: evaporation_zeta
    !                          ** description : shape factor
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 40
    !                          ** min : 0
    !                          ** default : 40
    !                          ** unit : dimensionless
    !            * name: maximum_evaporation_impact_depth
    !                          ** description : maximumEvaporationImpactDepth
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 5
    !                          ** unit : dm
    !            * name: evaporation_reduction_method
    !                          ** description : THESEUS (0) or HERMES (1) evaporation reduction method
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 1
    !                          ** unit : dimensionless
    !            * name: xsa_critical_soil_moisture
    !                          ** description : XSACriticalSoilMoisture
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1.5
    !                          ** min : 0
    !                          ** default : 0.1
    !                          ** unit : m3/m3
    !            * name: no_of_soil_layers
    !                          ** description : number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 20
    !                          ** unit : dimensionless
    !            * name: no_of_soil_moisture_layers
    !                          ** description : number of soil layers + 1
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 21
    !                          ** unit : dimensionless
    !            * name: layer_thickness
    !                          ** description : layer thickness array
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m
    !            * name: permanent_wilting_point
    !                          ** description : permanent wilting point array
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m3/m3
    !            * name: field_capacity
    !                          ** description : field capacity array
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m3/m3
    !            * name: has_snow_cover
    !                          ** description : is the soil covered by snow
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : dimensionless
    !            * name: crop_transpiration
    !                          ** description : crop transpiration array
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: crop_evaporated_from_intercepted
    !                          ** description : crop evaporated water from intercepted water
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: percentage_soil_coverage
    !                          ** description : fraction of soil covered by crop
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : m2/m2
    !            * name: surface_water_storage
    !                          ** description : Simulates a virtual layer that contains the surface water
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: evaporated_from_surface
    !                          ** description : evaporated_from_surface
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: actual_evaporation
    !                          ** description : actual evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: actual_transpiration
    !                          ** description : actual transpiration
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: soil_moisture
    !                          ** description : soil moisture array
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m3/m3
    !            * name: evaporation
    !                          ** description : evaporation array
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: transpiration
    !                          ** description : transpiration array
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: evapotranspiration
    !                          ** description : evapotranspiration array
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: actual_evapotranspiration
    !                          ** description : actual evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: use_external_et0
    !                          ** description : boolean condition to be met
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : BOOLEAN
    !                          ** default : false
    !                          ** unit : 
    !            * name: external_et0
    !                          ** description : value to be returned if condition is true
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
        !- outputs:
    !            * name: declination
    !                          ** description : declination
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : 
    !            * name: astronomic_daylength
    !                          ** description : astronomic_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: effective_daylength
    !                          ** description : effective_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: photoperiodic_daylength
    !                          ** description : photoperiodic_daylength
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: sunshine_hours_global_radiation
    !                          ** description : global radiation calculated from sunshine hours
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: extraterrestrial_radiation
    !                          ** description : extraterrestrial_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: clear_day_radiation
    !                          ** description : clear_day_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: overcast_day_radiation
    !                          ** description : overcast_day_radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : MJ/m2
    !            * name: phot_act_radiation_mean
    !                          ** description : phot_act_radiation_mean
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : J/m2
    !            * name: reference_evapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: potential_evapotranspiration
    !                          ** description : the potential evapotranspiration
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
        call model_radiation(latitude, global_radiation, julian_day,  &
                sunshine_hours,declination,astronomic_daylength,effective_daylength,photoperiodic_daylength,sunshine_hours_global_radiation,extraterrestrial_radiation,clear_day_radiation,overcast_day_radiation,phot_act_radiation_mean)
        call model_saturatedvaporpressure(max_air_temperature,  &
                min_air_temperature,  &
                relative_humidity,saturated_vapor_pressure,vapor_pressure)
        internal_vapor_pressure = vapor_pressure
        call model_useextvaporpressure(use_external_vapor_pressure,  &
                external_vapor_pressure, internal_vapor_pressure,vapor_pressure)
        call model_netradiation(height_nn, reference_albedo,  &
                global_radiation, max_air_temperature, min_air_temperature,  &
                extraterrestrial_radiation, vapor_pressure,net_radiation)
        call model_saturationvaporpressuredeficit(saturated_vapor_pressure,  &
                vapor_pressure,saturation_vapor_pressure_deficit)
        call model_stomataresistance(saturation_beta,  &
                stomata_conductance_alpha, carboxylation_pathway,  &
                atmospheric_co2_concentration, saturation_vapor_pressure_deficit,  &
                gross_photosynthesis_reference_mol,stomata_resistance)
        calculated_stomata_resistance = stomata_resistance
        call model_calcstomataresistance(calc_stomata_resistance,  &
                calculated_stomata_resistance,  &
                fixed_stomata_resistance,stomata_resistance)
        call model_referenceevapotranspiration(height_nn,  &
                mean_air_temperature, wind_speed, wind_speed_height, net_radiation,  &
                stomata_resistance,  &
                saturation_vapor_pressure_deficit,reference_evapotranspiration)
        internal_et0 = reference_evapotranspiration
        call model_useextet0(use_external_et0, external_et0, internal_et0,et0)
        reference_evapotranspiration = et0
        call  &
                model_potentialevapotranspiration(potential_evapotranspiration_cap,  &
                kc_factor, developmental_stage, crop_remaining_evapotranspiration,  &
                reference_evapotranspiration,potential_evapotranspiration)
        call model_evapotranspiration(evaporation_zeta,  &
                maximum_evaporation_impact_depth, evaporation_reduction_method,  &
                xsa_critical_soil_moisture, no_of_soil_layers,  &
                no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point,  &
                field_capacity, kc_factor, has_snow_cover, developmental_stage,  &
                crop_transpiration, crop_evaporated_from_intercepted,  &
                percentage_soil_coverage, potential_evapotranspiration,  &
                surface_water_storage, evaporated_from_surface, actual_evaporation,  &
                actual_transpiration, soil_moisture, evaporation, transpiration,  &
                evapotranspiration, actual_evapotranspiration)
    END SUBROUTINE model_et

    SUBROUTINE init_et(latitude, &
        global_radiation, &
        julian_day, &
        sunshine_hours, &
        height_nn, &
        reference_albedo, &
        max_air_temperature, &
        min_air_temperature, &
        saturation_beta, &
        stomata_conductance_alpha, &
        carboxylation_pathway, &
        atmospheric_co2_concentration, &
        relative_humidity, &
        mean_air_temperature, &
        wind_speed, &
        wind_speed_height, &
        potential_evapotranspiration_cap, &
        kc_factor, &
        developmental_stage, &
        crop_remaining_evapotranspiration, &
        evaporation_zeta, &
        maximum_evaporation_impact_depth, &
        evaporation_reduction_method, &
        xsa_critical_soil_moisture, &
        no_of_soil_layers, &
        no_of_soil_moisture_layers, &
        layer_thickness, &
        permanent_wilting_point, &
        field_capacity, &
        has_snow_cover, &
        crop_transpiration, &
        crop_evaporated_from_intercepted, &
        percentage_soil_coverage, &
        surface_water_storage, &
        evaporated_from_surface, &
        actual_evaporation, &
        actual_transpiration, &
        soil_moisture, &
        evaporation, &
        transpiration, &
        evapotranspiration, &
        actual_evapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: latitude
        REAL, INTENT(IN) :: global_radiation
        INTEGER, INTENT(IN) :: julian_day
        REAL, INTENT(IN) :: sunshine_hours
        REAL, INTENT(IN) :: height_nn
        REAL, INTENT(IN) :: reference_albedo
        REAL, INTENT(IN) :: max_air_temperature
        REAL, INTENT(IN) :: min_air_temperature
        REAL, INTENT(IN) :: saturation_beta
        REAL, INTENT(IN) :: stomata_conductance_alpha
        INTEGER, INTENT(IN) :: carboxylation_pathway
        REAL, INTENT(IN) :: atmospheric_co2_concentration
        REAL, INTENT(IN) :: relative_humidity
        REAL, INTENT(IN) :: mean_air_temperature
        REAL, INTENT(IN) :: wind_speed
        REAL, INTENT(IN) :: wind_speed_height
        REAL, INTENT(IN) :: potential_evapotranspiration_cap
        REAL, INTENT(IN) :: kc_factor
        INTEGER, INTENT(IN) :: developmental_stage
        REAL, INTENT(IN) :: crop_remaining_evapotranspiration
        REAL, INTENT(IN) :: evaporation_zeta
        REAL, INTENT(IN) :: maximum_evaporation_impact_depth
        INTEGER, INTENT(IN) :: evaporation_reduction_method
        REAL, INTENT(IN) :: xsa_critical_soil_moisture
        INTEGER, INTENT(IN) :: no_of_soil_layers
        INTEGER, INTENT(IN) :: no_of_soil_moisture_layers
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                layer_thickness
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                permanent_wilting_point
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                field_capacity
        LOGICAL, INTENT(IN) :: has_snow_cover
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                crop_transpiration
        REAL, INTENT(IN) :: crop_evaporated_from_intercepted
        REAL, INTENT(IN) :: percentage_soil_coverage
        REAL, INTENT(OUT) :: surface_water_storage
        REAL, INTENT(OUT) :: evaporated_from_surface
        REAL, INTENT(OUT) :: actual_evaporation
        REAL, INTENT(OUT) :: actual_transpiration
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: soil_moisture
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: evaporation
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: transpiration
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: evapotranspiration
        REAL, INTENT(OUT) :: actual_evapotranspiration
        ALLOCATE(soil_moisture(no_of_soil_moisture_layers))
        ALLOCATE(evaporation(no_of_soil_moisture_layers))
        ALLOCATE(transpiration(no_of_soil_moisture_layers))
        ALLOCATE(evapotranspiration(no_of_soil_moisture_layers))
        call init_evapotranspiration(evaporation_zeta,  &
                maximum_evaporation_impact_depth, evaporation_reduction_method,  &
                xsa_critical_soil_moisture, no_of_soil_layers,  &
                no_of_soil_moisture_layers, layer_thickness, permanent_wilting_point,  &
                field_capacity, kc_factor, has_snow_cover, developmental_stage,  &
                crop_transpiration, crop_evaporated_from_intercepted,  &
                percentage_soil_coverage,surface_water_storage,evaporated_from_surface,actual_evaporation,actual_transpiration,soil_moisture,evaporation,transpiration,evapotranspiration,actual_evapotranspiration)
    END SUBROUTINE init_et

END MODULE
