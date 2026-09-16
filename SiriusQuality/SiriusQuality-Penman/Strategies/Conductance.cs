using System;
using System.Collections.Generic;
using System.Linq;
public class Conductance
{
    private double _vonKarman;
    public double vonKarman
    {
        get { return this._vonKarman; }
        set { this._vonKarman = value; }
    }
    private double _heightWeatherMeasurements;
    public double heightWeatherMeasurements
    {
        get { return this._heightWeatherMeasurements; }
        set { this._heightWeatherMeasurements = value; }
    }
    private double _zm;
    public double zm
    {
        get { return this._zm; }
        set { this._zm = value; }
    }
    private double _zh;
    public double zh
    {
        get { return this._zh; }
        set { this._zh = value; }
    }
    private double _d;
    public double d
    {
        get { return this._d; }
        set { this._d = value; }
    }
    public Conductance() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: Conductance -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: Conductance Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
        //        
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
        //            canopy and the canopy structure. The approach does not take into account buoyancy
        //            effects. 
        //        
        //            * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
        //            canopy and the canopy structure. The approach does not take into account buoyancy
        //            effects.
        //        
        //- inputs:
        //            * name: ih
        //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
        //                          ** parametercategory : state
        //                          ** datatype : INT
        //                          ** default : -999
        //                          ** min : -999
        //                          ** max : 24
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: vonKarman
        //                          ** description : von Karman constant
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 1
        //                          ** default : 0.42
        //                          ** unit : dimensionless
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //                          ** parametercategory : constant
        //            * name: heightWeatherMeasurements
        //                          ** description : reference height of wind and humidity measurements
        //                          ** parametercategory : soil
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10
        //                          ** default : 2
        //                          ** unit : m
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: zm
        //                          ** description : roughness length governing momentum transfer, FAO
        //                          ** parametercategory : constant
        //                          ** inputtype : parameter
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 1
        //                          ** default : 0.13
        //                          ** unit : m
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: zh
        //                          ** description : roughness length governing transfer of heat and vapour, FAO
        //                          ** parametercategory : constant
        //                          ** inputtype : parameter
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 1
        //                          ** default : 0.013
        //                          ** unit : m
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: d
        //                          ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
        //                          ** inputtype : parameter
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0.67
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : dimensionless
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547rl
        //            * name: plantHeight
        //                          ** description : plant Height
        //                          ** datatype : DOUBLE
        //                          ** default : 0
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : mm
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //                          ** variablecategory : auxiliary
        //            * name: wind
        //                          ** description : wind
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 124000
        //                          ** min : 0
        //                          ** max : 1000000
        //                          ** unit : m/d
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //- outputs:
        //            * name: conductance
        //                          ** description : the boundary layer conductance
        //                          ** variablecategory : state
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** unit : m/d
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%
        double plantHeight = a.plantHeight;
        double wind = a.wind;
        int ih= s.ih;
        double conductance;
        double h;

        double clim = 0.10d;
        if (ih != -999) clim = 36.00d;

        h = Math.Max(10.00d, plantHeight) / 100.00d;
        conductance = wind * Math.Pow(vonKarman, 2) / (Math.Log((heightWeatherMeasurements - (d * h)) / (zm * h)) * Math.Log((heightWeatherMeasurements - (d * h)) / (zh * h)));
        s.conductance = Math.Max(clim, conductance);
    }
}