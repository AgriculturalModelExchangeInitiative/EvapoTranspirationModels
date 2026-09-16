import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class PotentialET_PTRate
{
    private double evapoTranspirationPriestlyTaylor;
    
    public PotentialET_PTRate() { }
    
    public PotentialET_PTRate(PotentialET_PTRate toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.evapoTranspirationPriestlyTaylor = toCopy.getevapoTranspirationPriestlyTaylor();
        }
    }
    public double getevapoTranspirationPriestlyTaylor()
    { return evapoTranspirationPriestlyTaylor; }

    public void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor)
    { this.evapoTranspirationPriestlyTaylor= _evapoTranspirationPriestlyTaylor; } 
    
}