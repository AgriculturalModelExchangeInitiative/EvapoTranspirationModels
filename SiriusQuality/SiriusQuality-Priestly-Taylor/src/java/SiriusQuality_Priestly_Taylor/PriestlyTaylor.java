import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class PriestlyTaylor
{
    private double lambdaV;
    public double getlambdaV()
    { return lambdaV; }

    public void setlambdaV(double _lambdaV)
    { this.lambdaV= _lambdaV; } 
    
    private double psychrometricConstant;
    public double getpsychrometricConstant()
    { return psychrometricConstant; }

    public void setpsychrometricConstant(double _psychrometricConstant)
    { this.psychrometricConstant= _psychrometricConstant; } 
    
    private double Alpha;
    public double getAlpha()
    { return Alpha; }

    public void setAlpha(double _Alpha)
    { this.Alpha= _Alpha; } 
    
    private Integer ih;
    public Integer getih()
    { return ih; }

    public void setih(Integer _ih)
    { this.ih= _ih; } 
    
    public PriestlyTaylor() { }
    public void  Calculate_Model(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a,  PotentialET_PTExogenous ex)
    {
        //- Name: PriestlyTaylor -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: evapoTranspirationPriestlyTaylor  Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: Calculate Energy Balance
    //            * ShortDescription: It uses Priestly-Taylor method
        //- inputs:
    //            * name: lambdaV
    //                          ** description : latent heat of vaporization of water
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10.0
    //                          ** min : 0.0
    //                          ** default : 2.454
    //                          ** unit : MJ kg-1
    //            * name: netRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 5000.0
    //                          ** min : 0.0
    //                          ** default : 1.566
    //                          ** unit : MJ m-2 d-1
    //            * name: psychrometricConstant
    //                          ** description : psychrometric constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1.0
    //                          ** min : 0.0
    //                          ** default : 0.66
    //                          ** unit : 
    //            * name: Alpha
    //                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 1.5
    //                          ** unit : 
    //            * name: solarRadiation
    //                          ** description : solar Radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000.0
    //                          ** min : 0.0
    //                          ** default : 3.0
    //                          ** unit : MJ m-2 d-1
    //            * name: hslope
    //                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000.0
    //                          ** min : 0.0
    //                          ** default : 0.584
    //                          ** unit : hPa degC-1
    //            * name: ih
    //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    //                          ** inputtype : variable
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 24
    //                          ** min : -999
    //                          ** default : -999
    //                          ** unit : 
        //- outputs:
    //            * name: evapoTranspirationPriestlyTaylor
    //                          ** description : evapoTranspiration of Priestly Taylor
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 10000.0
    //                          ** min : 0.0
    //                          ** unit : g m-2 d-1
        double netRadiation = a.getnetRadiation();
        double solarRadiation = a.getsolarRadiation();
        double hslope = a.gethslope();
        double evapoTranspirationPriestlyTaylor;
        double a_G_Rn;
        a_G_Rn = 1.00d;
        if (ih != -999)
        {
            if (solarRadiation < 0.001d)
            {
                a_G_Rn = 0.50d;
            }
            else
            {
                a_G_Rn = 0.90d;
            }
        }
        evapoTranspirationPriestlyTaylor = Math.max(Alpha * hslope * (netRadiation / lambdaV * 1000.00d) * a_G_Rn / (hslope + psychrometricConstant), 0.00d);
        r.setevapoTranspirationPriestlyTaylor(evapoTranspirationPriestlyTaylor);
    }
}