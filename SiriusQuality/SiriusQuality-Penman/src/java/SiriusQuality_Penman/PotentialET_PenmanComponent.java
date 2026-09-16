public class PotentialET_PenmanComponent
{
    
    public PotentialET_PenmanComponent() { }

    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    public double getlambdaV()
    { return _PriestlyTaylor.getlambdaV(); }
    public void setlambdaV(double _lambdaV){
    _PriestlyTaylor.setlambdaV(_lambdaV);
    _Penman.setlambdaV(_lambdaV);
    }

    public double getpsychrometricConstant()
    { return _PriestlyTaylor.getpsychrometricConstant(); }
    public void setpsychrometricConstant(double _psychrometricConstant){
    _PriestlyTaylor.setpsychrometricConstant(_psychrometricConstant);
    _Penman.setpsychrometricConstant(_psychrometricConstant);
    }

    public double getAlpha()
    { return _PriestlyTaylor.getAlpha(); }
    public void setAlpha(double _Alpha){
    _PriestlyTaylor.setAlpha(_Alpha);
    _Penman.setAlpha(_Alpha);
    }

    public Integer getih()
    { return _PriestlyTaylor.getih(); }
    public void setih(Integer _ih){
    _PriestlyTaylor.setih(_ih);
    }

    public double getspecificHeatCapacityAir()
    { return _Penman.getspecificHeatCapacityAir(); }
    public void setspecificHeatCapacityAir(double _specificHeatCapacityAir){
    _Penman.setspecificHeatCapacityAir(_specificHeatCapacityAir);
    }

    public double getrhoDensityAir()
    { return _Penman.getrhoDensityAir(); }
    public void setrhoDensityAir(double _rhoDensityAir){
    _Penman.setrhoDensityAir(_rhoDensityAir);
    }
    public void  Calculate_Model(PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex)
    {
        _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
        _Penman.Calculate_Model(s, s1, r, a, ex);
    }
    private double lambdaV;
    private double psychrometricConstant;
    private double Alpha;
    private Integer ih;
    private double specificHeatCapacityAir;
    private double rhoDensityAir;
    public PotentialET_PenmanComponent(PotentialET_PenmanComponent toCopy) // copy constructor 
    {
        this.lambdaV = toCopy.getlambdaV();
        this.psychrometricConstant = toCopy.getpsychrometricConstant();
        this.Alpha = toCopy.getAlpha();
        this.ih = toCopy.getih();
        this.specificHeatCapacityAir = toCopy.getspecificHeatCapacityAir();
        this.rhoDensityAir = toCopy.getrhoDensityAir();

    }
}