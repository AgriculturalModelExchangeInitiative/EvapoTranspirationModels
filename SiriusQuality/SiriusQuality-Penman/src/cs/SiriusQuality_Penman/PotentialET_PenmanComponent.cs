public class PotentialET_PenmanComponent
{
    
    /// <summary>
    /// Constructor of the PotentialET_PenmanComponent component")
    /// </summary>  
    public PotentialET_PenmanComponent() { }
    

    //Declaration of the associated strategies
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    public double lambdaV
    {
        get
        {
             return _PriestlyTaylor.lambdaV; 
        }
        set
        {
            _PriestlyTaylor.lambdaV = value;
            _Penman.lambdaV = value;
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
            _Penman.psychrometricConstant = value;
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
            _Penman.Alpha = value;
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
    public double specificHeatCapacityAir
    {
        get
        {
             return _Penman.specificHeatCapacityAir; 
        }
        set
        {
            _Penman.specificHeatCapacityAir = value;
        }
    }
    public double rhoDensityAir
    {
        get
        {
             return _Penman.rhoDensityAir; 
        }
        set
        {
            _Penman.rhoDensityAir = value;
        }
    }

    public void  CalculateModel(PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex)
    {
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
        _Penman.CalculateModel(s,s1, r, a, ex);
    }
    
    public PotentialET_PenmanComponent(PotentialET_PenmanComponent toCopy): this() // copy constructor 
    {

        lambdaV = toCopy.lambdaV;
        psychrometricConstant = toCopy.psychrometricConstant;
        Alpha = toCopy.Alpha;
        ih = toCopy.ih;
        specificHeatCapacityAir = toCopy.specificHeatCapacityAir;
        rhoDensityAir = toCopy.rhoDensityAir;
    }
}