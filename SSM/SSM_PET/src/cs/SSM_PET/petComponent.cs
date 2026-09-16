public class PetComponent
{
    
    /// <summary>
    /// Constructor of the petComponent component")
    /// </summary>  
    public petComponent() { }
    

    //Declaration of the associated strategies
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double albedo
    {
        get
        {
             return _PotentialEvapotranspiration.albedo; 
        }
        set
        {
            _PotentialEvapotranspiration.albedo = value;
        }
    }

    public void  CalculateModel(petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex)
    {
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }
    
    public petComponent(petComponent toCopy): this() // copy constructor 
    {

        albedo = toCopy.albedo;
    }
}