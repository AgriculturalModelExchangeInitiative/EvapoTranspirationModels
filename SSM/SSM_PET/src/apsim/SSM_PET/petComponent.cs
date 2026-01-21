using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  pet component
/// </summary>
public class PetComponent 
{

    /// <summary>
    ///  constructor of Pet component
    /// </summary>
    public PetComponent() {}

    //Declaration of the associated strategies
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    /// <summary>
    /// Gets and sets the Extinction coefficient for canopy
    /// </summary>
    [Description("Extinction coefficient for canopy")] 
    [Units("-")] 
    public double ket
    {
        get
        {
             return _PotentialEvapotranspiration.ket; 
        }
        set
        {
            _PotentialEvapotranspiration.ket = value;
        }
    }

    /// <summary>
    /// Gets and sets the Crop albedo
    /// </summary>
    [Description("Crop albedo")] 
    [Units("-")] 
    public double calb
    {
        get
        {
             return _PotentialEvapotranspiration.calb; 
        }
        set
        {
            _PotentialEvapotranspiration.calb = value;
        }
    }

    /// <summary>
    /// Gets and sets the Soil albedo
    /// </summary>
    [Description("Soil albedo")] 
    [Units("-")] 
    public double salb
    {
        get
        {
             return _PotentialEvapotranspiration.salb; 
        }
        set
        {
            _PotentialEvapotranspiration.salb = value;
        }
    }

    /// <summary>
    /// Algorithm of Pet component
    /// </summary>
    public void CalculateModel(PetState s,PetState s1,PetRate r,PetAuxiliary a,PetExogenous ex)
    {
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of Pet component
    /// </summary>
    public void Init(PetState s, PetState s1, PetRate r, PetAuxiliary a, PetExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of Pet component
    /// </summary>
    /// <param name="toCopy"></param>
    public PetComponent(PetComponent toCopy): this() // copy constructor 
    {
        ket = toCopy.ket;
        calb = toCopy.calb;
        salb = toCopy.salb;
}
}