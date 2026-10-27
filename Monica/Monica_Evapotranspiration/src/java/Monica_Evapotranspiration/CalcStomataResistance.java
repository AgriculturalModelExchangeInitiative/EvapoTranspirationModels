import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class CalcStomataResistance
{
    
    public CalcStomataResistance() { }
    public void  Calculate_Model(ETState s, ETState s1, ETRate r, ETAuxiliary a,  ETExogenous ex)
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
        Boolean calc_stomata_resistance = a.getcalc_stomata_resistance();
        double calculated_stomata_resistance = a.getcalculated_stomata_resistance();
        double fixed_stomata_resistance = a.getfixed_stomata_resistance();
        double stomata_resistance;
        if (calc_stomata_resistance)
        {
            stomata_resistance = calculated_stomata_resistance;
        }
        else
        {
            stomata_resistance = fixed_stomata_resistance;
        }
        a.setstomata_resistance(stomata_resistance);
    }
}