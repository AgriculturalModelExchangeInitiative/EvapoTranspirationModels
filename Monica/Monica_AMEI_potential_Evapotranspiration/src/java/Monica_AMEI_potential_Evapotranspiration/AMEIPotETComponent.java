public class AMEIPotETComponent
{
    
    public AMEIPotETComponent() { }

    SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double getheight_nn()
    { return _ReferenceEvapotranspiration.getheight_nn(); }
    public void setheight_nn(double _height_nn){
    _ReferenceEvapotranspiration.setheight_nn(_height_nn);
    }
    public void  Calculate_Model(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
    {
        _SaturationVaporPressureDeficit.Calculate_Model(s, s1, r, a, ex);
        _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
        _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double height_nn;
    public AMEIPotETComponent(AMEIPotETComponent toCopy) // copy constructor 
    {
        this.height_nn = toCopy.getheight_nn();

    }
}