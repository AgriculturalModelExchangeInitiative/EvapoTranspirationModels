using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace AMEIRefET.DomainClass
{
    public interface IStrategyAMEIRefET : IStrategy
    {
        void Estimate( AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex);

        string TestPreConditions( AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex, string callID);

        string TestPostConditions( AMEIRefETState s, AMEIRefETState s1, AMEIRefETRate r, AMEIRefETAuxiliary a, AMEIRefETExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}