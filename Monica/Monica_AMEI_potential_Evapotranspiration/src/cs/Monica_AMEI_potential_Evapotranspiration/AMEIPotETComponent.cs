public class AMEIPotETComponent
{
    
    /// <summary>
    /// Constructor of the AMEIPotETComponent component")
    /// </summary>  
    public AMEIPotETComponent() { }
    

    //Declaration of the associated strategies
    SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double height_nn
    {
        get
        {
             return _ReferenceEvapotranspiration.height_nn; 
        }
        set
        {
            _ReferenceEvapotranspiration.height_nn = value;
        }
    }

    public void  CalculateModel(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
    {
        _SaturationVaporPressureDeficit.CalculateModel(s,s1, r, a, ex);
        _ReferenceEvapotranspiration.CalculateModel(s,s1, r, a, ex);
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }
    
    public AMEIPotETComponent(AMEIPotETComponent toCopy): this() // copy constructor 
    {

        height_nn = toCopy.height_nn;
    }
}