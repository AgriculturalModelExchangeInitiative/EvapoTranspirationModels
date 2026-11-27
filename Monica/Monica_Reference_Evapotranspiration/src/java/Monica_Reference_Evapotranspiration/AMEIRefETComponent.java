public class AMEIRefETComponent
{
    
    public AMEIRefETComponent() { }

    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

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
    public void  Calculate_Model(AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex)
    {
        _ReferenceEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double height_nn;
    private double latent_heat_of_vaporization;
    public AMEIRefETComponent(AMEIRefETComponent toCopy) // copy constructor 
    {
        this.height_nn = toCopy.getheight_nn();
        this.latent_heat_of_vaporization = toCopy.getlatent_heat_of_vaporization();

    }
}