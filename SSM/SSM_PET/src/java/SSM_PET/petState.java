import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class petState
{
    private double pet;
    
    public petState() { }
    
    public petState(petState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.pet = toCopy.getpet();
        }
    }
    public double getpet()
    { return pet; }

    public void setpet(double _pet)
    { this.pet= _pet; } 
    
}