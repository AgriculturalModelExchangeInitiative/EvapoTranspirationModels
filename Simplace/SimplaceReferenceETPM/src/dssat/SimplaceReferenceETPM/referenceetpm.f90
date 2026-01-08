MODULE Referenceetpmmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_referenceetpm(cAltitude, &
        iTMax, &
        iTMin, &
        iActualVapourPressure, &
        iNetRadiation, &
        iWindspeed, &
        ReferenceCropEvapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: cAltitude
        REAL, INTENT(IN) :: iTMax
        REAL, INTENT(IN) :: iTMin
        REAL, INTENT(IN) :: iActualVapourPressure
        REAL, INTENT(IN) :: iNetRadiation
        REAL, INTENT(IN) :: iWindspeed
        REAL, INTENT(OUT) :: ReferenceCropEvapotranspiration
        REAL:: T
        REAL:: e_s
        !- Name: ReferenceETPM -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ReferenceETPM model
    !            * Authors: Gunther Krauss
    !            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    !            * Institution: INRES Pflanzenbau, Uni Bonn
    !            * ExtendedDescription: as given in the documentation
    !            * ShortDescription: None
        !- inputs:
    !            * name: cAltitude
    !                          ** description : elevation above sea level
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    !            * name: iTMax
    !                          ** description : maximum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: iTMin
    !                          ** description : minimum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: iActualVapourPressure
    !                          ** description : actual vapour pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
    !            * name: iNetRadiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    !            * name: iWindspeed
    !                          ** description : wind speed at 2m height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
        !- outputs:
    !            * name: ReferenceCropEvapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
        T = (iTMax + iTMin) / 2
        e_s = MeanSaturatedVapourPressure(iTMax, iTMin)
        IF(iActualVapourPressure .GT. e_s) THEN
            iActualVapourPressure = e_s
        END IF
        ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T,  &
                iNetRadiation, iWindspeed, e_s, iActualVapourPressure, cAltitude)
    END SUBROUTINE model_referenceetpm

    FUNCTION SaturationVapourPressureAtTemperature(T) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: T
        REAL:: res_cyml
        res_cyml = 0.6108 * EXP(17.27 * T / (T + 237.3))
        RETURN
    END FUNCTION SaturationVapourPressureAtTemperature

    FUNCTION MeanSaturatedVapourPressure(T_max, &
        T_min) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: T_max
        REAL, INTENT(IN) :: T_min
        REAL:: res_cyml
        res_cyml = (SaturationVapourPressureAtTemperature(T_max) +  &
                SaturationVapourPressureAtTemperature(T_min)) / 2
        RETURN
    END FUNCTION MeanSaturatedVapourPressure

    FUNCTION SlopeOfSaturationVapPressureCurve(T) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: T
        REAL:: tempT
        REAL:: res_cyml
        tempT = T + 237.3
        res_cyml = 4098 * (0.6108 * EXP(17.27 * T / tempT)) /  (tempT ** 2)
        RETURN
    END FUNCTION SlopeOfSaturationVapPressureCurve

    FUNCTION PsychrometricConstant(P) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: P
        REAL:: lambdav
        REAL:: c_p
        REAL:: epsilon
        REAL:: factor
        REAL:: res_cyml
        lambdav = 2.45
        c_p = 1.013E-3
        epsilon = 0.622
        factor = NINT(c_p / (epsilon * lambdav) * 10E6) / 10E6
        res_cyml = factor * P
        RETURN
    END FUNCTION PsychrometricConstant

    FUNCTION AtmosphericPressure(z) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: z
        REAL:: res_cyml
        res_cyml = 101.3 *  (((293 - (0.0065 * z)) / 293) ** 5.26)
        RETURN
    END FUNCTION AtmosphericPressure

    FUNCTION ReferenceEvapotranspiration(T, &
        R_n, &
        u_2, &
        e_s, &
        e_a, &
        z) RESULT(ET0)
        IMPLICIT NONE
        REAL, INTENT(IN) :: T
        REAL, INTENT(IN) :: R_n
        REAL, INTENT(IN) :: u_2
        REAL, INTENT(IN) :: e_s
        REAL, INTENT(IN) :: e_a
        REAL, INTENT(IN) :: z
        REAL:: ET0
        REAL:: P
        REAL:: gamma
        REAL:: Delta
        REAL:: G
        REAL:: res_cyml
        P = AtmosphericPressure(z)
        gamma = PsychrometricConstant(P)
        Delta = SlopeOfSaturationVapPressureCurve(T)
        G = REAL(0)
        ET0 = (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 *  &
                (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))))
    END FUNCTION ReferenceEvapotranspiration

END MODULE
