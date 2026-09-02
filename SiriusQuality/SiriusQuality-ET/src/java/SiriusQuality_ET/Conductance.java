import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Conductance
{
    private double d;
    public double getd()
    { return d; }

    public void setd(double _d)
    { this.d= _d; } 
    
    private double heightWeatherMeasurements;
    public double getheightWeatherMeasurements()
    { return heightWeatherMeasurements; }

    public void setheightWeatherMeasurements(double _heightWeatherMeasurements)
    { this.heightWeatherMeasurements= _heightWeatherMeasurements; } 
    
    private double zh;
    public double getzh()
    { return zh; }

    public void setzh(double _zh)
    { this.zh= _zh; } 
    
    private double zm;
    public double getzm()
    { return zm; }

    public void setzm(double _zm)
    { this.zm= _zm; } 
    
    private double vonKarman;
    public double getvonKarman()
    { return vonKarman; }

    public void setvonKarman(double _vonKarman)
    { this.vonKarman= _vonKarman; } 
    
    private Integer ih;
    public Integer getih()
    { return ih; }

    public void setih(Integer _ih)
    { this.ih= _ih; } 
    
    public Conductance() { }
    public void  Calculate_Model(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a,  EnergyBalanceCompositeExogenous ex)
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
        double plantHeight = a.getplantHeight();
        double wind = a.getwind();
        double conductance;
        double h;
        double clim;
        clim = 0.10d;
        if (ih != -999)
        {
            clim = 36.00d;
        }
        h = Math.max(10.00d, plantHeight) / 100.00d;
        conductance = wind * Math.pow(vonKarman, 2) / (Math.log((heightWeatherMeasurements - (d * h)) / (zm * h)) * Math.log((heightWeatherMeasurements - (d * h)) / (zh * h)));
        conductance = Math.max(clim, conductance);
        s.setconductance(conductance);
    }
}