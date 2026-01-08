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
#include "ReferenceETPM.h"
using namespace SimplaceReferenceETPM;
ReferenceETPM::ReferenceETPM() {}
double ReferenceETPM::getcAltitude() { return this->cAltitude; }
void ReferenceETPM::setcAltitude(double _cAltitude) { this->cAltitude = _cAltitude; }
void ReferenceETPM::Calculate_Model(ReferenceETPM_State &s, ReferenceETPM_State &s1, ReferenceETPM_Rate &r, ReferenceETPM_Auxiliary &a, ReferenceETPM_Exogenous &ex)
{
    //- Name: ReferenceETPM -Version: 001, -Time step: 1
    //- Description:
    //            * Title: ReferenceETPM model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
    //- inputs:
    //            * name: cAltitude
    //                          ** description : elevation above sea level
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
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
    //            * name: iActualVapourPressure
    //                          ** description : actual vapour pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/kilopascal
    //            * name: iNetRadiation
    //                          ** description : net radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day
    //            * name: iWindspeed
    //                          ** description : wind speed at 2m height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time
    //- outputs:
    //            * name: ReferenceCropEvapotranspiration
    //                          ** description : reference evapotranspiration (ET0)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
    double T;
    double e_s;
    T = (ex.iTMax + ex.iTMin) / 2;
    e_s = MeanSaturatedVapourPressure(ex.iTMax, ex.iTMin);
    if (ex.iActualVapourPressure > e_s)
    {
        ex.iActualVapourPressure = e_s;
    }
    a.ReferenceCropEvapotranspiration = ReferenceEvapotranspiration(T, ex.iNetRadiation, ex.iWindspeed, e_s, ex.iActualVapourPressure, cAltitude);
}
double ReferenceETPM::SaturationVapourPressureAtTemperature(double T)
{
    return 0.6108 * std::exp(17.27 * T / (T + 237.3));
}
double ReferenceETPM::MeanSaturatedVapourPressure(double T_max, double T_min)
{
    return (SaturationVapourPressureAtTemperature(T_max) + SaturationVapourPressureAtTemperature(T_min)) / 2;
}
double ReferenceETPM::SlopeOfSaturationVapPressureCurve(double T)
{
    double tempT;
    tempT = T + 237.3;
    return 4098 * (0.6108 * std::exp(17.27 * T / tempT)) / std::pow(tempT, 2);
}
double ReferenceETPM::PsychrometricConstant(double P)
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
double ReferenceETPM::AtmosphericPressure(double z)
{
    return 101.3 * std::pow((293 - (0.0065 * z)) / 293, 5.26);
}
double ReferenceETPM::ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z)
{
    double P;
    double gamma;
    double Delta;
    double G;
    double ET0;
    P = AtmosphericPressure(z);
    gamma = PsychrometricConstant(P);
    Delta = SlopeOfSaturationVapPressureCurve(T);
    G = float(0);
    ET0 = (0.408 * Delta * (R_n - G) + (gamma * (900 / (T + 273)) * u_2 * (e_s - e_a))) / (Delta + (gamma * (1 + (0.34 * u_2))));
    return ET0;
}