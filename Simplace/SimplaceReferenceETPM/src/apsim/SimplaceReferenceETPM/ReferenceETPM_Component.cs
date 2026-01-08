using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  ReferenceETPM_ component
/// </summary>
public class ReferenceETPM_Component 
{

    /// <summary>
    ///  constructor of ReferenceETPM_ component
    /// </summary>
    public ReferenceETPM_Component() {}

    //Declaration of the associated strategies
    ReferenceETPM _ReferenceETPM = new ReferenceETPM();

    /// <summary>
    /// Gets and sets the elevation above sea level
    /// </summary>
    [Description("elevation above sea level")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/metre")] 
    public double cAltitude
    {
        get
        {
             return _ReferenceETPM.cAltitude; 
        }
        set
        {
            _ReferenceETPM.cAltitude = value;
        }
    }

    /// <summary>
    /// Algorithm of ReferenceETPM_ component
    /// </summary>
    public void CalculateModel(ReferenceETPM_State s,ReferenceETPM_State s1,ReferenceETPM_Rate r,ReferenceETPM_Auxiliary a,ReferenceETPM_Exogenous ex)
    {
        _ReferenceETPM.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of ReferenceETPM_ component
    /// </summary>
    public void Init(ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of ReferenceETPM_ component
    /// </summary>
    /// <param name="toCopy"></param>
    public ReferenceETPM_Component(ReferenceETPM_Component toCopy): this() // copy constructor 
    {
        cAltitude = toCopy.cAltitude;
}
}