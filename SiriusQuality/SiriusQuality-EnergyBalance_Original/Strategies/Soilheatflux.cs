using System;
using System.Collections.Generic;
using System.Linq;
public class SoilHeatFlux
{

    public SoilHeatFlux() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: SoilHeatFlux -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: SoilHeatFlux Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: The available energy in the soil 
        //            * ShortDescription: The available energy in the soil
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
        //                          ** variablecategory : auxiliary
        //                          ** description : net Radiation Equivalent Evaporation
        //                          ** datatype : DOUBLE
        //                          ** default : 638.142
        //                          ** min : 0
        //                          ** max : 5000
        //                          ** unit : g m-2 d-1
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
        //            * name: soilEvaporation
        //                          ** description : soil Evaporation
        //                          ** variablecategory : auxiliary
        //                          ** datatype : DOUBLE
        //                          ** default : 448.240
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //- outputs:
        //            * name: soilHeatFlux
        //                          ** description : soil Heat Flux 
        //                          ** variablecategory : rate
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** unit : g m-2 d-1
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%
        double netRadiationEquivalentEvaporation = a.netRadiationEquivalentEvaporation;
        double soilEvaporation = a.soilEvaporation;
        int ih = s.ih;
        double tau = a.tau;
        double solarRadiation = a.solarRadiation;
        double soilHeatFlux;
        if (ih == -999)
        {

            soilHeatFlux = tau * netRadiationEquivalentEvaporation - soilEvaporation;
        }
        else
        {
            if (solarRadiation < 0.001d) soilHeatFlux = netRadiationEquivalentEvaporation * 0.50d;
            else soilHeatFlux = netRadiationEquivalentEvaporation * 0.10d;
        }
            r.soilHeatFlux = soilHeatFlux;
    }
}