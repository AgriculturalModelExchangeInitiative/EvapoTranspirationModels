public class EnergyBalanceCompositeComponent
{
    
    /// <summary>
    /// Constructor of the EnergyBalanceCompositeComponent component")
    /// </summary>  
    public EnergyBalanceCompositeComponent() { }
    

    //Declaration of the associated strategies
    NetRadiation _NetRadiation = new NetRadiation();
    Conductance _Conductance = new Conductance();
    NetRadiationEquivalentEvaporation _NetRadiationEquivalentEvaporation = new NetRadiationEquivalentEvaporation();
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    public double albedoCoefficient
    {
        get
        {
             return _NetRadiation.albedoCoefficient; 
        }
        set
        {
            _NetRadiation.albedoCoefficient = value;
        }
    }
    public double tau
    {
        get
        {
             return _NetRadiation.tau; 
        }
        set
        {
            _NetRadiation.tau = value;
        }
    }
    public double elevation
    {
        get
        {
             return _NetRadiation.elevation; 
        }
        set
        {
            _NetRadiation.elevation = value;
        }
    }
    public double stefanBoltzman
    {
        get
        {
             return _NetRadiation.stefanBoltzman; 
        }
        set
        {
            _NetRadiation.stefanBoltzman = value;
        }
    }
    public double albedoCoefficientCan
    {
        get
        {
             return _NetRadiation.albedoCoefficientCan; 
        }
        set
        {
            _NetRadiation.albedoCoefficientCan = value;
        }
    }
    public double d
    {
        get
        {
             return _Conductance.d; 
        }
        set
        {
            _Conductance.d = value;
        }
    }
    public double heightWeatherMeasurements
    {
        get
        {
             return _Conductance.heightWeatherMeasurements; 
        }
        set
        {
            _Conductance.heightWeatherMeasurements = value;
        }
    }
    public double zh
    {
        get
        {
             return _Conductance.zh; 
        }
        set
        {
            _Conductance.zh = value;
        }
    }
    public double zm
    {
        get
        {
             return _Conductance.zm; 
        }
        set
        {
            _Conductance.zm = value;
        }
    }
    public double vonKarman
    {
        get
        {
             return _Conductance.vonKarman; 
        }
        set
        {
            _Conductance.vonKarman = value;
        }
    }
    public double lambdaV
    {
        get
        {
             return _NetRadiationEquivalentEvaporation.lambdaV; 
        }
        set
        {
            _NetRadiationEquivalentEvaporation.lambdaV = value;
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

    public void  CalculateModel(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
        _NetRadiation.CalculateModel(s,s1, r, a, ex);
        _Conductance.CalculateModel(s,s1, r, a, ex);
        _NetRadiationEquivalentEvaporation.CalculateModel(s,s1, r, a, ex);
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
        _Penman.CalculateModel(s,s1, r, a, ex);
    }
    
    public EnergyBalanceCompositeComponent(EnergyBalanceCompositeComponent toCopy): this() // copy constructor 
    {

        albedoCoefficient = toCopy.albedoCoefficient;
        tau = toCopy.tau;
        elevation = toCopy.elevation;
        stefanBoltzman = toCopy.stefanBoltzman;
        albedoCoefficientCan = toCopy.albedoCoefficientCan;
        d = toCopy.d;
        heightWeatherMeasurements = toCopy.heightWeatherMeasurements;
        zh = toCopy.zh;
        zm = toCopy.zm;
        vonKarman = toCopy.vonKarman;
        lambdaV = toCopy.lambdaV;
        psychrometricConstant = toCopy.psychrometricConstant;
        Alpha = toCopy.Alpha;
        specificHeatCapacityAir = toCopy.specificHeatCapacityAir;
        rhoDensityAir = toCopy.rhoDensityAir;
    }
}