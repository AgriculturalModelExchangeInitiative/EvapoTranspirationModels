public class ReferenceETPriestleyTaylor_Component
{
    
    public ReferenceETPriestleyTaylor_Component() { }

    ReferenceETPriestleyTaylor _ReferenceETPriestleyTaylor = new ReferenceETPriestleyTaylor();

    public double getcAlphaPT()
    { return _ReferenceETPriestleyTaylor.getcAlphaPT(); }
    public void setcAlphaPT(double _cAlphaPT){
    _ReferenceETPriestleyTaylor.setcAlphaPT(_cAlphaPT);
    }

    public double getcAltitude()
    { return _ReferenceETPriestleyTaylor.getcAltitude(); }
    public void setcAltitude(double _cAltitude){
    _ReferenceETPriestleyTaylor.setcAltitude(_cAltitude);
    }
    public void  Calculate_Model(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex)
    {
        _ReferenceETPriestleyTaylor.Calculate_Model(s, s1, r, a, ex);
    }
    private double cAlphaPT;
    private double cAltitude;
    public ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component toCopy) // copy constructor 
    {
        this.cAlphaPT = toCopy.getcAlphaPT();
        this.cAltitude = toCopy.getcAltitude();

    }
}