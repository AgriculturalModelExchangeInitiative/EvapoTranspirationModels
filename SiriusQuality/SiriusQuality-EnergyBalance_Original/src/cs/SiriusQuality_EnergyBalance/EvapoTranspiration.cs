using System;
using System.Collections.Generic;
using System.Linq;
public class EvapoTranspiration
{
    private int _isWindVpDefined;
    public int isWindVpDefined
    {
        get { return this._isWindVpDefined; }
        set { this._isWindVpDefined= value; } 
    }
    /// <summary>
    /// Constructor of the EvapoTranspiration component")
    /// </summary>  
    public EvapoTranspiration() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        //- Name: EvapoTranspiration -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: Evapotranspiration Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: According to the availability of wind and/or vapor pressure daily data, the
    //SiriusQuality2 model calculates the evapotranspiration rate using the Penman (if wind
    //and vapor pressure data are available) (Penman 1948) or the Priestly-Taylor
    //(Priestley and Taylor 1972) method
    //            * ShortDescription: It uses to choose evapotranspiration of Penmann or Priestly-Taylor
        //- inputs:
    //            * name: evapoTranspirationPenman
    //                          ** description : evapoTranspiration of Penman
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 830.958
    //                          ** unit : mm
    //            * name: isWindVpDefined
    //                          ** description : if wind and vapour pressure are defined
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 1
    //                          ** unit : 
    //            * name: evapoTranspirationPriestlyTaylor
    //                          ** description : evapoTranspiration of Priestly Taylor
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 449.367
    //                          ** unit : mm
        //- outputs:
    //            * name: evapoTranspiration
    //                          ** description : evapoTranspiration
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : mm
        double evapoTranspirationPenman = r.evapoTranspirationPenman;
        double evapoTranspirationPriestlyTaylor = r.evapoTranspirationPriestlyTaylor;
        double evapoTranspiration;
        if (isWindVpDefined == 1)
        {
            evapoTranspiration = evapoTranspirationPenman;
        }
        else
        {
            evapoTranspiration = evapoTranspirationPriestlyTaylor;
        }
        r.evapoTranspiration = evapoTranspiration;
    }
}