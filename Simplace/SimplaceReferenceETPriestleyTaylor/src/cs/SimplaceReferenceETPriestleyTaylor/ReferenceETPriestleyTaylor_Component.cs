public class ReferenceETPriestleyTaylor_Component
{
    
    /// <summary>
    /// Constructor of the ReferenceETPriestleyTaylor_Component component")
    /// </summary>  
    public ReferenceETPriestleyTaylor_Component() { }
    

    //Declaration of the associated strategies
    ReferenceETPriestleyTaylor _ReferenceETPriestleyTaylor = new ReferenceETPriestleyTaylor();

    public double cAlphaPT
    {
        get
        {
             return _ReferenceETPriestleyTaylor.cAlphaPT; 
        }
        set
        {
            _ReferenceETPriestleyTaylor.cAlphaPT = value;
        }
    }
    public double cAltitude
    {
        get
        {
             return _ReferenceETPriestleyTaylor.cAltitude; 
        }
        set
        {
            _ReferenceETPriestleyTaylor.cAltitude = value;
        }
    }

    public void  CalculateModel(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex)
    {
        _ReferenceETPriestleyTaylor.CalculateModel(s,s1, r, a, ex);
    }
    
    public ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component toCopy): this() // copy constructor 
    {

        cAlphaPT = toCopy.cAlphaPT;
        cAltitude = toCopy.cAltitude;
    }
}