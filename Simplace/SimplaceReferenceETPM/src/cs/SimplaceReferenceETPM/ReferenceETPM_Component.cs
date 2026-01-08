public class ReferenceETPM_Component
{
    
    /// <summary>
    /// Constructor of the ReferenceETPM_Component component")
    /// </summary>  
    public ReferenceETPM_Component() { }
    

    //Declaration of the associated strategies
    ReferenceETPM _ReferenceETPM = new ReferenceETPM();

    public double cAltitude
    {
        get
        {
             return _ReferenceETPM.cAltitude; 
        }
        set
        {
            _ReferenceETPM.cAltitude = value;
        }
    }

    public void  CalculateModel(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
    {
        _ReferenceETPM.CalculateModel(s,s1, r, a, ex);
    }
    
    public ReferenceETPM_Component(ReferenceETPM_Component toCopy): this() // copy constructor 
    {

        cAltitude = toCopy.cAltitude;
    }
}