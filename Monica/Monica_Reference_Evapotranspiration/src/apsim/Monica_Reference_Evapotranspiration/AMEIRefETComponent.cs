using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  AMEIRefET component
/// </summary>
public class AMEIRefETComponent 
{

    /// <summary>
    ///  constructor of AMEIRefET component
    /// </summary>
    public AMEIRefETComponent() {}

    //Declaration of the associated strategies
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();

    /// <summary>
    /// Gets and sets the height above sea level
    /// </summary>
    [Description("height above sea level")] 
    [Units("m")] 
    public double height_nn
    {
        get
        {
             return _ReferenceEvapotranspiration.height_nn; 
        }
        set
        {
            _ReferenceEvapotranspiration.height_nn = value;
        }
    }

    /// <summary>
    /// Gets and sets the latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure)
    /// </summary>
    [Description("latent heat of vaporization lambda (0: MONICA's constants, 0.408 = 1/2.45 and psychrometric constant 0.000665 * pressure)")] 
    [Units("MJ/kg")] 
    public double latent_heat_of_vaporization
    {
        get
        {
             return _ReferenceEvapotranspiration.latent_heat_of_vaporization; 
        }
        set
        {
            _ReferenceEvapotranspiration.latent_heat_of_vaporization = value;
        }
    }

    /// <summary>
    /// Algorithm of AMEIRefET component
    /// </summary>
    public void CalculateModel(AMEIRefETState s,AMEIRefETState s1,AMEIRefETRate r,AMEIRefETAuxiliary a,AMEIRefETExogenous ex)
    {
        _ReferenceEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of AMEIRefET component
    /// </summary>
    public void Init(AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of AMEIRefET component
    /// </summary>
    /// <param name="toCopy"></param>
    public AMEIRefETComponent(AMEIRefETComponent toCopy): this() // copy constructor 
    {
        height_nn = toCopy.height_nn;
        latent_heat_of_vaporization = toCopy.latent_heat_of_vaporization;
}
}