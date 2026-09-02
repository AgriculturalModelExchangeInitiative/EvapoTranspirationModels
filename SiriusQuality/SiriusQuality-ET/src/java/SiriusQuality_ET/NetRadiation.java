import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class NetRadiation
{
    private double albedoCoefficient;
    public double getalbedoCoefficient()
    { return albedoCoefficient; }

    public void setalbedoCoefficient(double _albedoCoefficient)
    { this.albedoCoefficient= _albedoCoefficient; } 
    
    private double tau;
    public double gettau()
    { return tau; }

    public void settau(double _tau)
    { this.tau= _tau; } 
    
    private double elevation;
    public double getelevation()
    { return elevation; }

    public void setelevation(double _elevation)
    { this.elevation= _elevation; } 
    
    private double stefanBoltzman;
    public double getstefanBoltzman()
    { return stefanBoltzman; }

    public void setstefanBoltzman(double _stefanBoltzman)
    { this.stefanBoltzman= _stefanBoltzman; } 
    
    private double albedoCoefficientCan;
    public double getalbedoCoefficientCan()
    { return albedoCoefficientCan; }

    public void setalbedoCoefficientCan(double _albedoCoefficientCan)
    { this.albedoCoefficientCan= _albedoCoefficientCan; } 
    
    public NetRadiation() { }
    public void  Calculate_Model(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a,  EnergyBalanceCompositeExogenous ex)
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
        double maxTair = a.getmaxTair();
        double minTair = a.getminTair();
        double vaporPressure = a.getvaporPressure();
        Integer ih = s.getih();
        double extraSolarRadiation = a.getextraSolarRadiation();
        double solarRadiation = a.getsolarRadiation();
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
            Nsr = solarRadiation * (1 - (albedoCoefficientCan * tau + (albedoCoefficient * (1.00d - tau))));
        }
        else
        {
            cov = (double)(1);
            if (solarRadiation > 0.01d)
            {
                if (ih <= 7)
                {
                    cov = 0.30d;
                }
                else if ( ih > 7 && ih < 11)
                {
                    cov = 0.30d - (0.09d / 3.00d * (ih - 7.00d));
                }
                else if ( ih == 11)
                {
                    cov = 0.21d;
                }
                else if ( ih > 11 && ih < 15)
                {
                    cov = 0.21d + (0.09d / 3.00d * (ih - 11.00d));
                }
                else
                {
                    cov = 0.30d;
                }
            }
            Nsr = (1 - cov) * solarRadiation;
        }
        clearSkySolarRadiation = (0.750d + (2 * Math.pow(10.00d, -5) * elevation)) * extraSolarRadiation;
        averageT = (Math.pow(maxTair + 273.160d, 4) + Math.pow(minTair + 273.160d, 4)) / 2.00d;
        surfaceEmissivity = 0.340d - (0.140d * Math.sqrt(vaporPressure / 10.00d));
        cloudCoverFactor = 1.350d * (solarRadiation / clearSkySolarRadiation) - 0.350d;
        Nolr = stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;
        if (ih != -999)
        {
            Nolr = Nolr / 24.00d;
        }
        netRadiation = Nsr - Nolr;
        netOutGoingLongWaveRadiation = Nolr;
        a.setnetRadiation(netRadiation);
        a.setnetOutGoingLongWaveRadiation(netOutGoingLongWaveRadiation);
    }
}