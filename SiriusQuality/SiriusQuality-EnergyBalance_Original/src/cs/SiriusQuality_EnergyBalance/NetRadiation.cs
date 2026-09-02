using System;
using System.Collections.Generic;
using System.Linq;
public class NetRadiation
{
    private double _albedoCoefficient;
    public double albedoCoefficient
    {
        get { return this._albedoCoefficient; }
        set { this._albedoCoefficient= value; } 
    }
    private double _tau;
    public double tau
    {
        get { return this._tau; }
        set { this._tau= value; } 
    }
    private double _elevation;
    public double elevation
    {
        get { return this._elevation; }
        set { this._elevation= value; } 
    }
    private double _stefanBoltzman;
    public double stefanBoltzman
    {
        get { return this._stefanBoltzman; }
        set { this._stefanBoltzman= value; } 
    }
    private double _albedoCoefficientCan;
    public double albedoCoefficientCan
    {
        get { return this._albedoCoefficientCan; }
        set { this._albedoCoefficientCan= value; } 
    }
    /// <summary>
    /// Constructor of the NetRadiation component")
    /// </summary>  
    public NetRadiation() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        //- Name: NetRadiation -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: NetRadiation Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both short
    //and long wavelength radiation
    //            * ShortDescription: It refers as difference between incoming and outgoing radiation of both short
    //and long wavelength radiation
        //- inputs:
    //            * name: albedoCoefficient
    //                          ** description : albedo Coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.23
    //                          ** unit : 
    //            * name: maxTair
    //                          ** description : maximum air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 45
    //                          ** min : 30
    //                          ** default : 7.2
    //                          ** unit : degC
    //            * name: minTair
    //                          ** description : minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 45
    //                          ** min : 30
    //                          ** default : 0.7
    //                          ** unit : degC
    //            * name: vaporPressure
    //                          ** description : vapor Pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 6.1
    //                          ** unit : hPa
    //            * name: ih
    //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 24
    //                          ** min : 999
    //                          ** default : 999
    //                          ** unit : 
    //            * name: extraSolarRadiation
    //                          ** description : extra Solar Radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 11.7
    //                          ** unit : MJ m2 d-1
    //            * name: solarRadiation
    //                          ** description : solar Radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : MJ m-2 d-1
    //            * name: tau
    //                          ** description : plant cover factor
    //                          ** inputtype : parameter
    //                          ** parametercategory : species
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 0.9983
    //                          ** unit : 
    //            * name: elevation
    //                          ** description : elevation
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 500
    //                          ** default : 0
    //                          ** unit : m
    //            * name: stefanBoltzman
    //                          ** description : stefan Boltzman constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 4.903E-09
    //                          ** unit : 
    //            * name: albedoCoefficientCan
    //                          ** description : albedo Coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.23
    //                          ** unit : 
        //- outputs:
    //            * name: netRadiation
    //                          ** description : net radiation
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** unit : MJ m-2 d-1
    //            * name: netOutGoingLongWaveRadiation
    //                          ** description : net OutGoing Long Wave Radiation
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** unit : g m-2 d-1
        double maxTair = a.maxTair;
        double minTair = a.minTair;
        double vaporPressure = a.vaporPressure;
        int ih = s.ih;
        double extraSolarRadiation = a.extraSolarRadiation;
        double solarRadiation = a.solarRadiation;
        double netRadiation;
        double netOutGoingLongWaveRadiation;
        double Nsr;
        double clearSkySolarRadiation;
        double averageT;
        double surfaceEmissivity;
        double cloudCoverFactor;
        double Nolr;
        double cov;
        if (ih == -999)
        {
            Nsr = solarRadiation * (1 - (albedoCoefficientCan * tau + (albedoCoefficient * (1.00 - tau))));
        }
        else
        {
            cov = (double)(1);
            if (solarRadiation > 0.01)
            {
                if (ih <= 7)
                {
                    cov = 0.30;
                }
                else if ( ih > 7 && ih < 11)
                {
                    cov = 0.30 - (0.09 / 3.00 * (ih - 7.00));
                }
                else if ( ih == 11)
                {
                    cov = 0.21;
                }
                else if ( ih > 11 && ih < 15)
                {
                    cov = 0.21 + (0.09 / 3.00 * (ih - 11.00));
                }
                else
                {
                    cov = 0.30;
                }
            }
            Nsr = (1 - cov) * solarRadiation;
        }
        clearSkySolarRadiation = (0.750 + (2 * Math.Pow(10.00, -5) * elevation)) * extraSolarRadiation;
        averageT = (Math.Pow(maxTair + 273.160, 4) + Math.Pow(minTair + 273.160, 4)) / 2.00;
        surfaceEmissivity = 0.340 - (0.140 * Math.Sqrt(vaporPressure / 10.00));
        cloudCoverFactor = 1.350 * (solarRadiation / clearSkySolarRadiation) - 0.350;
        Nolr = stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;
        if (ih != -999)
        {
            Nolr = Nolr / 24.00;
        }
        netRadiation = Nsr - Nolr;
        netOutGoingLongWaveRadiation = Nolr;
        a.netRadiation= netRadiation;
        a.netOutGoingLongWaveRadiation= netOutGoingLongWaveRadiation;
    }
}