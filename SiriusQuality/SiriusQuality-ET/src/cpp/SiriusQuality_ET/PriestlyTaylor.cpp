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
#include "PriestlyTaylor.h"
using namespace SiriusQuality-ET;
PriestlyTaylor::PriestlyTaylor() {}
double PriestlyTaylor::getpsychrometricConstant() { return this->psychrometricConstant; }
double PriestlyTaylor::getAlpha() { return this->Alpha; }
int PriestlyTaylor::getih() { return this->ih; }
void PriestlyTaylor::setpsychrometricConstant(double _psychrometricConstant) { this->psychrometricConstant = _psychrometricConstant; }
void PriestlyTaylor::setAlpha(double _Alpha) { this->Alpha = _Alpha; }
void PriestlyTaylor::setih(int _ih) { this->ih = _ih; }
void PriestlyTaylor::Calculate_Model(EnergyBalanceCompositeState &s, EnergyBalanceCompositeState &s1, EnergyBalanceCompositeRate &r, EnergyBalanceCompositeAuxiliary &a, EnergyBalanceCompositeExogenous &ex)
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
    double netRadiationEquivalentEvaporation = a.getnetRadiationEquivalentEvaporation();
    double solarRadiation = a.getsolarRadiation();
    double hslope = a.gethslope();
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
    evapoTranspirationPriestlyTaylor = std::max(Alpha * hslope * netRadiationEquivalentEvaporation * a_G_Rn / (hslope + psychrometricConstant), 0.00);
    r.setevapoTranspirationPriestlyTaylor(evapoTranspirationPriestlyTaylor);
}