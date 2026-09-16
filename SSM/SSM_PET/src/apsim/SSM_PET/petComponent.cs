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
    /// Gets and sets the Surface albedo.
    /// </summary>
    [Description("Surface albedo.")] 
    [Units("-")] 
    public double albedo
    {
        get
        {
             return _PotentialEvapotranspiration.albedo; 
        }
        set
        {
            _PotentialEvapotranspiration.albedo = value;
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
        albedo = toCopy.albedo;
}
}