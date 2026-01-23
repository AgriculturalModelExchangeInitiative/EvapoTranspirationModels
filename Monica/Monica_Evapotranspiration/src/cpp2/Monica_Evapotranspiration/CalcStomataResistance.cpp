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
#include "CalcStomataResistance.h"
using namespace Monica_Evapotranspiration;
CalcStomataResistance::CalcStomataResistance() {}
void CalcStomataResistance::Calculate_Model(ETState &s, ETState &s1, ETRate &r, ETAuxiliary &a, ETExogenous &ex)
{
    //- Name: CalcStomataResistance -Version: 1, -Time step: 1
    //- Description:
    //            * Title: If Else unit 
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: switches between two input values 
    //- inputs:
    //            * name: calc_stomata_resistance
    //                          ** description : boolean condition to be met
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : BOOLEAN
    //                          ** default : false
    //                          ** unit : 
    //            * name: calculated_stomata_resistance
    //                          ** description : value to be returned if condition is true
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 100
    //                          ** unit : s/m
    //            * name: fixed_stomata_resistance
    //                          ** description : value to be returned if condition is false
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** default : 100
    //                          ** unit : s/m
    //- outputs:
    //            * name: stomata_resistance
    //                          ** description : the output value
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 10000
    //                          ** min : 0
    //                          ** unit : s/m
    if (a.calc_stomata_resistance) {
        a.stomata_resistance = a.calculated_stomata_resistance;
    }
    else {
        a.stomata_resistance = a.fixed_stomata_resistance;
    }
}