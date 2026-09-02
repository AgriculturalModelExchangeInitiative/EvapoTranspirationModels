using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: Conductance -Version: 1.0, -Time step: 1
///- Description:
///            * Title: Conductance Model
///            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
///            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
///
///            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.,
///New Zealand Institute for Crop and Food Research Ltd.
///
///            * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
///canopy and the canopy structure. The approach does not take into account buoyancy
///effects.
///
///            * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
///canopy and the canopy structure. The approach does not take into account buoyancy
///effects.
///
///- inputs:
///            * name: d
///                          ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.67
///                          ** unit : dimensionless
///            * name: heightWeatherMeasurements
///                          ** description : reference height of wind and humidity measurements
///                          ** inputtype : parameter
///                          ** parametercategory : soil
///                          ** datatype : DOUBLE
///                          ** max : 10
///                          ** min : 0
///                          ** default : 2
///                          ** unit : m
///            * name: plantHeight
///                          ** description : plant Height
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000
///                          ** min : 0
///                          ** default : 0
///                          ** unit : mm
///            * name: zh
///                          ** description : roughness length governing transfer of heat and vapour, FAO
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.013
///                          ** unit : m
///            * name: zm
///                          ** description : roughness length governing momentum transfer, FAO
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.13
///                          ** unit : m
///            * name: vonKarman
///                          ** description : von Karman constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.42
///                          ** unit : dimensionless
///            * name: ih
///                          ** description : hour of the day if the component is hourly, -999 if the component is daily
///                          ** inputtype : variable
///                          ** parametercategory : state
///                          ** datatype : INT
///                          ** max : 24
///                          ** min : 999
///                          ** default : 999
///                          ** unit : 
///            * name: wind
///                          ** description : wind
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 1000000
///                          ** min : 0
///                          ** default : 124000
///                          ** unit : m/d
///- outputs:
///            * name: conductance
///                          ** description : the boundary layer conductance
///                          ** datatype : DOUBLE
///                          ** variablecategory : state
///                          ** max : 10000
///                          ** min : 0
///                          ** unit : m/d
/// </summary>
public class Conductance
{

    private double _d;
    /// <summary>
    /// Gets and sets the corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
    /// </summary>
    [Description("corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO")] 
    [Units("dimensionless")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.67, parametercategory=constant, inputtype="parameter")] 
    public double d
    {
        get { return this._d; }
        set { this._d= value; } 
    }

    private double _heightWeatherMeasurements;
    /// <summary>
    /// Gets and sets the reference height of wind and humidity measurements
    /// </summary>
    [Description("reference height of wind and humidity measurements")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=10, default=2, parametercategory=soil, inputtype="parameter")] 
    public double heightWeatherMeasurements
    {
        get { return this._heightWeatherMeasurements; }
        set { this._heightWeatherMeasurements= value; } 
    }

    private double _zh;
    /// <summary>
    /// Gets and sets the roughness length governing transfer of heat and vapour, FAO
    /// </summary>
    [Description("roughness length governing transfer of heat and vapour, FAO")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.013, parametercategory=constant, inputtype="parameter")] 
    public double zh
    {
        get { return this._zh; }
        set { this._zh= value; } 
    }

    private double _zm;
    /// <summary>
    /// Gets and sets the roughness length governing momentum transfer, FAO
    /// </summary>
    [Description("roughness length governing momentum transfer, FAO")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.13, parametercategory=constant, inputtype="parameter")] 
    public double zm
    {
        get { return this._zm; }
        set { this._zm= value; } 
    }

    private double _vonKarman;
    /// <summary>
    /// Gets and sets the von Karman constant
    /// </summary>
    [Description("von Karman constant")] 
    [Units("dimensionless")] 
    //[Crop2ML(datatype="DOUBLE", min=0, max=1, default=0.42, parametercategory=constant, inputtype="parameter")] 
    public double vonKarman
    {
        get { return this._vonKarman; }
        set { this._vonKarman= value; } 
    }

    private int _ih;
    /// <summary>
    /// Gets and sets the hour of the day if the component is hourly, -999 if the component is daily
    /// </summary>
    [Description("hour of the day if the component is hourly, -999 if the component is daily")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=999, max=24, default=999, parametercategory=state, inputtype="parameter")] 
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }

    
    /// <summary>
    /// Constructor of the Conductance component")
    /// </summary>  
    public Conductance() { }
    
    /// <summary>
    /// Algorithm of the Conductance component
    /// </summary>
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        double plantHeight = a.plantHeight;
        double wind = a.wind;
        double conductance;
        double h;
        double clim;
        clim = 0.10;
        if (ih != -999)
        {
            clim = 36.00;
        }
        h = Math.Max(10.00, plantHeight) / 100.00;
        conductance = wind * Math.Pow(vonKarman, 2) / (Math.Log((heightWeatherMeasurements - (d * h)) / (zm * h)) * Math.Log((heightWeatherMeasurements - (d * h)) / (zh * h)));
        conductance = Math.Max(clim, conductance);
        s.conductance= conductance;
    }
}