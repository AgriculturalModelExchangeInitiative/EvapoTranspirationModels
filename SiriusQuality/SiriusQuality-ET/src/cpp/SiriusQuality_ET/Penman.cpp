#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <set>
#include <tuple>
#include "Penman.h"
using namespace SiriusQuality-ET;
Penman::Penman() {}
double Penman::getspecificHeatCapacityAir() { return this->specificHeatCapacityAir; }
double Penman::getpsychrometricConstant() { return this->psychrometricConstant; }
double Penman::getrhoDensityAir() { return this->rhoDensityAir; }
double Penman::getAlpha() { return this->Alpha; }
double Penman::getlambdaV() { return this->lambdaV; }
void Penman::setspecificHeatCapacityAir(double _specificHeatCapacityAir) { this->specificHeatCapacityAir = _specificHeatCapacityAir; }
void Penman::setpsychrometricConstant(double _psychrometricConstant) { this->psychrometricConstant = _psychrometricConstant; }
void Penman::setrhoDensityAir(double _rhoDensityAir) { this->rhoDensityAir = _rhoDensityAir; }
void Penman::setAlpha(double _Alpha) { this->Alpha = _Alpha; }
void Penman::setlambdaV(double _lambdaV) { this->lambdaV = _lambdaV; }
void Penman::Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex)
{
    //- Name: Penman -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: Penman Model
    //            * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.,
    //New Zealand Institute for Crop and Food Research Ltd.
    //
    //            * ExtendedDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
    //            * ShortDescription: It uses Penmann-Monteith method vase on the availability of wind and vapor pressure daily data
    //- inputs:
    //            * name: VPDair
    //                          ** description : vapour pressure density
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 2.19
    //                          ** unit : hPa
    //            * name: specificHeatCapacityAir
    //                          ** description : Specific heat capacity of dry air
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.00101
    //                          ** unit : 
    //            * name: psychrometricConstant
    //                          ** description : psychrometric constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.66
    //                          ** unit : 
    //            * name: rhoDensityAir
    //                          ** description : Density of air
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : None
    //                          ** min : None
    //                          ** default : 1.225
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
    //            * name: evapoTranspirationPriestlyTaylor
    //                          ** description : evapoTranspiration of Priestly Taylor
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 449.367
    //                          ** unit : g m-2 d-1
    //            * name: lambdaV
    //                          ** description : latent heat of vaporization of water
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 2.454
    //                          ** unit : 
    //            * name: hslope
    //                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 0.584
    //                          ** unit : hPa degC-1
    //            * name: conductance
    //                          ** description : conductance
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 598.685
    //                          ** unit : m d-1
    //- outputs:
    //            * name: evapoTranspirationPenman
    //                          ** description : evapoTranspiration of Penman Monteith
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 5000
    //                          ** min : 0
    //                          ** unit : g m-2 d-1
    double VPDair = a.getVPDair();
    double evapoTranspirationPriestlyTaylor = r.getevapoTranspirationPriestlyTaylor();
    double hslope = a.gethslope();
    double conductance = s.getconductance();
    double evapoTranspirationPenman;
    evapoTranspirationPenman = evapoTranspirationPriestlyTaylor / Alpha + (1000.00 * (rhoDensityAir * specificHeatCapacityAir * VPDair * conductance / (lambdaV * (hslope + psychrometricConstant))));
    r.setevapoTranspirationPenman(evapoTranspirationPenman);
}