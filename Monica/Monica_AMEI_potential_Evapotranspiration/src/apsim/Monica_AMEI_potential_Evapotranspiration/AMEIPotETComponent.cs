using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  AMEIPotET component
/// </summary>
public class AMEIPotETComponent 
{

    /// <summary>
    ///  constructor of AMEIPotET component
    /// </summary>
    public AMEIPotETComponent() {}

    //Declaration of the associated strategies
    SaturationVaporPressureDeficit _SaturationVaporPressureDeficit = new SaturationVaporPressureDeficit();
    ReferenceEvapotranspiration _ReferenceEvapotranspiration = new ReferenceEvapotranspiration();
    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

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
    /// Algorithm of AMEIPotET component
    /// </summary>
    public void CalculateModel(AMEIPotETState s,AMEIPotETState s1,AMEIPotETRate r,AMEIPotETAuxiliary a,AMEIPotETExogenous ex)
    {
        _SaturationVaporPressureDeficit.CalculateModel(s,s1, r, a, ex);
        _ReferenceEvapotranspiration.CalculateModel(s,s1, r, a, ex);
        _PotentialEvapotranspiration.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of AMEIPotET component
    /// </summary>
    public void Init(AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex)
    {
    }

    /// <summary>
    /// constructor copy of AMEIPotET component
    /// </summary>
    /// <param name="toCopy"></param>
    public AMEIPotETComponent(AMEIPotETComponent toCopy): this() // copy constructor 
    {
        height_nn = toCopy.height_nn;
        latent_heat_of_vaporization = toCopy.latent_heat_of_vaporization;
}
}