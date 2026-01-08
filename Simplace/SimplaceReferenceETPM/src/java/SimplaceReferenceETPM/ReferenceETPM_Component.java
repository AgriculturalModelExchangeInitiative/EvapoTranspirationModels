public class ReferenceETPM_Component
{
    
    public ReferenceETPM_Component() { }

    ReferenceETPM _ReferenceETPM = new ReferenceETPM();

    public double getcAltitude()
    { return _ReferenceETPM.getcAltitude(); }
    public void setcAltitude(double _cAltitude){
    _ReferenceETPM.setcAltitude(_cAltitude);
    }
    public void  Calculate_Model(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
    {
        _ReferenceETPM.Calculate_Model(s, s1, r, a, ex);
    }
    private double cAltitude;
    public ReferenceETPM_Component(ReferenceETPM_Component toCopy) // copy constructor 
    {
        this.cAltitude = toCopy.getcAltitude();

    }
}