using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualityAMEIPotET.DomainClass
{
    public interface IStrategySiriusQualityAMEIPotET : IStrategy
    {
        void Estimate( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex);

        string TestPreConditions( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex, string callID);

        string TestPostConditions( AMEIPotETState s, AMEIPotETState s1, AMEIPotETRate r, AMEIPotETAuxiliary a, AMEIPotETExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}