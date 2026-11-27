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

    public double getlatent_heat_of_vaporization()
    { return _ReferenceEvapotranspiration.getlatent_heat_of_vaporization(); }
    public void setlatent_heat_of_vaporization(double _latent_heat_of_vaporization){
    _ReferenceEvapotranspiration.setlatent_heat_of_vaporization(_latent_heat_of_vaporization);
    }
    public void  Calculate_Model(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
    {
        _SaturationVaporPressureDeficit.Calculate_Model(s, s1, r, a, ex);
        _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
        _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double height_nn;
    private double latent_heat_of_vaporization;
    public AMEIPotETComponent(AMEIPotETComponent toCopy) // copy constructor 
    {
        this.height_nn = toCopy.getheight_nn();
        this.latent_heat_of_vaporization = toCopy.getlatent_heat_of_vaporization();

    }
}