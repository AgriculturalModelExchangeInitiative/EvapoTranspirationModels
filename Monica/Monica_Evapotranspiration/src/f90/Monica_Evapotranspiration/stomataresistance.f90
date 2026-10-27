MODULE Stomataresistancemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_stomataresistance(saturation_beta, &
        stomata_conductance_alpha, &
        carboxylation_pathway, &
        atmospheric_co2_concentration, &
        saturation_vapor_pressure_deficit, &
        gross_photosynthesis_reference_mol, &
        stomata_resistance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: saturation_beta
        REAL, INTENT(IN) :: stomata_conductance_alpha
        INTEGER, INTENT(IN) :: carboxylation_pathway
        REAL, INTENT(IN) :: atmospheric_co2_concentration
        REAL, INTENT(IN) :: saturation_vapor_pressure_deficit
        REAL, INTENT(IN) :: gross_photosynthesis_reference_mol
        REAL, INTENT(OUT) :: stomata_resistance
        !- Name: StomataResistance -Version: 1, -Time step: 1
        !- Description:
    !            * Title: MONICA stomata resistance
    !            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
    !            * Reference: 
    !        
    !            * Institution: ZALF e.V.
    !            * ExtendedDescription: 
    !        
    !            * ShortDescription: Calculates the MONICA reference evapotranspiration
        !- inputs:
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
    !            * name: atmospheric_co2_concentration
    !                          ** description : CO2 concentration in the atmosphere. Optional if no crop.
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 430
    !                          ** unit : ppm
    !            * name: saturation_vapor_pressure_deficit
    !                          ** description : saturation_vapor_pressure_deficit
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** unit : kPa
    !            * name: gross_photosynthesis_reference_mol
    !                          ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : -1
    !                          ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
        !- outputs:
    !            * name: stomata_resistance
    !                          ** description : stomata resistance (FAO default value is 100)
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 10000
    !                          ** min : 0
    !                          ** unit : s/m
        IF(carboxylation_pathway .GT. 0) THEN
            IF(gross_photosynthesis_reference_mol .LE. 0.0) THEN
                stomata_resistance = 999999.9
            ELSE IF ( carboxylation_pathway .EQ. 1) THEN
                stomata_resistance = atmospheric_co2_concentration * (1.0 +  &
                        (saturation_vapor_pressure_deficit / saturation_beta)) /  &
                        (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
            ELSE
                stomata_resistance = atmospheric_co2_concentration * (1.0 +  &
                        (saturation_vapor_pressure_deficit / saturation_beta)) /  &
                        (stomata_conductance_alpha * gross_photosynthesis_reference_mol)
            END IF
        END IF
    END SUBROUTINE model_stomataresistance

END MODULE
