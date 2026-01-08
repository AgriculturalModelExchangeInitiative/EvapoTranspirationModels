MODULE Referenceetpriestleytaylormod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_referenceetpriestleytaylor(cAltitude, &
        cAlphaPT, &
        iTMax, &
        iTMin, &
        iNetRadiation, &
        ReferenceCropEvapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: cAltitude
        REAL, INTENT(IN) :: cAlphaPT
        REAL, INTENT(IN) :: iTMax
        REAL, INTENT(IN) :: iTMin
        REAL, INTENT(IN) :: iNetRadiation
        REAL, INTENT(OUT) :: ReferenceCropEvapotranspiration
        REAL:: lambdav
        REAL:: T
        REAL:: Delta
        REAL:: AtmPres
        REAL:: Gamma
        REAL:: G
        !- Name: ReferenceETPriestleyTaylor -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ReferenceETPriestleyTaylor model
    !            * Authors: Gunther Krauss
    !            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    !            * Institution: INRES Pflanzenbau, Uni Bonn
    !            * ExtendedDescription: as given in the documentation
    !            * ShortDescription: None
        !- inputs:
    !            * name: cAltitude
    !                          ** description : altitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    !            * name: cAlphaPT
    !                          ** description : Priestley-Taylor coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0.0
    !                          ** default : 1.26
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
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
    !            * name: iNetRadiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
        !- outputs:
    !            * name: ReferenceCropEvapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
        lambdav = 2.45
        T = (iTMax + iTMin) / 2.0
        Delta = SlopeOfSaturationVapPressureCurve(T)
        AtmPres = AtmosphericPressure(cAltitude)
        Gamma = PsychrometricConstant(AtmPres)
        G = 0.0
        ReferenceCropEvapotranspiration = MAX(float(0), cAlphaPT * Delta /  &
                (Delta + Gamma) * (iNetRadiation - G) / lambdav)
    END SUBROUTINE model_referenceetpriestleytaylor

    FUNCTION SlopeOfSaturationVapPressureCurve(T) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: T
        REAL:: tempT
        REAL:: res_cyml
        tempT = T + 237.3
        res_cyml = 4098 * (0.6108 * EXP(17.27 * T / tempT)) /  (tempT ** 2)
        RETURN
    END FUNCTION SlopeOfSaturationVapPressureCurve

    FUNCTION AtmosphericPressure(z) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: z
        REAL:: res_cyml
        res_cyml = 101.3 *  (((293 - (0.0065 * z)) / 293) ** 5.26)
        RETURN
    END FUNCTION AtmosphericPressure

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

END MODULE
