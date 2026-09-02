using System;
using System.Collections.Generic;
using System.Linq;
public class CanopyTemperature
{


    private double _lambdaV;
    public double lambdaV
    {
        get { return this._lambdaV; }
        set { this._lambdaV = value; }
    }

    private double _rhoDensityAir;
    public double rhoDensityAir
    {
        get { return this._rhoDensityAir; }
        set { this._rhoDensityAir = value; }
    }
    private double _specificHeatCapacityAir;
    public double specificHeatCapacityAir
    {
        get { return this._specificHeatCapacityAir; }
        set { this._specificHeatCapacityAir = value; }
    }


    /// <summary>
    /// Constructor of the Claculate Demand component")
    /// </summary>
    public CanopyTemperature() { }

    public void CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //%%CyML Description Begin%%
        //- Name: CanopyTemperature -Version: 1.0, -Time step: 1
        //- Description:
        //            * Title: CanopyTemperature Model
        //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
        //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
        //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.,
        //            New Zealand Institute for Crop and Food Research Ltd.
        //        
        //            * ExtendedDescription: It is calculated from the crop heat flux and the boundary layer conductance 
        //            * ShortDescription: It is calculated from the crop heat flux and the boundary layer conductance 
        //- inputs:
        //            * name: minTair
        //                          ** description : minimum air temperature
        //                          ** datatype : DOUBLE
        //                          ** variablecategory : auxiliary
        //                          ** min : -30
        //                          ** max : 45
        //                          ** default : 0.7
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: maxTair
        //                          ** description : maximum air Temperature
        //                          ** datatype : DOUBLE
        //                          ** variablecategory : auxiliary
        //                          ** min : -30
        //                          ** max : 45
        //                          ** default : 7.2
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : variable
        //            * name: cropHeatFlux
        //                          ** description : Crop heat flux
        //                          ** variablecategory : rate
        //                          ** inputtype : variable
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** default : 447.912
        //                          ** unit : g/m**2/d
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: conductance
        //                          ** description : the boundary layer conductance
        //                          ** variablecategory : state
        //                          ** inputtype : variable
        //                          ** datatype : DOUBLE
        //                          ** min : 0
        //                          ** max : 10000
        //                          ** default : 598.685
        //                          ** unit : m/d
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: lambdaV
        //                          ** description : latent heat of vaporization of water
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 2.454
        //                          ** min : 0
        //                          ** max : 10
        //                          ** unit : MJ/kg
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: rhoDensityAir
        //                          ** description : Density of air
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 1.225
        //                          ** unit : kg/m**3
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //            * name: specificHeatCapacityAir
        //                          ** description : Specific heat capacity of dry air
        //                          ** parametercategory : constant
        //                          ** datatype : DOUBLE
        //                          ** default : 0.00101
        //                          ** unit : MJ/kg/degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //                          ** inputtype : parameter
        //- outputs:
        //            * name: minCanopyTemperature
        //                          ** description : minimal Canopy Temperature  
        //                          ** datatype : DOUBLE
        //                          ** variablecategory : state
        //                          ** min : -30
        //                          ** max : 45
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //            * name: maxCanopyTemperature
        //                          ** description : maximal Canopy Temperature 
        //                          ** datatype : DOUBLE
        //                          ** variablecategory : state
        //                          ** min : -30
        //                          ** max : 45
        //                          ** unit : degC
        //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        //%%CyML Description End%%

        double minTair = a.minTair;
        double maxTair = a.maxTair;
        double cropHeatFlux = r.cropHeatFlux;
        double conductance = s.conductance;
        double minCanopyTemperature;
        double maxCanopyTemperature;

        if (minTair == 999 && maxTair == -999)
        {
            minCanopyTemperature = 999;
            maxCanopyTemperature = -999;

        }
        else
        {
            minCanopyTemperature = minTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00d));
            maxCanopyTemperature = maxTair + (cropHeatFlux / (rhoDensityAir * specificHeatCapacityAir * conductance / lambdaV * 1000.00d));
            s.minCanopyTemperature = minCanopyTemperature;
            s.maxCanopyTemperature = maxCanopyTemperature;

        }



    }


}