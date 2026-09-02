public class EnergyBalanceCompositeComponent
{
    
    public EnergyBalanceCompositeComponent() { }

    NetRadiation _NetRadiation = new NetRadiation();
    Conductance _Conductance = new Conductance();
    NetRadiationEquivalentEvaporation _NetRadiationEquivalentEvaporation = new NetRadiationEquivalentEvaporation();
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    public double getalbedoCoefficient()
    { return _NetRadiation.getalbedoCoefficient(); }
    public void setalbedoCoefficient(double _albedoCoefficient){
    _NetRadiation.setalbedoCoefficient(_albedoCoefficient);
    }

    public double gettau()
    { return _NetRadiation.gettau(); }
    public void settau(double _tau){
    _NetRadiation.settau(_tau);
    }

    public double getelevation()
    { return _NetRadiation.getelevation(); }
    public void setelevation(double _elevation){
    _NetRadiation.setelevation(_elevation);
    }

    public double getstefanBoltzman()
    { return _NetRadiation.getstefanBoltzman(); }
    public void setstefanBoltzman(double _stefanBoltzman){
    _NetRadiation.setstefanBoltzman(_stefanBoltzman);
    }

    public double getalbedoCoefficientCan()
    { return _NetRadiation.getalbedoCoefficientCan(); }
    public void setalbedoCoefficientCan(double _albedoCoefficientCan){
    _NetRadiation.setalbedoCoefficientCan(_albedoCoefficientCan);
    }

    public double getd()
    { return _Conductance.getd(); }
    public void setd(double _d){
    _Conductance.setd(_d);
    }

    public double getheightWeatherMeasurements()
    { return _Conductance.getheightWeatherMeasurements(); }
    public void setheightWeatherMeasurements(double _heightWeatherMeasurements){
    _Conductance.setheightWeatherMeasurements(_heightWeatherMeasurements);
    }

    public double getzh()
    { return _Conductance.getzh(); }
    public void setzh(double _zh){
    _Conductance.setzh(_zh);
    }

    public double getzm()
    { return _Conductance.getzm(); }
    public void setzm(double _zm){
    _Conductance.setzm(_zm);
    }

    public double getvonKarman()
    { return _Conductance.getvonKarman(); }
    public void setvonKarman(double _vonKarman){
    _Conductance.setvonKarman(_vonKarman);
    }

    public double getlambdaV()
    { return _NetRadiationEquivalentEvaporation.getlambdaV(); }
    public void setlambdaV(double _lambdaV){
    _NetRadiationEquivalentEvaporation.setlambdaV(_lambdaV);
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
    public void  Calculate_Model(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        _NetRadiation.Calculate_Model(s, s1, r, a, ex);
        _Conductance.Calculate_Model(s, s1, r, a, ex);
        _NetRadiationEquivalentEvaporation.Calculate_Model(s, s1, r, a, ex);
        _PriestlyTaylor.Calculate_Model(s, s1, r, a, ex);
        _Penman.Calculate_Model(s, s1, r, a, ex);
    }
    private double albedoCoefficient;
    private double tau;
    private double elevation;
    private double stefanBoltzman;
    private double albedoCoefficientCan;
    private double d;
    private double heightWeatherMeasurements;
    private double zh;
    private double zm;
    private double vonKarman;
    private double lambdaV;
    private double psychrometricConstant;
    private double Alpha;
    private double specificHeatCapacityAir;
    private double rhoDensityAir;
    public EnergyBalanceCompositeComponent(EnergyBalanceCompositeComponent toCopy) // copy constructor 
    {
        this.albedoCoefficient = toCopy.getalbedoCoefficient();
        this.tau = toCopy.gettau();
        this.elevation = toCopy.getelevation();
        this.stefanBoltzman = toCopy.getstefanBoltzman();
        this.albedoCoefficientCan = toCopy.getalbedoCoefficientCan();
        this.d = toCopy.getd();
        this.heightWeatherMeasurements = toCopy.getheightWeatherMeasurements();
        this.zh = toCopy.getzh();
        this.zm = toCopy.getzm();
        this.vonKarman = toCopy.getvonKarman();
        this.lambdaV = toCopy.getlambdaV();
        this.psychrometricConstant = toCopy.getpsychrometricConstant();
        this.Alpha = toCopy.getAlpha();
        this.specificHeatCapacityAir = toCopy.getspecificHeatCapacityAir();
        this.rhoDensityAir = toCopy.getrhoDensityAir();

    }
}