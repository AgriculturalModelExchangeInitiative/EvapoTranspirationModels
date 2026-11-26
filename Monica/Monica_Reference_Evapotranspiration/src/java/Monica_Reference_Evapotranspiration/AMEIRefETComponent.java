public class AMEIRefETComponent
{
    
    public AMEIRefETComponent() { }

    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

    public double getheight_nn()
    { return _ReferenceEvapotranspiration.getheight_nn(); }
    public void setheight_nn(double _height_nn){
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
    }
    public void  Calculate_Model(AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex)
    {
        _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double height_nn;
    public AMEIRefETComponent(AMEIRefETComponent toCopy) // copy constructor 
    {
        this.height_nn = toCopy.getheight_nn();

    }
}