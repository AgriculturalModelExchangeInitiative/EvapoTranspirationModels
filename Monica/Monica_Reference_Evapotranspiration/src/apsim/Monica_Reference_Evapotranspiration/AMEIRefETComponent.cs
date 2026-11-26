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
}
}