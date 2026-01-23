public class PetComponent
{
    
    /// <summary>
    /// Constructor of the petComponent component")
    /// </summary>  
    public petComponent() { }
    

    //Declaration of the associated strategies
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double ket
    {
        get
        {
             return _PotentialEvapotranspiration.ket; 
        }
        set
        {
            _PotentialEvapotranspiration.ket = value;
        }
    }
    public double calb
    {
        get
        {
             return _PotentialEvapotranspiration.calb; 
        }
        set
        {
            _PotentialEvapotranspiration.calb = value;
        }
    }
    public double salb
    {
        get
        {
             return _PotentialEvapotranspiration.salb; 
        }
        set
        {
            _PotentialEvapotranspiration.salb = value;
        }
    }

    public void  CalculateModel(petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex)
    {
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }
    
    public petComponent(petComponent toCopy): this() // copy constructor 
    {

        ket = toCopy.ket;
        calb = toCopy.calb;
        salb = toCopy.salb;
    }
}