MODULE Referenceethargreavesmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_referenceethargreaves(cConvertLeByTemp, &
        iTMax, &
        iTMin, &
        iSolarRadiation, &
        ReferenceCropEvapotranspiration)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        LOGICAL, INTENT(IN) :: cConvertLeByTemp
        REAL, INTENT(IN) :: iTMax
        REAL, INTENT(IN) :: iTMin
        REAL, INTENT(IN) :: iSolarRadiation
        REAL, INTENT(OUT) :: ReferenceCropEvapotranspiration
        REAL:: R_s_eveq
        !- Name: ReferenceETHargreaves -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ReferenceETHargreaves model
    !            * Authors: Gunther Krauss
    !            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    !            * Institution: INRES Pflanzenbau, Uni Bonn
    !            * ExtendedDescription: as given in the documentation
    !            * ShortDescription: None
        !- inputs:
    !            * name: cConvertLeByTemp
    !                          ** description : Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** default : false
    !                          ** unit : 
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
    !            * name: iSolarRadiation
    !                          ** description : solar radiation
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
        IF(cConvertLeByTemp) THEN
            R_s_eveq = EvaporationEquivalentToRadiation1(iSolarRadiation, 0.5 *  &
                    (iTMax + iTMin))
        ELSE
            R_s_eveq = EvaporationEquivalentToRadiation2(iSolarRadiation)
        END IF
        ReferenceCropEvapotranspiration = MAX(float(0),  &
                ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax, iTMin))
    END SUBROUTINE model_referenceethargreaves

    FUNCTION EvaporationEquivalentToRadiation1(Radiation, &
        DailyMeanTemperature) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: Radiation
        REAL, INTENT(IN) :: DailyMeanTemperature
        REAL:: res_cyml
        res_cyml = 1 / (2.501 - (0.002361 * DailyMeanTemperature)) * Radiation
        RETURN
    END FUNCTION EvaporationEquivalentToRadiation1

    FUNCTION EvaporationEquivalentToRadiation2(Radiation) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: Radiation
        REAL:: res_cyml
        res_cyml = 0.408 * Radiation
        RETURN
    END FUNCTION EvaporationEquivalentToRadiation2

    FUNCTION ReferenceEvapoTranspirationFromSolarRadiation(R_s, &
        T_max, &
        T_min) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: R_s
        REAL, INTENT(IN) :: T_max
        REAL, INTENT(IN) :: T_min
        REAL:: T_mean
        REAL:: res_cyml
        T_mean = (T_max + T_min) / 2
        res_cyml = 0.0135 * (T_mean + 17.8) * R_s
        RETURN
    END FUNCTION ReferenceEvapoTranspirationFromSolarRadiation

END MODULE
