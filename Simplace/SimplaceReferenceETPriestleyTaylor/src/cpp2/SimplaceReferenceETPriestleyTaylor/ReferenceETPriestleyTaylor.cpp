#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "ReferenceETPriestleyTaylor.h"
using namespace SimplaceReferenceETPriestleyTaylor;
ReferenceETPriestleyTaylor::ReferenceETPriestleyTaylor() {}
double ReferenceETPriestleyTaylor::getcAltitude() { return this->cAltitude; }
double ReferenceETPriestleyTaylor::getcAlphaPT() { return this->cAlphaPT; }
void ReferenceETPriestleyTaylor::setcAltitude(double _cAltitude) { this->cAltitude = _cAltitude; }
void ReferenceETPriestleyTaylor::setcAlphaPT(double _cAlphaPT) { this->cAlphaPT = _cAlphaPT; }
void ReferenceETPriestleyTaylor::Calculate_Model(ReferenceETPriestleyTaylor_State &s, ReferenceETPriestleyTaylor_State &s1, ReferenceETPriestleyTaylor_Rate &r, ReferenceETPriestleyTaylor_Auxiliary &a, ReferenceETPriestleyTaylor_Exogenous &ex)
{
    //- Name: ReferenceETPriestleyTaylor -Version: 001, -Time step: 1
    //- Description:
    //            * Title: ReferenceETPriestleyTaylor model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
    //- inputs:
    //            * name: cAltitude
    //                          ** description : altitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: cAlphaPT
    //                          ** description : Priestley-Taylor coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 1.26
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: iTMax
    //                          ** description : maximum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iTMin
    //                          ** description : minimum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    //- outputs:
    //            * name: ReferenceCropEvapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
    double lambdav;
    double T;
    double Delta;
    double AtmPres;
    double Gamma;
    double G;
    lambdav = 2.45;
    T = (ex.iTMax + ex.iTMin) / 2.0;
    Delta = SlopeOfSaturationVapPressureCurve(T);
    AtmPres = AtmosphericPressure(cAltitude);
    Gamma = PsychrometricConstant(AtmPres);
    G = 0.0;
    a.ReferenceCropEvapotranspiration = std::max(double(0), cAlphaPT * Delta / (Delta + Gamma) * (ex.iNetRadiation - G) / lambdav);
}
double ReferenceETPriestleyTaylor::SlopeOfSaturationVapPressureCurve(double T)
{
    double tempT;
    tempT = T + 237.3;
    return 4098 * (0.6108 * std::exp(17.27 * T / tempT)) / std::pow(tempT, 2);
}
double ReferenceETPriestleyTaylor::AtmosphericPressure(double z)
{
    return 101.3 * std::pow((293 - (0.0065 * z)) / 293, 5.26);
}
double ReferenceETPriestleyTaylor::PsychrometricConstant(double P)
{
    double lambdav;
    double c_p;
    double epsilon;
    double factor;
    lambdav = 2.45;
    c_p = 1.013E-3;
    epsilon = 0.622;
    factor = std::round(c_p / (epsilon * lambdav) * 10E6) / 10E6;
    return factor * P;
}