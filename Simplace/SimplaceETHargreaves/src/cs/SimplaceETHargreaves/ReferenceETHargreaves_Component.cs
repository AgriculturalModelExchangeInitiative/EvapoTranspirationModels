public class ReferenceETHargreaves_Component
{
    
    /// <summary>
    /// Constructor of the ReferenceETHargreaves_Component component")
    /// </summary>  
    public ReferenceETHargreaves_Component() { }
    

    //Declaration of the associated strategies
    ReferenceETHargreaves _ReferenceETHargreaves = new ReferenceETHargreaves();

    public bool cConvertLeByTemp
    {
        get
        {
             return _ReferenceETHargreaves.cConvertLeByTemp; 
        }
        set
        {
            _ReferenceETHargreaves.cConvertLeByTemp = value;
        }
    }

    public void  CalculateModel(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex)
    {
        _ReferenceETHargreaves.CalculateModel(s,s1, r, a, ex);
    }
    
    public ReferenceETHargreaves_Component(ReferenceETHargreaves_Component toCopy): this() // copy constructor 
    {

        cConvertLeByTemp = toCopy.cConvertLeByTemp;
    }
}