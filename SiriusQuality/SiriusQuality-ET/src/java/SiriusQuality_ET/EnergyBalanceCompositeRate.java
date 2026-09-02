import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class EnergyBalanceCompositeRate
{
    private double evapoTranspirationPriestlyTaylor;
    private double evapoTranspirationPenman;
    
    public EnergyBalanceCompositeRate() { }
    
    public EnergyBalanceCompositeRate(EnergyBalanceCompositeRate toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.evapoTranspirationPriestlyTaylor = toCopy.getevapoTranspirationPriestlyTaylor();
            this.evapoTranspirationPenman = toCopy.getevapoTranspirationPenman();
            this.evapoTranspirationPriestlyTaylor = toCopy.getevapoTranspirationPriestlyTaylor();
        }
    }
    public double getevapoTranspirationPriestlyTaylor()
    { return evapoTranspirationPriestlyTaylor; }

    public void setevapoTranspirationPriestlyTaylor(double _evapoTranspirationPriestlyTaylor)
    { this.evapoTranspirationPriestlyTaylor= _evapoTranspirationPriestlyTaylor; } 
    
    public double getevapoTranspirationPenman()
    { return evapoTranspirationPenman; }

    public void setevapoTranspirationPenman(double _evapoTranspirationPenman)
    { this.evapoTranspirationPenman= _evapoTranspirationPenman; } 
    
}