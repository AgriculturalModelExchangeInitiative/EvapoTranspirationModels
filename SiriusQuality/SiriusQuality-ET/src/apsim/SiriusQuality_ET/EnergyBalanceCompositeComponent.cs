using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  EnergyBalanceComposite component
/// </summary>
public class EnergyBalanceCompositeComponent 
{

    /// <summary>
    ///  constructor of EnergyBalanceComposite component
    /// </summary>
    public EnergyBalanceCompositeComponent() {}

    //Declaration of the associated strategies
    NetRadiation _NetRadiation = new NetRadiation();
    Conductance _Conductance = new Conductance();
    NetRadiationEquivalentEvaporation _NetRadiationEquivalentEvaporation = new NetRadiationEquivalentEvaporation();
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    /// <summary>
    /// Gets and sets the albedo Coefficient
    /// </summary>
    [Description("albedo Coefficient")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the plant cover factor
    /// </summary>
    [Description("plant cover factor")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the elevation
    /// </summary>
    [Description("elevation")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the stefan Boltzman constant
    /// </summary>
    [Description("stefan Boltzman constant")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the albedo Coefficient
    /// </summary>
    [Description("albedo Coefficient")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
    /// </summary>
    [Description("corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO")] 
    [Units("dimensionless")] 
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

    /// <summary>
    /// Gets and sets the reference height of wind and humidity measurements
    /// </summary>
    [Description("reference height of wind and humidity measurements")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the roughness length governing transfer of heat and vapour, FAO
    /// </summary>
    [Description("roughness length governing transfer of heat and vapour, FAO")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the roughness length governing momentum transfer, FAO
    /// </summary>
    [Description("roughness length governing momentum transfer, FAO")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the von Karman constant
    /// </summary>
    [Description("von Karman constant")] 
    [Units("dimensionless")] 
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

    /// <summary>
    /// Gets and sets the latent heat of vaporization of water
    /// </summary>
    [Description("latent heat of vaporization of water")] 
    [Units("MJ kg-1")] 
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

    /// <summary>
    /// Gets and sets the psychrometric constant
    /// </summary>
    [Description("psychrometric constant")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Priestley-Taylor evapotranspiration proportionality constant
    /// </summary>
    [Description("Priestley-Taylor evapotranspiration proportionality constant")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Specific heat capacity of dry air
    /// </summary>
    [Description("Specific heat capacity of dry air")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Density of air
    /// </summary>
    [Description("Density of air")] 
    [Units("")] 
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

    /// <summary>
    /// Algorithm of EnergyBalanceComposite component
    /// </summary>
    public void CalculateModel(EnergyBalanceCompositeState s,EnergyBalanceCompositeState s1,EnergyBalanceCompositeRate r,EnergyBalanceCompositeAuxiliary a,EnergyBalanceCompositeExogenous ex)
    {
        _NetRadiation.CalculateModel(s,s1, r, a, ex);
        _Conductance.CalculateModel(s,s1, r, a, ex);
        _NetRadiationEquivalentEvaporation.CalculateModel(s,s1, r, a, ex);
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
        _Penman.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of EnergyBalanceComposite component
    /// </summary>
    public void Init(EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of EnergyBalanceComposite component
    /// </summary>
    /// <param name="toCopy"></param>
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