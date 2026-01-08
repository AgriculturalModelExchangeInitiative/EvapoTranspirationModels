MODULE Referenceetpriestleytaylor_mod
    USE Referenceetpriestleytaylormod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_referenceetpriestleytaylor_(iTMin, &
        cAlphaPT, &
        iNetRadiation, &
        iTMax, &
        cAltitude, &
        ReferenceCropEvapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: iTMin
        REAL, INTENT(IN) :: cAlphaPT
        REAL, INTENT(IN) :: iNetRadiation
        REAL, INTENT(IN) :: iTMax
        REAL, INTENT(IN) :: cAltitude
        REAL, INTENT(OUT) :: ReferenceCropEvapotranspiration
        !- Name: ReferenceETPriestleyTaylor_ -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ReferenceETPriestleyTaylor_ model
    !            * Authors: Gunther Krauss
    !            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    !            * Institution: INRES Pflanzenbau, Uni Bonn
    !            * ExtendedDescription: as given in the documentation
    !            * ShortDescription: None
        !- inputs:
    !            * name: iTMin
    !                          ** description : minimum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: cAlphaPT
    !                          ** description : Priestley-Taylor coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0.0
    !                          ** default : 1.26
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    !            * name: iNetRadiation
    !                          ** description : net radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    !            * name: iTMax
    !                          ** description : maximum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: cAltitude
    !                          ** description : altitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
        !- outputs:
    !            * name: ReferenceCropEvapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
        call model_referenceetpriestleytaylor(cAltitude, cAlphaPT, iTMax,  &
                iTMin, iNetRadiation,ReferenceCropEvapotranspiration)
    END SUBROUTINE model_referenceetpriestleytaylor_

END MODULE
