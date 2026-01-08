MODULE Referenceethargreaves_mod
    USE Referenceethargreavesmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_referenceethargreaves_(iTMax, &
        iSolarRadiation, &
        iTMin, &
        cConvertLeByTemp, &
        ReferenceCropEvapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: iTMax
        REAL, INTENT(IN) :: iSolarRadiation
        REAL, INTENT(IN) :: iTMin
        LOGICAL, INTENT(IN) :: cConvertLeByTemp
        REAL, INTENT(OUT) :: ReferenceCropEvapotranspiration
        !- Name: ReferenceETHargreaves_ -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ReferenceETHargreaves_ model
    !            * Authors: Gunther Krauss
    !            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    !            * Institution: INRES Pflanzenbau, Uni Bonn
    !            * ExtendedDescription: as given in the documentation
    !            * ShortDescription: None
        !- inputs:
    !            * name: iTMax
    !                          ** description : maximum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: iSolarRadiation
    !                          ** description : solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    !            * name: iTMin
    !                          ** description : minimum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    !            * name: cConvertLeByTemp
    !                          ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** default : false
    !                          ** unit : 
        !- outputs:
    !            * name: ReferenceCropEvapotranspiration
    !                          ** description : reference evapotranspiration (ET0)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
        call model_referenceethargreaves(cConvertLeByTemp, iTMax, iTMin,  &
                iSolarRadiation,ReferenceCropEvapotranspiration)
    END SUBROUTINE model_referenceethargreaves_

END MODULE
