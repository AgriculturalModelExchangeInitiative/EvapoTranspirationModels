using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  PotentialET_PT component
/// </summary>
public class PotentialET_PTComponent 
{

    /// <summary>
    ///  constructor of PotentialET_PT component
    /// </summary>
    public PotentialET_PTComponent() {}

    //Declaration of the associated strategies
    PriestlyTaylor _PriestlyTaylor = new PriestlyTaylor();

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
    /// Algorithm of PotentialET_PT component
    /// </summary>
    public void CalculateModel(PotentialET_PTState s,PotentialET_PTState s1,PotentialET_PTRate r,PotentialET_PTAuxiliary a,PotentialET_PTExogenous ex)
    {
        _PriestlyTaylor.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of PotentialET_PT component
    /// </summary>
    public void Init(PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of PotentialET_PT component
    /// </summary>
    /// <param name="toCopy"></param>
    public PotentialET_PTComponent(PotentialET_PTComponent toCopy): this() // copy constructor 
    {
        lambdaV = toCopy.lambdaV;
        psychrometricConstant = toCopy.psychrometricConstant;
        Alpha = toCopy.Alpha;
        ih = toCopy.ih;
}
}