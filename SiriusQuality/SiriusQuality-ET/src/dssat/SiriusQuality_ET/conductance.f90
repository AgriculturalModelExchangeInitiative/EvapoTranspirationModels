MODULE Conductancemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_conductance(d, &
        heightWeatherMeasurements, &
        plantHeight, &
        zh, &
        zm, &
        vonKarman, &
        ih, &
        wind, &
        conductance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: d
        REAL, INTENT(IN) :: heightWeatherMeasurements
        REAL, INTENT(IN) :: plantHeight
        REAL, INTENT(IN) :: zh
        REAL, INTENT(IN) :: zm
        REAL, INTENT(IN) :: vonKarman
        INTEGER, INTENT(IN) :: ih
        REAL, INTENT(IN) :: wind
        REAL, INTENT(OUT) :: conductance
        REAL:: h
        REAL:: clim
        !- Name: Conductance -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: Conductance Model
    !            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.,
    !New Zealand Institute for Crop and Food Research Ltd.
    !
    !            * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
    !canopy and the canopy structure. The approach does not take into account buoyancy
    !effects.
    !
    !            * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
    !canopy and the canopy structure. The approach does not take into account buoyancy
    !effects.
    !
        !- inputs:
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
    !            * name: ih
    !                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    !                          ** inputtype : variable
    !                          ** parametercategory : state
    !                          ** datatype : INT
    !                          ** max : 24
    !                          ** min : 999
    !                          ** default : 999
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
        !- outputs:
    !            * name: conductance
    !                          ** description : the boundary layer conductance
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : m/d
        clim = 0.10
        IF(ih .NE. -999) THEN
            clim = 36.00
        END IF
        h = MAX(10.00, plantHeight) / 100.00
        conductance = wind *  (vonKarman ** 2) /  &
                (LOG((heightWeatherMeasurements - (d * h)) / (zm * h)) *  &
                LOG((heightWeatherMeasurements - (d * h)) / (zh * h)))
        conductance = MAX(clim, conductance)
    END SUBROUTINE model_conductance

END MODULE
