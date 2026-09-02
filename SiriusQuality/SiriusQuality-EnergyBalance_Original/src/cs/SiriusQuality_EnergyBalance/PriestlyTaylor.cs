using System;
using System.Collections.Generic;
using System.Linq;
public class PriestlyTaylor
{
    private double _psychrometricConstant;
    public double psychrometricConstant
    {
        get { return this._psychrometricConstant; }
        set { this._psychrometricConstant= value; } 
    }
    private double _Alpha;
    public double Alpha
    {
        get { return this._Alpha; }
        set { this._Alpha= value; } 
    }
    private int _ih;
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    /// <summary>
    /// Constructor of the PriestlyTaylor component")
    /// </summary>  
    public PriestlyTaylor() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
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
    //            * name: netRadiationEquivalentEvaporation
    //                          ** description : net Radiation in Equivalent Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** default : 638.142
    //                          ** unit : g m-2 d-1
    //            * name: psychrometricConstant
    //                          ** description : psychrometric constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.66
    //                          ** unit : 
    //            * name: Alpha
    //                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 1.5
    //                          ** unit : 
    //            * name: solarRadiation
    //                          ** description : solar Radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : MJ m-2 d-1
    //            * name: hslope
    //                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 0.584
    //                          ** unit : hPa degC-1
    //            * name: ih
    //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    //                          ** inputtype : variable
    //                          ** parametercategory : state
    //                          ** datatype : INT
    //                          ** max : 24
    //                          ** min : 999
    //                          ** default : 999
    //                          ** unit : 
        //- outputs:
    //            * name: evapoTranspirationPriestlyTaylor
    //                          ** description : evapoTranspiration of Priestly Taylor
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : g m-2 d-1
        double netRadiationEquivalentEvaporation = a.netRadiationEquivalentEvaporation;
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
        evapoTranspirationPriestlyTaylor = Math.Max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00);
        r.evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor;
    }
}