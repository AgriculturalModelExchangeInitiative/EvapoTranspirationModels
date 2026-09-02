using OfficeOpenXml.Drawing.Slicer.Style;
using OfficeOpenXml.Drawing.Style.Fill;
using System;
using System.Collections.Generic;
using System.Linq;
public class PtSoil
{
    private double _Alpha;
    public double Alpha
    {
        get { return this._Alpha; }
        set { this._Alpha = value; }
    }
    
    private double _tauAlpha;
    public double tauAlpha
    {
        get { return this._tauAlpha; }
        set { this._tauAlpha = value; }
    }
    public PtSoil() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: PtSoil -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: PtSoil EnergyLimitedEvaporation Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: Evaporation from the soil in the energy-limited stage 
        //            * ShortDescription: Evaporation from the soil in the energy-limited stage
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
        //            * name: evapoTranspirationPriestlyTaylor
        //                          ** description : evapoTranspiration Priestly Taylor
        //                          ** variablecategory : rate
        //                          ** datatype : DOUBLE
        //                          ** default : 120
        //                          ** min : 0
        //                          ** max : 1000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: tau
        //                          ** description : soil cover factor
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 120
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : -
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
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
        //            * name: tauAlpha
        //                          ** description : Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1
        //                          ** parametercategory : soil
        //                          ** datatype : DOUBLE
        //                          ** default : 0.3
        //                          ** min : 0
        //                          ** max : 1
        //                          ** unit : 
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //- outputs:
        //            * name: energyLimitedEvaporation
        //                          ** description : energy Limited Evaporation 
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 5000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%
        double evapoTranspirationPriestlyTaylor = r.evapoTranspirationPriestlyTaylor;
        double tau = a.tau;
        int ih = s.ih;
        double energyLimitedEvaporation;
        double AlphaE;

        if (ih == -999)
        {
            if (tau < tauAlpha)
            {
                AlphaE = 1.00d;
            }
            else
            {
                AlphaE = Alpha - ((Alpha - 1.00d) * (1.00d - tau) / (1.00d - tauAlpha));
            }
            energyLimitedEvaporation = evapoTranspirationPriestlyTaylor / Alpha * AlphaE * tau;
        }
        else
        {
            energyLimitedEvaporation = 0.00d;
        }

            a.energyLimitedEvaporation = energyLimitedEvaporation;
    }
}