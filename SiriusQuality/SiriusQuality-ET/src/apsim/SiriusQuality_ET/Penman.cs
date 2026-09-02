using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: Penman -Version: 1.0, -Time step: 1
///- Description:
///            * Title: Penman Model
///            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
///            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
///            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.
///
///            * ExtendedDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
///            * ShortDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
///- inputs:
///            * name: VPDair
///                          ** description : vapour pressure density
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000
///                          ** min : 0
///                          ** default : 2.19
///                          ** unit : hPa
///            * name: specificHeatCapacityAir
///                          ** description : Specific heat capacity of dry air
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.00101
///                          ** unit : 
///            * name: psychrometricConstant
///                          ** description : psychrometric constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.66
///                          ** unit : 
///            * name: rhoDensityAir
///                          ** description : Density of air
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : None
///                          ** min : None
///                          ** default : 1.225
///                          ** unit : 
///            * name: Alpha
///                          ** description : Priestley-Taylor evapotranspiration proportionality constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 100
///                          ** min : 0
///                          ** default : 1.5
///                          ** unit : 
///            * name: evapoTranspirationPriestlyTaylor
///                          ** description : evapoTranspiration of Priestly Taylor
///                          ** inputtype : variable
///                          ** variablecategory : rate
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** default : 449.367
///                          ** unit : g m-2 d-1
///            * name: lambdaV
///                          ** description : latent heat of vaporization of water
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 10
///                          ** min : 0
///                          ** default : 2.454
///                          ** unit : 
///            * name: hslope
///                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000
///                          ** min : 0
///                          ** default : 0.584
///                          ** unit : hPa degC-1
///            * name: conductance
///                          ** description : conductance
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 10000
///                          ** min : 0
///                          ** default : 598.685
///                          ** unit : m d-1
///- outputs:
///            * name: evapoTranspirationPenman
///                          ** description : evapoTranspiration of Penman Monteith
///                          ** datatype : DOUBLE
///                          ** variablecategory : rate
///                          ** max : 5000
///                          ** min : 0
///                          ** unit : g m-2 d-1
/// </summary>
public class Penman
{

    private double _specificHeatCapacityAir;
    /// <summary>
    /// Gets and sets the Specific heat capacity of dry air
    /// </summary>
    [Description("Specific heat capacity of dry air")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.00101, parametercategory=constant, inputtype="parameter")] 
    public double specificHeatCapacityAir
    {
        get { return this._specificHeatCapacityAir; }
        set { this._specificHeatCapacityAir= value; } 
    }

    private double _psychrometricConstant;
    /// <summary>
    /// Gets and sets the psychrometric constant
    /// </summary>
    [Description("psychrometric constant")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.66, parametercategory=constant, inputtype="parameter")] 
    public double psychrometricConstant
    {
        get { return this._psychrometricConstant; }
        set { this._psychrometricConstant= value; } 
    }

    private double _rhoDensityAir;
    /// <summary>
    /// Gets and sets the Density of air
    /// </summary>
    [Description("Density of air")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=None, max=None, default=1.225, parametercategory=constant, inputtype="parameter")] 
    public double rhoDensityAir
    {
        get { return this._rhoDensityAir; }
        set { this._rhoDensityAir= value; } 
    }

    private double _Alpha;
    /// <summary>
    /// Gets and sets the Priestley-Taylor evapotranspiration proportionality constant
    /// </summary>
    [Description("Priestley-Taylor evapotranspiration proportionality constant")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=100, default=1.5, parametercategory=constant, inputtype="parameter")] 
    public double Alpha
    {
        get { return this._Alpha; }
        set { this._Alpha= value; } 
    }

    private double _lambdaV;
    /// <summary>
    /// Gets and sets the latent heat of vaporization of water
    /// </summary>
    [Description("latent heat of vaporization of water")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=10, default=2.454, parametercategory=constant, inputtype="parameter")] 
    public double lambdaV
    {
        get { return this._lambdaV; }
        set { this._lambdaV= value; } 
    }

    
    /// <summary>
    /// Constructor of the Penman component")
    /// </summary>  
    public Penman() { }
    
    /// <summary>
    /// Algorithm of the Penman component
    /// </summary>
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        double VPDair = a.VPDair;
        double evapoTranspirationPriestlyTaylor = r.evapoTranspirationPriestlyTaylor;
        double hslope = a.hslope;
        double conductance = s.conductance;
        double evapoTranspirationPenman;
        evapoTranspirationPenman = evapoTranspirationPriestlyTaylor / Alpha + (1000.00 * (rhoDensityAir * specificHeatCapacityAir * VPDair * conductance / (lambdaV * (hslope + psychrometricConstant))));
        r.evapoTranspirationPenman = evapoTranspirationPenman;
    }
}