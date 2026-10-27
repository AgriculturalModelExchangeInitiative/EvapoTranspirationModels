using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: StomataResistance -Version: 1, -Time step: 1
///- Description:
///            * Title: MONICA stomata resistance
///            * Authors: Claas Nendel (transcription into Crop2ML by Michael Berg-Mohnicke)
///            * Reference: 
///        
///            * Institution: ZALF e.V.
///            * ExtendedDescription: 
///        
///            * ShortDescription: Calculates the MONICA reference evapotranspiration
///- inputs:
///            * name: saturation_beta
///                          ** description : Original: Yu et al. 2001; beta = 3.5
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 2.5
///                          ** unit : 
///            * name: stomata_conductance_alpha
///                          ** description : Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 40
///                          ** unit : mmol/m2/s
///            * name: carboxylation_pathway
///                          ** description : Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 2
///                          ** min : 0
///                          ** default : 0
///                          ** unit : dimensionless
///            * name: atmospheric_co2_concentration
///                          ** description : CO2 concentration in the atmosphere. Optional if no crop.
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : 430
///                          ** unit : ppm
///            * name: saturation_vapor_pressure_deficit
///                          ** description : saturation_vapor_pressure_deficit
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** unit : kPa
///            * name: gross_photosynthesis_reference_mol
///                          ** description : gross_photosynthesis_reference_mol (-1 = not supplied = no crop)
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 0
///                          ** default : -1
///                          ** unit : [mol m-2 s-1] or [cm3 cm-2 s-1]
///- outputs:
///            * name: stomata_resistance
///                          ** description : stomata resistance (FAO default value is 100)
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** unit : s/m
/// </summary>
public class StomataResistance
{

    private double _saturation_beta;
    /// <summary>
    /// Gets and sets the Original: Yu et al. 2001; beta = 3.5
    /// </summary>
    [Description("Original: Yu et al. 2001; beta = 3.5")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=2.5, parametercategory=constant, inputtype="parameter")] 
    public double saturation_beta
    {
        get { return this._saturation_beta; }
        set { this._saturation_beta= value; } 
    }

    private double _stomata_conductance_alpha;
    /// <summary>
    /// Gets and sets the Original: Yu et al. 2001; alpha = 0.06 mol/m2/s
    /// </summary>
    [Description("Original: Yu et al. 2001; alpha = 0.06 mol/m2/s")] 
    [Units("mmol/m2/s")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=40, parametercategory=constant, inputtype="parameter")] 
    public double stomata_conductance_alpha
    {
        get { return this._stomata_conductance_alpha; }
        set { this._stomata_conductance_alpha= value; } 
    }

    private int _carboxylation_pathway;
    /// <summary>
    /// Gets and sets the Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)
    /// </summary>
    [Description("Is it a C3 (=1) or C4 (=2) crop. (0 = no crop)")] 
    [Units("dimensionless")] 
    //[Crop2ML(datatype="INT", min=0, max=2, default=0, parametercategory=constant, inputtype="parameter")] 
    public int carboxylation_pathway
    {
        get { return this._carboxylation_pathway; }
        set { this._carboxylation_pathway= value; } 
    }

    
    /// <summary>
    /// Constructor of the StomataResistance component")
    /// </summary>  
    public StomataResistance() { }
    
    /// <summary>
    /// Algorithm of the StomataResistance component
    /// </summary>
    public void  CalculateModel(ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex)
    {
        double atmospheric_co2_concentration = ex.atmospheric_co2_concentration;
        double saturation_vapor_pressure_deficit = a.saturation_vapor_pressure_deficit;
        double gross_photosynthesis_reference_mol = a.gross_photosynthesis_reference_mol;
        double stomata_resistance;
        if (carboxylation_pathway > 0)
        {
            if (gross_photosynthesis_reference_mol <= 0.0)
            {
                stomata_resistance = 999999.9;
            }
            else if ( carboxylation_pathway == 1)
            {
                stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol);
            }
            else
            {
                stomata_resistance = atmospheric_co2_concentration * (1.0 + (saturation_vapor_pressure_deficit / saturation_beta)) / (stomata_conductance_alpha * gross_photosynthesis_reference_mol);
            }
        }
        a.stomata_resistance= stomata_resistance;
    }
}