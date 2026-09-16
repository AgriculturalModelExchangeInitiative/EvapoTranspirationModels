public class PetComponent
{
    
    public PetComponent() { }

    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double getalbedo()
    { return _PotentialEvapotranspiration.getalbedo(); }
    public void setalbedo(double _albedo){
    _PotentialEvapotranspiration.setalbedo(_albedo);
    }
    public void  Calculate_Model(petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex)
    {
        _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double albedo;
    public petComponent(petComponent toCopy) // copy constructor 
    {
        this.albedo = toCopy.getalbedo();

    }
}