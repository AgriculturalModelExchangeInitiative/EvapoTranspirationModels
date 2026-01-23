using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace pet.DomainClass
{
    public interface IStrategypet : IStrategy
    {
        void Estimate( petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex);

        string TestPreConditions( petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex, string callID);

        string TestPostConditions( petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}