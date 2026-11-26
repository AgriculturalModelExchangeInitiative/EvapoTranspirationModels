public class AMEIRefETComponent
{
    
    /// <summary>
    /// Constructor of the AMEIRefETComponent component")
    /// </summary>  
    public AMEIRefETComponent() { }
    

    //Declaration of the associated strategies
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

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

    public void  CalculateModel(AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex)
    {
        _ReferenceEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }
    
    public AMEIRefETComponent(AMEIRefETComponent toCopy): this() // copy constructor 
    {

        height_nn = toCopy.height_nn;
    }
}