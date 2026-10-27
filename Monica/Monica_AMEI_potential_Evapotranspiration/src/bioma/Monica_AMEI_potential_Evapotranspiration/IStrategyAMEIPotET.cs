using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace AMEIPotET.DomainClass
{
    public interface IStrategyAMEIPotET : IStrategy
    {
        void Estimate( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex);

        string TestPreConditions( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex, string callID);

        string TestPostConditions( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}