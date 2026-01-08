public class ReferenceETHargreaves_Component
{
    
    public ReferenceETHargreaves_Component() { }

    ReferenceETHargreaves _ReferenceETHargreaves = new ReferenceETHargreaves();

    public Boolean getcConvertLeByTemp()
    { return _ReferenceETHargreaves.getcConvertLeByTemp(); }
    public void setcConvertLeByTemp(Boolean _cConvertLeByTemp){
    _ReferenceETHargreaves.setcConvertLeByTemp(_cConvertLeByTemp);
    }
    public void  Calculate_Model(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex)
    {
        _ReferenceETHargreaves.Calculate_Model(s, s1, r, a, ex);
    }
    private Boolean cConvertLeByTemp;
    public ReferenceETHargreaves_Component(ReferenceETHargreaves_Component toCopy) // copy constructor 
    {
        this.cConvertLeByTemp = toCopy.getcConvertLeByTemp();

    }
}