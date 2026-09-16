using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: PriestlyTaylor -Version: 1.0, -Time step: 1
///- Description:
///            * Title: evapoTranspirationPriestlyTaylor  Model
///            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
///            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
///            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.
///
///            * ExtendedDescription: Calculate Energy Balance
///            * ShortDescription: It uses Priestly-Taylor method
///- inputs:
///            * name: lambdaV
///                          ** description : latent heat of vaporization of water
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 10.0
///                          ** min : 0.0
///                          ** default : 2.454
///                          ** unit : MJ kg-1
///            * name: netRadiation
///                          ** description : net radiation
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 5000.0
///                          ** min : 0.0
///                          ** default : 1.566
///                          ** unit : MJ m-2 d-1
///            * name: psychrometricConstant
///                          ** description : psychrometric constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1.0
///                          ** min : 0.0
///                          ** default : 0.66
///                          ** unit : 
///            * name: Alpha
///                          ** description : Priestley-Taylor evapotranspiration proportionality constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 100.0
///                          ** min : 0.0
///                          ** default : 1.5
///                          ** unit : 
///            * name: solarRadiation
///                          ** description : solar Radiation
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000.0
///                          ** min : 0.0
///                          ** default : 3.0
///                          ** unit : MJ m-2 d-1
///            * name: hslope
///                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000.0
///                          ** min : 0.0
///                          ** default : 0.584
///                          ** unit : hPa degC-1
///            * name: ih
///                          ** description : hour of the day if the component is hourly, -999 if the component is daily
///                          ** inputtype : variable
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 24
///                          ** min : -999
///                          ** default : -999
///                          ** unit : 
///- outputs:
///            * name: evapoTranspirationPriestlyTaylor
///                          ** description : evapoTranspiration of Priestly Taylor
///                          ** datatype : DOUBLE
///                          ** variablecategory : rate
///                          ** max : 10000.0
///                          ** min : 0.0
///                          ** unit : g m-2 d-1
/// </summary>
public class PriestlyTaylor
{

    private double _lambdaV;
    /// <summary>
    /// Gets and sets the latent heat of vaporization of water
    /// </summary>
    [Description("latent heat of vaporization of water")] 
    [Units("MJ kg-1")] 
    //[Crop2ML(datatype="DOUBLE", min=0.0, max=10.0, default=2.454, parametercategory=constant, inputtype="parameter")] 
    public double lambdaV
    {
        get { return this._lambdaV; }
        set { this._lambdaV= value; } 
    }

    private double _psychrometricConstant;
    /// <summary>
    /// Gets and sets the psychrometric constant
    /// </summary>
    [Description("psychrometric constant")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0.0, max=1.0, default=0.66, parametercategory=constant, inputtype="parameter")] 
    public double psychrometricConstant
    {
        get { return this._psychrometricConstant; }
        set { this._psychrometricConstant= value; } 
    }

    private double _Alpha;
    /// <summary>
    /// Gets and sets the Priestley-Taylor evapotranspiration proportionality constant
    /// </summary>
    [Description("Priestley-Taylor evapotranspiration proportionality constant")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=0.0, max=100.0, default=1.5, parametercategory=constant, inputtype="parameter")] 
    public double Alpha
    {
        get { return this._Alpha; }
        set { this._Alpha= value; } 
    }

    private int _ih;
    /// <summary>
    /// Gets and sets the hour of the day if the component is hourly, -999 if the component is daily
    /// </summary>
    [Description("hour of the day if the component is hourly, -999 if the component is daily")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=-999, max=24, default=-999, parametercategory=constant, inputtype="parameter")] 
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }

    
    /// <summary>
    /// Constructor of the PriestlyTaylor component")
    /// </summary>  
    public PriestlyTaylor() { }
    
    /// <summary>
    /// Algorithm of the PriestlyTaylor component
    /// </summary>
    public void  CalculateModel(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex)
    {
        double netRadiation = a.netRadiation;
        double solarRadiation = a.solarRadiation;
        double hslope = a.hslope;
        double evapoTranspirationPriestlyTaylor;
        double a_G_Rn;
        a_G_Rn = 1.00;
        if (ih != -999)
        {
            if (solarRadiation < 0.001)
            {
                a_G_Rn = 0.50;
            }
            else
            {
                a_G_Rn = 0.90;
            }
        }
        evapoTranspirationPriestlyTaylor = Math.Max(Alpha * hslope * (netRadiation / lambdaV * 1000.00) * a_G_Rn / (hslope + psychrometricConstant), 0.00);
        r.evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor;
    }
}