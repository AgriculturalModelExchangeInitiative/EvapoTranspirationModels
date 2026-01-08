using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  ReferenceETPriestleyTaylor_ component
/// </summary>
public class ReferenceETPriestleyTaylor_Component 
{

    /// <summary>
    ///  constructor of ReferenceETPriestleyTaylor_ component
    /// </summary>
    public ReferenceETPriestleyTaylor_Component() {}

    //Declaration of the associated strategies
    ReferenceETPriestleyTaylor _ReferenceETPriestleyTaylor = new ReferenceETPriestleyTaylor();

    /// <summary>
    /// Gets and sets the Priestley-Taylor coefficient
    /// </summary>
    [Description("Priestley-Taylor coefficient")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/one")] 
    public double cAlphaPT
    {
        get
        {
             return _ReferenceETPriestleyTaylor.cAlphaPT; 
        }
        set
        {
            _ReferenceETPriestleyTaylor.cAlphaPT = value;
        }
    }

    /// <summary>
    /// Gets and sets the altitude
    /// </summary>
    [Description("altitude")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/metre")] 
    public double cAltitude
    {
        get
        {
             return _ReferenceETPriestleyTaylor.cAltitude; 
        }
        set
        {
            _ReferenceETPriestleyTaylor.cAltitude = value;
        }
    }

    /// <summary>
    /// Algorithm of ReferenceETPriestleyTaylor_ component
    /// </summary>
    public void CalculateModel(ReferenceETPriestleyTaylor_State s,ReferenceETPriestleyTaylor_State s1,ReferenceETPriestleyTaylor_Rate r,ReferenceETPriestleyTaylor_Auxiliary a,ReferenceETPriestleyTaylor_Exogenous ex)
    {
        _ReferenceETPriestleyTaylor.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of ReferenceETPriestleyTaylor_ component
    /// </summary>
    public void Init(ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of ReferenceETPriestleyTaylor_ component
    /// </summary>
    /// <param name="toCopy"></param>
    public ReferenceETPriestleyTaylor_Component(ReferenceETPriestleyTaylor_Component toCopy): this() // copy constructor 
    {
        cAlphaPT = toCopy.cAlphaPT;
        cAltitude = toCopy.cAltitude;
}
}