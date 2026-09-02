using System;
using System.Collections.Generic;
using System.Linq;
public class NetRadiation
{
    private double _albedoCoefficient;
    public double albedoCoefficient
    {
        get { return this._albedoCoefficient; }
        set { this._albedoCoefficient = value; }
    }

    private double _albedoCoefficientCan;

    public double albedoCoefficientCan
    {
        get { return this._albedoCoefficientCan; }
        set { this._albedoCoefficientCan = value; }
    }

    private double _stefanBoltzman;
    public double stefanBoltzman
    {
        get { return this._stefanBoltzman; }
        set { this._stefanBoltzman = value; }
    }
    private double _elevation;
    public double elevation
    {
        get { return this._elevation; }
        set { this._elevation = value; }
    }
    public NetRadiation() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: NetRadiation -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: NetRadiation Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both short
        //                     and long wavelength radiation 
        //            * ShortDescription: It refers as difference between incoming and outgoing radiation of both short
        //            and long wavelength radiation 
        //- inputs:
        //            * name: ih
        //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
        //                          ** variablecategory : state
        //                          ** datatype : INT
        //                          ** default : -999
        //                          ** min : -999
        //                          ** max : 24
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: tau
        //                          ** description : plant cover factor
        //                          ** parametercategory : species
        //                          ** datatype : DOUBLE
        //                          ** default : 0.9983
        //                          ** min : 0
        //                          ** max : 100
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: minTair
        //                          ** description : minimum air temperature
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** min : -30
        //                          ** max : 45
        //                          ** default : 0.7
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: maxTair
        //                          ** description : maximum air Temperature
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** min : -30
        //                          ** max : 45
        //                          ** default : 7.2
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: albedoCoefficient
        //                          ** description : albedo Coefficient
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0.23
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: albedoCoefficientCan
        //                          ** description : albedo Coefficient
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0.23
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: stefanBoltzman
        //                          ** description : stefan Boltzman constant
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 4.903E-09
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: elevation
        //                          ** description : elevation
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0
        //                          ** min : -500
        //                          ** max : 10000
        //                          ** unit : m
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: solarRadiation
        //                          ** description : solar Radiation
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 3
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : MJ m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: vaporPressure
        //                          ** description : vapor Pressure
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 6.1
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : hPa
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: extraSolarRadiation
        //                          ** description : extra Solar Radiation
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 11.7
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : MJ m2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //- outputs:
        //            * name: netRadiation
        //                          ** description :  net radiation 
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 5000
        //                          ** unit : MJ m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: netOutGoingLongWaveRadiation
        //                          ** description : net OutGoing Long Wave Radiation 
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 5000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%
        double minTair = a.minTair;
        double maxTair = a.maxTair;
        double solarRadiation = a.solarRadiation;
        double vaporPressure = a.vaporPressure;
        double extraSolarRadiation = a.extraSolarRadiation;
        int ih = s.ih;
        double tau = a.tau;
        double netRadiation;
        double netOutGoingLongWaveRadiation;
        double Nsr;
        double clearSkySolarRadiation;
        double averageT;
        double surfaceEmissivity;
        double cloudCoverFactor;
        double Nolr;

        if (ih == -999)
        {

            Nsr = solarRadiation * (1-(albedoCoefficientCan * tau+ albedoCoefficient*(1.00d-tau)));
        }
        else
        {
            double cov = 1;

            if (solarRadiation > 0.01d)
            {
                if (ih <= 7) cov = 0.30d;
                else if (ih > 7 && ih < 11)
                {
                    cov = 0.30d- (0.09d / 3.00d) * (ih - 7.00d);
                }
                else if (ih == 11)
                {
                    cov = 0.21d;

                }
                else if (ih > 11 && ih < 15)
                {
                    cov = 0.21d + (0.09d / 3.00d) * (ih - 11.00d);
                }
                else
                {
                    cov = 0.30d;
                }
            }

            Nsr = (1 - cov) * solarRadiation;
        }
        clearSkySolarRadiation = (0.750d + (2 * Math.Pow(10.00d, -5) * elevation)) * extraSolarRadiation;
        averageT = (Math.Pow(maxTair + 273.160d, 4) + Math.Pow(minTair + 273.160d, 4)) / 2.00d;
        surfaceEmissivity = 0.340d - (0.140d * Math.Sqrt(vaporPressure / 10.00d));
        cloudCoverFactor = 1.350d * (solarRadiation / clearSkySolarRadiation) - 0.350d;
        Nolr = stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;

        if (ih != -999)
        {
            Nolr /= 24.00d;
        }

        netRadiation = Nsr - Nolr;
        netOutGoingLongWaveRadiation = Nolr;
        a.netRadiation = netRadiation;
        a.netOutGoingLongWaveRadiation = netOutGoingLongWaveRadiation;
    }
}