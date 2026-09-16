using System;
using System.Collections.Generic;
using System.Linq;
public class PriestlyTaylor
{
    private double _psychrometricConstant;
    public double psychrometricConstant
    {
        get { return this._psychrometricConstant; }
        set { this._psychrometricConstant = value; }
    }
    private double _Alpha;
    public double Alpha
    {
        get { return this._Alpha; }
        set { this._Alpha = value; }
    }
    public PriestlyTaylor() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: PriestlyTaylor -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: evapoTranspirationPriestlyTaylor  Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: Calculate Energy Balance 
        //            * ShortDescription: It uses Priestly-Taylor method
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
        //            * name: netRadiationEquivalentEvaporation
        //                          ** description : net Radiation in Equivalent Evaporation
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 638.142
        //                          ** min : 0
        //                          ** max : 5000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: hslope
        //                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature 
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 0.584
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : hPa degC-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: psychrometricConstant
        //                          ** description : psychrometric constant
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0.66
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: Alpha
        //                          ** description : Priestley-Taylor evapotranspiration proportionality constant
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 1.5
        //                          ** min : 0
        //                          ** max : 100
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //- outputs:
        //            * name: evapoTranspirationPriestlyTaylor
        //                          ** description : evapoTranspiration of Priestly Taylor 
        //                          ** variablecategory : rate
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%
        double netRadiationEquivalentEvaporation = a.netRadiationEquivalentEvaporation;
        double hslope = a.hslope;
        int ih = s.ih;
        double solarRadiation = a.solarRadiation;
        double evapoTranspirationPriestlyTaylor;

        double a_G_Rn = 1.00d;

        if (ih != -999)
        {
            if (solarRadiation < 0.001d) a_G_Rn = 0.50d;
            else a_G_Rn = 0.90d;

        }


        evapoTranspirationPriestlyTaylor = Math.Max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00d);
        r.evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor;
    }
}