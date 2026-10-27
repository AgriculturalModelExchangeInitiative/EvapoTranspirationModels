MODULE Evapotranspirationmod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_evapotranspiration(evaporation_zeta, &
        maximum_evaporation_impact_depth, &
        evaporation_reduction_method, &
        xsa_critical_soil_moisture, &
        no_of_soil_layers, &
        no_of_soil_moisture_layers, &
        layer_thickness, &
        permanent_wilting_point, &
        field_capacity, &
        kc_factor, &
        has_snow_cover, &
        developmental_stage, &
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
        REAL, INTENT(IN) :: kc_factor
        LOGICAL, INTENT(IN) :: has_snow_cover
        INTEGER, INTENT(IN) :: developmental_stage
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
        surface_water_storage = 0.0
        evaporated_from_surface = 0.0
        actual_evaporation = 0.0
        actual_transpiration = 0.0
        ALLOCATE(soil_moisture(no_of_soil_moisture_layers))
        ALLOCATE(evaporation(no_of_soil_moisture_layers))
        ALLOCATE(transpiration(no_of_soil_moisture_layers))
        ALLOCATE(evapotranspiration(no_of_soil_moisture_layers))
        actual_evapotranspiration = 0.0
        ALLOCATE(soil_moisture(no_of_soil_moisture_layers))
        soil_moisture = 0.0
        ALLOCATE(evaporation(no_of_soil_moisture_layers))
        evaporation = 0.0
        ALLOCATE(transpiration(no_of_soil_moisture_layers))
        transpiration = 0.0
        ALLOCATE(evapotranspiration(no_of_soil_moisture_layers))
        evapotranspiration = 0.0
    END SUBROUTINE init_evapotranspiration

    SUBROUTINE model_evapotranspiration(evaporation_zeta, &
        maximum_evaporation_impact_depth, &
        evaporation_reduction_method, &
        xsa_critical_soil_moisture, &
        no_of_soil_layers, &
        no_of_soil_moisture_layers, &
        layer_thickness, &
        permanent_wilting_point, &
        field_capacity, &
        kc_factor, &
        has_snow_cover, &
        developmental_stage, &
        crop_transpiration, &
        crop_evaporated_from_intercepted, &
        percentage_soil_coverage, &
        potential_evapotranspiration, &
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
        REAL, INTENT(IN) :: kc_factor
        LOGICAL, INTENT(IN) :: has_snow_cover
        INTEGER, INTENT(IN) :: developmental_stage
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                crop_transpiration
        REAL, INTENT(IN) :: crop_evaporated_from_intercepted
        REAL, INTENT(IN) :: percentage_soil_coverage
        REAL, INTENT(IN) :: potential_evapotranspiration
        REAL, INTENT(INOUT) :: surface_water_storage
        REAL, INTENT(INOUT) :: evaporated_from_surface
        REAL, INTENT(INOUT) :: actual_evaporation
        REAL, INTENT(INOUT) :: actual_transpiration
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: soil_moisture
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                evaporation
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                transpiration
        REAL , DIMENSION(no_of_soil_moisture_layers ), INTENT(IN) ::  &
                evapotranspiration
        REAL, INTENT(INOUT) :: actual_evapotranspiration
        REAL:: evaporated_from_intercept
        LOGICAL:: evaporation_from_surface
        REAL:: eRed1
        REAL:: eRed2
        REAL:: eRed3
        REAL:: eReducer
        INTEGER:: i
        evaporation_from_surface = .FALSE.
        !- Name: Evapotranspiration -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA evapotranspiration model
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: None
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: None
    !            * ShortDescription: Calculates the MONICA evapotranspiration
        !- inputs:
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
    !            * name: kc_factor
    !                          ** description : crop coefficient ETc/ET0
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0.75
    !                          ** unit : dimensionless
    !            * name: has_snow_cover
    !                          ** description : is the soil covered by snow
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : BOOLEAN
    !                          ** default : false
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
    !            * name: potential_evapotranspiration
    !                          ** description : the potential evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : mm
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
        !- outputs:
    !            * name: evaporated_from_surface
    !                          ** description : 
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: actual_evapotranspiration
    !                          ** description : actual evapotranspiration
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 200
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: actual_evaporation
    !                          ** description : actual evaporation
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: actual_transpiration
    !                          ** description : actual transpiration
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: surface_water_storage
    !                          ** description : Simulates a virtual layer that contains the surface water
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : mm
    !            * name: soil_moisture
    !                          ** description : soil moisture array
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : no_of_soil_moisture_layers
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : m3/m3
        IF(developmental_stage .GT. 0) THEN
            evaporated_from_intercept = crop_evaporated_from_intercepted
        ELSE
            evaporated_from_intercept = 0.0
        END IF
        evaporated_from_surface = 0.0
        actual_evaporation = 0.0
        actual_transpiration = 0.0
        IF(potential_evapotranspiration .GT. 0.0) THEN
            evaporation_from_surface = .FALSE.
            IF(surface_water_storage .GT. 0.0) THEN
                evaporation_from_surface = .TRUE.
                potential_evapotranspiration = potential_evapotranspiration * (1.1 /  &
                        kc_factor)
                IF(has_snow_cover) THEN
                    evaporated_from_surface = 0.0
                ELSE IF ( surface_water_storage .LT. potential_evapotranspiration)  &
                        THEN
                    potential_evapotranspiration = potential_evapotranspiration -  &
                            surface_water_storage
                    evaporated_from_surface = surface_water_storage
                    surface_water_storage = 0.0
                ELSE
                    surface_water_storage = surface_water_storage -  &
                            potential_evapotranspiration
                    evaporated_from_surface = potential_evapotranspiration
                    potential_evapotranspiration = 0.0
                END IF
                potential_evapotranspiration = potential_evapotranspiration *  &
                        (kc_factor / 1.1)
            END IF
            IF(potential_evapotranspiration .GT. 0.0) THEN
                DO i = 0 , no_of_soil_layers-1, 1
                    eRed1 = e_reducer_1(permanent_wilting_point(i+1),  &
                            field_capacity(i+1), soil_moisture(i+1), percentage_soil_coverage,  &
                            potential_evapotranspiration, evaporation_reduction_method,  &
                            xsa_critical_soil_moisture)
                    eRed2 = 0.0
                    IF(REAL(i) .GE. maximum_evaporation_impact_depth) THEN
                        eRed2 = 0.0
                    ELSE
                        eRed2 = get_deprivation_factor(i + 1,  &
                                maximum_evaporation_impact_depth, evaporation_zeta,  &
                                layer_thickness(i+1))
                    END IF
                    eRed3 = 0.0
                    IF(i .GT. 0 .AND. soil_moisture(i+1) .LT. soil_moisture(i - 1+1)) THEN
                        eRed3 = 0.1
                    ELSE
                        eRed3 = 1.0
                    END IF
                    eReducer = eRed1 * eRed2 * eRed3
                    IF(developmental_stage .GT. 0) THEN
                        IF(percentage_soil_coverage .GE. 0.0 .AND. percentage_soil_coverage  &
                                .LT. 1.0) THEN
                            evaporation(i+1) = (1.0 - percentage_soil_coverage) * eReducer *  &
                                    potential_evapotranspiration
                        ELSE IF ( percentage_soil_coverage .GE. 1.0) THEN
                            evaporation(i+1) = 0.0
                        END IF
                        IF(has_snow_cover) THEN
                            evaporation(i+1) = 0.0
                        END IF
                        transpiration(i+1) = crop_transpiration(i+1)
                        IF(evaporation_from_surface) THEN
                            transpiration(i+1) = percentage_soil_coverage * eReducer *  &
                                    potential_evapotranspiration
                        END IF
                    ELSE
                        IF(has_snow_cover) THEN
                            evaporation(i+1) = 0.0
                        ELSE
                            evaporation(i+1) = potential_evapotranspiration * eReducer
                        END IF
                        transpiration(i+1) = 0.0
                    END IF
                    evapotranspiration(i+1) = evaporation(i+1) + transpiration(i+1)
                    soil_moisture(i+1) = soil_moisture(i+1) - (evapotranspiration(i+1) /  &
                            1000.0 / layer_thickness(i+1))
                    IF(soil_moisture(i+1) .LT. 0.01) THEN
                        soil_moisture(i+1) = 0.01
                    END IF
                    actual_transpiration = actual_transpiration + transpiration(i+1)
                    actual_evaporation = actual_evaporation + evaporation(i+1)
                END DO
            END IF
        END IF
        actual_evapotranspiration = actual_transpiration + actual_evaporation  &
                + evaporated_from_intercept + evaporated_from_surface
    END SUBROUTINE model_evapotranspiration

    FUNCTION bound(lower, &
        value, &
        upper) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: lower
        REAL, INTENT(IN) :: value
        REAL, INTENT(IN) :: upper
        REAL:: res_cyml
        IF(value .LT. lower) THEN
            res_cyml = lower
            RETURN
        END IF
        IF(value .GT. upper) THEN
            res_cyml = upper
            RETURN
        END IF
        res_cyml = value
        RETURN
    END FUNCTION bound

    FUNCTION get_deprivation_factor(layer_no, &
        deprivation_depth, &
        zeta, &
        layer_thickness) RESULT(deprivation_factor)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer_no
        REAL, INTENT(IN) :: deprivation_depth
        REAL, INTENT(IN) :: zeta
        REAL, INTENT(IN) :: layer_thickness
        REAL:: deprivation_factor
        REAL:: ltf
        REAL:: c2
        REAL:: c3
        REAL:: res_cyml
        ltf = deprivation_depth / (layer_thickness * 10.0)
        IF(ABS(zeta) .LT. 0.0003) THEN
            deprivation_factor = 2.0 / ltf - (1.0 / (ltf * ltf) * (2 * layer_no -  &
                    1))
        ELSE
            c2 = LOG((ltf + (zeta * layer_no)) / (ltf + (zeta * (layer_no - 1))))
            c3 = zeta / (ltf * (zeta + 1.0))
            deprivation_factor = (c2 - c3) / (LOG(zeta + 1.0) - (zeta / (zeta +  &
                    1.0)))
        END IF
    END FUNCTION get_deprivation_factor

    FUNCTION e_reducer_1(pwp, &
        fc, &
        sm, &
        percentage_soil_coverage, &
        reference_evapotranspiration, &
        evaporation_reduction_method, &
        xsa_critical_soil_moisture) RESULT(e_reduction_factor)
        IMPLICIT NONE
        REAL, INTENT(IN) :: pwp
        REAL, INTENT(IN) :: fc
        REAL, INTENT(IN) :: sm
        REAL, INTENT(IN) :: percentage_soil_coverage
        REAL, INTENT(IN) :: reference_evapotranspiration
        INTEGER, INTENT(IN) :: evaporation_reduction_method
        REAL, INTENT(IN) :: xsa_critical_soil_moisture
        REAL:: e_reduction_factor
        REAL:: relative_evaporable_water
        REAL:: critical_soil_moisture
        REAL:: reducer
        REAL:: xsa
        REAL:: res_cyml
        e_reduction_factor = 0.0
        sm = MAX(0.33 * pwp, sm)
        relative_evaporable_water = MIN(1.0, (sm - (0.33 * pwp)) / (fc -  &
                (0.33 * pwp)))
        IF(evaporation_reduction_method .EQ. 0) THEN
            critical_soil_moisture = 0.65 * fc
            IF(percentage_soil_coverage .GT. 0.0) THEN
                reducer = 1.0
                IF(reference_evapotranspiration .GT. 2.5) THEN
                    xsa = (0.65 * fc - pwp) * (fc - pwp)
                    reducer = xsa + ((1 - xsa) / 17.5 * (reference_evapotranspiration -  &
                            2.5))
                ELSE
                    reducer = xsa_critical_soil_moisture / 2.5 *  &
                            reference_evapotranspiration
                END IF
                critical_soil_moisture = fc * reducer
            END IF
            IF(sm .GT. critical_soil_moisture) THEN
                e_reduction_factor = 1.0
            ELSE IF ( sm .GT. (0.33 * pwp)) THEN
                e_reduction_factor = relative_evaporable_water
            ELSE
                e_reduction_factor = 0.0
            END IF
        ELSE
            IF(relative_evaporable_water .GT. 0.33) THEN
                e_reduction_factor = 1.0 - (0.1 * (1.0 - relative_evaporable_water) /  &
                        (1.0 - 0.33))
            ELSE IF ( relative_evaporable_water .GT. 0.22) THEN
                e_reduction_factor = 0.9 - (0.625 * (0.33 -  &
                        relative_evaporable_water) / (0.33 - 0.22))
            ELSE IF ( relative_evaporable_water .GT. 0.2) THEN
                e_reduction_factor = 0.275 - (0.225 * (0.22 -  &
                        relative_evaporable_water) / (0.22 - 0.2))
            ELSE
                e_reduction_factor = 0.05 - (0.05 * (0.2 - relative_evaporable_water)  &
                        / 0.2)
            END IF
        END IF
    END FUNCTION e_reducer_1

END MODULE
