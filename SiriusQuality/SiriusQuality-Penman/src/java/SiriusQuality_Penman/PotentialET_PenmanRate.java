import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class PotentialET_PenmanRate
{
    private double evapoTranspirationPenman;
    private double evapoTranspirationPriestlyTaylor;
    
    public PotentialET_PenmanRate() { }
    
    public PotentialET_PenmanRate(PotentialET_PenmanRate toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.evapoTranspirationPenman = toCopy.getevapoTranspirationPenman();
            this.evapoTranspirationPriestlyTaylor = toCopy.getevapoTranspirationPriestlyTaylor();
        }
    }
    public double getevapoTranspirationPenman()
    { return evapoTranspirationPenman; }

    public void setevapoTranspirationPenman(double _evapoTranspirationPenman)
    { this.evapoTranspirationPenman= _evapoTranspirationPenman; } 
    
    public double getevapoTranspirationPriestlyTaylor()
    { return evapoTranspirationPriestlyTaylor; }

    public void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor)
    { this.evapoTranspirationPriestlyTaylor= _evapoTranspirationPriestlyTaylor; } 
    
}