public class PotentialET_PTComponent
{
    
    /// <summary>
    /// Constructor of the PotentialET_PTComponent component")
    /// </summary>  
    public PotentialET_PTComponent() { }
    

    //Declaration of the associated strategies
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();

    public double lambdaV
    {
        get
        {
             return _PriestlyTaylor.lambdaV; 
        }
        set
        {
            _PriestlyTaylor.lambdaV = value;
        }
    }
    public double psychrometricConstant
    {
        get
        {
             return _PriestlyTaylor.psychrometricConstant; 
        }
        set
        {
            _PriestlyTaylor.psychrometricConstant = value;
        }
    }
    public double Alpha
    {
        get
        {
             return _PriestlyTaylor.Alpha; 
        }
        set
        {
            _PriestlyTaylor.Alpha = value;
        }
    }
    public int ih
    {
        get
        {
             return _PriestlyTaylor.ih; 
        }
        set
        {
            _PriestlyTaylor.ih = value;
        }
    }

    public void  CalculateModel(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex)
    {
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
    }
    
    public PotentialET_PTComponent(PotentialET_PTComponent toCopy): this() // copy constructor 
    {

        lambdaV = toCopy.lambdaV;
        psychrometricConstant = toCopy.psychrometricConstant;
        Alpha = toCopy.Alpha;
        ih = toCopy.ih;
    }
}