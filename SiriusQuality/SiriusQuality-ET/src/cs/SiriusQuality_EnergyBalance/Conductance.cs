using System;
using System.Collections.Generic;
using System.Linq;
public class Conductance
{
    private double _d;
    public double d
    {
        get { return this._d; }
        set { this._d= value; } 
    }
    private double _heightWeatherMeasurements;
    public double heightWeatherMeasurements
    {
        get { return this._heightWeatherMeasurements; }
        set { this._heightWeatherMeasurements= value; } 
    }
    private double _zh;
    public double zh
    {
        get { return this._zh; }
        set { this._zh= value; } 
    }
    private double _zm;
    public double zm
    {
        get { return this._zm; }
        set { this._zm= value; } 
    }
    private double _vonKarman;
    public double vonKarman
    {
        get { return this._vonKarman; }
        set { this._vonKarman= value; } 
    }
    private int _ih;
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    /// <summary>
    /// Constructor of the Conductance component")
    /// </summary>  
    public Conductance() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        //- Name: Conductance -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: Conductance Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
    //canopy and the canopy structure. The approach does not take into account buoyancy
    //effects.
    //
    //            * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
    //canopy and the canopy structure. The approach does not take into account buoyancy
    //effects.
    //
        //- inputs:
    //            * name: d
    //                          ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.67
    //                          ** unit : dimensionless
    //            * name: heightWeatherMeasurements
    //                          ** description : reference height of wind and humidity measurements
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 2
    //                          ** unit : m
    //            * name: plantHeight
    //                          ** description : plant Height
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: zh
    //                          ** description : roughness length governing transfer of heat and vapour, FAO
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.013
    //                          ** unit : m
    //            * name: zm
    //                          ** description : roughness length governing momentum transfer, FAO
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.13
    //                          ** unit : m
    //            * name: vonKarman
    //                          ** description : von Karman constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.42
    //                          ** unit : dimensionless
    //            * name: ih
    //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    //                          ** inputtype : variable
    //                          ** parametercategory : state
    //                          ** datatype : INT
    //                          ** max : 24
    //                          ** min : 999
    //                          ** default : 999
    //                          ** unit : 
    //            * name: wind
    //                          ** description : wind
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000000
    //                          ** min : 0
    //                          ** default : 124000
    //                          ** unit : m/d
        //- outputs:
    //            * name: conductance
    //                          ** description : the boundary layer conductance
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : m/d
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