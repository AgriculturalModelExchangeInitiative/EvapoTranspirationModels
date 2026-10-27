using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualityET.DomainClass
{
    public interface IStrategySiriusQualityET : IStrategy
    {
        void Estimate( ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex);

        string TestPreConditions( ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex, string callID);

        string TestPostConditions( ETState s, ETState s1, ETRate r, ETAuxiliary a, ETExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}