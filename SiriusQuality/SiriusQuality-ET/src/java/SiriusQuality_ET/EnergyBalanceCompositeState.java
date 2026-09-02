import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class EnergyBalanceCompositeState
{
    private Integer ih;
    private double conductance;
    
    public EnergyBalanceCompositeState() { }
    
    public EnergyBalanceCompositeState(EnergyBalanceCompositeState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.ih = toCopy.getih();
            this.conductance = toCopy.getconductance();
        }
    }
    public Integer getih()
    { return ih; }

    public void setih(Integer _ih)
    { this.ih= _ih; } 
    
    public double getconductance()
    { return conductance; }

    public void setconductance(double _conductance)
    { this.conductance= _conductance; } 
    
}