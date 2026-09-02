using System;
using System.Collections.Generic;
using System.Linq;
public class SoilEvaporation
{
    private int _ih;
    public int ih
    {
        get { return this._ih; }
        set { this._ih= value; } 
    }
    /// <summary>
    /// Constructor of the SoilEvaporation component")
    /// </summary>  
    public SoilEvaporation() { }
    
    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        //- Name: SoilEvaporation -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: SoilEvaporation Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: Starting from a soil at field capacity, soil evaporation  is assumed to
    //be energy limited during the first phase of evaporation and diffusion limited thereafter.
    //Hence, the soil evaporation model considers these two processes taking the minimum between
    //the energy limited evaporation (PtSoil) and the diffused limited
    //evaporation
    //            * ShortDescription: Starting from a soil at field capacity, soil evaporation  is assumed to
    //be energy limited during the first phase of evaporation and diffusion limited thereafter.
    //Hence, the soil evaporation model considers these two processes taking the minimum between
    //the energy limited evaporation (PtSoil) and the diffused limited
    //evaporation
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
    //            * name: energyLimitedEvaporation
    //                          ** description : energy Limited Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 448.240
    //                          ** unit : g m-2 d-1
    //            * name: diffusionLimitedEvaporation
    //                          ** description : diffusion Limited Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 6605.505
    //                          ** unit : g m-2 d-1
        //- outputs:
    //            * name: soilEvaporation
    //                          ** description : soil Evaporation
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** unit : g m-2 d-1
        double energyLimitedEvaporation = a.energyLimitedEvaporation;
        double diffusionLimitedEvaporation = s.diffusionLimitedEvaporation;
        double soilEvaporation;
        if (ih == -999)
        {
            soilEvaporation = Math.Min(diffusionLimitedEvaporation, energyLimitedEvaporation);
        }
        else
        {
            soilEvaporation = 0.0;
        }
        a.soilEvaporation= soilEvaporation;
    }
}