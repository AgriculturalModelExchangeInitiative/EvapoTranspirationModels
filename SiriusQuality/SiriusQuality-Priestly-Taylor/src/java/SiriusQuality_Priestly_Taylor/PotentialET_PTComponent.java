public class PotentialET_PTComponent
{
    
    public PotentialET_PTComponent() { }

    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();

    public double getlambdaV()
    { return _PriestlyTaylor.getlambdaV(); }
    public void setlambdaV(double _lambdaV){
    _PriestlyTaylor.setlambdaV(_lambdaV);
    }

    public double getpsychrometricConstant()
    { return _PriestlyTaylor.getpsychrometricConstant(); }
    public void setpsychrometricConstant(double _psychrometricConstant){
    _PriestlyTaylor.setpsychrometricConstant(_psychrometricConstant);
    }

    public double getAlpha()
    { return _PriestlyTaylor.getAlpha(); }
    public void setAlpha(double _Alpha){
    _PriestlyTaylor.setAlpha(_Alpha);
    }

    public Integer getih()
    { return _PriestlyTaylor.getih(); }
    public void setih(Integer _ih){
    _PriestlyTaylor.setih(_ih);
    }
    public void  Calculate_Model(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex)
    {
        _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
    }
    private double lambdaV;
    private double psychrometricConstant;
    private double Alpha;
    private Integer ih;
    public PotentialET_PTComponent(PotentialET_PTComponent toCopy) // copy constructor 
    {
        this.lambdaV = toCopy.getlambdaV();
        this.psychrometricConstant = toCopy.getpsychrometricConstant();
        this.Alpha = toCopy.getAlpha();
        this.ih = toCopy.getih();

    }
}