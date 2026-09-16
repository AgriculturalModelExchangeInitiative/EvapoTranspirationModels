using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  PotentialET_Penman component
/// </summary>
public class PotentialET_PenmanComponent 
{

    /// <summary>
    ///  constructor of PotentialET_Penman component
    /// </summary>
    public PotentialET_PenmanComponent() {}

    //Declaration of the associated strategies
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();
    Penman _Penman = new Penman();

    /// <summary>
    /// Gets and sets the latent heat of vaporization of water
    /// </summary>
    [Description("latent heat of vaporization of water")] 
    [Units("MJ kg-1")] 
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
    /// Gets and sets the hour of the day if the component is hourly, -999 if the component is daily
    /// </summary>
    [Description("hour of the day if the component is hourly, -999 if the component is daily")] 
    [Units("")] 
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
    /// Algorithm of PotentialET_Penman component
    /// </summary>
    public void CalculateModel(PotentialET_PenmanState s,PotentialET_PenmanState s1,PotentialET_PenmanRate r,PotentialET_PenmanAuxiliary a,PotentialET_PenmanExogenous ex)
    {
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
        _Penman.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of PotentialET_Penman component
    /// </summary>
    public void Init(PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of PotentialET_Penman component
    /// </summary>
    /// <param name="toCopy"></param>
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