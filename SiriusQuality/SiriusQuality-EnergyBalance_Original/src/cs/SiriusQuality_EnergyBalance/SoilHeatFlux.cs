using System;
using System.Collections.Generic;
using System.Linq;
public class SoilHeatFlux
{
    private int _ih;
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    private double _tau;
    public double tau
    {
        get { return this._tau; }
        set { this._tau= value; } 
    }
    /// <summary>
    /// Constructor of the SoilHeatFlux component")
    /// </summary>  
    public SoilHeatFlux() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        //- Name: SoilHeatFlux -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: SoilHeatFlux Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: The available energy in the soil
    //            * ShortDescription: The available energy in the soil
        //- inputs:
    //            * name: ih
    //                          ** description : hour of the day if the component is hourly, -999 if the component is daily
    //                          ** inputtype : variable
    //                          ** parametercategory : state
    //                          ** datatype : INT
    //                          ** max : 24
    //                          ** min : 999
    //                          ** default : 999
    //                          ** unit : 
    //            * name: soilEvaporation
    //                          ** description : soil Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 448.240
    //                          ** unit : g m-2 d-1
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
    //            * name: netRadiationEquivalentEvaporation
    //                          ** description : net Radiation Equivalent Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** default : 638.142
    //                          ** unit : g m-2 d-1
        //- outputs:
    //            * name: soilHeatFlux
    //                          ** description : soil Heat Flux
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : g m-2 d-1
        double soilEvaporation = a.soilEvaporation;
        double solarRadiation = a.solarRadiation;
        double netRadiationEquivalentEvaporation = a.netRadiationEquivalentEvaporation;
        double soilHeatFlux;
        if (ih == -999)
        {
            soilHeatFlux = tau * netRadiationEquivalentEvaporation - soilEvaporation;
        }
        else
        {
            if (solarRadiation < 0.001)
            {
                soilHeatFlux = netRadiationEquivalentEvaporation * 0.50;
            }
            else
            {
                soilHeatFlux = netRadiationEquivalentEvaporation * 0.10;
            }
        }
        r.soilHeatFlux = soilHeatFlux;
    }
}