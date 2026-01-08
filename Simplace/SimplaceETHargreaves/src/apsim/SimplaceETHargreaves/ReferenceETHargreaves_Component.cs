using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  ReferenceETHargreaves_ component
/// </summary>
public class ReferenceETHargreaves_Component 
{

    /// <summary>
    ///  constructor of ReferenceETHargreaves_ component
    /// </summary>
    public ReferenceETHargreaves_Component() {}

    //Declaration of the associated strategies
    ReferenceETHargreaves _ReferenceETHargreaves = new ReferenceETHargreaves();

    /// <summary>
    /// Gets and sets the Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.
    /// </summary>
    [Description("Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.")] 
    [Units("")] 
    public bool cConvertLeByTemp
    {
        get
        {
             return _ReferenceETHargreaves.cConvertLeByTemp; 
        }
        set
        {
            _ReferenceETHargreaves.cConvertLeByTemp = value;
        }
    }

    /// <summary>
    /// Algorithm of ReferenceETHargreaves_ component
    /// </summary>
    public void CalculateModel(ReferenceETHargreaves_State s,ReferenceETHargreaves_State s1,ReferenceETHargreaves_Rate r,ReferenceETHargreaves_Auxiliary a,ReferenceETHargreaves_Exogenous ex)
    {
        _ReferenceETHargreaves.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of ReferenceETHargreaves_ component
    /// </summary>
    public void Init(ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of ReferenceETHargreaves_ component
    /// </summary>
    /// <param name="toCopy"></param>
    public ReferenceETHargreaves_Component(ReferenceETHargreaves_Component toCopy): this() // copy constructor 
    {
        cConvertLeByTemp = toCopy.cConvertLeByTemp;
}
}